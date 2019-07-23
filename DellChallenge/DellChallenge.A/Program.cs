using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.
            //A.A()
            //B.B()
            //A.Age
            // When an object is created, the runtime checks if the class inherits from other classes and firstly the root class is instantiated then the child and after the values are set.
            // In our case B inherits from A si firstly A is created, than B and once both constructors are called the next step is ti set the value for Age
            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A.Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
