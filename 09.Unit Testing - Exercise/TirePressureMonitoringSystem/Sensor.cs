using System;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Sensor
    {
        const double offset = 16;
        readonly Random randomPressureSampleSimulator = new Random();

        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue = ReadPressureSample();

            return offset + pressureTelemetryValue;
        }

        private double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6 * this.randomPressureSampleSimulator.NextDouble() * this.randomPressureSampleSimulator.NextDouble();
        }
    }
}
