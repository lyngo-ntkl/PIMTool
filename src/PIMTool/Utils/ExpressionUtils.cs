using System.Linq.Expressions;

namespace PIMTool.Utils
{
    public class ExpressionUtils
    {
        public static Expression StringContains<T>(Expression stringInstance, Expression stringValue)
        {
            string a = "";
            var method = typeof(String).GetMethod("Contains", new Type[] { typeof(string) });
            var expression = Expression.Call(instance: stringInstance, method: method, stringValue);
            return expression;
        }
    }
}
