using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Text;

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
            using (var parser = new TextFieldParser(FilePath, Encoding.GetEncoding(1251)))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                var listResult = new List<List<string>>();
                while (!parser.EndOfData)
                {
                    var fields = new List<string>(parser.ReadFields());
                    listResult.Add(fields);
                }
                return listResult;
            }
            
        }
    }
}
