using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections;
namespace IQVL.DataLayer
{
  public static class CsvHelpers
  {

      public static DataTable ToDataTable(this Dictionary<string, List<object>> dict)
      {
          DataTable dataTable = new DataTable();

          dataTable.Columns.AddRange(dict.Keys.Select(c => new DataColumn(c)).ToArray());

          for (int i = 0; i < dict.Values.Max(item => item.Count()); i++)
          {
              DataRow dataRow = dataTable.NewRow();

              foreach (var key in dict.Keys)
              {
                  if (dict[key].Count > i)
                      dataRow[key] = dict[key][i];
              }
              dataTable.Rows.Add(dataRow);
          }

          return dataTable;
      }
      public static void ForEach<T>(
                 this IEnumerable<T> source,
    Action<T> action)
      {
          foreach (T element in source)
              action(element);
      }
      public static DataTable CombineMisMatchedCsvFiles(string[] filePaths, char splitter = ',')
      {

          HashSet<string> combinedheaders = new HashSet<string>();
          int i;
          // aggregate headers
          for (i = 0; i < filePaths.Length; i++)
          {
              string file = filePaths[i];
              combinedheaders.UnionWith(File.ReadLines(file).First().Split(splitter));
          }
          var hdict = combinedheaders.ToDictionary(y => y, y => new List<object>());

          string[] combinedHeadersArray = combinedheaders.ToArray();
          for (i = 0; i < filePaths.Length; i++)
          {
              var fileheaders = File.ReadLines(filePaths[i]).First().Split(splitter);
              var notfileheaders = combinedheaders.Except(fileheaders);

              File.ReadLines(filePaths[i]).Skip(1).Select(line => line.Split(splitter)).ForEach(spline =>
              {
                  for (int j = 0; j < fileheaders.Length; j++)
                  {
                      hdict[fileheaders[j]].Add(spline[j]);
                  }
                  foreach (string header in notfileheaders)
                  {
                      hdict[header].Add(null);
                  }

              });
          }

          DataTable dt = hdict.ToDataTable();
          return dt;
        
      }
    }
}
