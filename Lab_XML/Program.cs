using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* 1 --- LinqXml3. Даны имена существующего текстового файла и создаваемого XML-документа. Создать XML-документ с корневым элементом 
 * root и элементами первого уровня line, каждый из которых содержит одну строку из исходного файла. Элемент, содержащий строку 
 * с порядковым номером N (1, 2, ), должен иметь атрибут num со значением, равным N. 
 2 --- Дан XML-документ, содержащий хотя бы один элемент первого уровня. Для каждого элемента первого уровня найти суммарное 
количество атрибутов у его элементов-потомков второго уровня (т. е. элементов, являющихся дочерними элементами его дочерних 
элементов) и вывести найденное количество атрибутов и имя элемента. Элементы выводить в порядке убывания найденного количества
атрибутов, а при совпадении количества атрибутов в алфавитном порядке имен.
 */

namespace Lab_XML
{
    class Program
    {
        static void FirstTask()
        {
            StringBuilder XmlFileName = new StringBuilder();
            List<string> FileLines = new List<string>();
            using (StreamReader File = new StreamReader(Path.GetFullPath("SourseFile.txt")))
            {
                while (!File.EndOfStream)
                {
                    FileLines.Add(File.ReadLine());
                }
            }
            Console.WriteLine("Введите имя нового xml файла: ");
            XmlFileName.Append(Console.ReadLine());
            XmlFileName.Append(".xml");
            XmlWriterSettings Settings = new XmlWriterSettings();
            Settings.Encoding = Encoding.GetEncoding("windows-1251");
            XmlWriter Writer = XmlWriter.Create(XmlFileName.ToString(), Settings);
            Writer.WriteStartDocument();
            Writer.WriteStartElement("root");
            for (int i = 0; i < FileLines.Count; i++)
            {
                Writer.WriteStartElement("line");
                Writer.WriteAttributeString("num", $"{i + 1}");
                Writer.WriteString(FileLines[i].ToString());
                Writer.WriteEndElement();
            }
            Writer.WriteEndElement();
            Writer.WriteEndDocument();
            Writer.Close();
        }

        static void SecondTask()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path.GetFullPath("XmlFile.xml"));
            XmlElement Element = xDoc.DocumentElement;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] roots = { "one", "two", "three" };
            XmlNodeList list = Element.SelectNodes("firstLevel");
            foreach (XmlNode item in list)
            {
                int i = 0;
                int NumberOfIterations = 0;
                do
                {
                    XmlNodeList BuffList = item.SelectNodes(roots[i]);
                    foreach (XmlNode node in BuffList)
                    {
                        XmlNodeList NewList = node.ChildNodes;
                        NumberOfIterations = NewList.Count;
                        foreach (XmlNode NewNode in NewList)
                        {
                            dictionary.Add(NewNode.Name, NewNode.Attributes.Count.ToString());
                        }
                    }
                    i++;
                } while (i < NumberOfIterations);
            }
            var Result = dictionary.OrderBy(num => num.Key);
            Result = Result.OrderByDescending(num => num.Value);
            foreach (var item in Result)
            {
                Console.WriteLine("Name: " + item.Key + "  —  Number of attributes: " + item.Value);
            }
        }

        static void Main(string[] args)
        {
            string Key;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("1 - первое задание\n2 - второе задание");
                Key = Console.ReadLine();
                if (Key == "1")
                {
                    Console.Clear();
                    FirstTask();
                }
                else if (Key == "2")
                {
                    Console.Clear();
                    SecondTask();
                    Console.ReadKey();
                }
                else if (Key == "E")
                {
                    break;
                }
            }
        }
    }
}