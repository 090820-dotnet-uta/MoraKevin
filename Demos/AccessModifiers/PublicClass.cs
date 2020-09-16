namespace AccessModifiersPractice
{
    public class PublicClass
    {
        public void PublicMethod()
        {
            System.Console.WriteLine("this is PublicMethod()");
        }

        private void PrivateMethod()
        {
            System.Console.WriteLine("this is PrivateMethod()");
        }

        virtual internal void InternalMethod()
        {
            System.Console.WriteLine("this is InternalMethod()");
        }

        protected void ProtectedeMethod()
        {
            System.Console.WriteLine("this is ProtectedeMethod()");
        }

        protected internal void ProtectedInternalMethod()
        {
            System.Console.WriteLine("this is ProtectedInternalMethod()");
        }

        private protected void PrivateProtectedMethod()
        {
            System.Console.WriteLine("this is PrivateProtectedMethod()");
        }
    }
}