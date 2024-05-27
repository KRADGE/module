using System.Windows.Forms;
    public class SelectPathToDb
    {
        public SelectPathToDb( TextBox TxtBox)//Метод для получение пути до файла через OpenFileDialog
        {
            string PathToFile = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = $"All Files| *.mdf";//Фильтр файлов с расширением '*.mdf'
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                PathToFile = openFile.FileName;
            }
            TxtBox.Text = PathToFile;
        }
    }   

