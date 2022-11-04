namespace ExplicitInterfaces.Core
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Models;
    using ExplicitInterfaces.IO.Interfaces;
    using ExplicitInterfaces.Models.Interfaces;

    internal class Engine : IEngine
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
            List<Citizen> citizens = new List<Citizen>();
            GetCitizens(citizens);

            Print(citizens);
        }

        private void Print(List<Citizen> citizens)
        {
            foreach (var citizen in citizens)
            {
                IPerson person = citizen as IPerson;
                this.writer.WriteLine(person.GetName());
                IResident resident = citizen as IResident;
                this.writer.WriteLine(resident.GetName());
            }
        }

        private void GetCitizens(List<Citizen> citizens)
        {
            string cmd;
            while ((cmd = this.reader.ReadLine()) != "End")
            {
                string[] citizenInfo = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);
                Citizen citizen = new Citizen(name, country, age);
                citizens.Add(citizen);
            }
        }
    }
}
