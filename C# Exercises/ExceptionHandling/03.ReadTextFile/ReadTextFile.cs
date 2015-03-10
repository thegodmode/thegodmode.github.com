using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;


class ReadTextFile
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter file to read!");
        //string filePath = Console.ReadLine();
        string filePath = @"c:\emaili.txt";
        try
        {
            string data = File.ReadAllText(filePath);
            Console.WriteLine(data);
        }
        catch (ArgumentNullException)
        {

            Console.WriteLine("The path cannot be null!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path is a zero-length string, contains only white space, or contains one or more invalid characters!");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("file path must be less then 248 characters and file name must be less then 260 characters!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The specified path is invalid!");
        }

        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Path specified a file that is read-only,or this operation is not supported on the current platform,or Path specified a directory,Or The caller does not have the required permission.");
        }
        catch (FileNotFoundException)
        {

            Console.WriteLine("The file specified in path was not found.");
        }
        catch (NotSupportedException)
        {

            Console.WriteLine("Path is invalid format!");
        }

        catch (SecurityException)
        {

            Console.WriteLine("The caller does not have the required permission.");
        }
        

    }
}

