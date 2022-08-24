namespace Censor01;
using System.Text.RegularExpressions;
public abstract class RegexTextEdit
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
    public static Information Info (string str, string [] badWords)
    {
        List <string> info = new List<string>();
        var countChangeLetters = 0;
        foreach (var w in badWords)
        {
            string pattern = @"(\w*)" + w + @"(\w*)";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(str);
            foreach (Match match in matches)
            {
                info.Add(match.Value.ToString());
                countChangeLetters += w.Length;
            }
        }
        return new Information(info, countChangeLetters);
    }
}

