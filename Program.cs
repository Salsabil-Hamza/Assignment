using System;

namespace ConsoleApp1
{
    class Coffee{
        protected string t = "Coffee";

        public override string ToString() {
            return "Im a " + t + "!";
        }

    }

    class Espresso : Coffee
    {
        public Espresso()
        {
            t = "Espresso";
        }
    }

    class Machiato : Espresso    {

        public override string ToString()
        {
            return "Its a melange of " + base.t + " and Milk!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Coffee _base = new Coffee();
            var esp = new Espresso();
            var mac = new Machiato();

            Console.WriteLine(_base);
            Console.WriteLine(esp);
            Console.WriteLine((Coffee) esp);
            Console.WriteLine(mac);

        }
    }
}
