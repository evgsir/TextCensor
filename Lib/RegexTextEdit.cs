namespace Censor01;
using System.Text.RegularExpressions;
public class RegexTextEdit
{
    public static string Replace (string str, string [] badWords)
    {
        foreach (var w in badWords)
        {
            var pattern = w;
            string target = new string('*', w.Length);
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            str = regex.Replace(str, target);
        }
        return str;
    }
}