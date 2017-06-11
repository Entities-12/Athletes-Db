//using System;
//using System.Data;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
//using System.IO;
//using Gym.DatabaseAndContext;

//namespace Gym.Exporters
//{
//    public class PDFExporter : IExporter 
//    {
//        private string path = "../../ExportedFiles/pdfexports.pdf";

//        public PDFExporter() { }

//        public void ExportFile(IDatabase db, string table)
//        {
//            switch (table.ToLower())
//            {
//                case "export":
//                    Console.WriteLine("Export workouts");
//                    break;
//                default:
//                    Console.WriteLine("The table is NOT FOUND!");
//                    return;

//            }
//        }

//        private string GetWorkouts(IDatabase db)
//        {
//            var workouts = db.GetInstance().Workouts;

//            return workouts.ToString();
//        }


//    }
//}
