using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

class PhonesMain
{
    static void Main(string[] args)
    {
        string phonesFilePath = "phones.txt";
        string commandsFilePath = "commands.txt";
        PhoneBook phonebook = new PhoneBook();
        List<Command> commands = new List<Command>();
        StringBuilder output = new StringBuilder();
       
        GeneratePhoneBook(phonesFilePath, phonebook);

        ParseCommands(commandsFilePath, commands);

        CommandExecutor executor = new CommandExecutor(phonebook, commands);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        executor.ExecuteCommands(output);
        Console.WriteLine(stopwatch.Elapsed);
       // Console.WriteLine(output);
    }

    private static void ParseCommands(string commandsFilePath, List<Command> commands)
    {
        var fileReader = new StreamReader(commandsFilePath);
        CommandParser.ParseCommnandsFromFile(fileReader, commands);
    }

    private static void GeneratePhoneBook(string filePath, PhoneBook phonebook)
    {
        var fileReader = new StreamReader(filePath);
        Creator.CreatePhoneBook(fileReader, phonebook);
    }
}