namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Enums;
    using Interfaces;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private IReadOnlyCollection<IRepair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, HashSet<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps}")
                .AppendLine($"Repairs:");
            foreach (var pair in repairs)
            {
                sb.AppendLine("  " + pair.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
