namespace BankManager
{
    public static class Avtorization
    {
        private static User user;
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine($"<======BankManager======>");
            Console.WriteLine($"1.Войти");
            Console.WriteLine($"2.Создать аккаунт");
            Console.WriteLine($"3.Выйти");
            Console.Write($"\nВыберите операцию: ");
            ChooseOperation(Console.ReadLine());
        }
        private static void ChooseOperation(string str)
        {
            switch(str)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                case "3":
                    Console.WriteLine("\nGood Bye!!!");
                    break;
                default:
                    Console.Clear();
                    Start();
                break;
            }
        }
        private static void Login()
        {
            Console.Clear();
            Console.WriteLine($"<======BankManager======>");
            Console.Write($"Введите ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            if(id < 1)
            {
                Console.WriteLine("Ошибка! Невыерный ID");
                Console.WriteLine("\nНажмите на Enter для выхода");
                Console.Read();
                Start();
            }
            Console.Write($"Введите пароль: ");
            string password = Console.ReadLine();
            user = Log.FindUserOfID(id);
            if (user != null) user.Login(password);
            
            Console.WriteLine("\nНажмите на Enter для выхода");
            Console.Read();
            Start();
              
        }
        private static void Register()
        {
            Console.Clear();
            Console.WriteLine($"<======BankManager======>");
            Console.Write($"Введите имя: ");
            string firstName = Console.ReadLine();
            Console.Write($"Введите фамилию: ");
            string secondName = Console.ReadLine();
            Console.Write($"Введите пароль: ");
            string password = Console.ReadLine();
            if (firstName != "" && secondName != "" && password != "")
            {
                Log.UserAdd(firstName, secondName, password);
                Console.WriteLine("\nНажмите на Enter для выхода");
                Console.Read();
                Start();
            }
            Console.WriteLine("Ошибка! Не все данные были введены!");
            Console.WriteLine("\nНажмите на Enter для выхода");
            Console.Read();
            Start();
        }
    }
}
