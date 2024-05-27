using System.Windows.Forms;
    public class SelectPathToDb
    {
        public SelectPathToDb( TextBox TxtBox)
        {
            string PathToFile = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = $"All Files| *.mdf";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                PathToFile = openFile.FileName;
            }
            TxtBox.Text = PathToFile;
        }
    }   

