using System;
using System.Collections.Generic;

namespace AzIf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Proccess type[1,2,3]");
            string input = Console.ReadLine();
            var isParsed = enumProccessType.TryParse(input, out enumProccessType proccessType);

            if (isParsed && ((int) proccessType).Between(0, 4))
            {
                var dummy = new Dummy();
                dummy.Say(proccessType);
            }
            else
            {
                Console.WriteLine("invalid input");
            }
        }

    }


    public enum enumProccessType
    {
        SayHi = 1,
        SayHello = 2,
        SaySomething = 3
    }




    public class Dummy
    {
        private Dictionary<enumProccessType, Action> proccessList;

        public Dummy()
        {
            proccessList = new Dictionary<enumProccessType, Action>();
            proccessList.Add(enumProccessType.SayHi, SayHi);
            proccessList.Add(enumProccessType.SayHello, SayHello);
            proccessList.Add(enumProccessType.SaySomething, SaySomething);

        }

        private void SayHi()
        {
            Console.WriteLine("Hi!");
        }

        private void SayHello()
        {
            Console.WriteLine("Hello!");
        }

        private void SaySomething()
        {
            Console.WriteLine("Hello World!");
        }

        public void Say(enumProccessType proccessType)
        {
            //this.proccessList[proccessType].Invoke(); // or
            this.proccessList[proccessType]();
        }
    }

    public static class Extensions
    {
        public static bool Between(this int value, int min, int max)
        {
            return value > min && value < max;
        }
    }
}