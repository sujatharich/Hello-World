using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral
{
    using System.Security.Cryptography.X509Certificates;

    // Given a language, define a representation for its grammar along with an interpreter 
    // that uses the representation to interpret sentences in the language.

    public interface  IExpression
    {
        int Interpret();
    }
    public  class NumberExpression: IExpression
    {
        private readonly int number;
        public NumberExpression(int number)
        {
            this.number = number;
        }

        public NumberExpression(string s)
        {
            this.number = int.Parse(s);
        }
        public int Interpret()
        {
            return this.number;
        }
    }

    public  class PlusExpression: IExpression
    {
        private readonly IExpression leftExpression;
        private readonly IExpression rightExpression;

        public PlusExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public int Interpret()
        {
            return this.leftExpression.Interpret() + this.rightExpression.Interpret();
        }
    }

    public class MinusExpression : IExpression
    {
        private readonly IExpression leftExpression;
        private readonly IExpression rightExpression;

        public MinusExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public int Interpret()
        {
            return this.leftExpression.Interpret() - this.rightExpression.Interpret();
        }
    }
}
