namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            /*var subTree = new Tree<char>('B',
                        new Tree<char>('D'),
                        new Tree<char>('E',
                            new Tree<char>('I')),
                        new Tree<char>('F')
                        );

            var tree = new Tree<char>('A',
                subTree,
                new Tree<char>('C',
                    new Tree<char>('G'))
                );*/
            var tree = new Tree<int>(7,
                        new Tree<int>(19,
                                new Tree<int>(1),
                                new Tree<int>(12),
                                new Tree<int>(31)),
                        new Tree<int>(21),
                        new Tree<int>(14,
                                new Tree<int>(23),
                                new Tree<int>(6)));

            Console.WriteLine(string.Join(", ", tree.OrderBfs()));

        }
    }
}
