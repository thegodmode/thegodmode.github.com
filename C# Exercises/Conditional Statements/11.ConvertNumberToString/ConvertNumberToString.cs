using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ConvertNumberToString
{
    static void Main(string[] args)
    {
        int number = 471;
        switch (number)
        {
            case 0: Console.WriteLine("Zero"); break;
            case 1: Console.WriteLine("One"); break;
            case 2: Console.WriteLine("Two"); break;
            case 3: Console.WriteLine("Three"); break;
            case 4: Console.WriteLine("Four"); break;
            case 5: Console.WriteLine("Five"); break;
            case 6: Console.WriteLine("Six"); break;
            case 7: Console.WriteLine("Seven"); break;
            case 8: Console.WriteLine("Eight"); break;
            case 9: Console.WriteLine("Nine"); break;
            case 10: Console.WriteLine("Ten"); break;
            case 11: Console.WriteLine("Eleven"); break;
            case 12: Console.WriteLine("Twelve"); break;
            case 13: Console.WriteLine("Thirteen"); break;
            case 14: Console.WriteLine("Fourteen"); break;
            case 15: Console.WriteLine("Fifteen"); break;
            case 16: Console.WriteLine("Sixteen"); break;
            case 17: Console.WriteLine("Seventeen"); break;
            case 18: Console.WriteLine("Eighteen"); break;
            case 19: Console.WriteLine("Nineteen"); break;
            case 20: Console.WriteLine("Twenty"); break;
            default: switch (number / 10)
                {

                    case 2:
                        Console.Write("Twenty");
                        switch (number % 10)
                        {
                            case 0: break;
                            case 1: Console.WriteLine(" One"); break;
                            case 2: Console.WriteLine(" Two"); break;
                            case 3: Console.WriteLine(" Three"); break;
                            case 4: Console.WriteLine(" Four"); break;
                            case 5: Console.WriteLine(" Five"); break;
                            case 6: Console.WriteLine(" Six"); break;
                            case 7: Console.WriteLine(" Seven"); break;
                            case 8: Console.WriteLine(" Eight"); break;
                            case 9: Console.WriteLine(" Nine"); break;
                        }
                        break;
                    case 3:
                        Console.Write("Thirty");
                        switch (number % 10)
                        {
                            case 0: break;
                            case 1: Console.WriteLine(" One"); break;
                            case 2: Console.WriteLine(" Two"); break;
                            case 3: Console.WriteLine(" Three"); break;
                            case 4: Console.WriteLine(" Four"); break;
                            case 5: Console.WriteLine(" Five"); break;
                            case 6: Console.WriteLine(" Six"); break;
                            case 7: Console.WriteLine(" Seven"); break;
                            case 8: Console.WriteLine(" Eight"); break;
                            case 9: Console.WriteLine(" Nine"); break;
                        }
                        break;
                    case 4:
                        Console.Write("Fourthy");
                        switch (number % 10)
                        {
                            case 0: break;
                            case 1: Console.WriteLine(" One"); break;
                            case 2: Console.WriteLine(" Two"); break;
                            case 3: Console.WriteLine(" Three"); break;
                            case 4: Console.WriteLine(" Four"); break;
                            case 5: Console.WriteLine(" Five"); break;
                            case 6: Console.WriteLine(" Six"); break;
                            case 7: Console.WriteLine(" Seven"); break;
                            case 8: Console.WriteLine(" Eight"); break;
                            case 9: Console.WriteLine(" Nine"); break;
                        }
                        break;
                    case 5:
                        Console.Write("Fifty");
                        switch (number % 10)
                        {
                            case 0: break;
                            case 1: Console.WriteLine(" One"); break;
                            case 2: Console.WriteLine(" Two"); break;
                            case 3: Console.WriteLine(" Three"); break;
                            case 4: Console.WriteLine(" Four"); break;
                            case 5: Console.WriteLine(" Five"); break;
                            case 6: Console.WriteLine(" Six"); break;
                            case 7: Console.WriteLine(" Seven"); break;
                            case 8: Console.WriteLine(" Eight"); break;
                            case 9: Console.WriteLine(" Nine"); break;
                        }
                        break;
                    case 6:
                        Console.Write("Sixty");
                        switch (number % 10)
                        {
                            case 0: break;
                            case 1: Console.WriteLine(" One"); break;
                            case 2: Console.WriteLine(" Two"); break;
                            case 3: Console.WriteLine(" Three"); break;
                            case 4: Console.WriteLine(" Four"); break;
                            case 5: Console.WriteLine(" Five"); break;
                            case 6: Console.WriteLine(" Six"); break;
                            case 7: Console.WriteLine(" Seven"); break;
                            case 8: Console.WriteLine(" Eight"); break;
                            case 9: Console.WriteLine(" Nine"); break;
                        }
                        break;
                    case 7:
                        Console.Write("Seventy");
                        switch (number % 10)
                        {
                            case 0: break;
                            case 1: Console.WriteLine(" One"); break;
                            case 2: Console.WriteLine(" Two"); break;
                            case 3: Console.WriteLine(" Three"); break;
                            case 4: Console.WriteLine(" Four"); break;
                            case 5: Console.WriteLine(" Five"); break;
                            case 6: Console.WriteLine(" Six"); break;
                            case 7: Console.WriteLine(" Seven"); break;
                            case 8: Console.WriteLine(" Eight"); break;
                            case 9: Console.WriteLine(" Nine"); break;
                        }
                        break;
                    case 8:
                        Console.Write("Eighty");
                        switch (number % 10)
                        {
                            case 0: break;
                            case 1: Console.WriteLine(" One"); break;
                            case 2: Console.WriteLine(" Two"); break;
                            case 3: Console.WriteLine(" Three"); break;
                            case 4: Console.WriteLine(" Four"); break;
                            case 5: Console.WriteLine(" Five"); break;
                            case 6: Console.WriteLine(" Six"); break;
                            case 7: Console.WriteLine(" Seven"); break;
                            case 8: Console.WriteLine(" Eight"); break;
                            case 9: Console.WriteLine(" Nine"); break;
                        }
                        break;
                    case 9:
                        Console.Write("Ninety");
                        switch (number % 10)
                        {
                            case 0: break;
                            case 1: Console.WriteLine(" One"); break;
                            case 2: Console.WriteLine(" Two"); break;
                            case 3: Console.WriteLine(" Three"); break;
                            case 4: Console.WriteLine(" Four"); break;
                            case 5: Console.WriteLine(" Five"); break;
                            case 6: Console.WriteLine(" Six"); break;
                            case 7: Console.WriteLine(" Seven"); break;
                            case 8: Console.WriteLine(" Eight"); break;
                            case 9: Console.WriteLine(" Nine"); break;
                        }
                        break;
                    default: switch (number / 100)
                        {
                            case 1: 
                                Console.Write("One Hundred ");
                                switch (number % 100)
                                {
                                    case 0: break;
                                    case 1: Console.WriteLine("and One"); break;
                                    case 2: Console.WriteLine("and Two"); break;
                                    case 3: Console.WriteLine("and Three"); break;
                                    case 4: Console.WriteLine("and Four"); break;
                                    case 5: Console.WriteLine("and Five"); break;
                                    case 6: Console.WriteLine("and Six"); break;
                                    case 7: Console.WriteLine("and Seven"); break;
                                    case 8: Console.WriteLine("and Eight"); break;
                                    case 9: Console.WriteLine("and Nine"); break;
                                    case 10: Console.WriteLine("and Ten"); break;
                                    case 11: Console.WriteLine("and Eleven"); break;
                                    case 12: Console.WriteLine("and Twelve"); break;
                                    case 13: Console.WriteLine("and Thirteen"); break;
                                    case 14: Console.WriteLine("and Fourteen"); break;
                                    case 15: Console.WriteLine("and Fifteen"); break;
                                    case 16: Console.WriteLine("and Sixteen"); break;
                                    case 17: Console.WriteLine("and Seventeen"); break;
                                    case 18: Console.WriteLine("and Eighteen"); break;
                                    case 19: Console.WriteLine("and Nineteen"); break;
                                    case 20: Console.WriteLine("and Twenty"); break;
                                    default: 
                                         number = number % 100;
                                         switch (number/10)
	                                     {
                                             case 2:
                                                 Console.Write("Twenty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 3:
                                                 Console.Write("Thirty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 4:
                                                 Console.Write("Fourthy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 5:
                                                 Console.Write("Fifty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 6:
                                                 Console.Write("Sixty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 7:
                                                 Console.Write("Seventy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 8:
                                                 Console.Write("Eighty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 9:
                                                 Console.Write("Ninety");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
	                                     }
                                         break;
                                }
                                break;
                            case 2: 
                                Console.Write("Two Hundred ");
                                switch (number % 100)
                                {
                                    case 0: break;
                                    case 1: Console.WriteLine("and One"); break;
                                    case 2: Console.WriteLine("and Two"); break;
                                    case 3: Console.WriteLine("and Three"); break;
                                    case 4: Console.WriteLine("and Four"); break;
                                    case 5: Console.WriteLine("and Five"); break;
                                    case 6: Console.WriteLine("and Six"); break;
                                    case 7: Console.WriteLine("and Seven"); break;
                                    case 8: Console.WriteLine("and Eight"); break;
                                    case 9: Console.WriteLine("and Nine"); break;
                                    case 10: Console.WriteLine("and Ten"); break;
                                    case 11: Console.WriteLine("and Eleven"); break;
                                    case 12: Console.WriteLine("and Twelve"); break;
                                    case 13: Console.WriteLine("and Thirteen"); break;
                                    case 14: Console.WriteLine("and Fourteen"); break;
                                    case 15: Console.WriteLine("and Fifteen"); break;
                                    case 16: Console.WriteLine("and Sixteen"); break;
                                    case 17: Console.WriteLine("and Seventeen"); break;
                                    case 18: Console.WriteLine("and Eighteen"); break;
                                    case 19: Console.WriteLine("and Nineteen"); break;
                                    case 20: Console.WriteLine("and Twenty"); break;
                                    default: 
                                         number = number % 100;
                                         switch (number/10)
	                                     {
                                             case 2:
                                                 Console.Write("Twenty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 3:
                                                 Console.Write("Thirty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 4:
                                                 Console.Write("Fourthy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 5:
                                                 Console.Write("Fifty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 6:
                                                 Console.Write("Sixty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 7:
                                                 Console.Write("Seventy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 8:
                                                 Console.Write("Eighty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 9:
                                                 Console.Write("Ninety");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
	                                     }
                                         break;
                                }
                                break;
                               
                            case 3: 
                                Console.Write("Three Hundred ");
                                switch (number % 100)
                                {
                                    case 0: break;
                                    case 1: Console.WriteLine("and One"); break;
                                    case 2: Console.WriteLine("and Two"); break;
                                    case 3: Console.WriteLine("and Three"); break;
                                    case 4: Console.WriteLine("and Four"); break;
                                    case 5: Console.WriteLine("and Five"); break;
                                    case 6: Console.WriteLine("and Six"); break;
                                    case 7: Console.WriteLine("and Seven"); break;
                                    case 8: Console.WriteLine("and Eight"); break;
                                    case 9: Console.WriteLine("and Nine"); break;
                                    case 10: Console.WriteLine("and Ten"); break;
                                    case 11: Console.WriteLine("and Eleven"); break;
                                    case 12: Console.WriteLine("and Twelve"); break;
                                    case 13: Console.WriteLine("and Thirteen"); break;
                                    case 14: Console.WriteLine("and Fourteen"); break;
                                    case 15: Console.WriteLine("and Fifteen"); break;
                                    case 16: Console.WriteLine("and Sixteen"); break;
                                    case 17: Console.WriteLine("and Seventeen"); break;
                                    case 18: Console.WriteLine("and Eighteen"); break;
                                    case 19: Console.WriteLine("and Nineteen"); break;
                                    case 20: Console.WriteLine("and Twenty"); break;
                                    default: 
                                         number = number % 100;
                                         switch (number/10)
	                                     {
                                             case 2:
                                                 Console.Write("Twenty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 3:
                                                 Console.Write("Thirty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 4:
                                                 Console.Write("Fourthy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 5:
                                                 Console.Write("Fifty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 6:
                                                 Console.Write("Sixty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 7:
                                                 Console.Write("Seventy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 8:
                                                 Console.Write("Eighty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 9:
                                                 Console.Write("Ninety");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
	                                     }
                                         break;
                                }
                                break;
                            case 4:
                                Console.Write("Four Hundred ");
                                switch (number % 100)
                                {
                                    case 0: break;
                                    case 1: Console.WriteLine("and One"); break;
                                    case 2: Console.WriteLine("and Two"); break;
                                    case 3: Console.WriteLine("and Three"); break;
                                    case 4: Console.WriteLine("and Four"); break;
                                    case 5: Console.WriteLine("and Five"); break;
                                    case 6: Console.WriteLine("and Six"); break;
                                    case 7: Console.WriteLine("and Seven"); break;
                                    case 8: Console.WriteLine("and Eight"); break;
                                    case 9: Console.WriteLine("and Nine"); break;
                                    case 10: Console.WriteLine("and Ten"); break;
                                    case 11: Console.WriteLine("and Eleven"); break;
                                    case 12: Console.WriteLine("and Twelve"); break;
                                    case 13: Console.WriteLine("and Thirteen"); break;
                                    case 14: Console.WriteLine("and Fourteen"); break;
                                    case 15: Console.WriteLine("and Fifteen"); break;
                                    case 16: Console.WriteLine("and Sixteen"); break;
                                    case 17: Console.WriteLine("and Seventeen"); break;
                                    case 18: Console.WriteLine("and Eighteen"); break;
                                    case 19: Console.WriteLine("and Nineteen"); break;
                                    case 20: Console.WriteLine("and Twenty"); break;
                                default: 
                                         number = number % 100;
                                         switch (number/10)
	                                     {
                                             case 2:
                                                 Console.Write("Twenty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 3:
                                                 Console.Write("Thirty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 4:
                                                 Console.Write("Fourthy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 5:
                                                 Console.Write("Fifty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 6:
                                                 Console.Write("Sixty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 7:
                                                 Console.Write("Seventy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 8:
                                                 Console.Write("Eighty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 9:
                                                 Console.Write("Ninety");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
	                                     }
                                         break;
                                }
                                break;
                            case 5: 
                                Console.Write("Five Hundred ");
                                switch (number % 100)
                                {
                                    case 0: break;
                                    case 1: Console.WriteLine("and One"); break;
                                    case 2: Console.WriteLine("and Two"); break;
                                    case 3: Console.WriteLine("and Three"); break;
                                    case 4: Console.WriteLine("and Four"); break;
                                    case 5: Console.WriteLine("and Five"); break;
                                    case 6: Console.WriteLine("and Six"); break;
                                    case 7: Console.WriteLine("and Seven"); break;
                                    case 8: Console.WriteLine("and Eight"); break;
                                    case 9: Console.WriteLine("and Nine"); break;
                                    case 10: Console.WriteLine("and Ten"); break;
                                    case 11: Console.WriteLine("and Eleven"); break;
                                    case 12: Console.WriteLine("and Twelve"); break;
                                    case 13: Console.WriteLine("and Thirteen"); break;
                                    case 14: Console.WriteLine("and Fourteen"); break;
                                    case 15: Console.WriteLine("and Fifteen"); break;
                                    case 16: Console.WriteLine("and Sixteen"); break;
                                    case 17: Console.WriteLine("and Seventeen"); break;
                                    case 18: Console.WriteLine("and Eighteen"); break;
                                    case 19: Console.WriteLine("and Nineteen"); break;
                                    case 20: Console.WriteLine("and Twenty"); break;
                                    default: 
                                         number = number % 100;
                                         switch (number/10)
	                                     {
                                             case 2:
                                                 Console.Write("Twenty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 3:
                                                 Console.Write("Thirty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 4:
                                                 Console.Write("Fourthy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 5:
                                                 Console.Write("Fifty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 6:
                                                 Console.Write("Sixty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 7:
                                                 Console.Write("Seventy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 8:
                                                 Console.Write("Eighty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 9:
                                                 Console.Write("Ninety");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
	                                     }
                                         break;
                                }
                                break;
                            case 6:
                                Console.Write("Six Hundred ");
                                switch (number % 100)
                                {
                                    case 0: break;
                                    case 1: Console.WriteLine("and One"); break;
                                    case 2: Console.WriteLine("and Two"); break;
                                    case 3: Console.WriteLine("and Three"); break;
                                    case 4: Console.WriteLine("and Four"); break;
                                    case 5: Console.WriteLine("and Five"); break;
                                    case 6: Console.WriteLine("and Six"); break;
                                    case 7: Console.WriteLine("and Seven"); break;
                                    case 8: Console.WriteLine("and Eight"); break;
                                    case 9: Console.WriteLine("and Nine"); break;
                                    case 10: Console.WriteLine("and Ten"); break;
                                    case 11: Console.WriteLine("and Eleven"); break;
                                    case 12: Console.WriteLine("and Twelve"); break;
                                    case 13: Console.WriteLine("and Thirteen"); break;
                                    case 14: Console.WriteLine("and Fourteen"); break;
                                    case 15: Console.WriteLine("and Fifteen"); break;
                                    case 16: Console.WriteLine("and Sixteen"); break;
                                    case 17: Console.WriteLine("and Seventeen"); break;
                                    case 18: Console.WriteLine("and Eighteen"); break;
                                    case 19: Console.WriteLine("and Nineteen"); break;
                                    case 20: Console.WriteLine("and Twenty"); break;
                               default: 
                                         number = number % 100;
                                         switch (number/10)
	                                     {
                                             case 2:
                                                 Console.Write("Twenty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 3:
                                                 Console.Write("Thirty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 4:
                                                 Console.Write("Fourthy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 5:
                                                 Console.Write("Fifty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 6:
                                                 Console.Write("Sixty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 7:
                                                 Console.Write("Seventy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 8:
                                                 Console.Write("Eighty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 9:
                                                 Console.Write("Ninety");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
	                                     }
                                         break;
                                }
                                break;
                            case 7:
                                Console.Write("Seven Hundred ");
                                switch (number % 100)
                                {
                                    case 0: break;
                                    case 1: Console.WriteLine("and One"); break;
                                    case 2: Console.WriteLine("and Two"); break;
                                    case 3: Console.WriteLine("and Three"); break;
                                    case 4: Console.WriteLine("and Four"); break;
                                    case 5: Console.WriteLine("and Five"); break;
                                    case 6: Console.WriteLine("and Six"); break;
                                    case 7: Console.WriteLine("and Seven"); break;
                                    case 8: Console.WriteLine("and Eight"); break;
                                    case 9: Console.WriteLine("and Nine"); break;
                                    case 10: Console.WriteLine("and Ten"); break;
                                    case 11: Console.WriteLine("and Eleven"); break;
                                    case 12: Console.WriteLine("and Twelve"); break;
                                    case 13: Console.WriteLine("and Thirteen"); break;
                                    case 14: Console.WriteLine("and Fourteen"); break;
                                    case 15: Console.WriteLine("and Fifteen"); break;
                                    case 16: Console.WriteLine("and Sixteen"); break;
                                    case 17: Console.WriteLine("and Seventeen"); break;
                                    case 18: Console.WriteLine("and Eighteen"); break;
                                    case 19: Console.WriteLine("and Nineteen"); break;
                                    case 20: Console.WriteLine("and Twenty"); break;
                                default: 
                                         number = number % 100;
                                         switch (number/10)
	                                     {
                                             case 2:
                                                 Console.Write("Twenty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 3:
                                                 Console.Write("Thirty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 4:
                                                 Console.Write("Fourthy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 5:
                                                 Console.Write("Fifty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 6:
                                                 Console.Write("Sixty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 7:
                                                 Console.Write("Seventy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 8:
                                                 Console.Write("Eighty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 9:
                                                 Console.Write("Ninety");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
	                                     }
                                         break;
                                }
                                break;
                            case 8: 
                                Console.Write("Eight Hundred ");
                                switch (number % 100)
                                {
                                    case 0: break;
                                    case 1: Console.WriteLine("and One"); break;
                                    case 2: Console.WriteLine("and Two"); break;
                                    case 3: Console.WriteLine("and Three"); break;
                                    case 4: Console.WriteLine("and Four"); break;
                                    case 5: Console.WriteLine("and Five"); break;
                                    case 6: Console.WriteLine("and Six"); break;
                                    case 7: Console.WriteLine("and Seven"); break;
                                    case 8: Console.WriteLine("and Eight"); break;
                                    case 9: Console.WriteLine("and Nine"); break;
                                    case 10: Console.WriteLine("and Ten"); break;
                                    case 11: Console.WriteLine("and Eleven"); break;
                                    case 12: Console.WriteLine("and Twelve"); break;
                                    case 13: Console.WriteLine("and Thirteen"); break;
                                    case 14: Console.WriteLine("and Fourteen"); break;
                                    case 15: Console.WriteLine("and Fifteen"); break;
                                    case 16: Console.WriteLine("and Sixteen"); break;
                                    case 17: Console.WriteLine("and Seventeen"); break;
                                    case 18: Console.WriteLine("and Eighteen"); break;
                                    case 19: Console.WriteLine("and Nineteen"); break;
                                    case 20: Console.WriteLine("and Twenty"); break;
                               default: 
                                         number = number % 100;
                                         switch (number/10)
	                                     {
                                             case 2:
                                                 Console.Write("Twenty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 3:
                                                 Console.Write("Thirty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 4:
                                                 Console.Write("Fourthy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 5:
                                                 Console.Write("Fifty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 6:
                                                 Console.Write("Sixty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 7:
                                                 Console.Write("Seventy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 8:
                                                 Console.Write("Eighty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 9:
                                                 Console.Write("Ninety");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
	                                     }
                                         break;
                                }
                                break;
                            case 9:
                                Console.Write("Nine Hundred ");
                                switch (number % 100)
                                {
                                    case 0: break;
                                    case 1: Console.WriteLine("and One"); break;
                                    case 2: Console.WriteLine("and Two"); break;
                                    case 3: Console.WriteLine("and Three"); break;
                                    case 4: Console.WriteLine("and Four"); break;
                                    case 5: Console.WriteLine("and Five"); break;
                                    case 6: Console.WriteLine("and Six"); break;
                                    case 7: Console.WriteLine("and Seven"); break;
                                    case 8: Console.WriteLine("and Eight"); break;
                                    case 9: Console.WriteLine("and Nine"); break;
                                    case 10: Console.WriteLine("and Ten"); break;
                                    case 11: Console.WriteLine("and Eleven"); break;
                                    case 12: Console.WriteLine("and Twelve"); break;
                                    case 13: Console.WriteLine("and Thirteen"); break;
                                    case 14: Console.WriteLine("and Fourteen"); break;
                                    case 15: Console.WriteLine("and Fifteen"); break;
                                    case 16: Console.WriteLine("and Sixteen"); break;
                                    case 17: Console.WriteLine("and Seventeen"); break;
                                    case 18: Console.WriteLine("and Eighteen"); break;
                                    case 19: Console.WriteLine("and Nineteen"); break;
                                    case 20: Console.WriteLine("and Twenty"); break;
                               default: 
                                         number = number % 100;
                                         switch (number/10)
	                                     {
                                             case 2:
                                                 Console.Write("Twenty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 3:
                                                 Console.Write("Thirty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 4:
                                                 Console.Write("Fourthy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 5:
                                                 Console.Write("Fifty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 6:
                                                 Console.Write("Sixty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 7:
                                                 Console.Write("Seventy");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 8:
                                                 Console.Write("Eighty");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
                                             case 9:
                                                 Console.Write("Ninety");
                                                 switch (number % 10)
                                                 {
                                                     case 0: break;
                                                     case 1: Console.WriteLine(" One"); break;
                                                     case 2: Console.WriteLine(" Two"); break;
                                                     case 3: Console.WriteLine(" Three"); break;
                                                     case 4: Console.WriteLine(" Four"); break;
                                                     case 5: Console.WriteLine(" Five"); break;
                                                     case 6: Console.WriteLine(" Six"); break;
                                                     case 7: Console.WriteLine(" Seven"); break;
                                                     case 8: Console.WriteLine(" Eight"); break;
                                                     case 9: Console.WriteLine(" Nine"); break;
                                                 }
                                                 break;
	                                     }
                                         break;
                                }
                                break;
                        }; break;
                } break;

        }
    }
}

