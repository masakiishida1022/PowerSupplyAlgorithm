using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSupply
{
    public class PowerUnit
    {
        public string Name { get; }
        public double Power { get; }

        public PowerUnit(string name, double power)
        {
            this.Name = name;
            this.Power = power;
        }
    }
}
