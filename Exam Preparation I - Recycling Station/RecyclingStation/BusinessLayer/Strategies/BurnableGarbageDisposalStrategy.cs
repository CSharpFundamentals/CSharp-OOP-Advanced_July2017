namespace RecyclingStation.BusinessLayer.Strategies
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            return 0;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            double totalVolume = garbage.CalculateWasteTotalVolume();

            double energyProduce = totalVolume;
            double energyUsed = totalVolume * 0.2;

            return energyProduce - energyUsed;
        }
    }
}
