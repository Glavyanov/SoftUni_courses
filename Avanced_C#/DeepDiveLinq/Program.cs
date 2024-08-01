using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Parsers;

namespace DeepDiveLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            //IEnumerable<int> e = GetValues();

            //using IEnumerator<int> enumerator = e.GetEnumerator();
            //Console.WriteLine(enumerator);
            //while (enumerator.MoveNext()) 
            //{
            //    int i = enumerator.Current;
            //    Console.WriteLine(i);
            //}

            /*foreach (var item in GetValues())
            {
                Console.WriteLine(item);
            }*/

            //IEnumerable<Person> persons = 
            //    [
            //        new Person { Name = "Joe" },
            //        new Person { Name = "Foo" },
            //        new Person { Name = "Jil" }
            //    ];

            //IEnumerable<string> names = SelectCompiler(persons, x => x.Name).ToList();
            //Console.WriteLine(string.Join(", ", names));

            //Console.WriteLine("Try throw exception");
            //IEnumerable<object> e = SelectCompiler<Person, object>(null!, x => x);
            //Console.WriteLine("Not throwed");
            //using IEnumerator<object> enumerator = e.GetEnumerator();
            //Console.WriteLine("Still Not throwed");
            //Console.WriteLine(e.Count()); //Gotcha
            IEnumerable<int> source = Enumerable.Range(0, 1000).ToArray();

            //for (int i = 0; i < 10_000; i++)
            //{
            //    foreach (var item in SelectManual(source, x => x * 2))
            //    {

            //    }
            //}



            /*Console.WriteLine($"Built in: {Enumerable.Select(source, x => x * 2).Sum()}");
            var s = TestBenchExampl.SelectCompiler(source, x => x * 2);
            Console.WriteLine($"With Iteration1: {s.Sum()}");
            Console.WriteLine($"With Iteration2: {s.Sum()}");
            var m = TestBenchExampl.SelectManual(source, x => x * 2);
            Console.WriteLine($"Manualy Impl1: {m.Sum()}");
            Console.WriteLine($"Manualy Impl2: {m.Sum()}");*/


            /*Console.WriteLine(Enumerable.Select(source, x => x * 2));
            Console.WriteLine(TestBenchExampl.SelectCompiler(source, x => x * 2));
            Console.WriteLine(TestBenchExampl.SelectManual(source, x => x * 2));*/
        }

        public static IEnumerable<int> GetValues()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            /*return [1, 2, 3, 4, 5];*/
        }


        [MemoryDiagnoser]
        [ShortRunJob]
        public class TestBenchExampl
        {
            public IEnumerable<int> source = Enumerable.Range(0, 1000).ToArray();

            [Benchmark]
            public int SumLocal()
            {
                int sum = 0;
                foreach (int i in SelectCompiler(source, x => x * 2))
                {
                    sum += i;
                }
                return sum;
            }

            [Benchmark]
            public int SumManual()
            {
                int sum = 0;
                foreach (int i in SelectManual(source, x => x * 2))
                {
                    sum += i;
                }
                return sum;
            }

            [Benchmark]
            public int SumLinq()
            {
                int sum = 0;
                foreach (int i in Enumerable.Select(source, x => x * 2))
                {
                    sum += i;
                }
                return sum;
            }

            public static IEnumerable<TResult> SelectCompiler<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
            {
                ArgumentNullException.ThrowIfNull(source, nameof(source));
                ArgumentNullException.ThrowIfNull(selector, nameof(selector));

                if (source is TSource[] array)
                {
                    return ArrayImpl(array, selector);
                }

                return EnumerableImpl(source, selector);

                static IEnumerable<TResult> EnumerableImpl(IEnumerable<TSource> source, Func<TSource, TResult> selector)
                {
                    foreach (var item in source)
                    {
                        yield return selector(item);
                    }
                }

                static IEnumerable<TResult> ArrayImpl(TSource[] source, Func<TSource, TResult> selector)
                {
                    foreach (var item in source)
                    {
                        yield return selector(item);
                    }
                }
            }

            public static IEnumerable<TResult> SelectManual<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
            {
                ArgumentNullException.ThrowIfNull(source, nameof(source));
                ArgumentNullException.ThrowIfNull(selector, nameof(selector));

                if (source is TSource[] array)
                {
                    return new SelectManualArray<TSource, TResult>(array, selector);
                }

                return new SelectManualEnumerable<TSource, TResult>(source, selector);
            }

        }
    }
}
