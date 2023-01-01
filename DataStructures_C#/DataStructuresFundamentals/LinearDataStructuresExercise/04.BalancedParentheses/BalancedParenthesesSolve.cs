namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> stack = new Stack<char>();
            bool round = true;
            bool square = true;
            bool curly = true;
            bool unbalanced = true;
            for (int i = 0; i < parentheses.Length; i++)
            {
                char current = parentheses[i];
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
                            round = current == ')';
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
                        return unbalanced;
                    }

                }

            }
            if (round && stack.Count == 0 && square && curly && unbalanced)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
