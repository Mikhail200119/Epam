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
            string SyntaxString, LanguageString;

            ProgramConverter[] Elements =
            {
                new ProgramHelper(),
                new ProgramConverter(),
                new ProgramConverter(),
                new ProgramHelper(),
                new ProgramConverter(),
                new ProgramHelper(),
                new ProgramHelper()
            };

            Console.Write("Введите кодовую строку: ");
            SyntaxString = Console.ReadLine();
            Console.Write("Введите язык программирования: ");
            LanguageString = Console.ReadLine();
            ProgramConverter Object;

            for (int i = 0; i < Elements.Length; i++)
            {
                Object = Elements[i] as ProgramHelper;
                if (Object != null) 
                {
                    Console.WriteLine($"{i + 1}.{Elements[i].GetType()} реализует интерфейс ICodeChecker:");
                    ProgramHelper Helper = new ProgramHelper();
                    if (Helper.CheckCodeSyntax(SyntaxString, LanguageString))
                    {
                        if (LanguageString == "C#")
                        {
                            Console.WriteLine(Elements[i].ConvertToVB(SyntaxString));
                        }
                        else if (LanguageString == "VB")
                        {
                            Console.WriteLine(Elements[i].ConvertToSharp(SyntaxString));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неправильный язык программирования!");
                    }
                }
                else
                {
                    Console.WriteLine($"{i + 1}.{Elements[i].GetType()} не реализует интерфейс ICodeChecker => " +
                        $"выполняется два метода преобразования:");
                    Console.WriteLine(Elements[i].ConvertToSharp(SyntaxString));
                    Console.WriteLine(Elements[i].ConvertToVB(SyntaxString));
                }
            }
        }
    }
}