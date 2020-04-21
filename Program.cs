using System;
using System.Data;
using System.Data.SqlClient;
using BD_SQL;

namespace Console_Bank_Alif_C_
{
    
    class Program
    {
          const string Const = @"Data Source=localhost; Initial Catalog=master;Integrated Security=True";

        static void Main(string[] args)
        {
            SqlConnection conn =new SqlConnection();
            bool work=true;
                while(work)
                {
                    System.Console.WriteLine("1->'Sign in'");
                    System.Console.WriteLine("2->'Заполнение анкеты клиента'");
                    System.Console.WriteLine("3->'Добавление заявки на кредит клиенту'");
                    System.Console.WriteLine("4->'можно ли взять кредит или нет'");
                    System.Console.WriteLine("5->'Оформление кредита с графиком погашения'");
                    System.Console.WriteLine("6->'Выход'");

                }
                     
                        
        }

        static void Sign_in(SqlConnection conn)
        {
            Console.Clear();
            System.Console.WriteLine("Введите свое имя:");
            string Name= Console.ReadLine();
            System.Console.WriteLine("Введите свою Фамилию:");
            string Surname=Console.ReadLine();
            System.Console.WriteLine("Введите своe Отчество(не обязательно):");
            string MiddleName=Console.ReadLine();
            System.Console.WriteLine("Введите свой адрес:");
            string address=Console.ReadLine();
            System.Console.WriteLine("Введите свой город проживания:");
            string City=Console.ReadLine();
            System.Console.WriteLine("Введите свою почту:");
            string gmail=Console.ReadLine();
            System.Console.WriteLine("Введите свой пол:");
            string sex=Console.ReadLine();
        }
    }
}
