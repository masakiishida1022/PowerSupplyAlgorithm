using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSupply
{
    public class PowerCalculationResult : List<DeviceInfo>
    {
        public PowerUnit Unit { get; }

        public PowerCalculationResult(PowerUnit unit)
        {
            this.Unit = unit;
        }
    }
}
