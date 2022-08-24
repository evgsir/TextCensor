using Censor01;

Console.WriteLine("Введите путь до текстового файла: ");
var path = Console.ReadLine();

var info = TextCensor.FileText(path);

if (info.findWords.Count > 0)
{
    Console.WriteLine("Найдено " + info.findWords.Count + " нежелательных слов, а именно:");
    foreach (var i in info.findWords)
    {
        Console.WriteLine(i);
    }
    Console.WriteLine("Было заменено " + info.countChangedLetters + " букв");
}
else Console.WriteLine("Нежелательных слов не найдено");






