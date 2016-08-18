using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CVSToDataTableUsingADODotNet4._0
{
    class Program
    {
        private const string _csvFilename = "AdventureWorksPersonPerson.csv";

        public static DataTable GetDataTableFromCSV(string folderPath, string csvFileName)
        {
            DataTable table = new DataTable();
            string connectionText = String.Format(
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';Extended Properties='text;HDR=Yes';",
                folderPath);
            string commandText = String.Format("SELECT * FROM [{0}]", csvFileName);

            using (OleDbConnection connection = new OleDbConnection(connectionText))
            {
                connection.Open();
                using (OleDbDataAdapter command = new OleDbDataAdapter(commandText, connection))
                {
                    command.Fill(table);
                    command.Dispose();
                }

                connection.Close();
            }

            return table;
        }

        static void Main(string[] args)
        {
            DataTable table;
            string executableFilename = Environment.GetCommandLineArgs()[0];
            string executablePath = Path.GetDirectoryName(executableFilename);

            try
            {
                table = GetDataTableFromCSV(executablePath, _csvFilename);
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
