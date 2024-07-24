using gasprom_test.Inteface;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace gasprom_test.Service
{
    public class DialogService : IDialogService
    {
        public string FilePath { get ; set ; }

        public IFileService FileService()
        {
            var ext = Path.GetExtension(FilePath);
            switch (ext)
            {
                case ".xlsx":
                    {
                        return new ExcelFileService(false);
                    }
                case ".xls":
                    {
                        return new ExcelFileService(true);
                    }
                case ".csv":
                    {
                        return new CsvFileService();
                    }
                default: throw new Exception("Неподдерживаемый формат файла");

            }
        }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|Csv files|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
