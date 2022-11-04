namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;

    internal interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
