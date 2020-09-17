using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;

namespace FAST_Framework
{
    public class ExcelUtil
    {

        public static List<Datacollection> dataCol = new List<Datacollection>();
        public static int numberOfRows = 0;
        public static int numberOfTests = 0;

        public static DataTable ExcelToDataTable(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTableCollection table = result.Tables;
                    DataTable resultTable = table["Sheet1"];

                    return resultTable;
                }
            }
        }

        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };

                    dataCol.Add(dtTable);
                }
            }

            numberOfRows = GetNumberOfRows();
            numberOfTests = GetNumberOfTests();

        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static int GetNumberOfRows()
        {
            int maxRow = 0;

            foreach (var dc in dataCol)
            {
                if (dc.rowNumber > maxRow)
                    maxRow = dc.rowNumber;
            }

            return maxRow;

        }

        public static int GetNumberOfTests()
        {

            for (int i = 1; i < dataCol.Count; i++)
            {
                if (!(dataCol[i].colValue.Contains("Test")))
                    return i-1;
            }

            return 0;

        }

        public static TestCase ReadTestCase(int testNumber)
        {
            string[] testValues = new string[numberOfRows];
            string testName = $"Test {testNumber}";

            for (int i = 1; i <= numberOfRows; i++)
            {
                testValues[i-1] = (ReadData(i, testName));
                //Console.WriteLine(testValues[i - 1]);
            }

            return new TestCase(testName, testValues);

        }

    }

    public class TestCase
    {
        public string testName;
        public string[] testValues;

        public TestCase(string testName, string[] testValues)
        {
            this.testName = testName;
            this.testValues = testValues;
        }        
    }

    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}
