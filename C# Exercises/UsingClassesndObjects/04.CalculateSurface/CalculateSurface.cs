using System;
using System.Linq;

class CalculateSurface
{
    static void Main(string[] args)
    {
        CreateMenu();
        byte key = Byte.Parse(Console.ReadLine());
        SelectMethod(key);
    }

    static void CreateMenu()
    {
        Console.WriteLine("Calculate the surface of a triangle by given:");
        Console.WriteLine(" 1: Side and an altitude to it");
        Console.WriteLine(" 2:Three sides");
        Console.WriteLine(" 3:Two sides and an angle between them");
    }

    static void SelectMethod(byte key)
    {
        switch (key)
        {
            case 1:
                {
                    int side = EnterSide();
                    int altitude = EnterAltitude();
                    Console.WriteLine("The Surface is: {0}", SideSurface(side, altitude));
                    break;
                }
            case 2:
                {
                    int fside = EnterSide();
                    int sside = EnterSide();
                    int tside = EnterSide();
                    Console.WriteLine("The Surface is: {0}", ThreeSideSurface(fside, sside, tside));
                    break;
                }
            case 3:
                {
                    int fside = EnterSide();
                    int sside = EnterSide();
                    int angle = EnterAngle();
                    Console.WriteLine("The Surface is: {0}", TwoSideSurface(fside, sside, angle));
                    break;
                }
            default:
                break;
        }
    }

    static double SideSurface(int side, int altitude)
    {
        return (side * altitude) / 2;
    }

    static int EnterSide()
    {
        Console.WriteLine("Enter Side");
        return Int32.Parse(Console.ReadLine());
    }

    static int EnterAltitude()
    {
        Console.WriteLine("Enter Altitude");
        return Int32.Parse(Console.ReadLine());
    }

    static double ThreeSideSurface(int a, int b, int c)
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    static int EnterAngle()
    {
        Console.WriteLine("Enter Angle");
        return Int32.Parse(Console.ReadLine());
    }

    static double TwoSideSurface(int a, int b, int angle)
    {
        return(a * b * Math.Sin(angle)) / 2;
    }
}