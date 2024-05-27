using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
    internal class WorkWithDb
    {
        private readonly string СonnectString = ConnectionString.GetConectString();//Объявление переменной, в которой хранится строка подключения к базе данных
         


        public List<string> GetAllColumnName(string ThisTable)//Метод для получения всех имен столбцов
        {
            List<string> ColumnName = new List<string>();

            SqlConnection Connect = new SqlConnection(СonnectString);//Подключение к Базе Данных
            string Query = $"select Column_name from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{ThisTable}'";//Новая команда  для БД
            SqlCommand Cmd = new SqlCommand(Query, Connect);
            Connect.Open();//Открытие подключения
            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())//чтение выполненого SQL запроса
            {
                ColumnName.Add((string)reader.GetValue(0)); // запись в N элемент массива имя столбца
             }
            reader.Close();//Закрытие чтения
            Connect.Close();//Закрытие подключения
            return ColumnName;//Возвращение массива со всеми именами столбцов
        }



    public List<string> AllTableNameFromDB()//Метод, для получения названия всех таблиц в базе данных 
        {
            List<string> AllTableName = new List<string>();//Обьявление массива для хранения всех полученных имен, и имеющий размер N

            string Query = "Select TABLE_NAME from INFORMATION_SCHEMA.TABLES";//Новая команда  для БД
            SqlConnection Conection = new SqlConnection(СonnectString);
            SqlCommand Cmd = new SqlCommand(Query, Conection);
            Conection.Open();//Открытие подключения
            SqlDataReader Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                AllTableName.Add((string)Reader.GetValue(0));// запись в N элемент массива имя столбца
            }

            Reader.Close();//Закрытие чтения
            Conection.Close();//Закрытие подключения

            return AllTableName;//Возвращение массива со всеми именами таблиц
        }



        public void UserQuery(string QueryStr)//Метод выполнения пользовательского запроса в Базу Данных
        {
            SqlConnection Conn = new SqlConnection(СonnectString);//Подключение к Базе Данных
            string Query = QueryStr;//Новая команда для БД
            SqlCommand Cmd = new SqlCommand(Query, Conn);
            Conn.Open();//Открытие подключения
            Cmd.ExecuteNonQuery();//Выполнение запроса
            Conn.Close();//Закрытие подключения
            MessageBox.Show("Запрос выполнен\nвыберите таблицу снова, для отображения результата","Внимание");
        }
        


        private bool IsUser(string UserLogin, string UserPass, string ThisTable, string LoginVar = "login", string PassVar = "password")//Метод, для того что бы узнать, существует ли такой пользователь
        {
            try //Обработчик исключений
            {
                int CountUser = 0;// Счетчик
                string Query = $"select Count(*) from {ThisTable} where {LoginVar}='{UserLogin}' and {PassVar}='{UserPass}';";//Новая команда для БД
                SqlConnection Conection = new SqlConnection(СonnectString);//Подключение к Базе Данных
                SqlCommand Cmd = new SqlCommand(Query, Conection);
                Conection.Open();//Открытие подключения
                SqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    CountUser = (int)Reader.GetValue(0);// Получение количества пользователей с таким логином или паролем
                }

                Reader.Close();//Закрытие чтения
                Conection.Close();//Закрытие подключения

                if (CountUser >= 1)//Если пользователей с таким логином или паролем больше 1
                {
                    return true;//возвращение true(Такой пользователь существует)
                }
                return false;//возвращение false(Такого пользователя не существует)
            }
            catch { return false; }//возвращение false(Такого пользователя не существует)

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
            Reader.Close();//Закрытие чтения
            Conection.Close();
            return CountUserInfo;
        }
        public List<string> UserInfo(string Login, string Pass, string ThisTable = "Auth", string LoginVar = "login", string PassVar = "password")//Метод, для получении информации о пользователе
        {
            int CountUser = UserInfoCount(ThisTable);// Счетчик
            List<string> Info = new List<string>();// Обьявление нового списка
            string Query = $"select * from {ThisTable} where {LoginVar} = N'{Login}' and {PassVar} = N'{Pass}';";//Новая команда для БД
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
            Reader.Close();//Закрытие чтения
            Conection.Close();//Закрытие подключения
            return Info;// Возвращения списка с информацией о пользователе
        }





        public void AuthMethod (Form ThisForm,Form nextForm,string login, string pass, string AuthTableName = "Auth")//Аунтентификация
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