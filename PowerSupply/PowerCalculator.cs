using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSupply
{
    public class PowerCalculator
    {
        public List<PowerCalculationResult> Calculate(List<DeviceInfo> deviceList, List<PowerUnit> powerUnitList)
        {
            var resultList = new List<PowerCalculationResult>();
            var sortedPowerUnitList = powerUnitList.OrderBy(p => p.Power).ToList();
            var sortedDeviceList = deviceList.OrderByDescending(d => d.Power).ToList();

            do
            {
                (PowerUnit powerUnit, List<DeviceInfo> dList) = Assign(sortedDeviceList, sortedPowerUnitList);
                Debug.Assert(0 < dList.Count);
                var result = new PowerCalculationResult(powerUnit);
                result.AddRange(dList);
                resultList.Add(result);
            } while (0 < sortedDeviceList.Count);

            return resultList;
        }

        private (PowerUnit, List<DeviceInfo>) Assign(List<DeviceInfo> sortedDeviceList, List<PowerUnit> sortedPowerUnitList)
        {
            var resultDeviceList = new List<DeviceInfo>();
            
            double totalPower = sortedDeviceList.Sum(d => d.Power);
            //まずは一台でpowerが収まるか調べる
            var powerUnit = sortedPowerUnitList.FirstOrDefault(p => totalPower <= p.Power);
            if (powerUnit == null)
            {
                //一台で収まらないなら最も容量が大きいものにできるだけつなぐ
                powerUnit = sortedPowerUnitList.Last();
            }
              
            double remainPower = powerUnit.Power;
            
            while(true)
            {
                var deviceInfo = sortedDeviceList.FirstOrDefault(d => d.Power <= remainPower);
                if (deviceInfo == null) break;

                remainPower -= deviceInfo.Power;
                resultDeviceList.Add(deviceInfo);
                sortedDeviceList.Remove(deviceInfo);
                if (sortedDeviceList.Count == 0) break;
            }

            return (powerUnit, resultDeviceList);
            
        }
        
    }//class
}
