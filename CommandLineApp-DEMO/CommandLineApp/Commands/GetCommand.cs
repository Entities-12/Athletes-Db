using CommandLineApp.Commands.Contracts;
using CommandLineApp.Models;
using CommandLineApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace CommandLineApp.Commands
{
    public class GetCommand : ICommand
    {
        public GetCommand(IList<string> command)
        {
            this.Command = command;
            this.Database = new GymDbContext();
        }

        public IList<string> Command { get; private set; }
        public GymDbContext Database { get; private set; }

        public void Execute()
        {
            var table = this.Command[1];


            Console.WriteLine("In progress!");

            switch (table.ToLower())
            {
                case "athletes":

                    IQueryable<IPerson> athletes = this.Database.Athletes
                                                .Where(at => at.FirstName == at.FirstName);

                    IList<IPerson> athList = athletes.ToList();


                    this.DisplayInfo(athList);

                    break;
                case "companies":
                    var companies = this.Database.Companies
                                               .Where(cmp => cmp.CompanyName == cmp.CompanyName)
                                               .ToList();

                    this.CheckIfHaveAny(companies);

                    this.DisplayInfo(companies);

                    break;
                case "trainers":
                    var trainers = this.Database.Trainers
                                               .Where(tr => tr.FirstName == tr.FirstName)
                                               .ToList();

                    this.CheckIfHaveAny(trainers);

                    this.DisplayInfo(trainers);

                    break;

            }
        }

        public void DisplayInfo(IList<IPerson> athletes)
        {
            for (int i = 0; i < athletes.Count; i += 1)
            {
                Console.WriteLine(athletes[i].FirstName);
            }



        //    athletes.ForEach(at =>
         //           Console.WriteLine("ID: " + at + "| " + "FirstName: " + at.FirstName + "| " + "LastName: " + at.LastName));
        }

        public void DisplayInfo(List<Company> companies)
        {
            companies.ForEach(cmpn =>
                   Console.WriteLine("ID: " + cmpn.Id + "| " + "CompanyName: " + cmpn.CompanyName + "| " + "CompanyNumber: " + cmpn.CompanyNumber));
        }

        public void DisplayInfo(List<Trainer> trainers)
        {
            trainers.ForEach(tr =>
                     Console.WriteLine("ID: " + tr.Id + "| " + "CompanyName: " + tr.FirstName + "| " + "CompanyNumber: " + tr.LastName));

        }

        private void CheckIfHaveAny(List<Trainer> info)
        {
            if (info.Count == 0)
            {
                Console.WriteLine("No trainers!");
            }
        }

        private void CheckIfHaveAny(List<Company> info)
        {
            if (info.Count == 0)
            {
                Console.WriteLine("No companies!");
            }
        }

    }
}
