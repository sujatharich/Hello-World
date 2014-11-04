// -----------------------------------------------------------------------
//  <copyright file="Program.cs" company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Patterns
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Patterns.Creational;

    internal class Program
    {
        private static void Main(string[] args)
        {
            /* singleton class testing */
            const int count = 100;
            var s = new Singleton[count];
            Parallel.For(
                0,
                count,
                i =>
                {
                    s[i] = Singleton.Instance();
                    s[i].GetValue();
                });

            /* factory method testing */

            var f = new ActiveCountFactory();
            List<double> counts =  f.GetActiveCountObject(ActiveCountObject.Cosmos).GetActiveCount();
            foreach (var value in counts)
            {
                Console.WriteLine("Cosmos value: " + value);
            }

            counts = f.GetActiveCountObject(ActiveCountObject.Db).GetActiveCount();
            foreach (var value in counts)
            {
                Console.WriteLine("DB value: " + value);
            }
        }
    }
}
