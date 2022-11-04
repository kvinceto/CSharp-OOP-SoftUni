namespace MilitaryElite.Models.Interfaces
{
    using Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
