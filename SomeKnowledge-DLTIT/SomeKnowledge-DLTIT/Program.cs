using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeKnowledge_DLTIT
{
    class Program
    {
        static void Main(string[] args)
        {
            //aMethod(new Cat() { Name = "Nope" });
        }

        public static void aMethod(Animal animal)
        {
            Console.WriteLine(animal.Name);
        }

        public static void bMethod(Dog dog)
        {
            Console.WriteLine(dog.Name);
        }
    }

    class Animal
    {
        public string Name { get; set; }
        public string NumberOfLegs { get; set; }
        public string Location { get; set; }
    }

    class Dog : Animal
    {
        static void Main(string[] args)
        {
        }
    }

    class Cat : Animal
    {
        static void Main(string[] args)
        {
        }
    }
}
