using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp58
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderSet newyear = new OrderSet("Пицца", "Суши", "Бургер");
            Console.WriteLine("Исходный набор: " + newyear);

            OrderSet office = newyear.Clone();
            Console.WriteLine("Клонированный набор: " + office);

            office.UpdateOrder("Пицца", null, "Бургер"); 
            Console.WriteLine("Обновленный клонированный набор: " + office);

            Console.WriteLine("Исходный набор после изменений в клоне: " + newyear);
        }

        public interface IClonePrototype<T>
        {
            T Clone();
        }

        public class OrderSet : IClonePrototype<OrderSet>
        {
            public string Pizza { get; set; }
            public string Sushi { get; set; }
            public string Burger { get; set; }
            public OrderSet(string pizza, string sushi, string burger)
            {
                Pizza = pizza;
                Sushi = sushi;
                Burger = burger;
            }

            public OrderSet Clone()
            {
                return (OrderSet)MemberwiseClone();
            }

            public void UpdateOrder(string pizza, string sushi, string burger)
            {
                if (pizza != null) Pizza = pizza;
                if (sushi != null) Sushi = sushi;
                if (burger != null) Burger = burger;
            }

            public override string ToString()
            {
                return $"Pizza: {Pizza}, Sushi: {Sushi}, Burger: {Burger}";
            }
        }
    }
}
