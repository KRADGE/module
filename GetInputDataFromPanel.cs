using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
    public static class GetInputDataFromPanel
    {
        public static  List<string> Result{ get; set; } 
        public static List<string> ColumnName { get; set; } 

        public static void GetInputDataPanel(Panel ThisPanel)
        {
          List<string> result = new List<string>();
          List<string> columns = new List<string>();
          int Count = 0;
          foreach (TextBox txtbuffer in ThisPanel.Controls.OfType<TextBox>())
           {
           
             result.Add(txtbuffer.Text);
             columns.Add(txtbuffer.Name);
             Count++;
          }

          Result = result;
          ColumnName = columns;
 
        }
    }

