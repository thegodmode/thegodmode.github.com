using System;
using System.Linq;

public class Command
{
    private CommandType type;
    private string[] nameParameters;
    private string town;

    public Command(CommandType type, string[] parameters, string town = null)
    {
        this.NameParameters = parameters;
        this.Type = type;
        this.town = town;
    }

    public string Town
    {
        get
        {
            return this.town;
        }
        private set
        {
            this.town = value;
        }
    }

    public string[] NameParameters
    {
        get
        {
            return this.nameParameters;
        }
        private set
        {
            this.nameParameters = value;
        }
    }

    public CommandType Type
    {
        get
        {
            return this.type;
        }
        private set
        {
            this.type = value;
        }
    }
}