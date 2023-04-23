using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerSupply;

namespace PowerSupplyTest
{
    [TestClass]
    public class PowerSupplyTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            PowerCalculator calc = new PowerCalculator();

            List<PowerUnit> powerUnitList = new List<PowerUnit>();
            powerUnitList.Add(new PowerUnit("UA4", 6.5));
            powerUnitList.Add(new PowerUnit("UA5", 12));
            powerUnitList.Add(new PowerUnit("UA6", 18));

            List<DeviceInfo> deviceList = new List<DeviceInfo>();
            deviceList.Add(new DeviceInfo("POE1", 1.2));
            deviceList.Add(new DeviceInfo("Camera1", 4.2));
            deviceList.Add(new DeviceInfo("Light1", 4.2));
            deviceList.Add(new DeviceInfo("本格調光", 2.2));
            deviceList.Add(new DeviceInfo("Light2", 15));
            deviceList.Add(new DeviceInfo("Light3", 10.5));

            var result = calc.Calculate(deviceList, powerUnitList);
            double total = 0;

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Unit.Name}, {item.Unit.Power}-------------");
                foreach (var device in item)
                {
                    total += device.Power;
                    Console.WriteLine($"{device.Name}, {device.Power}");

                }
                
                Assert.AreEqual(true, item.Unit.Power >= item.Sum(d=>d.Power));
                
            }

            Assert.AreEqual(true, Math.Abs(deviceList.Sum(d=>d.Power) - total) < 0.0001);


        }
    }
}
