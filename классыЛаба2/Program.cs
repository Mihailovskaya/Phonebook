﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace классыЛаба2
{
    [Serializable]
    /// <summary>
    /// абстрактный класс телефонная книга
    /// так так адрес и телефон есть у всех представителей класса, записываем эти параметры в абстрактный класс
    /// </summary>
    public abstract class Phonebook
    {
        
        public string Address { get; set; }
        public string Number { get; set; }
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Phonebook() { }
        /// <summary>
        /// конструктор для Phonebook
        /// </summary>
        /// <param name="address">Адрес</param>
        /// <param name="number">Номер</param>
        public Phonebook(string address, string number)
        {
            Address = address;
            Number = number;
        }
        /// <summary>
        /// абстрактный метод вывода на экран
        /// </summary>
        public abstract void print();

        /// <summary>
        /// абстрактный метод запроса к базе 
        /// </summary>
        /// <param name="characteristic">строка с названием организации или фамилии, по которой будет производиться поиск</param>
        /// <returns>возвращает строку, в которой храниться результат</returns>
        public abstract string request(string characteristic);
    }
    [Serializable]
    /// <summary>
    /// производный класс: Человек 
    /// </summary>
    public class Person : Phonebook
    {
        public string LastName { get; set; }
        /// <summary>
        /// конструктор по умолчанию 
        /// </summary>
        public Person() { }
        /// <summary>
        /// конструктор класса Person
        /// </summary>
        /// <param name="lastname">Фамилия</param>
        /// <param name="address">Адрес</param>
        /// <param name="number">номер телефона</param>
        public Person(string lastname, string address, string number): base(address,number)
        {
            LastName = lastname;
        }
        /// <summary>
        /// определение метода вывода для класса Person
        /// </summary>
        public override void print()
        {
            Console.WriteLine("PERSON Фамилия: " + LastName + ", Адрес: " +Address + ", Номер: " + Number);
            Trace.WriteLine("Работа метода print для класса Person была завершена");
        }
        /// <summary>
        /// определение метода запроса к базе для класса Person
        /// </summary>
        /// <param name="Name">имя, по которому будет производиться поиск</param>
        /// <returns> возвращает либо пустую строку, либо все поля для найденного человека</returns>
        public override string request(string Name)
        {
            string input = "";
            if (Name == LastName)
                input = input + "Фамилия: " + LastName + ", Адрес: " + Address + ", Номер: " + Number;
            Trace.WriteLine("Работа метода request для класса Person была завершена");
            return input;
        }


    }
    [Serializable]
    /// <summary>
    /// производный класс: Организация
    /// </summary>
    public class Organization : Phonebook
    {
        public string OrgName { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        /// <summary>
        /// конструктор по умолчанию 
        /// </summary>
        public Organization() { }
        /// <summary>
        /// конструктор класса Organization
        /// </summary>
        /// <param name="orgname"> Название компании</param>
        /// <param name="address">Адрес компании</param>
        /// <param name="number">Номер компании</param>
        /// <param name="fax">Факс компании</param>
        /// <param name="contactperson">Человек для связи</param>
        public Organization(string orgname, string address, string number, string fax, string contactperson)
            : base(address, number)
        {
            OrgName = orgname;
            Fax = fax;
            ContactPerson = contactperson;
        }
        /// <summary>
        /// определение метода вывода для класса Organization
        /// </summary>
        public override void print()
        {
            Console.WriteLine("ORGANIZATION Название организации: " + OrgName + ", Адрес: " + Address + ", Номер: " + Number + ", Факс: " + Fax + ", Контактное лицо: " + ContactPerson);
            Trace.WriteLine("Работа метода print для класса Organization была завершена");
        }
        /// <summary>
        /// определение метода запроса к базе для класса Organization
        /// </summary>
        /// <param name="Name">название, по которому будет производиться поиск</param>
        /// <returns>возвращает либо пустую строку, либо все поля для найденной организации </returns>
        public override string request(string Name)
        {
            string input="";
            if (Name==OrgName)
                input = input + "Название организации: " + OrgName + ", Адрес: " + Address + ", Номер: " + Number + ", Факс: " + Fax + ", Контактное лицо: " + ContactPerson;
            Trace.WriteLine("Работа метода request для класса Organization была завершена");
            return input;
        }
    }
    [Serializable]
    /// <summary>
    /// происводный класс: Друг
    /// </summary>
    public class Friend : Phonebook
    {
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Friend() { }
        /// <summary>
        /// конструктор класса Friend
        /// </summary>
        /// <param name="lastname">Фамилия</param>
        /// <param name="address">Адрес</param>
        /// <param name="number">Номер телефона</param>
        /// <param name="birthday">День Рождения</param>
        public Friend(string lastname, string address, string number, DateTime birthday)
            : base(address, number)
        {
            LastName = lastname;
            Birthday = birthday;
        }
        /// <summary>
        /// определение метода вывода для класса Friend
        /// </summary>
        public override void print()
        {
            Console.WriteLine("FRIEND Фамилия: " + LastName + ", Адрес: " + Address + ", Номер: " + Number + ", День Рождения: " + Birthday);
            Trace.WriteLine("Работа метода print для класса Friend была завершена");
        }
        /// <summary>
        /// определение метода запроса к базе для класса Friend
        /// </summary>
        /// <param name="Name"> имя, по которому будет производиться поиск</param>
        /// <returns>возвращает либо пустую строку, либо все поля для найденного человека</returns>
        public override string request(string Name)
        {
            string input="";
            if (Name==LastName)
                input = input + "Фамилия: " + LastName + ", Адрес: " + Address + ", Номер: " + Number + ", День Рождения: " + Birthday + "\n";
            Trace.WriteLine("Работа метода request для класса Friend была завершена");
            return input;
        }
    }

    /// <summary>
    /// основной класс
    /// </summary>
    class Program
    {
        /// <summary>
        /// метод чтения из файла
        /// все данные записываются в двумерный массив
        /// входные данные: поля отделены табом, строки - переносом строки, на месте пропусков стоит "-" 
        /// </summary>
        /// <param name="inFile"> путь к файлу </param>
        /// <returns> возвращает массив с данными</returns>
        static string[,] Read(string inFile)
        {
            string[] lines = File.ReadAllLines(inFile);
            string[,] arrDatabase = new string[lines.Length, 7];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split('\t');
                for (int j = 0; j < 7; j++)
                    arrDatabase[i, j] = temp[j];
            }
            return arrDatabase;
        }
        /// <summary>
        /// метод добавления в список и разделения на классы
        /// </summary>
        /// <param name="phbook">список, в который будут помещаться данные</param>
        /// <param name="arrDb">массив с данными</param>
        /// <returns> список с данными</returns>
        static List<Phonebook> Add(List<Phonebook> phbook, string[,] arrDb)
        {
           
            for (int i = 0; i < arrDb.GetLength(0); i++)
            {
                if (arrDb[i, 0] == "-")
                    phbook.Add(new Organization(arrDb[i, 1], arrDb[i, 2], arrDb[i, 3], arrDb[i, 4], arrDb[i, 5]));
                else if (arrDb[i, 6] != "-")
                    phbook.Add(new Friend(arrDb[i, 0], arrDb[i, 2], arrDb[i, 3], Convert.ToDateTime(arrDb[i, 6])));
                else if (arrDb[i, 6] == "-")
                    phbook.Add(new Person(arrDb[i, 0], arrDb[i, 2], arrDb[i, 3]));
            }
            return phbook;
        }
        /// <summary>
        /// вход в программу
        /// определяется путь к файлу
        /// запрашивается действие
        /// в зависимости от выбора, запускается метод(или выводиться сведение об ошибке)
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Введите путь исходного файла:");
            string inFile = Console.ReadLine();
            string[,] arrDatabase = Read(inFile);
            ///Users/gggisss/Downloads/пп.txt
            List <Phonebook> phonebook = new List<Phonebook>();
            phonebook = Add(phonebook, arrDatabase);
            int k = 0;
            while (k!=3)
            {
                Console.WriteLine("Выберите действие:\n" +
                "1). Вывод телефонной книги\n" +
                "2). Поиск по фамилии/названию организации\n" +
                "3). выход из программы");
                k = Convert.ToInt32(Console.ReadLine());
                if (k == 1)
                {
                    foreach (Phonebook P in phonebook)
                        P.print();
                }
                else if (k == 2)
                {
                    Console.WriteLine("Введите фамилию/название организации:");
                    string str = Console.ReadLine();
                    string input = "";
                    foreach (Phonebook P in phonebook)
                        input = input + P.request(str);
                    if (input == "")
                        Console.WriteLine("Ничего не найдено");
                    else Console.WriteLine(input);
                }
                else if (k==3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка\n" +
                        "Выберите действие:\n" +
                        "1). Вывод телефонной книги\n" +
                        "2). Поиск по фамилии/названию организации\n" +
                        "3). выход из программы");
                    k = Convert.ToInt32(Console.ReadLine());
                }

            }

            if (File.Exists("data.xml"))
                File.Delete("data.xml");
            foreach (Phonebook p in phonebook)
            {
                if(Convert.ToString(p.GetType())== "классыЛаба2.Person")
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Person));
                    using (FileStream fs = new FileStream("data.xml", FileMode.Append))
                    {
                        serializer.Serialize(fs, p);
                    }
                }
                else if (Convert.ToString(p.GetType()) == "классыЛаба2.Organization")
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Organization));
                    using (FileStream fs = new FileStream("data.xml", FileMode.Append))
                    {
                        serializer.Serialize(fs, p);
                    }
                }
                else if (Convert.ToString(p.GetType()) == "классыЛаба2.Friend")
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Friend));
                    using (FileStream fs = new FileStream("data.xml", FileMode.Append))
                    {
                        serializer.Serialize(fs, p);
                    }
                }

            }
            
        }
    }
}




