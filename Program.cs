using System;
using System.Data;
using System.Data.SqlClient;

namespace Console_Bank_Alif_C_
{
    
    class Program
    {
          const string Const = @"Data Source=localhost; Initial Catalog=Account_user ;Integrated Security=True";
    SqlConnection conn =new SqlConnection();

        static void Main()
        {
            System.Console.WriteLine("Добро пожаловать в Консольный мини банк от Alif_Sarmoya)");
          
            System.Console.WriteLine("Как вы предпочитайте зарегистрироваться:");
           
            System.Console.Write("Если как клиент нажмит 'Q' если как админ то 'A':");
           string z=Console.ReadLine();
                   if(z=="Q")
                   {
                       Console.Clear();
                       System.Console.WriteLine("Вы успешно зашли как Клиент!");
                       System.Console.WriteLine("если вы хотите узнать что вы можете сделать в качестве клиента наберите 'Fun' ");
                       string fun=Console.ReadLine();
                       if(fun.ToLower()=="fun")
                       {
                           
                       }
                   }
            
           
        }
     
    }

        
}
           
            
            
          

