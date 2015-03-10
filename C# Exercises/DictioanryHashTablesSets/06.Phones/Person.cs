using System;
using System.Text;

public class Person
{
    private string name;
    private string town;
    private string phoneNumber;

    public Person(string name, string town, string phoneNumber)
    {
        this.PhoneNumber = phoneNumber;
        this.Town = town;
        this.Name = name;
    }

    public string PhoneNumber
    {
        get
        {
            return this.phoneNumber;
        }
        private set
        {
            this.phoneNumber = value;
        }
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

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append(name);
        str.Append(" | ");
        str.Append(town);
        str.Append(" | ");
        str.Append(phoneNumber);
        return str.ToString();
    }
}