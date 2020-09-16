namespace AccessModifiersPractice
{
    public class DerivedClass : PublicClass
    {
        override internal void InternalMethod()
        {
            System.Console.WriteLine("This is DerivedClass.InternalMethod()");
        }

        public void CallsProtectedMethod()
        {// A protected member of a base class is 
         // accessible in a derived class only if 
         // the access occurs through the derived class type.
            DerivedClass dc = new DerivedClass();
            dc.ProtectedeMethod();

            PublicClass pc = new PublicClass();
            //pc.ProtectedMethod();//not available
        }
    }
}