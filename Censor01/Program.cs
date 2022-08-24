using Censor01;

Console.WriteLine("Введите путь до текстового файла: ");
var path = Console.ReadLine();

var info = TextCensor.FileText(path);

if (info.Count > 0)
{
    Console.WriteLine("Найдено " + info.Count + " нежелательных слов, а именно:");
    foreach (var i in info)
    {
        Console.WriteLine(i);
    }
}
else Console.WriteLine("Нежелательных слов не найдено");






