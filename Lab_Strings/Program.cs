using System;
using System.IO;

/*(Вариант 9) Дан текстовый файл Inlet.in, содержащий строковые величины S. В двух последних его строках
 находятся соответственно целочисленная величина k и символьная величина Буква.
Определить количество слов этой величины, содержащий более k% буквы (от количества букв слова),
значение которой хранит переменная Буква. Если
этого сделать нельзя, в качестве ответа выдать значение –1.*/

/*Файлы Inlet.in и Output.out находятся в каталоге проекта в папке \bin\Debug\netcoreapp3.1*/

namespace Ex
{
    class Program
    {
        static double PerCent(string str, int numberOfLetters)
        {
            if (str.Length == 0)
            {
                return 0;
            }
            return (100 * numberOfLetters) / str.Length;
        }

        static void Main(string[] args)
        {
            int WordCounter = 0, numberOfLetters = 0;
            double NumberPerCent = 0;
            string FileString;
            string PatIn = "Inlet.in";
            string PatOut = "Outlet.out";
            string[] ModString;
            char[] Splt = { ' ', ',', '.', '\n' };
            char Letter;
            using (var File = new StreamReader(Path.GetFullPath(PatIn)))
            {
                FileString = File.ReadToEnd();
            }
            FileString.ToLower();
            ModString = FileString.Split(Splt);
            NumberPerCent = int.Parse(ModString[ModString.Length - 1]);
            Letter = ModString[ModString.Length - 2][0];
            Letter = char.ToLower(Letter);
            for (int i = 0; i < ModString.Length; i++)
            {
                numberOfLetters = 0;
                for (int j = 0; j < ModString[i].Length - 2; j++)
                {
                    if (ModString[i][j] == Letter)
                    {
                        Console.WriteLine(ModString[i]);
                        numberOfLetters++;
                    }
                }
                if (PerCent(ModString[i], numberOfLetters) > NumberPerCent)
                {
                    WordCounter++;
                }
            }
            if (WordCounter == 0)
            {
                WordCounter = -1;
            }
            Console.WriteLine(WordCounter);
            using (var file = new StreamWriter(Path.GetFullPath(PatOut), false))
            {
                file.Write(WordCounter);
            }
        }
    }
}