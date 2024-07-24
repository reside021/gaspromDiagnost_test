using gasprom_test.Model;
using gasprom_test.Inteface;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;


namespace gasprom_test.Service
{
    public class ExcelFileService : IFileService
    {
        private bool _isOldFormat;
        public ExcelFileService(bool isOldFormat)
        {
            _isOldFormat = isOldFormat;
        }
        public List<Obj> Open(string path)
        {
            var objs = new List<Obj>();
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            IWorkbook workbook;
            if (_isOldFormat)
                workbook = new HSSFWorkbook(fileStream);
            else
                workbook = new XSSFWorkbook(fileStream);

            var sheet = workbook.GetSheetAt(0);

            for (int row = 0; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null) 
                {
                    var name = sheet.GetRow(row).GetCell(0).StringCellValue;
                    var distance = sheet.GetRow(row).GetCell(1).StringCellValue;
                    var angle = sheet.GetRow(row).GetCell(2).StringCellValue;
                    var width = sheet.GetRow(row).GetCell(3).StringCellValue;
                    var hegth = sheet.GetRow(row).GetCell(4).StringCellValue;
                    var isDefect = sheet.GetRow(row).GetCell(5).StringCellValue;
                    objs.Add(new Obj
                    {
                        Name = name,
                        Distance = distance,
                        Angle = angle,
                        Width = width,
                        Hegth = hegth,
                        IsDefect = isDefect
                    }
                    );
                }
            }
     
            return objs;
        }

        public void Save(string path, List<Obj> objects)
        {
            using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);

            IWorkbook workbook;
            if (_isOldFormat)
                workbook = new HSSFWorkbook(fileStream);
            else
                workbook = new XSSFWorkbook(fileStream);

            ISheet sheet = workbook.GetSheetAt(0);

            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row != null)
                {
                    sheet.RemoveRow(row);
                }
            }

            for (var i = 0; i < objects.Count; i++)
            {
                var row = sheet.CreateRow(i);
                for (var j = 0; j < 6; j++)
                {
                    row.CreateCell(j);
                }
                row.GetCell(0).SetCellValue(objects[i].Name);
                row.GetCell(1).SetCellValue(objects[i].Distance);
                row.GetCell(2).SetCellValue(objects[i].Angle);
                row.GetCell(3).SetCellValue(objects[i].Width);
                row.GetCell(4).SetCellValue(objects[i].Hegth);
                row.GetCell(5).SetCellValue(objects[i].IsDefect);
            }

            using (var fs = new FileStream(path, FileMode.Create))
            {
                workbook.Write(fs, false);
            }

            
        }
    }
}
