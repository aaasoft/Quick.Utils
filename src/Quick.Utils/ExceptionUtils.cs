using System.Text;

namespace Quick.Utils
{
    public class ExceptionUtils
    {
        //忽略的属性名称数组
        private static String[] ignorePropertiyNames = new String[]
        {
            "Message","InnerException","StackTrace","Data"
        };

        public static String GetExceptionString(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            Exception tmpEx = ex;
            while (tmpEx != null)
            {
                sb.AppendLine("------------------------------------------------------");
                _GetExceptionString(tmpEx, sb, String.Empty);
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
            while (tmpEx != null)
            {
                sb.Append(">");
                sb.AppendLine(tmpEx.Message);
                tmpEx = tmpEx.InnerException;
            }
            return sb.ToString();
        }
    }
}
