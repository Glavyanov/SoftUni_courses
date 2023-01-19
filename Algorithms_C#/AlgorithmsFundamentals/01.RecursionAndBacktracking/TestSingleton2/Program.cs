using static System.Net.Mime.MediaTypeNames;
using System;
using System.Linq.Expressions;

namespace TestSingleton2
{
    //thread safe code
    public sealed class Singleton2
    {
        private static readonly object isLocked = new object();//thread safe code
        private static Singleton2 instance = null;

        private Singleton2()
        {
            Console.WriteLine("ctor");
        }

        public static Singleton2 Instance
        {
            get
            {
                //ensures that only one thread will create an instance.
                lock (isLocked) // lock is for thread while not executed is locked
                {
                    if (instance == null)
                    {
                        instance = new Singleton2();
                        Console.WriteLine("new Singleton2");
                    }
                    return instance;
                }
            }
        }
    }
    /// <summary>
    /// The preceding implementation looks like a very simple code.
    /// This type of implementation has a static constructor, so it executes only once per Application Domain.
    /// It is not as lazy as the other implementation.
    /// </summary>
    public sealed class Singleton4
    {
        private static readonly Singleton4 instance = new Singleton4();

        static Singleton4()
        {
            Console.WriteLine("static ctor singleton4");
        }

        private Singleton4()
        {
            Console.WriteLine("private ctor singleton4");

        }

        public static Singleton4 Instance
        {
            get
            {
                return instance;
            }
        }
    }

    /// <summary>
    /// If you are using .NET 4 or higher then you can use the System.Lazy<T> type to make the laziness really simple.
    /// You can pass a delegate to the constructor that calls the Singleton constructor, which is done most easily with a lambda expression.
    /// Allows you to check whether or not the instance has been created with the IsValueCreated property.
    /// </summary>
    public sealed class Singleton5
    {
        private Singleton5()
        {
            Console.WriteLine("private ctor singleton 5");
        }
        private static readonly Lazy<Singleton5> lazy = new Lazy<Singleton5>(() => new Singleton5());

        public static Singleton5 Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            var test = Singleton2.Instance;
            test = Singleton2.Instance;
            var test2 = Singleton2.Instance;
            var test4 = Singleton4.Instance;
            test4 = Singleton4.Instance;

            var test5 = Singleton5.Instance;
            test5 = Singleton5.Instance;
        }
    }
}