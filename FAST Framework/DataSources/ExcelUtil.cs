using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ExcelDataReader;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace FAST_Framework
{
    public class ExcelUtil
    {

        #region ReadAttributes
        public static List<Datacollection> dataCol = new List<Datacollection>();
        public static int numberOfRows = 0;
        public static int numberOfTests = 0;
        #endregion

        #region WriteAttributes
        private static ExcelPackage ExcelPkg = new ExcelPackage(new FileInfo(Config.XLPath));
        private static ExcelWorksheet WsSheet1 = ExcelPkg.Workbook.Worksheets[0];
        private static int[] CurrentCell = new int[2] { 0, 0 };
        #endregion

        #region ReadFromExcel

        /// <summary>
        /// Creates the datatable with the values on the excel file to read later.
        /// </summary>
        /// <param name="fileName">Full path to the excel file to read</param>
        /// <returns>Data table with the values of the excel file</returns>
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

        /// <summary>
        /// Calls ExcelToDataTable method to create the datatable and arranges the values by the column names for easier reading of the values. 
        /// Also sets the number of rows and tests.
        /// </summary>
        /// <param name="fileName">Full path to the excel file to read</param>
        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

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

        /// <summary>
        /// Reads the value of the row specified by rowNumber and of the column specified by columnName
        /// </summary>
        /// <param name="rowNumber">Number of the row to read the value from</param>
        /// <param name="columnName">Name of the column to read the value from</param>
        /// <returns>Value read of the specified row and column</returns>
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

        /// <summary>
        /// Reads all of the columns of the excel and returns the maximum row number between them.
        /// </summary>
        /// <returns>Maximum number of rows of all the tests on the excel file</returns>
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

        // <summary>
        /// Reads all of the data returned from the excel and returns the number of tests on it.
        /// </summary>
        /// <returns>Number of tests of the excel</returns>
        public static int GetNumberOfTests()
        {

            for (int i = 1; i < dataCol.Count; i++)
            {
                if (!(dataCol[i].colName.Contains("Test")))
                    return i-1;
            }

            return 0;

        }

        /// <summary>
        /// Reads each row of the specified test, and adds them to a string array, then creates a TestCase object with the test name and the values read.
        /// </summary>
        /// <param name="testNumber">Number of the test to read values from</param>
        /// <returns>TestCase object which contains the test name and all of its values</returns>
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

#endregion

        #region WriteToExcel

        /// <summary>
        /// Writes the value to the cell specified by cell coordinates on the excel file.
        /// </summary>
        /// <param name="value">Value to write to the cell</param>
        /// <param name="cell">Cell to write the value to, it takes the format { row number, column number }</param>
        /// <param name="fileName">File to save the modified excel to</param>
        /// <param name="cellStyle">Style of the cell to write. Takes an ExcelCellStyle object</param>
        public static void WriteToCell(string value, int[] cell, string fileName, Config.ExcelCellStyle cellStyle)
        {
            using (ExcelRange Rng = WsSheet1.Cells[cell[0], cell[1]])
            {
                Rng.Value = value;
                Rng.Style.Font.Size = cellStyle.Size;
                Rng.Style.Font.Bold = cellStyle.Bold;
                Rng.Style.Font.Italic = cellStyle.Italic;
                if (!cellStyle.BgColor.IsEmpty)
                {
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(cellStyle.BgColor);
                }
                else
                    Rng.Style.Fill.PatternType = ExcelFillStyle.None;
                if (!cellStyle.FontColor.IsEmpty)
                    Rng.Style.Font.Color.SetColor(cellStyle.FontColor);
            }
            WsSheet1.Protection.IsProtected = false;
            WsSheet1.Protection.AllowSelectLockedCells = false;
            //ExcelPkg.SaveAs(new FileInfo($@"..\..\..\Output\{fileName}"));
            ExcelPkg.SaveAs(new FileInfo($@"..\..\..\{fileName}"));
        }

        /// <summary>
        /// Writes the value to the cell specified by a string with the cell name on the excel file.
        /// </summary>
        /// <param name="value">Value to write to the cell</param>
        /// <param name="cell">Cell to write the value to, it takes the format "ColumnLetterRowNumber", "A1" for example</param>
        /// <param name="fileName">File to save the modified excel to</param>
        /// <param name="cellStyle">Style of the cell to write. Takes an ExcelCellStyle object</param>
        public static void WriteToCell(string value, string cell, string fileName, Config.ExcelCellStyle cellStyle)
        {
            using (ExcelRange Rng = WsSheet1.Cells[cell])
            {
                
                Rng.Value = value;
                Rng.Style.Font.Size = cellStyle.Size;
                Rng.Style.Font.Bold = cellStyle.Bold;
                Rng.Style.Font.Italic = cellStyle.Italic;
                if (!cellStyle.BgColor.IsEmpty)
                {
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(cellStyle.BgColor);
                }
                else
                    Rng.Style.Fill.PatternType = ExcelFillStyle.None;
                if (!cellStyle.FontColor.IsEmpty)
                    Rng.Style.Font.Color.SetColor(cellStyle.FontColor);
            }
            WsSheet1.Protection.IsProtected = false;
            WsSheet1.Protection.AllowSelectLockedCells = false;
            ExcelPkg.SaveAs(new FileInfo($@"..\..\..\Output\{fileName}"));
        }

        /// <summary>
        /// Reads the specified cell of the excel by cell coordinates
        /// </summary>
        /// <param name="cell">Cell to write the value to, it takes the format { row number, column number }</param>
        /// <returns></returns>
        public static string ReadCell(int[] cell)
        {
            return WsSheet1.Cells[cell[0], cell[1]].Value.ToString();
        }

        /// <summary>
        /// Reads the specified cell of the excel by a string with the cell name
        /// </summary>
        /// <param name="cell">Cell to write the value to, it takes the format "ColumnLetterRowNumber", "A1" for example</param>
        /// <returns></returns>
        public static string ReadCell(string cell)
        {
            return WsSheet1.Cells[cell].Value.ToString();
        }

        /// <summary>
        /// Automatically writes the values to the test in order from the first output position or the one following the current one.
        /// </summary>
        /// <param name="values">Array of strings with the values to write to the excel</param>
        /// <param name="testNumber">Number of the test to write the values to</param>
        /// <param name="fileName">Name of the file to save the modified excel as</param>
        /// <param name="cellStyle">Style of the cell to write. Takes an ExcelCellStyle object</param>
        public static void WriteValuesToTest(string[] values, int testNumber, string fileName, Config.ExcelCellStyle cellStyle)
        {
            foreach (var value in values)
            {
                WriteToCell(value, GetNextPositionToWriteToOfTest(testNumber), fileName, cellStyle);
            }   
        }

        /// <summary>
        /// Finds the next position to write output to on the test
        /// </summary>
        /// <param name="testNumber">Number of the test to retrieve the position for</param>
        /// <returns>Cell to write the next value to, it takes the format { row number, column number }</returns>
        public static int[] GetNextPositionToWriteToOfTest(int testNumber)
        {
            if (CurrentCell[1] != testNumber+1)
                CurrentCell[0] = numberOfRows + 3;
            else
                CurrentCell[0] += 1;

            CurrentCell[1] = testNumber+1;

            return CurrentCell;

        }

        #endregion

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
