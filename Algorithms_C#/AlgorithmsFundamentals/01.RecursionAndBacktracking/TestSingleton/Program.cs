using System;

namespace TestSingleton
{
    public class Program
    {
        public sealed class MyClass
        {
            private static MyClass instance = null;
            private MyClass()
            {

            }

            public static MyClass Instance
            {
                get
                {
                    if (instance is null)
                    {
                        instance = new MyClass();
                        Console.WriteLine("new Instance");
                    }
                    return instance;
                }
            }
        }

        static void Main(string[] args)
        {

            var test = MyClass.Instance;
            var test2 = MyClass.Instance;

            return;
        }
    }
}
