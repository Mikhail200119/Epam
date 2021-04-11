using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Figure;
using System.IO;

/*
1. Создайте обобщенный класс CollectionType<T>. Определить в классе конструкторы, деструктор, методы добавления и удаления элементов, 
другие необходимые методы и, если требуется, перегруженные операции. Определить индексаторы и свойства. Не забывайте про обработку 
исключений. 
2. Возьмите, созданный тип (класс), например, 'геометрическая фигура', и реализуйте в нем интерфейс IComparable<T>.  
Используйте данный класс в качестве параметра вашего обобщенного класса.  Создайте несколько коллекций. Выполните сохранение в файл, 
сортировку, LINQ-запросы в соответствии с вариантом. 
3. Выполните несколько LINQToObject запросов (3-5) к коллекции объектов, используя одновременно более трех операций (пример:
where + select + orderBy, first + any + min).  

Вариант 9: создать массив объектов CollectionType, запросы – найти коллекции с отрицательными элементами (выбрать любое поле объекта), 
найти максимальную и минимальную коллекцию в массиве, содержащую указанный элемент. Обобщенная коллекция – Dictionary<T>.
*/

namespace Lab_Collections
{  
    class EllipseCollection<TKey, TValue> : List<Ellipse> where TValue:Ellipse  //Задание 1
    {
        public int Length { get; private set; } = 0;

        public Element[] Elements;

        private int index = -1;

        private bool IsLimitedCollection;

        public new Element this[int Index]
        {
            get
            {
                return Elements[Index];
            }
            private set
            {
                Elements[Index] = value;
            }
        }

        public EllipseCollection(int NumberOfElements)
        {
            Length = NumberOfElements;
            IsLimitedCollection = true;
        }

        public EllipseCollection()
        {
            Length = 0;
            IsLimitedCollection = false;
        }

        ~EllipseCollection()
        {
            Elements = null;
        }

        public void Add(TKey Key, TValue Value)
        {
            if (!IsLimitedCollection)
            {
                Length++;
                if (Elements != null)
                {    
                    Element[] Buff = new Element[Length];
                    Array.Copy(Elements, Buff, Elements.Length);
                    Elements = new Element[Buff.Length];
                    Array.Copy(Buff, Elements, Buff.Length);
                }
                else
                {
                    Elements = new Element[Length];
                }
                this[Length - 1] = new Element(Key, Value, Length - 1);
            }
            else
            {
                this[Length - 1] = new Element(Key, Value, Length - 1);
            }
        }

        public void Remove(TKey Key)
        {
            Element[] Buff = new Element[Length - 1];
            int j = 0;
            Array.Copy(Elements, Buff, Buff.Length);
            for (int i = 0; i <= Buff.Length; i++)
            {
                try
                {
                    if (Equals(Elements[i].Key, Key))
                    {
                        continue;
                    }
                    else
                    {
                        Buff[j] = Elements[i];
                        j++;
                    }
                }
                catch
                {
                    continue;
                }
            }
            Elements = Buff;
        }

        public bool MoveNext()
        {
            if (index == Elements.Length - 1)
            {
                return false;
            }
            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public new IEnumerator GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        public object Current
        {
            get
            {
                return Elements[index];
            }
        }

        public void WriteToFile()
        {
            using (var File = new StreamWriter(Path.GetFullPath(@"C:\Users\koval\Desktop\epam\Lab_Collections\Outlet.out")))
            {
                foreach (var item in Elements)
                {
                    File.Write("Ellipse " + item.Key + ": ");
                    File.Write("Diametres: " + item.Value.D1_DataChecking + ", " + item.Value.D2_DataChecking + "; ");
                    File.Write("Area: " + item.Value.S_Ellipse + "; ");
                    File.Write("SomeNumber: " + item.Value.SomeNumber + "; ");
                    File.Write("Perimetre: " + item.Value.P_Ellipse + "\n");
                }
                File.Dispose();
            }
        }

        public class Element
        {
            public TKey Key;
            public TValue Value;

            public Element(TKey Key, TValue Value, int Index)
            {
                this.Key = Key;
                this.Value = Value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EllipseCollection<int, Ellipse> Collection = new EllipseCollection<int, Ellipse>();
            for (int i = 0; i < 15; i++)
            {
                Collection.Add(i + 1, new Ellipse(i + 1, i + 1));
            }
            Collection.WriteToFile();
            var NegativeColletion = Collection.Elements.Where(i => i.Value.SomeNumber < 0);        //
            var MinValue = NegativeColletion.Min(num => num.Value.SomeNumber);                    //    Задание 2
            var MaxValue = NegativeColletion.Max(num => num.Value.SomeNumber);                   //
            Console.WriteLine("Числа из класса Ellipse: \n");
            foreach (var item in Collection.Elements)
            {
                Console.WriteLine(item.Value.SomeNumber);
            }
            Console.WriteLine("\n\nОтрицательные числа из класса Ellipse: \n");
            foreach (var item in NegativeColletion)
            {
                Console.WriteLine(item.Value.SomeNumber);
            }

            Console.WriteLine($"Максимальное отрицательное число: {MaxValue}\n" +
                $"Минимальное отрицательное число: {MinValue}");

            var GeneraCollection = Collection.Elements.Where(i => i.Value.SomeNumber > 0).  //Задание 3
                OrderBy(i => i.Value.SomeNumber).Distinct().Take(2);

            Console.WriteLine("\n\nМинимум 2 положительных элементов коллекции без повторений: \n");
            foreach (var item in GeneraCollection)
            {
                Console.WriteLine(item.Value.SomeNumber);
            }

            Console.WriteLine("\n\nCompareTo: " + Collection.Elements[0].Value.CompareTo(new Ellipse(1, 1)));   //CompareTo()
        }
    }
}