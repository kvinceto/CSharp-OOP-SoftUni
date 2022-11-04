namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Enums;
    using Interfaces;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private IReadOnlyCollection<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps, HashSet<IMission> missions) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps}")
                .AppendLine($"Missions:");
            foreach (var m in missions)
            {
                sb.AppendLine("  " + m.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
