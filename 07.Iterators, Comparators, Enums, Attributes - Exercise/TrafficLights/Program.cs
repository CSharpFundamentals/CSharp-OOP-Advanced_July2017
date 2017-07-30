namespace TrafficLights
{
    using System;
    using System.Collections.Generic;
    using Enums;

    public class Program
    {
        public static void Main()
        {
            List<TrafficLight> allTraficLights = new List<TrafficLight>();

            string[] inputSignal = Console.ReadLine().Split();
            int stateChangeCount = int.Parse(Console.ReadLine());

            foreach (var signal in inputSignal)
            {
                LightColor initialColorState = (LightColor)Enum.Parse(typeof(LightColor), signal);
                allTraficLights.Add(new TrafficLight(initialColorState));
            }

            for (int i = 0; i < stateChangeCount; i++)
            {
                foreach (var trafficLight in allTraficLights)
                {
                    trafficLight.ChangeState();
                }

                Console.WriteLine(String.Join(" ", allTraficLights));
            }
        }
    }
}
