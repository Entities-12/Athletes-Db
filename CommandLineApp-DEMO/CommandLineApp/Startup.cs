using CommandLineApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace CommandLineApp
{
    public class Startup
    {
        public static void Main()
        {
            // This is bad code PLEASE BE PATIENT.

            using (var context = new GymDbContext())
            {
                context.Database.CreateIfNotExists();

                var app = new App();

                app.Run();
            }
        }
    }
}
