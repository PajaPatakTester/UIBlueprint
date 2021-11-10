using System;
using System.Data;
using TechTalk.SpecFlow;

namespace Framework
{
    public static class CommonActions
    {
        public static string CurrentTime() => DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yy_HH-mm-ss");

        public static DataTable TableToDataTable(Table table)
        {
            var dataTable = new DataTable();

            foreach (var header in table.Header)
            {
                dataTable.Columns.Add(header, typeof(string));
            }

            foreach (var row in table.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var header in table.Header)
                {
                    newRow.SetField(header, row[header]);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }
    }
}
