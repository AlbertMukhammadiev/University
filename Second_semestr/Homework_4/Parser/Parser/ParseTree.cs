using System;
using MyException;

namespace ParseTreeNamespace
{
    public class ParseTree
    {
        /// <summary>
        /// creates a parse tree based on the arithmetic expression(using recursion)
        /// </summary>
        /// <param name="expression"></param>
        public void CreateTree(string expression)
        {
            var position = 0;
            var token = Token(expression, ref position);
            switch (token[0])
            {
                case '+':
                    {
                        root = new Addition();
                        break;
                    }

                case '-':
                    {
                        root = new Subtraction();
                        break;
                    }

                case '*':
                    {
                        root = new Multiplication();
                        break;
                    }

                case '/':
                    {
                        root = new Division();
                        break;
                    }

                default:
                    {
                        throw new InvalidExpressionException();
                    }
            }

            CreateNode(this.root, expression, ref position);
            CreateNode(this.root, expression, ref position);
        }

        /// <summary>
        /// prints the parse tree to the console
        /// </summary>
        public void Print()
        {
            this.root.PrintNode();
        }

        /// <summary>
        /// calculates the value of a parse tree and returns it
        /// </summary>
        /// <returns></returns>
        public int Calculate()
        {
            return this.root.Calculate();
        }

        private Node root;

        /// <summary>
        /// returns token(operands or operators(+, -, /, *)) which is located after the "position"
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private string Token(string expression, ref int position)
        {
            var length = expression.Length;
            var token = "";
            for (var i = position; i < length; ++i)
            {
                var symbol = expression[i];
                if ((expression[i] == ' ') || (expression[i] == '(') || (expression[i] == ')'))
                {
                    ++position;
                    continue;
                }

                if ((expression[i] >= '0') && (expression[i] <= '9'))
                {
                    token += expression[i];
                    for (var j = i + 1; j < length; ++j)
                    {
                        if ((expression[j] < '0') || (expression[j] > '9'))
                        {
                            break;
                        }

                        ++position;
                        token += expression[j];
                    }

                    ++position;
                    return token;
                }

                if ((expression[i] == '+') || (expression[i] == '*') || (expression[i] == '/') || (expression[i] == '-'))
                {
                    ++position;
                    return token + expression[i];
                }
            }

            return "error";
        }


        /// <summary>
        /// creates new node and makes it left or right child of the given node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="expression"></param>
        /// <param name="position"></param>
        private void CreateNode(Node node, string expression, ref int position)
        {
            if ((node.Left != null) && (node.Right != null))
            {
                return;
            }

            var token = Token(expression, ref position);
            Node newNode;
            switch (token[0])
            {
                case '+':
                    {
                        newNode = new Addition();
                        break;
                    }

                case '-':
                    {
                        newNode = new Subtraction();
                        break;
                    }

                case '*':
                    {
                        newNode = new Multiplication();
                        break;
                    }

                case '/':
                    {
                        newNode = new Division();
                        break;
                    }

                default:
                    {
                        if ((token[0] >= '0') && (token[0] <= '9'))
                        {
                            if (node.Left == null)
                            {
                                node.Left = new Operand(Convert.ToInt32(token));
                                CreateNode(node, expression, ref position);
                            }
                            else if (node.Right == null)
                            {
                                node.Right = new Operand(Convert.ToInt32(token));
                                CreateNode(node, expression, ref position);
                            }

                            return;
                        }

                        throw new InvalidExpressionException("the expression contains an invalid character");
                    }
            }

            if (node.Left == null)
            {
                node.Left = newNode;
                CreateNode(node.Left, expression, ref position);
                if (node.Right == null)
                {
                    CreateNode(node, expression, ref position);
                }
            }
            else if (node.Right == null)
            {
                node.Right = newNode;
                CreateNode(node.Right, expression, ref position);
            }
        }
    }
}
