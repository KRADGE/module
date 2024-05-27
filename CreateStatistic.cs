using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

internal class CreateStatistic
{
    private readonly string СonnectString = ConnectionString.GetConectString(); 

    public int CountByParam(string ThisTable,string ParamBySort,string SortValue)
    {
        int Count = 0;

        SqlConnection Connect = new SqlConnection(СonnectString);
        string Query = $"select Count(*) from {ThisTable} where {ParamBySort} = '{SortValue}';";
        SqlCommand Cmd = new SqlCommand(Query, Connect);
        Connect.Open();
        SqlDataReader reader = Cmd.ExecuteReader();
        while (reader.Read())
        {
            Count = (int)reader.GetValue(0);
        }
        reader.Close();
        Connect.Close();
        return Count;
    }
    



    public void FillDatGridViewByStatistic(string param,string ThisTable, DataGridView fillDataGrid) 
    {
        SqlConnection Connect = new SqlConnection(СonnectString); 
        string Query = $@"SELECT {param}, COUNT(*) as order_count FROM {ThisTable} GROUP BY {param}"; 
        Connect.Open(); 
        SqlCommand Cmd = new SqlCommand(Query, Connect);
        SqlDataAdapter SqlAdapter = new SqlDataAdapter(Cmd);
        DataTable DtRecord = new DataTable();
        SqlAdapter.Fill(DtRecord);
        Connect.Close(); 
        fillDataGrid.DataSource = DtRecord;
    }
    

}

