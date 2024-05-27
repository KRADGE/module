using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

    internal class CreateListBox
    {
        public CreateListBox(Panel thisPan,List<string> ColumnName,int width = 200,int height = 50) 
        {

            for (int i = 0; i < ColumnName.Count(); i++)
            {
                TextBox txtbox = new TextBox();
                Label lbl = new Label();

                lbl.Name = ColumnName[i];
                lbl.Text = lbl.Name;
                lbl.Location = new Point(60, 60 * i + 15);

                txtbox.Size = new Size(width, height);
                txtbox.Name = ColumnName[i];
                txtbox.Location = new Point(60, 60 * i + 40);

                thisPan.Controls.Add(lbl);
                thisPan.Controls.Add(txtbox);
            }

        }
    }
