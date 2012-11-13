using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Jade
{
    public partial class ExceptionForm : DevExpress.XtraEditors.XtraForm
    {
        public ExceptionForm(Exception ex)
        {
            InitializeComponent();
            this.txtRuleName.Text = ex.Message;
            StringBuilder sb = new StringBuilder();
            ProcessExecption(ex, sb);
            this.txtReplace.Text = sb.ToString();
        }


        void ProcessExecption(Exception ex, StringBuilder sb)
        {
            sb.AppendLine(string.Format("错误类型:{0}", ex.GetType().Name));
            sb.AppendLine(string.Format("错误信息:{0}", ex.Message));
            sb.AppendLine(string.Format("堆栈信息:{0}", ex.StackTrace));
            if (ex.InnerException != null)
            {
                sb.AppendLine(string.Format("包含内部异常:{0}", ex.InnerException.GetType().Name));
                ProcessExecption(ex.InnerException, sb);
            }
        }

        private void btnSelectAnotherXpath_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtReplace.Text);
            MessageBox.Show("已拷贝到剪切板，请通过QQ发送给管理员!");
        }

    }
}