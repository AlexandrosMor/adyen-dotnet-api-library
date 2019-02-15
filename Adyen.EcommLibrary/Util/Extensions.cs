﻿using System.Text;

namespace Adyen.EcommLibrary.Util
{
    internal static class Extensions
    {
        public static string ToClassDefinitionString(this object o)
        {
            try
            {
                var t = o.GetType();

                var propertyString = new StringBuilder().AppendLine($"class {o.GetType().Name} {{");

                foreach (var prop in t.GetProperties())
                {
                    var propertyValue = prop.GetValue(o, null);

                    propertyString.Append("\t")
                        .AppendLine(propertyValue != null
                            ? $"{prop.Name}: {propertyValue}".ToIndentedString()
                            : $"{prop.Name}: null");
                }

                propertyString.AppendLine("}");

                return propertyString.ToString();
            }
            catch
            {
                return o.ToString();
            }
        }


        public static string ToIndentedString(this object o)
        {
            return o == null ? "null"
                             : o.ToString().Replace("\n", "\n\t\t\t");
        }
    }
}
