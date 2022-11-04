namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Private { get; }
    }
}
