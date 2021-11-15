using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoPark.CsvHelper
{
    public class CsvReader
    {
        public CsvReader(string filePath)
        {
            FilePath = filePath;
        }
        public string FilePath { get; }

        public List<List<string>> Read()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var sr = new StreamReader(FilePath, Encoding.GetEncoding(1251)))
            {
                var listResult = new List<List<string>>();

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listResult.Add(ParseString(line));
                }
                return listResult;
            }

        }

        private List<string> ParseString(string str)
        {
            var fields = new List<string>();

            var splitString = Regex.Replace(
                    str,
                    "\"" + @"(?<firstNum>\d+)\,(?<secondNum>\d+)" + "\"",
                    "${firstNum}.${secondNum}")
                    .Split(',');

            foreach(var field in splitString)
            {
                fields.Add(Regex.Replace(
                    field,
                    @"(?<firstNum>\d+)\.(?<secondNum>\d+)",
                    "${firstNum},${secondNum}"));
            }
            return fields;
        }
    }
}
