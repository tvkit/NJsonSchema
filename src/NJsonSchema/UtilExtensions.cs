using System;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;

namespace NJsonSchema
{
    internal static class UtilExtensions
    {
        //private static readonly Regex LinkRegex = new Regex(, RegexOptions.Compiled | RegexOptions.Multiline);

        public static string NetDoc(string doc)
        {

            var s = Regex.Replace(doc, @"{@link +([^} ]+) *}", match =>
            {
                if (match.Groups.Count != 2)
                    return match.Value;

                var link = match.Groups[1].Value;
                var parts = link.Split('.');
                for (var i = 0; i < parts.Length; i++) parts[i] = parts[i][0].ToString().ToUpper() + parts[i].Substring(1);
                link = string.Join(".", parts);

                var cref =  $"<see cref=\"{link}\"/>";
                return cref;

            }, RegexOptions.Multiline); 
                
            return s;
        }
    }
}

