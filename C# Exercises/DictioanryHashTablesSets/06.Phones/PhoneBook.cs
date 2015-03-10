using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PhoneBook
{
    MultiDictionary<string, Person> names;
    MultiDictionary<string, Person> towns;

    public PhoneBook()
    {
        this.Names = new MultiDictionary<string, Person>(true);
        this.Towns = new MultiDictionary<string, Person>(true);
    }

    private MultiDictionary<string, Person> Towns
    {
        get
        {
            return this.towns;
        }
        set
        {
            this.towns = value;
        }
    }

    private MultiDictionary<string, Person> Names
    {
        get
        {
            return this.names;
        }
        set
        {
            this.names = value;
        }
    }

    public void Add(Person value, params string[] keys)
    {
        for (int index = 0; index < keys.Length; index++)
        {
            if (this.Names[keys[index]] == null)
            {
                this.Names.Add(keys[index], value);
            }
            else
            {
                this.Names[keys[index]].Add(value);
            }
        }
    }

    public IEnumerable<Person> GetMatchesByKeys(string[] param)
    {
        var matchedPersons = names[param[0]];
        HashSet<Person> result = new HashSet<Person>(matchedPersons);
        
        for (int i = 1; i < param.Length; i++)
        {
            matchedPersons = names[param[i]];
            var hashedSet = new HashSet<Person>(matchedPersons);
            result = new HashSet<Person>(result.Intersect(hashedSet));
        }

        return result;
    }

    public IEnumerable<Person> GetMatchesByKeysAndTown(string[] param)
    {
        var matchedPersons = names[param[0]];
        HashSet<Person> result = new HashSet<Person>(matchedPersons);
        
        for (int i = 1; i < param.Length; i++)
        {
            matchedPersons = names[param[i]];
            var hashedSet = new HashSet<Person>(matchedPersons);
            result = new HashSet<Person>(result.Intersect(hashedSet));
        }

        return result;
    }
}