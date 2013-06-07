using System;
using System.IO;

public static class Creator
{
    public static void CreatePhoneBook(StreamReader fileReader, PhoneBook phoneBook)
    {
        string line = null;

        while ((line = fileReader.ReadLine()) != null)
        {
            string[] data = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string[] name = data[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var person = new Person(data[0].Trim(), data[1].Trim(), data[2].Trim());
            phoneBook.Add(person, name);
            phoneBook.Add(person, data[1].Trim());
        }
    }
}