using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Utilities.Common
{
    public static class TableUtilities
    {
        public static bool CompareTable(DataTable origin, DataTable last)
        {
            var rows = origin.Rows.Count == last.Rows.Count;
            var columns = origin.Columns.Count == last.Columns.Count;
            var errorMessage = new StringBuilder();

            if (!rows)
                errorMessage.AppendLine($"Error Message: Rows number is different. Expected: {origin.Rows.Count} - Current: {last.Rows.Count}");
            if (!columns)
                errorMessage.AppendLine($"Error Message: Columns number is different. Expected: {origin.Columns.Count} - Current: {last.Columns.Count}");
            var countError = 0;
            var count = 0;
            var result = true;
            if (last.Rows.Count > 0)
                foreach (DataRow originRow in origin.Rows)
                {
                    result = Enumerable.SequenceEqual(originRow.ItemArray, last.Rows[count].ItemArray);
                    if (!result)
                    {
                        errorMessage.AppendLine($"Error Message: Rows number '{count + 1}' are different.\n Expected: {RowToString(originRow)} \n Current: {RowToString(last.Rows[count])}");
                        if (countError++ == 10) break;
                    }
                    count++;

                }
            if(errorMessage.Length > 0)
                throw new Exception(errorMessage.ToString());

            return rows && columns && result;
        }

        public static bool CompareTableWithList(DataTable table, List<string> rowList)
        {
            var rows = table.Rows.Count == rowList.Count;
            var errorMessage = new StringBuilder();

            if (!rows)
                errorMessage.AppendLine($"Error Message: Rows number is different. Expected: {table.Rows.Count} - Current: {rowList.Count}");

            var count = 0;
            var result = true;
            if (table.Rows.Count > 0)
                foreach (DataRow tableRow in table.Rows)
                {
                    result = tableRow.ItemArray.GetValue(0).ToString() == rowList[count];
                    if (!result)
                    {
                        errorMessage.AppendLine($"Error Message: Rows number '{count + 1}' are different.\n Expected: {tableRow.ItemArray.GetValue(0)} \n Current: {rowList[count]}");
                        break;
                    }
                    count++;

                }
            if (errorMessage.Length > 0)
                throw new Exception(errorMessage.ToString());

            return rows && result;
        }

        private static StringBuilder RowToString(DataRow row)
        {
            return new StringBuilder().AppendLine(string.Join(",", row.ItemArray));
        }
    }
}
