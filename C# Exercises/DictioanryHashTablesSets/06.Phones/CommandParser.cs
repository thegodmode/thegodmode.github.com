using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class CommandParser
{
    public static void ParseCommnandsFromFile(StreamReader fileReader, List<Command> commands)
    {
        string line = null;
              
        while ((line = fileReader.ReadLine()) != null)
        {
            string[] args = line.Split(new char[] { '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (args[0].Trim() == "find")
            {
                AddFindCommand(args, commands);
            }
        }
    }

    private static void AddFindCommand(string[] args, List<Command> listOfCommands)
    {
        var parameters = new string[args.Length - 1];
        for (int i = 1; i < args.Length; i++)
        {
            parameters[i - 1] = args[i].Trim();
        }
        var newCommand = new Command(CommandType.Find, parameters);
        listOfCommands.Add(newCommand);
    }
}