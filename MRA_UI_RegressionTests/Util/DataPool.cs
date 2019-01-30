using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

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

                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }

        //<summary>
        //This method will store data in Dictionary from DataTable
        //</summary>
        //<param name="filename">filename holds string value</param>
        //<param name="rowNum">rowNum holds int value</param>
        //<returns>
        //This method returns Dictionary<string, string>
        //</returns> 
        public static Dictionary<string, string> PopulateInCollection(string filename, int rowNum)
        {
            Dictionary<string, string> dataCol = new Dictionary<string, string>();
            string colValue;
            string colName;
            try
            {
                string filepath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                DataTable table = ConvertCSVtoDataTable(filepath + "\\TestData\\" + filename);
            
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    colName = table.Columns[col].ColumnName;
                    colValue = table.Rows[rowNum - 1][col].ToString();
                    dataCol.Add(colName, colValue);
                }

               
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
            return dataCol;
        }
    }

}
