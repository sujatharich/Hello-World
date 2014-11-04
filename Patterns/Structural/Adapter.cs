// -----------------------------------------------------------------------
//  <copyright file="Adapter.cs" company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Patterns.Structural
{
    public class CylindricalSocket
    {
        // Power comes only compatable (i.e cylindertype) stream
        public string PowerSupply(string cylinderSteam)
        {
            if (cylinderSteam == "cylinder")
            {
                return "power";
            }
            else
            {
                return "no power";
            }
        }
    }

    // Rectangular plug uses adapter to convert rectnagular steam to cylinder
    public class RectangularPlug
    {
        public int Steam { get; set; }

        public string GetPower()
        {
            var a = new Adapter();
            return a.Adapt(this.Steam);
        }
    }

    //  Method 1: Where adapter inherits socket object
    public class Adapter : CylindricalSocket
    {
        public string Adapt(int steam)
        {
            
            if (steam == 1)
            {
                // thi is needed for negative unit tests
                return this.PowerSupply("rectangle");
            }
            else
            {
                return this.PowerSupply("cylinder");
            }
        }
    }

    /*** Method 2:  composition where it socket object created with in adapter ***/

    public class RectangularPlugComposition
    {
        public int Steam { get; set; }

        public string GetPower()
        {
            var a = new Adapter();
            return a.Adapt(this.Steam);
        }
    }

    public class AdapterComposition
    {
        public string Adapt(int steam)
        {
            var c = new CylindricalSocket();
            if (steam == 1)
            {
                return c.PowerSupply("rectangle");
            }
            else
            {
                return c.PowerSupply("cylinder");
            }
        }
    }
}
