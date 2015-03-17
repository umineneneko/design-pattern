/*
 * March - Ranh roi sinh nong noi :3
 * Ngoc Huynh
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("\t\tRound:" + i + "\n");
                new Application(ReturnFactory(i));
                Thread.Sleep(200);
            }
            Console.ReadLine();
        }

        static IGUI ReturnFactory(int i)
        {
            if (i < 3)
            {
                return new AGUI();
            }
            else
            {
                if (i < 6)
                {
                    return new BGUI();
                }
                else
                {
                    return new CGUI();
                }
            }
        }
    }

    public interface IButton
    {
        void DisplayText();
    }
    public interface IGUI
    {
        IButton CreateButton();
    }

    #region products
    public class AButton : IButton
    {

        public void DisplayText()
        {
            Console.WriteLine("Orignal behaviors");
        }
    }

    public class BButton : IButton
    {
        public void DisplayText()
        {
            Console.WriteLine("The promise of the God will bound for eternity");
        }
    }

    public class CButton : IButton
    {
        public void DisplayText()
        {
            Console.WriteLine("Underground");
        }
    }
    #endregion


    #region factories
    public class AGUI : IGUI
    {
        public IButton CreateButton()
        {
            return new AButton();
        }
    }

    public class BGUI : IGUI
    {
        public IButton CreateButton()
        {
            return new BButton();
        }
    }

    public class CGUI : IGUI
    {
        public IButton CreateButton()
        {
            return new CButton();
        }
    }

    #endregion

    public class Application
    {
        public Application(IGUI factory)
        {
            IButton item = factory.CreateButton();
            item.DisplayText();
        }
    }

}
