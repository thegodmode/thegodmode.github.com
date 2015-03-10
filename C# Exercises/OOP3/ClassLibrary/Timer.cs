using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public delegate void myDelegate();

    public static class Timer
    {
        public static void RepeatAfter(int milisec, myDelegate func)
        {

            while (true)
            {
                func();
                Thread.Sleep(milisec);
            }
        }
    }
}