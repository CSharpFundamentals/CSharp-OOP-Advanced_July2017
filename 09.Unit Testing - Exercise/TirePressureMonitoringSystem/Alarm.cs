namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        readonly Sensor sensor = new Sensor();

        bool alarmOn = false;

        public void Check()
        {
            double psiPressureValue = this.sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                this.alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return this.alarmOn; }
        }

    }
}
