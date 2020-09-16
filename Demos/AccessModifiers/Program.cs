using System;

namespace AccessModifiersPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Whats up?!");

            PublicClass pc = new PublicClass();
            pc.ProtectedInternalMethod();
            pc.PublicMethod();
            pc.InternalMethod();

            DerivedClass dc = new DerivedClass();
            dc.InternalMethod();
            dc.ProtectedInternalMethod();
            dc.PublicMethod();

            PublicClass pc1 = new DerivedClass();
            pc1.InternalMethod();

            /*
            DerivedClass dc1 = new DerivedClass();
            dc1.ProtectedInternalMethod();
            */


        }
    }
}
