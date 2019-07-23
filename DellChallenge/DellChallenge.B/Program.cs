using System;
using System.Collections.Generic;
using System.Linq;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)

            var human = new Human();
            foreach(var a in human.GetSpecies())
            {
                Console.WriteLine(a);
            }


            Console.ReadKey();
        }
    }

    public interface ISpecie
    {
        void Eat();
        void Drink();
        IEnumerable<string> GetSpecies();
    }

    public interface IFlyingSpecie : ISpecie
    {
        void Fly();
    }

    public interface ISwimingSpecie : ISpecie
    {
        void Swim();
    }

    public abstract class Specie : ISpecie
    {
        public virtual void Drink()
        {
            Console.WriteLine("I'm drinking");
        }

        public void Eat()
        {
            Console.WriteLine("I'm eating");
        }

        public virtual IEnumerable<string> GetSpecies()
        {
            return GetType()
                 .GetInterfaces()
                 .Where(t => t.UnderlyingSystemType.GetInterfaces().Any(ti => ti == typeof(ISpecie)))
                 .Select(t => t.Name);
        }
    }

    public sealed class Human : Specie, ISwimingSpecie
    {
        public void Swim()
        {
            Console.WriteLine("I'm a swimming Human");
        }
    }
       
    public class Bird : Specie, IFlyingSpecie
    {
        public virtual void Fly()
        {
            Console.WriteLine("I'm a flying Bird");
        }
    }

    public class Fish : Specie, ISwimingSpecie
    {
        public virtual void Swim()
        {
            Console.WriteLine("I'm a swimming Fish");
        }
    }
}

