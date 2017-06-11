using System;
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
        private string path = "../../ExportedFiles/pdfexports.pdf";

        public PDFReporter() { }

        public void ReportFile(string table)
        {
            switch (table.ToLower())
            {
                case "workouts":
                    Console.WriteLine("Loading PDF Report");
                    DataTable workouts = fillDataTable(table);
                    ExportDataTableToPdf(workouts, path);
                    System.Diagnostics.Process.Start(path);
                    Console.WriteLine("go to ExportedFiles and check!");
                    break;
                default:
                    Console.WriteLine("The table is NOT FOUND!");
                    return;
            }
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
            Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, Color.WHITE);
            for (int i = 0; i < dbTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dbTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
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

        public DataTable fillDataTable(string table)
        {
            DataTable filledTable = new DataTable();
            string query = "SELECT * FROM " + table;
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

           using (SqlConnection con = new SqlConnection(connString))
           {

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            con.Close();
                            filledTable = dt;
                        
                    } // reader closed and disposed up here

                } // command disposed here

            } //connection closed and disposed here

            //SqlConnection sqlConn = new SqlConnection(connString);
            //SqlCommand cmd = new SqlCommand(query, sqlConn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //sqlConn.Close();
            //return dt;
            return filledTable;
        }
    }
}
