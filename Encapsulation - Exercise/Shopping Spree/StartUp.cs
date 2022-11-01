using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            try
            {
                foreach (var personInfo in peopleInput)
                {
                    string[] data = personInfo.Split('=');
                    Person person = new Person(data[0], decimal.Parse(data[1]));
                    people.Add(person.Name, person);
                }

                foreach (var productInfo in productsInput)
                {
                    string[] data = productInfo.Split('=');
                    Product product = new Product(data[0], decimal.Parse(data[1]));
                    products.Add(product.Name, product);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = cmd[0];
                string product = cmd[1];

                if (people.ContainsKey(name) && products.ContainsKey(product))
                {
                    if (people[name].Money >= products[product].Cost)
                    {
                        people[name].Money -= products[product].Cost;
                        people[name].Products.Add(products[product]);
                        Console.WriteLine($"{name} bought {product}");
                    }
                    else
                    {
                        Console.WriteLine($"{name} can't afford {product}");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var person in people.Values)
            {
                List<string> list = new List<string>();
                foreach (var product in person.Products)
                {
                    list.Add(product.Name);
                }

                Console.WriteLine(list.Count == 0
                    ? $"{person.Name} - Nothing bought"
                    : $"{person.Name} - {string.Join(", ", list)}");
            }
        }
    }
}
