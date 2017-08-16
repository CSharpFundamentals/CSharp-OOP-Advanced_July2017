namespace RecyclingStation.BusinessLayer.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using RecyclingStation.BusinessLayer.Contracts.Factories;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class WasteFactory : IWasteFactory
    {
        private const string GarbageSuffix = "Garbage";

        public IWaste Create(string name, double weight, double volumePerKg, string type)
        {
            string fullTypeName = type + GarbageSuffix;

            Type typeOfGarbageToActivate = Assembly.GetExecutingAssembly()
                                                .GetTypes().FirstOrDefault(t => t.Name.Equals(fullTypeName, StringComparison.OrdinalIgnoreCase));

            IWaste waste = (IWaste)Activator.CreateInstance(typeOfGarbageToActivate, name, weight, volumePerKg);

            return waste;
        }
    }
}
