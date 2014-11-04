// -----------------------------------------------------------------------
//  <copyright file="Strategy.cs" company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Patterns.Behavioral
{
    public abstract class Strategy
    {
        public abstract int TotalFromAlgorithm(int a, int b);
    }

    public class AdditionStrategy : Strategy
    {
        public override int TotalFromAlgorithm(int a, int b)
        {
            return a + b;
        }
    }

    public class SubstractionStrategy : Strategy
    {
        public override int TotalFromAlgorithm(int a, int b)
        {
            return a - b;
        }
    }

    public class MultiplicationStrategy : Strategy
    {
        public override int TotalFromAlgorithm(int a, int b)
        {
            return a * b;
        }
    }

    public class Calculator
    {
        private readonly Strategy strategy;

        public Calculator(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public int GetResult(int a, int b)
        {
            return this.strategy.TotalFromAlgorithm(a, b);
        }
    }
}
