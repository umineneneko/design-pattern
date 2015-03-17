using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Oh, it's been a year. It's sill having that feeling: The rainy April");
            Beverage table1 = new Expresso();
            table1 = new Mocha(table1);
            table1 = new Whip(table1);
            Console.WriteLine(table1.GetDescripton());
            Console.WriteLine("$" + table1.Cost());

            Beverage table2 = new Expresso();
            table2 = new Mocha(table2);
            table2 = new Mocha(table2);
            table2 = new Mocha(table2);
            table2 = new Whip(table2);
            table2 = new Fish(table2);
            Console.WriteLine(table2.GetDescripton());
            Console.WriteLine("$" + table2.Cost());
            Console.ReadLine();
        }
    }

    public abstract class Beverage
    {
        public string Description { get; set; }

        public virtual string GetDescripton()
        {
            return Description;
        }

        public abstract decimal Cost();
    }
    #region components

    public class Expresso : Beverage
    {
        public Expresso()
        {
            Description = "Expresso Coffee";
        }
        public override decimal Cost()
        {
            return new decimal(1.6);
        }

    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "HouseBlend Coffee";
        }

        public override decimal Cost()
        {
            return new decimal(2.3);
        }
    }
    
    #endregion

    #region Concrete Decorator classes

    public class Mocha : Beverage
    {
        private Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override string GetDescripton()
        {
            return _beverage.GetDescripton() + " , Mocha";
        }

        public override decimal Cost()
        {
            return _beverage.Cost() + new decimal(.56);
        }
    }

    public class Whip : Beverage
    {
        private Beverage _beverage;

        public Whip(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override string GetDescripton()
        {
            return _beverage.GetDescripton() + " , Whip";
        }

        public override decimal Cost()
        {
            return _beverage.Cost() + new decimal(.56);
        }
    }

    public class Fish : Beverage
    {
        private Beverage _beverage;

        public Fish(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override string GetDescripton()
        {
            return _beverage.GetDescripton() + " , Fish inside";
        }

        public override decimal Cost()
        {
            return _beverage.Cost() + new decimal(3.2);
        }
    } 
    #endregion
}
