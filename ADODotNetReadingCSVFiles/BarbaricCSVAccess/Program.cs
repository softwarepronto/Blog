using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbaricCSVAccess
{
    class Program
    {
        private const string _csvFilename = "AdventureWorks.Person.Person.csv";

        private static string GetCSVFilename()
        {
            string executableFilename = Environment.GetCommandLineArgs()[0];
            string executablePath = Path.GetDirectoryName(executableFilename);
            string csvFilename = Path.Combine(executablePath, _csvFilename);

            return csvFilename;
        }

        private static DataTable ReadCSVFile()
        {
            string[] rows = File.ReadAllLines(GetCSVFilename());
            string[] columnNames = null;
            DataTable table = new DataTable();

            if (rows.Length == 0)
            {
                return table; // error empty CSV file
            }

            columnNames = rows[0].Split(',');
            foreach (string columnName in columnNames)
            {
                table.Columns.Add(columnName);
            }

            object[] rowValues = new object[columnNames.Length];

            // start from 1 b/c rowindex=0 is the header row of column names
            for (int rowIndex = 1; rowIndex < rows.Length; rowIndex++)
            {
                string rowLine = rows[rowIndex];
                // flaw in code -- any string containing a column will generate an extra column
                string[] columnValues = rowLine.Split(',');

                if (columnNames.Length != columnValues.Length)
                {
                    throw new Exception("Split burned you because there is a comma in the data.");
                }

                for (int columnIndex = 0; columnIndex < columnValues.Length; columnIndex++)
                {
                    rowValues[columnIndex] = columnValues[columnIndex];
                }

                table.Rows.Add(rowValues);
            }

            return table; 
        }

        static void Main(string[] args)
        {
            ReadCSVFile();
        }
    }
}
