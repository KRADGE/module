using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

internal class FillDataGridView
{
        private readonly string СonnectString = ConnectionString.GetConectString();

        public void FillDatGridView(string ThisTable , DataGridView fillDataGrid)
        {

            SqlConnection Connect = new SqlConnection(СonnectString);
            string Query = $"select * from {ThisTable}";
            Connect.Open();
            SqlCommand Cmd = new SqlCommand(Query, Connect);
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(Cmd);
            DataTable DtRecord = new DataTable();
            SqlAdapter.Fill(DtRecord);
            Connect.Close();
            fillDataGrid.DataSource = DtRecord;
        }

        public void UserFillDatGridView(string UserQuery, DataGridView fillDataGrid)
        {
            SqlConnection Connect = new SqlConnection(СonnectString);
            string Query = UserQuery;
            Connect.Open();
            SqlCommand Cmd = new SqlCommand(Query, Connect);
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(Cmd);
            DataTable DtRecord = new DataTable();
            SqlAdapter.Fill(DtRecord);
            Connect.Close();
            fillDataGrid.DataSource = DtRecord;
        }
}

