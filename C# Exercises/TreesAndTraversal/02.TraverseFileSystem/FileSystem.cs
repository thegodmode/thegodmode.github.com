using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class FileSystem
{
    static void Main(string[] args)
    {
        try
        {
            Queue<DirectoryInfo> que = new Queue<DirectoryInfo>();
            var directory = Directory.CreateDirectory(@"C:\WINDOWS ");
            que.Enqueue(directory);
            while (que.Count != 0)
            {
                var currentDirectory = que.Dequeue();
                var currentFiles = currentDirectory.GetFiles();

                foreach (var file in currentFiles)
                {
                                       
                    if (file.Extension.Equals(".exe"))
                    {
                        Console.WriteLine(file.FullName);
                    }
                   
                }

                var subDirectories = currentDirectory.GetDirectories();
                foreach (var item in subDirectories)
                {
                    que.Enqueue(item);
                }
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            // this is not good i know 
            Console.WriteLine(ex.Message);
        }
    }
}