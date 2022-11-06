namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Models;
    using WildFarm.IO.Interfaces;
    using WildFarm.Models.Interfaces;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string[] animalData = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (animalData[0] == "End") break;

                string[] foodData = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal = CreateAnimal(animalData);
                Food food = CreateFood(foodData);

                writer.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Feed(food);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }

        private static Animal CreateAnimal(string[] animalData)
        {
            Animal animal = null;

            switch (animalData[0])
            {
                case "Hen":
                    animal = new Hen(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3]), 0);
                    break;
                case "Owl":
                    animal = new Owl(animalData[1], double.Parse(animalData[2]), 0, double.Parse(animalData[3]));
                    break;
                case "Mouse":
                    animal = new Mouse(animalData[1], double.Parse(animalData[2]), animalData[3], 0);
                    break;
                case "Dog":
                    animal = new Dog(animalData[1], double.Parse(animalData[2]), animalData[3], 0);
                    break;
                case "Tiger":
                    animal = new Tiger(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4], 0);
                    break;
                case "Cat":
                    animal = new Cat(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4], 0);
                    break;
            }

            return animal;
        }

        private Food CreateFood(string[] foodData)
        {
            Food food = null;
            switch (foodData[0])
            {
                case "Vegetable":
                    food = new Vegetable(int.Parse(foodData[1])); break;
                case "Fruit":
                    food = new Fruit(int.Parse(foodData[1])); break;
                case "Meat":
                    food = new Meat(int.Parse(foodData[1])); break;
                case "Seeds":
                    food = new Seeds(int.Parse(foodData[1])); break;
            }
            return food;
        }
    }
}
