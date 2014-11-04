// -----------------------------------------------------------------------
//  <copyright file="TemplateMethod.cs" company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Patterns.Behavioral
{
    public abstract class CrossCompiler
    {
        public string Compile()
        {
            string a = this.CollectSource();
            string b = this.CompileToTarget();
            return a + b;
        }

        protected abstract string CollectSource();

        protected abstract string CompileToTarget();
    }

    public class IPhoneCompiler : CrossCompiler
    {
        protected override string CollectSource()
        {
            return "iphone source";
        }

        protected override string CompileToTarget()
        {
            return " compile";
        }
    }

    public class AndroidCompiler : CrossCompiler
    {
        protected override string CollectSource()
        {
            return "android source";
        }

        protected override string CompileToTarget()
        {
            return " compile";
        }
    }
}
