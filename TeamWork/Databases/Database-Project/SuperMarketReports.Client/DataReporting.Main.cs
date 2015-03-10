using System;
using System.Data.Entity;
using System.Linq;
using Supermarket.Model;
using Supermarket.Model.Migrations;

namespace SuperMarketReports.Client
{
    class DataReporting_Main
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Console.WriteLine("Second try...");
            Console.WriteLine("\r\n\r\n");

            Console.ForegroundColor = ConsoleColor.Green;

            Database.SetInitializer(new CreateDatabaseIfNotExists<SupermarketContext>());
            Console.WriteLine("Migrating database from MySQL to SQL Server...");
            DbMigrator.MigrateFromMySqlToMSSql();
            Console.WriteLine("Database migration to SQL Server completed successfully.");
            Console.WriteLine();

            Console.WriteLine("Migrating reports from ZIP archives to SQL Server...");
            ReportsMigrator reportsMigrator = new ReportsMigrator(@"C:\Sample-Sales-Reports\Sample-Sales-Reports.zip");
            reportsMigrator.ExtractReports();
            reportsMigrator.GetAllReports();
            reportsMigrator.FillTable();
            reportsMigrator.DeleteReports();
            Console.WriteLine("Excel report migration completed successfully.");
            Console.WriteLine();

            Console.WriteLine("Creating PDF report...");
            PdfReportCreator.CreatePdf();
            Console.WriteLine("PDF report created successfully.");
            Console.WriteLine();

            Console.WriteLine("Generating XML report by vendors...");
            XmlReportCreator xmlReportCreator = new XmlReportCreator();
            xmlReportCreator.GenerateXmlFileReportByVendors();
            Console.WriteLine("XML report by vendors created successfully.");
            Console.WriteLine();

            Console.WriteLine("Creating MongoDB report by product Id...");
            ProductReportCreator reportCreator = new ProductReportCreator();
            reportCreator.CreateReportByProductId();
            Console.WriteLine("MongoDB report by product Id created successfully.");
            Console.WriteLine();

            Console.WriteLine("Loading XML expenses report to MongoDB and SQL Server...");
            VendorLoader vendorLoader = new VendorLoader();
            vendorLoader.ParseXml();
            Console.WriteLine("Loading XML expenses report completed successfully.");
            Console.WriteLine();

            //Console.WriteLine("Creating total expenses report by vendors...");
            //VendorsTotalReportCreator totalReportCreator = new VendorsTotalReportCreator();
            //totalReportCreator.CreateExcel();
            //totalReportCreator.ReadReportsFromMongo();
            //Console.WriteLine("Total expenses report created successfully.");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n\r\n");
            Console.WriteLine("12 points maybe?");

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
