using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool round = true;
            bool square = true;
            bool curly = true;
            bool unbalanced = true;
            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];
                if (current == '(' || current == '{' || current == '[')
                {
                    stack.Push(current);
                }
                else
                {
                    if (stack.Any())
                    {
                        char compare = stack.Pop();
                        if (compare == '(')
                        {
                            round =  current == ')';
                        }
                        else if (compare == '[')
                        {
                            square = current == ']';
                        }
                        else if (compare == '{')
                        {
                            curly = current == '}';
                        }
                        
                    }
                    else
                    {
                        unbalanced = false;
                        break;
                    }
                    
                }

            }
            if (round && stack.Count == 0 && square && curly && unbalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
          
        }
    }
}
