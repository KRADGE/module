
    public static class ConnectionString
    {
        public static string GetPath { get; set; }//Переменная, в которой хранится путь до базы данных

        public static string GetConectString()//Функция для получения строки подключения к БД
        {
            string ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{GetPath}"";Integrated Security=True";//Формирование строки подключекния к Базе данных
            return ConnectionString;
        }
       
    }
