using System;

namespace ParseTreeNamespace
{
    /// <summary>
    /// the parse tree of the arithmetic expression
    /// </summary>
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
            this.root = CreateOperator(token[0]);
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

        private Operator root;

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
        /// returns the Node that is created as the Operator of operation sign
        /// </summary>
        /// <param name="sign"></param>
        /// <returns></returns>
        private Operator CreateOperator(char sign)
        {
            switch (sign)
            {
                case '+':
                    {
                        return new Addition();
                    }

                case '-':
                    {
                        return new Subtraction();
                    }

                case '*':
                    {
                        return new Multiplication();
                    }

                case '/':
                    {
                        return new Division();
                    }

                default:
                    {
                        throw new InvalidExpressionException("the expression contains an invalid character or begins not with a symbol of the operation");
                    }
            }
        }

        /// <summary>
        /// creates new node and makes it left or right child of the given node(using recursion)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="expression"></param>
        /// <param name="position"></param>
        private void CreateNode(Operator node, string expression, ref int position)
        {
            if ((node.Left != null) && (node.Right != null))
            {
                return;
            }

            var token = Token(expression, ref position);
            Operator newNode;
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
            else
            {
                newNode = CreateOperator(token[0]);
            }

            if (node.Left == null)
            {
                node.Left = newNode;
                CreateNode(newNode, expression, ref position);
                if (node.Right == null)
                {
                    CreateNode(node, expression, ref position);
                }
            }
            else if (node.Right == null)
            {
                node.Right = newNode;
                CreateNode(newNode, expression, ref position);
            }
        }
    }
}
