using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;


namespace CSVReaderWriter
{
    class FileReader
    {
        public DataTable GetCsvData(string filePath)
        {
            StreamReader sreader = new StreamReader(filePath);
            DataTable datatable = new DataTable();
            int rowCount = 0;
            string[] columnNames = null;
            string[] streamdataValues = null;
            while (!sreader.EndOfStream)
            {
                string streamRowData = sreader.ReadLine().Trim();
                if (streamRowData.Length > 0)
                {
                    streamdataValues = streamRowData.Split(',');
                    if (rowCount == 0)
                    {
                        rowCount = 1;
                        columnNames = streamdataValues;
                        foreach (string csvHeader in columnNames)
                        {
                            DataColumn datacolumn = new DataColumn(csvHeader.ToUpper(), typeof(string));
                            datacolumn.DefaultValue = string.Empty;
                            datatable.Columns.Add(datacolumn);
                        }
                    }

                    else
                    {
                        DataRow datarow = datatable.NewRow();
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            datarow[columnNames[i]] = streamdataValues[i] == null ? string.Empty : streamdataValues[i].ToString();
                        }
                        datatable.Rows.Add(datarow);
                    }

                }
            }

            sreader.Close();
            sreader.Dispose();
            return datatable;
        }
        public void ViewData(string filePath)
        {
            StreamReader stReader = new StreamReader(filePath);
           DataTable dataTable = new DataTable();
            int rowCount = 0;

            string[] columnNames = null;
            string[] streamdataValues = null;
            while (!stReader.EndOfStream)
            {
                string streamRowData = stReader.ReadLine().Trim();
                if (streamRowData.Length > 0)
                {
                    streamdataValues = streamRowData.Split(',');
                    if (rowCount == 0)
                    {
                        rowCount = 1;
                        columnNames = streamdataValues;
                        foreach (string csvHeader in columnNames)
                        {
                            DataColumn datacolumn = new DataColumn(csvHeader.ToUpper(), typeof(string));
                            datacolumn.DefaultValue = string.Empty;
                            dataTable.Columns.Add(datacolumn);
                        }
                    }

                    else
                    {
                        DataRow datarow = dataTable.NewRow();
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            datarow[columnNames[i]] = streamdataValues[i] == null ? string.Empty : streamdataValues[i].ToString();
                        }
                        dataTable.Rows.Add(datarow);
                    }

                }
            }

            stReader.Close();
            stReader.Dispose();
            foreach (DataRow dr in dataTable.Rows)
            {
                string rowvalues = string.Empty;
                foreach (string csvColumns in columnNames)
                {
                    rowvalues += csvColumns + " = " + dr[csvColumns].ToString() + "   ";
                }
                Console.WriteLine(rowvalues);
            }
            Console.ReadLine();

        }
        public void DisplayData(DataTable myDataTable)
        {
            foreach (DataRow row in myDataTable.Rows)
            {
                Console.WriteLine();
                for (int x = 0; x < myDataTable.Columns.Count; x++)
                {
                    Console.Write(row[x].ToString() + " ");
                }
            }
        }

    }

}
