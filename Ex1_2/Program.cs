using System;

namespace MK_Project2
{
    class Program
    {
        static string ConvertNumberToBinary(uint number)
        {
            float buff_number = 0;
            string new_str;
            char[] str = new char[100];
            int i = 0;
            while (number > 0)
            {
                buff_number = number;
                if (buff_number % 2 == 0) 
                {
                    if (buff_number == 0)
                    {
                        str[i] = '1';
                        break;
                    }
                    str[i] = '0';
                }
                else if (buff_number % 2 == 1)
                {
                    str[i] = '1';
                }
                i++;
                number /= 2;
            }
            new_str = new string(str);
            new_str = new_str[0..i];
            str = new_str.ToCharArray();
            Array.Reverse(str);
            new_str = new string(str);
            return new_str;
        }

        static void Main(string[] args)
        {
            uint number;
            string str;
            Console.Write("Введите целое десятичное беззнаковое число: ");
            number = uint.Parse(Console.ReadLine());
            str = Convert.ToString(number, 2);
            Console.WriteLine(ConvertNumberToBinary(number));
            Console.WriteLine(str);
        }
    }
}
