using System;
using System.Data;
using System.Data.SqlClient;


namespace Console_Bank_Alif_C_
{

    class Program
    {
            const string Const = @"Data Source=localhost; Initial Catalog=Account_user ;Integrated Security=True";
   

        static void Main()
        {
            
            System.Console.WriteLine("Добро пожаловать в Консольный мини банк от Alif_Sarmoya)");
                Link:
            System.Console.WriteLine("Как вы предпочитайте зарегистрироваться:");
           
            System.Console.Write("Если как клиент нажмит 'Q' если как админ то 'A':");
           string z=Console.ReadLine();
                   if(z.ToUpper()=="Q")
                   { 
                       bool b=true;
                       while(b)
                       {
                       Console.Clear();
                       System.Console.WriteLine("Вы успешно зашли как Клиент!");
                       System.Console.WriteLine("если вы хотите узнать что вы можете сделать в качестве клиента наберите 'Fun' ");
                       string fun=Console.ReadLine();
                       if(fun.ToLower()=="fun")
                       {
                           System.Console.WriteLine("1.Зарегистрироваться->1");
                           System.Console.WriteLine("2.Заполнение анкеты для выдачи кредита->2");
                           System.Console.WriteLine("3.Добавление заявки на кредит клиенту");
                           System.Console.WriteLine("4.Вывод результата можно ли ему взять кредит или нет");
                           System.Console.WriteLine("5.Оформление кредита с графиком погашения");
                           System.Console.WriteLine("6.Выход из базы клиента!");
                       }
                         int n=int.Parse(Console.ReadLine());
                         if(n==1)
                         {
                                Regestretions();
                         }
                         if(n==6)
                         {
                             Console.Clear();
                             goto Link;
                         }

                       }
                   }
                        
        }
            
        static void Regestretions()
        {
            Console.Clear();

            
            System.Console.WriteLine("Перед началом регистрации рекомендуем взять паспорт и заполнять все поля внимательно!!");
            System.Console.WriteLine();
            System.Console.Write("Введите свое имя:");
            string Name=Console.ReadLine();
            System.Console.Write("Введите свою Фамилию:");
            string Surname=Console.ReadLine();
            System.Console.WriteLine("Введите свое Отчество:");
            string MiddleName=Console.ReadLine();
            System.Console.Write("Введите свой Address:");
            string Address=Console.ReadLine();
            E:
            System.Console.Write("Укажите свой пол:M-мужчина, W-женшина: ");
            Char sex =Char.Parse(Console.ReadLine());
            if(sex=='M'){System.Console.WriteLine("ок");}
            if(sex=='W'){System.Console.WriteLine("ок");}

            else{System.Console.WriteLine("Error!"); goto E;}
             Again:
            System.Console.Write("Введите свой номер телефона вместо логина:");
            int Tel=int.Parse(Console.ReadLine());
            if(Tel>0)
            {
            System.Console.WriteLine("Вы успешно зарегистрировались!)");
            }
            else
            {
                System.Console.WriteLine("вы ввели не верно свои номра или ввели больше или меньше 9 цифр!!!");
                 
                    goto Again;
            }

            SqlConnection conn = new SqlConnection();
            conn.Open();
            SqlCommand command=new SqlCommand(Const,conn);
           command.CommandText=$"INSERT INTO Sign_up ([Name],[Surname],[MiddleName],[Address],[sex],[Tel])values('{Name}','{Surname}','{MiddleName}','{Address}','{sex}','{Tel}'";
            
        }   

    static void ComplateTheForm()
    {

    }
     
    }

        
}
           
            
            
          

