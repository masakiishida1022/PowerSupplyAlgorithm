using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSupply
{
    public class DeviceInfo
    {
        public string Name { get; }
        public double Power { get; }

        public DeviceInfo(string name, double power)
        {
            this.Name = name;
            this.Power = power;
        }
    }
}
