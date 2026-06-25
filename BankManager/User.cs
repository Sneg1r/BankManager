namespace BankManager
{
    public class User
    {
        private static int startID = 1000;
        public static int NowID { get { return startID; }}

        public User(string firstName, string secondName, string password)
        {
            FirstName = firstName;
            SecondName = secondName;
            _log.AddInfo($"Создание аккаунта №{_ID}");
            _password = password;
        }

        private string _firstName;
        private string _secondName;
        private int _ID = startID++;
        private decimal _balance;
        private Log _log = new Log();
        private string _password;
        public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}
        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; }
        }
        public int ID
        {
            get { return _ID; }
        }
        public decimal Balance
        {
            get { return _balance; }
            private set { _balance = value; }
        }
        public void PrintInfo()
        {
            Console.Clear();
            Console.WriteLine($"<======BankManager======>");
            Console.WriteLine($"1.Имя: {_firstName}");
            Console.WriteLine($"2.Фамилия: {_secondName}");
            Console.WriteLine($"3.ID: {_ID}");
            Console.WriteLine($"4.Баланс: {_balance}");
            Console.WriteLine($"5.Пополнить счёт");
            Console.WriteLine($"6.Перевести на счёт");
            Console.WriteLine($"7.Пароль: {_password}");
            Console.WriteLine($"8.История операций");
            Console.WriteLine($"9.Выйти");
            Console.Write($"\nВыберите операцию: ");
            ChooseOperation(Console.ReadLine());
        }
        private void Pay(decimal money, int id)
        {
            User user = Log.FindUserOfID(id);
            if (user == null)  return;
            
            if (_balance - money >= 0)
            {
                _balance -= money;
                user.Balance += money;
                Console.WriteLine($"Перевод в размере {money}р на счёт {id}. Текущий баланс: {_balance}");
                user._log.AddInfo($"Пополнение счёта в размере {money}р от пользователя №{_ID}");

                _log.AddInfo($"Перевод в размере {money}р на счёт  №{id}.");
                return;
            }
            Console.WriteLine($"Ошибка! У вас недостаточно средств для перевода!");
            _log.AddInfo($"Ошибка! У вас недостаточно средств для перевода!");
        }
        private void Depozit(decimal money)
        {
            _balance+= money;
            Console.WriteLine($"Пополнение счёта в размере {money}р. Текущий баланс: {_balance}");
            _log.AddInfo($"Пополнение счёта в размере {money}р.");
        }
        private void ChooseOperation(string str)
        {
            int.TryParse(str, out int operation);
            switch(operation)
            {
                case 5:
                    
                    Console.Clear();
                    Console.WriteLine($"<======BankManager======>");
                    Console.Write($"Введите сумму пополнения: ");
                    decimal.TryParse(Console.ReadLine(), out decimal coins);
                    if (coins > 0)
                    {
                        Depozit(coins);
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка! Вы ввели неверные данные!");
                        _log.AddInfo($"Ошибка! Неверные данные!");
                    }
                    Console.WriteLine("\nНажмите на Enter для выхода");
                    Console.Read();
                    PrintInfo();
                break;

                case 6:

                    Console.Clear();
                    Console.WriteLine($"<======BankManager======>");
                    Console.Write($"Введите сумму перевода: ");
                    decimal.TryParse(Console.ReadLine(), out decimal money);
                    if (money > 0)
                    {
                        Console.Write($"Введите ID пользователя для перевода: ");
                        int.TryParse(Console.ReadLine(), out int id);
                        if (id > 0)
                        {
                            Pay(money, id);
                        }
                        else
                        {
                            Console.WriteLine($"Ошибка! Вы ввели неверный ID!");
                            _log.AddInfo($"Ошибка! Неверный ID!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка! Вы ввели неверные данные!");
                        _log.AddInfo($"Ошибка! Неверные данные!");
                    }

                    Console.WriteLine("\nНажмите на Enter для выхода");
                    Console.Read();
                    PrintInfo();
                break;

                case 8:
                    Console.Clear();
                    Console.WriteLine($"<======BankManager======>");
                    _log.Print();
                    Console.WriteLine("\nНажмите на Enter для выхода");
                    Console.Read();
                    PrintInfo();
                break;
                case 9:
                    Avtorization.Start();
                    break;
                default:
                    PrintInfo();
                break;
            }
        }
        public void Login(string password)
        {
            if (password == _password) PrintInfo();
            else Console.WriteLine("Ошибка входа! Пароль неверный!");
        }
    }
}
