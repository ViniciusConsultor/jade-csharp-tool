using System;
using System.Linq.Expressions;
using System.Text;
using System.Web;

namespace Never
{
    /// <summary>
    /// 表达式处理
    /// </summary>
    public class ExpressionProvider
    {
        /// <summary>
        /// 解析表达式为sql所需格式
        /// </summary>
        public static string ToSql(Expression Exp)
        {
            string Str = string.Empty;
            if (Exp is BinaryExpression)
            {
                BinaryExpression bExp = (BinaryExpression)Exp;
                ExpressionProvider ep = new ExpressionProvider();
                Str = ep.ConvertToString(bExp.Left, bExp.Right, bExp.NodeType);
            }
            return Str;
        }
        /// <summary>
        /// 转换表达式
        /// </summary>
        public string ConvertToString(Expression ExpLeft, Expression ExpRight, ExpressionType ExpType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            sb.Append(Router(ExpLeft));//处理左边
            sb.Append(TypeCast(ExpType));//处理符号
            string tmpStr = Router(ExpRight);//处理右边
            if (tmpStr == "null")
            {
                string strSb = sb.ToString();
                if (strSb.EndsWith(" ="))
                {
                    strSb = strSb.Substring(0, sb.Length - 2) + " is null";
                }
                else if (strSb.EndsWith("<>"))
                {
                    strSb = strSb.Substring(0, sb.Length - 2) + " is not null";
                }
                sb = new StringBuilder(strSb);
            }
            else
            {
                sb.Append(tmpStr);
            }
            return sb.Append(")").ToString();
        }
        /// <summary>
        /// 表达式路由计算
        /// </summary>
        public string Router(Expression Exp)
        {
            //string sb = string.Empty;
            if (Exp is BinaryExpression)
            {
                BinaryExpression be = ((BinaryExpression)Exp);
                return ConvertToString(be.Left, be.Right, be.NodeType);
            }
            else if (Exp is MemberExpression)
            {
                if (!Exp.ToString().StartsWith("value("))
                {
                    MemberExpression me = ((MemberExpression)Exp);
                    return me.Member.Name;
                }
                else
                {
                    var result = Expression.Lambda(Exp).Compile().DynamicInvoke();
                    if (result == null)
                    {
                        return "null";
                    }
                    if (result is ValueType)
                    {
                        return result.ToString();
                    }
                    else if (result is string || result is DateTime || result is char)
                    {
                        return string.Format("'{0}'", result.ToString());
                    }
                }
            }
            else if (Exp is NewArrayExpression)
            {
                NewArrayExpression ae = ((NewArrayExpression)Exp);
                StringBuilder tmpstr = new StringBuilder();
                foreach (Expression ex in ae.Expressions)
                {
                    tmpstr.Append(Router(ex));
                    tmpstr.Append(",");
                }
                return tmpstr.ToString(0, tmpstr.Length - 1);
            }
            else if (Exp is MethodCallExpression)
            {
                MethodCallExpression mce = (MethodCallExpression)Exp;
                if (mce.Method.Name == "Like")
                {
                    return string.Format("({0} like {1})",
                        Router(mce.Arguments[0]),
                        Router(mce.Arguments[1]));
                }
                else if (mce.Method.Name == "NotLike")
                {
                    return string.Format("({0} not like {1})",
                        Router(mce.Arguments[0]),
                        Router(mce.Arguments[1]));
                }
                else if (mce.Method.Name == "In")
                {
                    return string.Format("{0} in ({1})",
                        Router(mce.Arguments[0]),
                        Router(mce.Arguments[1]));
                }
                else if (mce.Method.Name == "NotIn")
                {
                    return string.Format("{0} not in ({1})", Router(mce.Arguments[0]),
                        Router(mce.Arguments[1]));
                }
            }
            else if (Exp is ConstantExpression)
            {
                ConstantExpression ce = ((ConstantExpression)Exp);
                if (ce.Value == null)
                {
                    return "null";
                }
                else if (ce.Value is ValueType)
                {
                    return ce.Value.ToString();
                }
                else if (ce.Value is string || ce.Value is DateTime || ce.Value is char)
                {
                    return string.Format("'{0}'", ce.Value.ToString());
                }
            }
            else if (Exp is UnaryExpression)
            {
                UnaryExpression ue = ((UnaryExpression)Exp);
                return Router(ue.Operand);
            }
            return null;
        }
        /// <summary>
        /// 获取表达式运算符对应sql运算符
        /// </summary>
        public string TypeCast(ExpressionType ExpType)
        {
            switch (ExpType)
            {
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    return " and ";
                case ExpressionType.Equal:
                    return " =";
                case ExpressionType.GreaterThan:
                    return " >";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
                case ExpressionType.NotEqual:
                    return "<>";
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return " or ";
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                    return "+";
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                    return "-";
                case ExpressionType.Divide:
                    return "/";
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                    return "*";
                default:
                    return null;
            }
        }
    }
}
