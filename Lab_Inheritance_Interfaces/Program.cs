using System;

/*•	Определить интерфейс IConvertible, указывающий, что реализующий его класс может конвертировать блок кода в С# или VB код.
 * В интерфейсе определить два метода ConvertToCSharp и ConvertToVB, каждый из которых принимает и возвращает строку.
 •	Создать класс ProgramHelper, реализующий интерфейс IConvertible. При написании методов вместо преобразования строки
использовать простые строковые сообщения для имитации преобразования.
 •	Создать новый интерфейс ICodeChecker, определив в нем метод CheckCodeSyntax, принимающий две строки: строка для проверки и
используемый язык. Метод должен возвращать тип bool. Добавить в класс ProgramHelper функциональность нового интерфейса IСodeChecker
•	Создать класс ProgramConverter, реализующий интерфейс IConvertible. Изменить класс ProgramHelper, наследуя его от класса 
ProgramConverterи интерфейса ICodeChecker.
•	Протестировать класс, создав массив объектов ProgramConverter, одни из которых имеют тип ProgramConverter, а другие– тип 
ProgramHelper. Для каждого элемента массива проверить, что он реализуют интерфейс IСodeChecker, или нет. Если реализует интерфейс 
IСodeChecker, то вызвать метод проверки кода, и соответствующий метод преобразования. Если не реализует интерфейс IСodeChecker, 
то вызвать два метода преобразования кода.*/

/* в данной программе синтаксис языка C# подразумевает собой наличие в конце вводимой строки точки с запятой, а язык VB -- наоборот
 * отсутствие*/

namespace Lab_Inheritance_Interfaces
{
    interface IConvertible
    {
        string ConvertToSharp(string str);
        string ConvertToVB(string str);
    }

    interface ICodeChecker
    {
        bool CheckCodeSyntax(string str1, string str2);
    }

    class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public new string ConvertToSharp(string str)
        {
            return "Конвертирование в C# выполнено успешно!";
        }

        public new string ConvertToVB(string str)
        {
            return "Конвертирование в VB выполнено успешно!";
        }

        public bool CheckCodeSyntax(string str1, string str2)
        {
            if (str2 == "C#")
            {
                if (str1[str1.Length - 1] == ';')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (str2 == "VB")
            {
                if (str1[str1.Length - 1] != ';')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }

    class ProgramConverter : IConvertible
    {
        public string ConvertToSharp(string str)
        {
            return "Конвертирование в C# выполнено успешно!";
        }

        public string ConvertToVB(string str)
        {
            return "Конвертирование в VB выполнено успешно!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProgramHelper[] Element_1 = new ProgramHelper[5];
            ProgramConverter[] Element_2 = new ProgramConverter[5];
            string CodeString, Language;
            Console.Write("Write code string: ");
            CodeString = Console.ReadLine();
            Console.Write("Write programming language: ");
            Language = Console.ReadLine();
            Console.WriteLine("ProgramHelper:");
            for (int i = 0; i < Element_1.Length; i++)
            {
                Element_1[i] = new ProgramHelper();
                if (Element_1[i] is ICodeChecker)
                {
                    if (Element_1[i].CheckCodeSyntax(CodeString, Language))
                    {
                        if (Language == "C#")
                        {
                            Console.WriteLine(Element_1[i].ConvertToVB(CodeString));
                        }
                        else if (Language == "VB")
                        {
                            Console.WriteLine(Element_1[i].ConvertToSharp(CodeString));
                        }
                    }
                }
                else
                {
                    Console.WriteLine(Element_1[i].ConvertToSharp(CodeString));
                    Console.WriteLine(Element_1[i].ConvertToVB(CodeString));
                }
            }
            Console.WriteLine("ProgramConverter:");
            for (int i = 0; i < Element_2.Length; i++)
            {
                Element_2[i] = new ProgramConverter();
                if (!(Element_2[i] is ICodeChecker))
                {
                    if (Language == "C#")
                    {
                        Console.WriteLine(Element_2[i].ConvertToVB(CodeString));
                    }
                    else if (Language == "VB")
                    {
                        Console.WriteLine(Element_2[i].ConvertToSharp(CodeString));
                    }
                }
                else
                {
                    Console.WriteLine(Element_2[i].ConvertToSharp(CodeString));
                    Console.WriteLine(Element_2[i].ConvertToVB(CodeString));
                }
            }
        }
    }
}