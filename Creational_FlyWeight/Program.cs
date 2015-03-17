/*
 * Green April with heartless goodbye!
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_FlyWeight
{
    class Program
    {
        private static CoffeeFlavor[] flavors = new CoffeeFlavor[100];
        private static CoffeeOrderContext[] tables = new CoffeeOrderContext[100];
        private static int ordersMade = 0;
        private static CoffeeFactory factory;    
        
        static void Main(string[] args)
        {
            Console.WriteLine("Consummer Flyweight pattern");
            factory = new CoffeeFactory();

            TakeOder("Sad Day", 1);
            TakeOder("Foggy Day", 1);
            TakeOder("Black March", 2);
            TakeOder("Green April", 10);
            TakeOder("Rainy Season", 3);
            TakeOder("Yellow November", 4);
            TakeOder("White December", 7);
            TakeOder("Rainy in Sadness", 6);
            TakeOder("Blue Sky", 5);
            TakeOder("Goodbye", 8);
            TakeOder("When will I see you again", 8);
            TakeOder("Torn Apart", 20);
            TakeOder("Missing", 12);
            TakeOder("Violet July", 15);
            TakeOder("When you forget me", 9);
            TakeOder("When you forget me", 4);
            TakeOder("When you forget me", 3);
            TakeOder("When you forget me", 3);
            TakeOder("When you forget me", 5);
            TakeOder("When you forget me", 8);
            TakeOder("When you forget me", 4);

            for (int i = 0; i < ordersMade; i++)
            {
                Console.Write("Order: " + (i+1) + " ");
                flavors[i].ServeCoffee(tables[i]);
            }

            Console.WriteLine("Total Flavors servered: " + factory.GetTotalCoffeeFlavorsMade());
            Console.WriteLine("Total Orders booked: " + ordersMade);
            Console.ReadLine();

        }
        private static void TakeOder(string flavorName, int table) {
            flavors[ordersMade] = factory.GetCoffeeFlavor(flavorName);
            tables[ordersMade++] = new CoffeeOrderContext(table);
        }
    }
    public class CoffeeOrderContext
    {
        private int _tableNumber;
        public CoffeeOrderContext(int tableNo)
        {
            _tableNumber = tableNo;
        }
        public int GetTable()
        {
            return _tableNumber;
        }
    }
    public interface CoffeeOrder
    {
        void ServeCoffee(CoffeeOrderContext context);
    }

    public class CoffeeFlavor : CoffeeOrder
    {
        private string _flavor;
        public CoffeeFlavor(string newFlavor)
        {
            _flavor = newFlavor;
        }
        public string GetFlavor()
        {
            return _flavor;
        }
        public void ServeCoffee(CoffeeOrderContext context)
        {
            Console.WriteLine("Serving coffee: " + _flavor + " / table: " + context.GetTable());
        }
    }
    public class CoffeeFactory
    {
        private Dictionary<string, CoffeeFlavor> _flavors =
            new Dictionary<string, CoffeeFlavor>();
        public CoffeeFlavor GetCoffeeFlavor(string name)
        {
            CoffeeFlavor cf;
            if (!_flavors.ContainsKey(name))
            {
                cf = new CoffeeFlavor(name);
                _flavors.Add(name, cf);
            }
            else
            {
                cf = _flavors.Where(p => p.Key == name).First().Value;
            }
            return cf;
        }

        public int GetTotalCoffeeFlavorsMade()
        {
            return _flavors.Count;
        }
    }
}
