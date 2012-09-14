using System;
namespace Jade
{
    public interface IUrlFilter
    {
        /// <summary>
        /// 必须包含
        /// </summary>
        string IncludePart { get; set; }

        /// <summary>
        /// 不包含
        /// </summary>
        string ExcludePart { get; set; }

        /// <summary>
        /// 自定义内容页地址
        /// </summary>
        string DiyContentPageUrl
        {
            get;
            set;
        }
    }
}
