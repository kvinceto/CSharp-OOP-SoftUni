namespace CollectionHierarchy.Models
{
    using Interfaces;

    public class AddCollection : IAddCollection
    {
        private string[] collection;
        private int index;

        public AddCollection()
        {
            this.collection = new string[100];
            this.index = -1;
        }
        public int Add(string text)
        {
            this.index++;
            this.collection[this.index] = text;
            return this.index;
        }
    }
}
