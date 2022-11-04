namespace CollectionHierarchy.Core
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Models;
    using CollectionHierarchy.IO.Interfaces;
    using CollectionHierarchy.Models.Interfaces;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IAddCollection add;
        private IAddRemoveCollection addRemove;
        private IMyList myList;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.add = new AddCollection();
            this.addRemove = new AddRemoveCollection();
            this.myList = new MyList();
        }

        public void Run()
        {
            List<string> outputLines = new List<string>();

            string[] itemsToAdd = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int numberOfItemsToRemove = int.Parse(reader.ReadLine());

            AddItemsToAddCollection(itemsToAdd, outputLines);

            AddItemsToAddRemoveCollection(itemsToAdd, outputLines);

            AddItemsToMyListCollection(itemsToAdd, outputLines);

            RemoveItemsFromAddRemoveCollection(numberOfItemsToRemove, outputLines);

            RemoveItemsFromMyListCollection(numberOfItemsToRemove, outputLines);

            Print(outputLines);
        }

        private void Print(List<string> outputLines)
        {
            foreach (var line in outputLines)
            {
                this.writer.WriteLine(line);
            }
        }

        private void RemoveItemsFromMyListCollection(int numberOfItemsToRemove,
            List<string> outputLines)
        {
            List<string> removedItems = new List<string>();
            for (int i = 0; i < numberOfItemsToRemove; i++)
            {
                string item = this.myList.Remove();
                removedItems.Add(item);
            }

            outputLines.Add($"{string.Join(" ", removedItems)}");
        }

        private void RemoveItemsFromAddRemoveCollection(int numberOfItemsToRemove,
            List<string> outputLines)
        {
            List<string> removedItems = new List<string>();
            for (int i = 0; i < numberOfItemsToRemove; i++)
            {
                string item = this.addRemove.Remove();
                removedItems.Add(item);
            }

            outputLines.Add($"{string.Join(" ", removedItems)}");
        }

        private void AddItemsToMyListCollection(string[] itemsToAdd, List<string> outputLines)
        {
            List<int> indexes = new List<int>();
            foreach (string item in itemsToAdd)
            {
                int index = this.myList.Add(item);
                indexes.Add(index);
            }

            outputLines.Add($"{string.Join(" ", indexes)}");
        }

        private void AddItemsToAddRemoveCollection(string[] itemsToAdd, List<string> outputLines)
        {
            List<int> indexes = new List<int>();
            foreach (string item in itemsToAdd)
            {
                int index = this.addRemove.Add(item);
                indexes.Add(index);
            }

            outputLines.Add($"{string.Join(" ", indexes)}");
        }

        private void AddItemsToAddCollection(string[] itemsToAdd, List<string> outputLines)
        {
            List<int> indexes = new List<int>();
            foreach (var item in itemsToAdd)
            {
                int index = this.add.Add(item);
                indexes.Add(index);
            }

            outputLines.Add($"{string.Join(" ", indexes)}");
        }
    }
}
