using System;
using System.IO;

/*(Вариант 9) Дан текстовый файл Inlet.in, содержащий строковые величины S. В двух последних его строках
 находятся соответственно целочисленная величина k и символьная величина Буква.
Определить количество слов этой величины, содержащий более k% буквы (от количества букв слова),
значение которой хранит переменная Буква. Если
этого сделать нельзя, в качестве ответа выдать значение –1.*/

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
            double NumberPerCent;
            string FileString;
            string PatIn = @"C:\Users\koval\Desktop\buff\Lab_Strings\Inlet.in";
            string PatOut = @"C:\Users\koval\Desktop\buff\Lab_Strings\Outlet.in";
            string[] ModString;
            char[] Splt = { ' ', ',', '.', '\n' };
            char Letter;
            using (var File = new StreamReader(PatIn))
            {
                FileString = File.ReadToEnd();
            }
            ModString = FileString.Split(Splt);
            Letter = ModString[ModString.Length - 2][0];
            NumberPerCent = int.Parse(ModString[ModString.Length - 1]);
            for (int i = 0; i < ModString.Length; i++)
            {
                numberOfLetters = 0;
                for (int j = 0; j < ModString[i].Length - 2; j++)
                {
                    if (ModString[i][j] == Letter)
                    {
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
            using (var file = new StreamWriter(PatOut, false))
            {
                file.Write(WordCounter);
            }
        }
    }
}