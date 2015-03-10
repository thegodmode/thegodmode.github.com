using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;


class DownloadFile
{
    static void Main(string[] args)
    {
        string url = @"http://www.devbg.org/img/Logo-BASD.jpg";
        string fileName = @"Logo-BASD.jpg";
        WebClient client = new WebClient();
        try
        {
            Console.WriteLine("Start Downloading...!");
            client.DownloadFile(url, fileName);
            Console.WriteLine("Downloading Completed!");
        }
        catch (WebException)
        {
            Console.WriteLine("The URL is invalid!");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The method has been called simultaneously on multiple threads.!");
        }
        catch (ArgumentNullException)
        {

            Console.WriteLine("URL can not be null!");
        }
    }
}

