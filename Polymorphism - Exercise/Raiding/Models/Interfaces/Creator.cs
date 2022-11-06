namespace Raiding.Models.Interfaces
{
    public abstract class Creator
    {
        public abstract BaseHero CreateHero(string type, string name);
    }
}
