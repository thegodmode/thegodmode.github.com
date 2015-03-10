using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CompanyInformation
{
    static void Main(string[] args)
    {
        string companyName = Console.ReadLine();
        string companyAdrress = Console.ReadLine();
        string phoneNumber = Console.ReadLine();
        string faxNumber = Console.ReadLine();
        string webSite = Console.ReadLine();
        string managerFirstName = Console.ReadLine();
        string managerSecondName = Console.ReadLine();
        string managerThirdName = Console.ReadLine();
        byte managerAge = byte.Parse(Console.ReadLine());
        string managerPhone = Console.ReadLine();
        Console.WriteLine("Welcome to {0}.We are located at {1}. "+
        "For more information use phonenumber:{2} or fax:{3}. "+
        "You can visit our website at {4}.Our manager is {5} {6} {7} "+ 
        "and he is at {8} years old.You can call him in anytime-phone:{9}",
         companyName, companyAdrress, phoneNumber, faxNumber,
         webSite, managerFirstName, managerSecondName, 
         managerThirdName, managerAge, managerPhone);
    }
}
