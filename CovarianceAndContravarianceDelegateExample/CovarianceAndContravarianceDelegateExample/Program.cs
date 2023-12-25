using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceAndContravarianceDelegateExample
{
    internal class Program
    {
        delegate Car CarFactoryDel(int id, string name);
        static void Main(string[] args)
        {
            CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;

            Car iceCar = carFactoryDel(1, "Audi R8");
            Console.WriteLine($"Objedct type: {iceCar.GetType()}");
            Console.WriteLine($"Car details: {iceCar.GetCarDetails()}");

            carFactoryDel = CarFactory.ReturnEVCar;
            Car evCar = carFactoryDel(1, "Tesla Model-3");
            Console.WriteLine($"Objedct type: {evCar.GetType()}");
            Console.WriteLine($"Car details: {evCar.GetCarDetails()}");

            Console.ReadKey();
        }

        public static class CarFactory 
        {
            public static ICECar ReturnICECar(int id, string name) 
            {
                return new ICECar { Id = id, Name = name };
            }

            public static EVCar ReturnEVCar(int id, string name)
            {
                return new EVCar { Id = id, Name = name };
            }

        }

        public abstract class Car 
        { 
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual string GetCarDetails() 
            {
                return $"{Id} - {Name}";
            }
        }

        public class ICECar : Car 
        {
            public override string GetCarDetails()
            {
                return $"{base.GetCarDetails()} - Internal Combustion Engine";
            }
        }

        public class EVCar : Car
        {
            public override string GetCarDetails()
            {
                return $"{base.GetCarDetails()} - Electric";
            }
        }
    }
}
