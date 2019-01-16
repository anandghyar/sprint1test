using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MRA_UI_RegressionTests.Util
{
    class DataPool
    {
        //<summary>
        //This method will convert CSV to DataTable
        //</summary>
        //<param name="strFilePath">strFilePath holds string value</param>
        //<returns>
        //This method returns a DataTable
        //</returns> 
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                        Debug.WriteLine("dr value is " + dr[i]);

                    }
                    dt.Rows.Add(dr);
                    Debug.WriteLine("dt value is " + dt);

                }

            }
            return dt;
        }
        public class DataCollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }

        }

        //<summary>
        //This method will store data in List of DataCollection
        //</summary>
        //<param name="filename">filename holds string value</param>
        //<returns>
        //This method returns void
        //</returns> 
        static List<DataCollection> dataCol = new List<DataCollection>();
        public static void PopulateInCollection(string filename)
        {
            try
            {
                string filepath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                DataTable table = ConvertCSVtoDataTable(filepath + "\\TestData\\" + filename);
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        DataCollection dtTable = new DataCollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };

                        dataCol.Add(dtTable);
                        Debug.WriteLine("dr value is " + dataCol);

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
        }

        //<summary>
        //This method will used to read data from the csv file based on Row Number and Column Name
        //</summary>
        //<param name="rowNumber">rowNumber holds integrer value</param>
        //<param name="columnName">columnName holds string value</param>
        //<returns>
        //This method returns a string
        //</returns>
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retrieving Data using LINQ
                var data = (from colData in dataCol where colData.colName == columnName && colData.rowNumber == rowNumber select colData.colValue).SingleOrDefault().ToString();
                return data;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return null;
            }
        }

    }

}
