using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
    internal class WorkWithDb
    {
        private readonly string СonnectString = ConnectionString.GetConectString(); 
         


        public List<string> GetAllColumnName(string ThisTable) 
        {
            List<string> ColumnName = new List<string>();

            SqlConnection Connect = new SqlConnection(СonnectString);
            string Query = $"select Column_name from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{ThisTable}'";
            SqlCommand Cmd = new SqlCommand(Query, Connect);
            Connect.Open();
            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                ColumnName.Add((string)reader.GetValue(0)); 
             }
            reader.Close();
            Connect.Close();
            return ColumnName;
        }



    public List<string> AllTableNameFromDB() 
        {
            List<string> AllTableName = new List<string>(); 

            string Query = "Select TABLE_NAME from INFORMATION_SCHEMA.TABLES"; 
            SqlConnection Conection = new SqlConnection(СonnectString);
            SqlCommand Cmd = new SqlCommand(Query, Conection);
            Conection.Open();
            SqlDataReader Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                AllTableName.Add((string)Reader.GetValue(0));
            }

            Reader.Close();
            Conection.Close();

            return AllTableName;
        }



        public void UserQuery(string QueryStr)
        {
            SqlConnection Conn = new SqlConnection(СonnectString);
            string Query = QueryStr;
            SqlCommand Cmd = new SqlCommand(Query, Conn);
            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
            MessageBox.Show("Запрос выполнен\nвыберите таблицу снова, для отображения результата","Внимание");
        }
        


        private bool IsUser(string UserLogin, string UserPass, string ThisTable, string LoginVar = "login", string PassVar = "password") 
        {
            try  
            {
                int CountUser = 0; 
                string Query = $"select Count(*) from {ThisTable} where {LoginVar}='{UserLogin}' and {PassVar}='{UserPass}';"; 
                SqlConnection Conection = new SqlConnection(СonnectString);
                SqlCommand Cmd = new SqlCommand(Query, Conection);
                Conection.Open();
                SqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    CountUser = (int)Reader.GetValue(0);
                }

                Reader.Close();
                Conection.Close();

                if (CountUser >= 1)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }

        }
        private int UserInfoCount(string ThisTable)
        {
            int CountUserInfo = 0;
            string Query = $"Select Count(Column_Name) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = N'{ThisTable}'";
            SqlConnection Conection = new SqlConnection(СonnectString);
            SqlCommand Cmd = new SqlCommand(Query, Conection);
            Conection.Open();
            SqlDataReader Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                CountUserInfo = (int)Reader.GetValue(0);
            }
            Reader.Close();
            Conection.Close();
            return CountUserInfo;
        }
        public List<string> UserInfo(string Login, string Pass, string ThisTable = "Auth", string LoginVar = "login", string PassVar = "password")
        {
            int CountUser = UserInfoCount(ThisTable);
            List<string> Info = new List<string>();
            string Query = $"select * from {ThisTable} where {LoginVar} = N'{Login}' and {PassVar} = N'{Pass}';";
            SqlConnection Conection = new SqlConnection(СonnectString);
            SqlCommand Cmd = new SqlCommand(Query, Conection);
            Conection.Open();
            SqlDataReader Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                for (int i = 0; i < CountUser; i++)
                {
                    Info.Add(Reader.GetValue(i).ToString());
                }
            }
            Reader.Close();
            Conection.Close();
            return Info;
        }





        public void AuthMethod (Form ThisForm,Form nextForm,string login, string pass, string AuthTableName = "Auth")
        {
            if (IsUser(login, pass, AuthTableName))
            {

                SaveUserInfo.UserInformation = UserInfo(login, pass, AuthTableName);

                MessageBox.Show("Вы успешно вошли в систему", "Добрый день/вечер");
                nextForm.Show();
                ThisForm.Hide();
        }
            else
            { MessageBox.Show("Внимание, произошла ошибка.\n Логин или пароль были введены не верно.\n Либо такого аккаунта не существует!", "Ошибка!"); }
        }

    }