using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace RueEngine.Utilities
{
    public static class Utility
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties) 
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static bool IsNumber(string input)
        {
            Regex _isNumericRegex =   new Regex(  "^(" +
                            /*Hex*/ @"0x[0-9a-f]+"  + "|" +
                            /*Bin*/ @"0b[01]+"      + "|" + 
                            /*Oct*/ @"0[0-7]*"      + "|" +
                            /*Dec*/ @"((?!0)|[-+]|(?=0+\.))(\d*\.)?\d+(e\d+)?" + 
                            ")$" );

            return _isNumericRegex.IsMatch(input);
        }
    }
}
