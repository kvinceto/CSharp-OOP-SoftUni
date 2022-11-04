namespace CollectionHierarchy.Models
{
    using Interfaces;

    public class MyList : IMyList
    {
        private string[] collection;
        private int index;

        public MyList()
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
            string item = this.collection[0];
            string[] arr = new string[100];
            for (int j = 1; j <= this.index; j++)
            {
               arr[j - 1] = this.collection[j];
            }
            this.collection = arr;
            this.index--;
            return item;
        }

        public int Used => this.index + 1;
    }
}
