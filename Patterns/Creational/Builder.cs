using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational
{

    public  class Vehicle
    {

    }

    interface IVehicleBuilder
    {
        Vehicle GetVehicle();
        void SetAccessories();

        void SetBody();

        void SetEngine();

        void SetModel();
    }

    public class HondaBuilder: IVehicleBuilder
    {
        private Vehicle vehicle = new Vehicle();

        public Vehicle GetVehicle()
        {
            return vehicle;
        }

        public void SetAccessories()
        {
            throw new NotImplementedException();
        }

        public void SetBody()
        {
            throw new NotImplementedException();
        }

        public void SetEngine()
        {
            throw new NotImplementedException();
        }

        public void SetModel()
        {
            throw new NotImplementedException();
        }
    }

    class Builder
    {
    }
}
