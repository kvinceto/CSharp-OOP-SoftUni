namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private IReadOnlyCollection<IPrivate> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary,
            HashSet<IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Private => privates;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"Privates:");
            foreach (IPrivate priv in privates)
            {
                sb.AppendLine("  " + priv.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
