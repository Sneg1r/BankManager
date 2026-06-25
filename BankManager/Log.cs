namespace BankManager
{
    public struct Log
    {
        private List<string> _logList = new List<string>(10);
        private static List<User> _users = new List<User>{ new User("Misha","Ogyrcov","1234")}; 
        public Log()
        {
          
        }
        public void AddInfo(string message)
        {
            _logList.Add($"{DateTime.Now}|{message}"); 
        }
        public void Print()
        {
            foreach (var log in _logList)
            {
                Console.WriteLine(log);
            }
        }
        public static User? FindUserOfID(int id)
        {
            if(_users.FirstOrDefault(u => u.ID == id)!= null)
            {
                    return _users.FirstOrDefault(u => u.ID == id);
            }
            Console.WriteLine($"Ошибка! Такого аккаунта не существует!");
                return null;    
        }
        public static void UserAdd(string firstName, string secondName, string password)
        {
            _users.Add(new User(firstName, secondName, password));
            Console.WriteLine($"Ваш аккаунт был создан! Войдите в него! ID: {User.NowID-1}");
            Console.Read();
        }
    }
}
