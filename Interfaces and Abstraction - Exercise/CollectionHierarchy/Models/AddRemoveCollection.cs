namespace CollectionHierarchy.Models
{
    using Interfaces;

    public class AddRemoveCollection : IAddRemoveCollection
    {
        private string[] collection;
        private int index;

        public AddRemoveCollection()
        {
            this.collection = new string[100];
            this.index = -1;
        }

        public int Add(string text)
        {
            string[] arr = new string[100];
            arr[0] = text;
            for (int i = 1; i <= index + 2; i++)
            {
                arr[i] = this.collection[i - 1];
            }
            this.index++;
            this.collection = arr;
            return 0;
        }

        public string Remove()
        {
            this.index--;
            return this.collection[this.index + 1];
        }
    }
}
