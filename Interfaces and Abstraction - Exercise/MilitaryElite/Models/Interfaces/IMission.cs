namespace MilitaryElite.Models.Interfaces
{
    using Enums;

    public interface IMission
    {
        public string CodeName { get; }
        public State State { get; }

        public void CompleteMission();
    }
}
