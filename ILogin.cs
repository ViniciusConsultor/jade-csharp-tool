using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HFBBS
{
    /// <summary>
    /// 提供一个接口，用戶登錄時驗證用戶名和密碼。
    /// </summary>
    public interface ILogin
    {
        /// <summary>
        /// 验证提供的用户名和密码是有效的。
        /// </summary>
        /// <param name="username">要验证的用户的名称。</param>
        /// <param name="password">指定的用户的密码。</param>
        /// <returns>如果提供的用户名和密码有效，则返回 true；否则返回 false。</returns>
        bool ValidateUser(string username, string password);
    }
}
