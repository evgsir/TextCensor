namespace Censor01;

public class TextCensor
{
    public static void Edit(string path)
    {
        var str = TextFile.Import(path);
        var n_str = RegexTextEdit.Replace(str, JsonStringArr.Import("badwords.json"));
        TextFile.Export(path, n_str);
    }
}