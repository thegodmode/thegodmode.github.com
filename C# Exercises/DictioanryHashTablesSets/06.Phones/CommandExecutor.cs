using System;
using System.Collections.Generic;
using System.Text;

class CommandExecutor
{
    private IEnumerable<Command> listOfCommands;
    private PhoneBook phonebook;

    public CommandExecutor(PhoneBook phonebook, IEnumerable<Command> listOfCommands)
    {
        this.Phonebook = phonebook;
        this.ListOfCommands = listOfCommands;
    }

    public void ExecuteCommands(StringBuilder output)
    {
        foreach (var command in listOfCommands)
        {
            if (command.Type == CommandType.Find)
            {
                var result = ExecuteFindCommand(command.NameParameters, command.Town);
                foreach (var person in result)
                {
                    output.Append(person.ToString());
                    output.AppendLine();
                }
            }
        }
    }

    private IEnumerable<Person> ExecuteFindCommand(string[] nameParameters, string town)
    {
        if (town != null)
        {
            var result = phonebook.GetMatchesByKeysAndTown(nameParameters);
            return result;
        }
        else
        {
            var result = phonebook.GetMatchesByKeys(nameParameters);
            return result;
        }
    }

    private PhoneBook Phonebook
    {
        get
        {
            return this.phonebook;
        }
        set
        {
            this.phonebook = value;
        }
    }

    private IEnumerable<Command> ListOfCommands
    {
        get
        {
            return this.listOfCommands;
        }
        set
        {
            this.listOfCommands = value;
        }
    }
}