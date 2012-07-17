using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections.Specialized;
using Jade.Model;
using XmlDatabase.Core;
using System.Drawing;
using System.Net;
using Com.iFLYTEK.WinForms.Browser;
using System.Threading;

namespace Jade.BLL
{
    public class RuleManager
    {
        const string DatabaseName = "SiteConfig";

        /// <summary>
        /// 获取站点规则
        /// </summary>
        /// <returns></returns>
        public List<SiteRule> GetSiteRules()
        {
            try
            {
                using (XDatabase db = XDatabase.Open(DatabaseName))
                {
                    var query = from o in db.Query<SiteRule>()
                                select o;
                    return query.ToList();
                }
            }
            catch
            {
                return new List<SiteRule>();
            }
        }
        public void AddSite(SiteRule name)
        {
            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                if (name.SiteRuleId == 0)
                {
                    name.SiteRuleId = GetNextId();
                }
                db.Store(name);

                if (name.IconImage == "favicon.ico")
                {
                    LoadIcon(name);
                }
            }
        }

        private void LoadIcon(Object name)
        {

            var rule = name as SiteRule;

            Uri uri = new Uri(rule.ForTestUrl);

            //to check input uri
            if (!Uri.TryCreate("http://" + uri.Host + "/favicon.ico", UriKind.Absolute, out uri))
            { return; }
            //to verify if icon exists
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(uri, CacheObject.IconDir + "\\" + uri.Host + ".ico");
                rule.IconImage = uri.Host + ".ico";
                Update(rule);
                return;
            }
            catch (WebException)
            {
                return;
            }
        }

        public SiteRule GetSiteRule(int id)
        {
            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                return db.Query<SiteRule>().FirstOrDefault(i => i.SiteRuleId == id);
            }
        }

        public void DeleteSite(int id)
        {
            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                var item = db.Query<SiteRule>().FirstOrDefault(i => i.SiteRuleId == id);
                if (item != null)
                {
                    db.Delete(item);
                }
            }
        }

        public void AddSite(string name)
        {
            var site = new SiteRule()
            {
                Name = name,
                SiteRuleId = GetNextId()
            };

            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                db.Store(site);
            }
        }

        public void Update(SiteRule rule)
        {
            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                db.Store(rule);

                if (rule.IconImage == "" || rule.IconImage == "favicon.ico")
                {
                    LoadIcon(rule);
                    //new Thread(LoadIcon).Start(rule);
                }
            }
        }
        /// <summary>
        /// 获取站点规则
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            try
            {
                using (XDatabase db = XDatabase.Open(DatabaseName))
                {
                    var query = from o in db.Query<Category>()
                                select o;
                    return query.ToList();
                }
            }
            catch
            {
                return new List<Category>();
            }
        }
        public void AddCategory(Category name)
        {
            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                if (name.ID == 0)
                {
                    name.ID = GetNextCategoryId();
                }
                db.Store(name);
            }
        }


        public Category GetCategory(int id)
        {
            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                return db.Query<Category>().FirstOrDefault(i => i.ID == id);
            }
        }

        public void DeleteCategory(int id)
        {
            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                var item = db.Query<Category>().FirstOrDefault(i => i.ID == id);
                if (item != null)
                {
                    db.Delete(item);
                }
            }
        }

        public void AddCategory(string name)
        {
            var site = new Category()
            {
                Name = name,
                ID = GetNextCategoryId()
            };

            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                db.Store(site);
            }
        }

        public void UpdateCategory(Category rule)
        {
            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                db.Store(rule);
            }
        }
        public int GetLastSiteId()
        {
            using (XDatabase db = XDatabase.Open(DatabaseName))
            {
                var query = from o in db.Query<SiteRule>()
                            orderby o.SiteRuleId descending
                            select o.SiteRuleId;
                return query.ToList().Count > 0 ? query.ToList()[0] : 1;
            }
        }
        public int GetNextId()
        {
            try
            {
                using (XDatabase db = XDatabase.Open(DatabaseName))
                {
                    var query = from o in db.Query<SiteRule>()
                                orderby o.SiteRuleId descending
                                select o.SiteRuleId;
                    return query.ToList().Count > 0 ? query.ToList()[0] + 1 : 1;
                }
            }
            catch
            {
                return 1;
            }
        }
        public int GetNextCategoryId()
        {
            try
            {
                using (XDatabase db = XDatabase.Open(DatabaseName))
                {
                    var query = from o in db.Query<Category>()
                                orderby o.ID descending
                                select o.ID;
                    return query.ToList().Count > 0 ? query.ToList()[0] + 1 : 1;
                }
            }
            catch
            {
                return 1;
            }
        }
    }
}
