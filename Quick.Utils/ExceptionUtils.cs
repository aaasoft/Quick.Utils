using System.Reflection;
using System.Text;

namespace Quick.Utils
{
    public class ExceptionUtils
    {
        public static String GetExceptionString(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            Exception tmpEx = ex;
            while (tmpEx != null)
            {
                sb.AppendLine("------------------------------------------------------");
                _GetExceptionString(tmpEx, sb, string.Empty);
                tmpEx = tmpEx.InnerException;
            }
            return sb.ToString();
        }

        private static void _GetExceptionString(Exception ex, StringBuilder sb, String prefix)
        {
            Type exType = ex.GetType();
            sb.AppendLine(prefix + "Exception Type: " + exType.FullName);
            sb.AppendLine(prefix + "Excepiton Message: " + ex.Message);
            sb.AppendLine(prefix + "Exception StackTrace: " + ex.StackTrace);
        }

        public static string GetExceptionMessage(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            Exception tmpEx = ex;
            var isFirst = true;
            while (tmpEx != null)
            {
                if (tmpEx is not TargetInvocationException)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        sb.Append(">");
                    sb.AppendLine(tmpEx.Message);
                }
                tmpEx = tmpEx.InnerException;
            }
            return sb.ToString();
        }
    }
}
