using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

internal class FillDataGridView
    {
        private readonly string СonnectString = ConnectionString.GetConectString();//Объявление переменной, в которой хранится строка подключения к базе данных

        public void FillDatGridView(string ThisTable , DataGridView fillDataGrid)//Метод, для заполнения таблицы(DataGridView )
        {

            SqlConnection Connect = new SqlConnection(СonnectString);//Подключение к Базе Данных
            string Query = $"select * from {ThisTable}";//Новая команда для БД
            Connect.Open();//Открытие подключения
            SqlCommand Cmd = new SqlCommand(Query, Connect);
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(Cmd);
            DataTable DtRecord = new DataTable();
            SqlAdapter.Fill(DtRecord);
            Connect.Close();//Закрытие подключения
            fillDataGrid.DataSource = DtRecord;
        }

        public void UserFillDatGridView(string UserQuery, DataGridView fillDataGrid)//Метод, для заполнения таблицы(DataGridView )
        {
            SqlConnection Connect = new SqlConnection(СonnectString);//Подключение к Базе Данных
            string Query = UserQuery;//Новая команда для БД
            Connect.Open();//Открытие подключения
            SqlCommand Cmd = new SqlCommand(Query, Connect);
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(Cmd);
            DataTable DtRecord = new DataTable();
            SqlAdapter.Fill(DtRecord);
            Connect.Close();//Закрытие подключения
            fillDataGrid.DataSource = DtRecord;
        }
}

