using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPointSix
{
    internal class Factory
    {
        int wood = 1000;
        int plastic = 500;

        List<IForSale> products = new List<IForSale>();

        public void CreatePencil(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Pencil pencil = new Pencil();
                products.Add(pencil);
                wood -= 10;
                plastic -= 5;
            }
        }
        public void CreatePen(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Pen pen = new Pen();
                products.Add(pen);
                plastic -= 5;
            }
        }

        public void ShowResouces()
        {
            Console.Write($"Дерево: " + wood + "\t");
            Console.Write($"Пластик: " + plastic);
        }
        public void ShowCost()
        {
            var price = 0;
            foreach (var el in products)
            {
                price += el.Sale();
            }
            Console.Write("\t" + "Итого: " + price + "\t");
        }
    }
}

namespace ControlPointSix
{
    internal interface IForSale
    {
        int Sale();
    }
}


namespace ControlPointSix
{
    internal class Pen : IForSale
    {
        public int Sale()
        {
            Random random = new Random();
            int penPrice = random.Next(3, 5);
            return penPrice;
        }
    }
}

namespace ControlPointSix
{
    internal class Pencil : IForSale
    {
        public int Sale()
        {
            int pencilPrice = 6;
            return pencilPrice;
        }
    }
}

namespace ControlPointSix
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            factory.CreatePen(50);
            factory.CreatePencil(50);
            factory.ShowCost();
            factory.ShowResouces();
            Console.ReadLine();
        }
    }
}