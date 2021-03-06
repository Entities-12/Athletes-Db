﻿using System;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Gym.DatabaseAndContext;
using Gym.Context;
using Gym.Models;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Gym.Exporters
{
    public class PDFReporter
    {
        //private string path = @"../../ExportedFiles/pdfexport.pdf";
        private string path = @"D:\test.pdf";

        public PDFReporter() { }

        public void ReportFile()
        {
            Console.WriteLine("Loading PDF Report");
            DataTable dtbl = fillDataTable();
            ExportDataTableToPdf(dtbl, path);
            System.Diagnostics.Process.Start(path);
            Console.WriteLine("go to ExportedFiles and check!");

        }

        void ExportDataTableToPdf(DataTable dbTable, String pdfPath)
        {
            System.IO.FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Write the table
            PdfPTable pdfTable = new PdfPTable(dbTable.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            for (int i = 0; i < dbTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();

                cell.AddElement(new Chunk(dbTable.Columns[i].ColumnName.ToUpper()));
                pdfTable.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dbTable.Rows.Count; i++)
            {
                for (int j = 0; j < dbTable.Columns.Count; j++)
                {
                    pdfTable.AddCell(dbTable.Rows[i][j].ToString());
                }
            }

            document.Add(pdfTable);
            document.Close();
            writer.Close();
            fs.Close();
        }

        public DataTable fillDataTable()

        {
            DataTable filledTable = new DataTable();

            using (var context = new GymDbContext())
            {
                var profileDetails = context.Athletes.ToList();
                var id = profileDetails.Select(a => a.Id).ToList();
                var firstName = profileDetails.Select(a => a.FirstName).ToList();
                var lastName = profileDetails.Select(a => a.LastName).ToList();
                var age = profileDetails.Select(a => a.Age).ToList();

                filledTable.Columns.Add("id");
                filledTable.Columns.Add("First Name");
                filledTable.Columns.Add("Last Name");
                filledTable.Columns.Add("Age");

                for (var i = 0; i < id.Count; i++)
                {
                    filledTable.Rows.Add(id[i], firstName[i], lastName[i], age[i]);

                    filledTable.Rows.Add(id[i], firstName[i], lastName[i], age[i]);      
                }

            }

            return filledTable;
        }
    }
}
