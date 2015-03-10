using System;
using System.Collections.Generic;
using System.Linq;

public class NameComparer : IComparer<Worker>
{
    public int Compare(Worker x, Worker y)
    {
        if (x.SName.CompareTo(y.SName) > 0)
        {
            return 1;
        }
        else if (x.SName.CompareTo(y.SName) < 0)
        {
            return -1;
        }

        return x.FName.CompareTo(y.FName);
    }
}

public class Worker
{
    private string fName = null;
    private string sName = null;
    private string position = null;
    private int positionValue = 0;

    public Worker(string first, string second, string pos, int value)
    {
        this.fName = first;
        this.sName = second;
        this.position = pos;
        this.positionValue = value;
    }

    public int PositionValue
    {
        get
        {
            return positionValue;
        }
    }

    public string SName
    {
        get
        {
            return sName;
        }
    }

    public string Position
    {
        get
        {
            return position;
        }
    }

    public string FName
    {
        get
        {
            return fName;
        }
    }
}

class Emploees
{
    static void PrintResult(List<Worker> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine("{0} {1}", item.FName, item.SName);
        }
    }

    static Dictionary<string, int> GeneratePositionRating(string[] positions)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int index = 0; index < positions.Length; index++)
        {
            string[] args = positions[index].Split(new char[]{'-'});
            if (!dic.ContainsKey(args[0].Trim()))
            {
                dic.Add(args[0].Trim(), Int32.Parse(args[1].Trim()));
            }
        }
        return dic;
    }

    static List<Worker> GenerateWorkers(string[] workers, Dictionary<string, int> dic)
    {
        List<Worker> list = new List<Worker>();
        for (int index = 0; index < workers.Length; index++)
        {
            string[] args = workers[index].Split(new char[]{'-'});
            string[] names = args[0].Split(new char[]{' '});
            int positionValue = dic[args[1].Trim()];
            Worker newWorker = new Worker(names[0].Trim(), names[1].Trim(), args[1].Trim(), positionValue);
            list.Add(newWorker);
        }
        return list;
    }

    static string[] GetWorkers()
    {
        int n = Int32.Parse(Console.ReadLine());
        string[] workers = new string[n];
        for (int index = 0; index < n; index++)
        {
            workers[index] = Console.ReadLine();
        }

        return workers;
    }

    static string[] GetPositions()
    {
        int m = Int32.Parse(Console.ReadLine());
        string[] positions = new string[m];
        for (int index = 0; index < m; index++)
        {
            positions[index] = Console.ReadLine();
        }

        return positions;
    }

    static void Main()
    {
        string[] positions = GetPositions();
        string[] workers = GetWorkers();
        Dictionary<string, int> positionRating = new Dictionary<string, int>();
        List<Worker> listOfWorkers = new List<Worker>();
        positionRating = GeneratePositionRating(positions);
        listOfWorkers = GenerateWorkers(workers, positionRating);
        listOfWorkers = listOfWorkers.OrderBy(n => n, new NameComparer()).ToList();
        listOfWorkers = listOfWorkers.OrderBy(n => -n.PositionValue).ToList();
        PrintResult(listOfWorkers);
    }
}