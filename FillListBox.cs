using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

    internal class FillListBox
    {
        public FillListBox(List<string> TablesFromDb, ListBox thisListBox)
        {
            List<string> SelectTable = TablesFromDb; 
           
            
            for (int i = 0; i < SelectTable.Count(); i++)
            {
                thisListBox.Items.Add(SelectTable[i]);
            }
        }
    }

