using System;
using System.Data;
using System.Globalization;
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

        public static Decimal FormatPrice(string price)
        {
            var invariantCulture = price.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            return Decimal.Parse(invariantCulture);
        }

        public static Decimal PriceInEur(string price, decimal exchageRate)
        {
            string formattedNumber = price;

            if (price.Contains("€")) formattedNumber = price.Replace("€", "").Replace(".", "").TrimEnd();
            if (price.Contains("din")) formattedNumber = price.Replace("din", "").Replace(".", "").TrimEnd();
            if (price.Contains("Kontakt")) return 0;

            var invariantCulture = formattedNumber.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);

            var thePrice = Decimal.Parse(invariantCulture);

            if (price.Contains("din")) thePrice = thePrice / exchageRate;
            
            return thePrice;
        }
    }
}
