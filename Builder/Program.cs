/*
 * The
builder pattern
is an
object creation
software
design pattern
. The intention is to abstract steps of construction of
objects so that different implementations of these steps can construct different representations of objects. Often, the
builder pattern is used to build products in accordance with the
composite pattern
.
Definition
The intent of the Builder design pattern is to separate the construction of a complex object from its representation.
By doing so, the same construction process can create different representations
 *
 * happy coding for happy living
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            string m = @"The
builder pattern
is an
object creation
software
design pattern
. The intention is to abstract steps of construction of
objects so that different implementations of these steps can construct different representations of objects. Often, the
builder pattern is used to build products in accordance with the
composite pattern
.
Definition
The intent of the Builder design pattern is to separate the construction of a complex object from its representation.
By doing so, the same construction process can create different representations";
            Console.WriteLine(m);
            for (int i = 0; i < 10; i++)
            {                
                Console.WriteLine("\t\tRound:" + i + "\n");
                Cook c = new Cook();
                PizzaBuilder pb = null;
                if (i < 5)
                {
                    pb = new APizzaBuilder();
                }
                else
                {
                    if (i < 7)
                    {
                        pb = new BPizzaBuilder();
                    }
                    else {
                        pb = new CPizzaBuilder();
                    }
                }
                c.SetPizzBuilder(pb);
                c.ContructPizza();
                c.GetPizza();
                Thread.Sleep(200);
            }
            Console.ReadLine();
        }
    }

    class Pizza
    {
        public string Dough = string.Empty;
        public string Sauce = string.Empty;
        public string Topping = string.Empty;
    }

    abstract class PizzaBuilder
    {
        protected Pizza pizz;
        public Pizza GetPizza()
        {
            Console.WriteLine("Type: " + pizz.Dough + " ---- " + pizz.Sauce + " ---- " + pizz.Topping);
            return pizz;
        }
        public void CreatePizza()
        {
            pizz = new Pizza();
        }
        //abstracts methods
        public abstract void CreateDough();
        public abstract void CreateSauce();
        public abstract void CreateTopping();
    }

    class APizzaBuilder : PizzaBuilder
    {
        public override void CreateDough()
        {
            pizz.Dough = "Cross";
        }
        public override void CreateSauce()
        {
            pizz.Sauce = "mild";
        }
        public override void CreateTopping()
        {
            pizz.Topping = "ham + pineapple";
        }
    }

    class BPizzaBuilder : PizzaBuilder
    {
        public override void CreateDough()
        {
            pizz.Dough = "Pan caked";
        }
        public override void CreateSauce()
        {
            pizz.Sauce = "Hot";
        }
        public override void CreateTopping()
        {
            pizz.Topping = "pepper soni + salami";
        }
    }

    class CPizzaBuilder : PizzaBuilder
    {
        public override void CreateDough()
        {
            pizz.Dough = "caked";
        }
        public override void CreateSauce()
        {
            pizz.Sauce = "medium";
        }
        public override void CreateTopping()
        {
            pizz.Topping = "Beef + cheese";
        }
    }
    class Cook
    {
        private PizzaBuilder _pizzBuilder;
        public void SetPizzBuilder(PizzaBuilder pb)
        {
            _pizzBuilder = pb;
        }
        public Pizza GetPizza() {
            return _pizzBuilder.GetPizza();
        }
        public void ContructPizza()
        {
            _pizzBuilder.CreatePizza();
            _pizzBuilder.CreateDough();
            _pizzBuilder.CreateSauce();
            _pizzBuilder.CreateTopping();
        }
    }


}
