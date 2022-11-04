namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using MilitaryElite.IO.Interfaces;
    using Models;
    using Models.Enums;
    using MilitaryElite.Models.Interfaces;

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
            var soldiers = CreateSoldiers();

            Print(soldiers);
        }

        private HashSet<ISoldier> CreateSoldiers()
        {
            HashSet<ISoldier> soldiers = new HashSet<ISoldier>();
            string input = String.Empty;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] soldierInfo = input.Split(' ');
                string soldierType = soldierInfo[0];
                string id = soldierInfo[1];
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];

                switch (soldierType)
                {
                    case "Private":
                        CreatePrivate(soldierInfo, id, firstName, lastName, soldiers);
                        break;
                    case "LieutenantGeneral":
                        CreateLieutenantGeneral(soldierInfo, soldiers, id, firstName, lastName);
                        break;
                    case "Engineer":
                        CreateEngineer(soldierInfo, id, firstName, lastName, soldiers);
                        break;
                    case "Commando":
                        CreateCommando(soldierInfo, id, firstName, lastName, soldiers);
                        break;
                    case "Spy":
                        CreateSpy(soldierInfo, id, firstName, lastName, soldiers);
                        break;
                }
            }

            return soldiers;
        }

        private void Print(HashSet<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }

        private static void CreateSpy(string[] soldierInfo, string id, string firstName, string lastName, HashSet<ISoldier> soldiers)
        {
            int codeNumber = int.Parse(soldierInfo[4]);
            Spy spy = new Spy(id, firstName, lastName, codeNumber);
            soldiers.Add(spy);
        }

        private static void CreateCommando(string[] soldierInfo, string id, string firstName, string lastName, HashSet<ISoldier> soldiers)
        {
            decimal salary = decimal.Parse(soldierInfo[4]);
            bool valid = Enum.TryParse(soldierInfo[5], false, out Corps corps);
            if (!valid) return;
            string[] missionsInfo = soldierInfo.Skip(6).ToArray();
            HashSet<IMission> missions = new HashSet<IMission>();
            for (int i = 0; i < missionsInfo.Length; i += 2)
            {
                string codeName = missionsInfo[i];
                bool validState = Enum.TryParse(missionsInfo[i + 1], false, out State state);
                if (!validState) continue;
                IMission m = new Mission(codeName, state);
                missions.Add(m);
            }

            Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
            soldiers.Add(commando);
        }

        private static void CreateEngineer(string[] soldierInfo, string id, string firstName, string lastName, HashSet<ISoldier> soldiers)
        {
            decimal salary = decimal.Parse(soldierInfo[4]);
            bool valid = Enum.TryParse(soldierInfo[5], false, out Corps corps);
            if (!valid) return;
            string[] repairsInfo = soldierInfo.Skip(6).ToArray();
            HashSet<IRepair> repairs = new HashSet<IRepair>();
            for (int i = 0; i < repairsInfo.Length; i += 2)
            {
                Repair r = new Repair(repairsInfo[i], int.Parse(repairsInfo[i + 1]));
                repairs.Add(r);
            }

            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
            soldiers.Add(engineer);
        }

        private static void CreateLieutenantGeneral(string[] soldierInfo, HashSet<ISoldier> soldiers, string id, string firstName, string lastName)
        {
            decimal salary = decimal.Parse(soldierInfo[4]);
            string[] ids = soldierInfo.Skip(5).ToArray();
            HashSet<IPrivate> list = new HashSet<IPrivate>();
            foreach (var item in ids)
            {
                IPrivate p = (IPrivate)soldiers.First(s => s.Id == item);
                list.Add(p);
            }

            LieutenantGeneral lieutenantGeneral =
                new LieutenantGeneral(id, firstName, lastName, salary, list);
            soldiers.Add(lieutenantGeneral);
        }

        private static void CreatePrivate(string[] soldierInfo, string id, string firstName, string lastName, HashSet<ISoldier> soldiers)
        {
            decimal salary = decimal.Parse(soldierInfo[4]);
            Private p = new Private(id, firstName, lastName, salary);
            soldiers.Add(p);
        }
    }
}
