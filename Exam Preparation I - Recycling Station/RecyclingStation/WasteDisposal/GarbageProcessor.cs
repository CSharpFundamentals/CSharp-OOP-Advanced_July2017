namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageProcessor : IGarbageProcessor
    {
        private IStrategyHolder strategyHolder;

        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public IStrategyHolder StrategyHolder
        {
            get
            {
                return this.strategyHolder;
            }

            private set
            {
                this.strategyHolder = value;
            }
        }
      
        public IProcessingData ProcessWaste(IWaste garbage)
        {
            Type type = garbage.GetType();
            DisposableAttribute disposalAttribute = (DisposableAttribute)type.GetCustomAttributes(typeof(DisposableAttribute), true).FirstOrDefault();
            if (disposalAttribute == null)
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            Type typeOfAttribute = disposalAttribute.GetType();
            if (!this.StrategyHolder.GetDisposalStrategies.ContainsKey(typeOfAttribute))
            {
                Type typeOfCorrespondingStrategy = disposalAttribute.CorrespondingStrategyType;

                IGarbageDisposalStrategy activatedStrategy = (IGarbageDisposalStrategy)Activator.CreateInstance(typeOfCorrespondingStrategy);

                this.StrategyHolder.AddStrategy(typeOfAttribute, activatedStrategy);
            }

            IGarbageDisposalStrategy currentStrategy = this.StrategyHolder.GetDisposalStrategies[typeOfAttribute];

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}
