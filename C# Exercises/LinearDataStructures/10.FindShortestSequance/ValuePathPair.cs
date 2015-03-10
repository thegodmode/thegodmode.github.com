using System;

public class ValuePathPair
{
    private int value;
    private string currentPath;

    public ValuePathPair(string previousPath, int value)
    {
        this.Value = value;
        if (previousPath == null)
        {
            this.CurrentPath = value.ToString();
        }
        else
        {
            SaveNewPath(previousPath);
        }
    }

    private void SaveNewPath(string path)
    {
        this.CurrentPath = path + " -> " + this.Value;
    }

    public string CurrentPath
    {
        get
        {
            return this.currentPath;
        }
        private set
        {
            this.currentPath = value;
        }
    }

    public int Value
    {
        get
        {
            return this.value;
        }
        private set
        {
            this.value = value;
        }
    }
}