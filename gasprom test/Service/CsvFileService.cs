using CsvHelper;
using CsvHelper.Configuration;
using gasprom_test.Inteface;
using gasprom_test.Model;
using System.Globalization;
using System.IO;
using System.Text;

namespace gasprom_test.Service
{
    internal class CsvFileService : IFileService
    {
        public List<Obj> Open(string path)
        {
            var objs = new List<Obj>();
            using var reader = new StreamReader(path, encoding: Encoding.UTF8);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };
            using var csv = new CsvReader(reader, csvConfig);

            var records = csv.GetRecords<Obj>();

            foreach( var record in records)
            {
                objs.Add(record);
            }
            return objs;
        }

        public void Save(string path, List<Obj> objects)
        {
            using var writer = new StreamWriter(path, false, encoding: Encoding.UTF8);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };
            using var csv = new CsvWriter(writer, csvConfig);
            csv.WriteRecords(objects);
        }
    }
}
