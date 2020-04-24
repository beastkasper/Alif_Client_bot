using System;
using System.Data;
using System.Data.SqlClient;


namespace Console_Bank_Alif_C_
{

    class Program
    {

        public static int ID{get;set;}
        public static int Tel{get;set;}
        public static bool b;
        const string Const = @"Data Source=localhost; Initial Catalog=CADB ;Integrated Security=True";
       SqlConnection conn =new SqlConnection(Const);
        static int id = 0;
        static void Main()
        {
            

            System.Console.WriteLine("Добро пожаловать в Консольный мини банк от Alif_Sarmoya");
        Link:
            System.Console.WriteLine("Как вы предпочитайте зарегистрироваться:");

            System.Console.Write("Если как клиент нажмит 'Q' если как админ то 'A':");
            string z = Console.ReadLine();
            if (z.ToUpper() == "Q")
            {
                bool b = true;
                while (b)
                {
                    //Console.Clear();
                    System.Console.WriteLine("Вы успешно зашли как Клиент!");
                        System.Console.WriteLine(" ");                   
                  
                        System.Console.WriteLine("Зарегистрироваться->1");
                        System.Console.WriteLine("Вход-> 3 чтобы войти уже существуюший аккаунт");
                        System.Console.WriteLine("Выход из базы клиента!->6");
                       System.Console.WriteLine("Если вы прошли заполнение анкеты и вам одобрели кредит ->4");
                    
                    int n = int.Parse(Console.ReadLine());
                    if (n == 1)
                    {
                        Regestretion(3);
                    }
                    if (n == 3)
                    {
                         
                        System.Console.WriteLine("Введите номер телефона");
                        int Tel=int.Parse(Console.ReadLine());
                        ID=Tel;
                        System.Console.WriteLine("Введите пороль");
                        string Password=Console.ReadLine();

                        SignIn(Tel,Password);
                    }

                        if(n==4)
                        {
                            Graph();
                            
                        }

                           

                        
                       
                    
                       
                    if (n == 6)
                    {
                        Console.Clear();
                        goto Link;
                    }

                }
                                 
            }
            if(z=="A")
            {
                System.Console.WriteLine("Вы зошли как Admin!");
                System.Console.WriteLine("Посмотреть всю инфу о клиентах-1");
                int n=int.Parse(Console.ReadLine());
                if(n==1)
                {
                            SelectAllClients();
                }
            }

        }

        static void Regestretion(int? rid)
        {
            Console.Clear();


            System.Console.WriteLine("Перед началом регистрации рекомендуем взять паспорт и заполнять все поля внимательно!!");
            System.Console.WriteLine();
            System.Console.Write("Введите свое имя:");
            string Name = Console.ReadLine();
            System.Console.Write("Введите свою Фамилию:");
            string Surname = Console.ReadLine();
            System.Console.Write("Введите свое Отчество:");
            string MiddleName = Console.ReadLine();
            System.Console.Write("Введите свой Address:");
            string Address = Console.ReadLine();
             E:
            System.Console.Write("Укажите свой пол:M-мужчина, W-женшина: ");
            string sex = Console.ReadLine();
            if (sex == "M") { System.Console.WriteLine("ок"); }
            else if (sex == "W") { System.Console.WriteLine("ок"); }

            else { System.Console.WriteLine("Error!"); goto E; }
             Again:
            System.Console.Write("Введите свой номер телефона вместо логина:");
            int Tel = int.Parse(Console.ReadLine());
            
            
            if (Tel < 0)
            {
                System.Console.WriteLine("вы ввели не верно свои номра или ввели больше или меньше 9 цифр!!!");

                goto Again;
            }
            System.Console.Write("Create Password (Mi-8):");
            string Password = Console.ReadLine();
            System.Console.WriteLine("введите Id паспорта");
            string ICard=Console.ReadLine();
          
            SqlConnection conn = new SqlConnection(Const);
            conn.Open();
            string com=string.Format($"INSERT INTO U_Accaunt ([Name],[Surname],[MiddleName],[Address],[Gender],[Login],[RoleId],[Password],[ICard]) VALUES ('{Name}','{Surname}','{MiddleName}','{Address}','{sex}',{Tel},{rid},'{Password}','{ICard}'");
            SqlCommand command=new SqlCommand(com,conn);
            SqlDataReader reader =command.ExecuteReader();
            System.Console.WriteLine("Вы успешно зарегистрировались!");
            ComplateTheForm();
        }

        static void ComplateTheForm()
        {
            Console.Clear();
            SqlConnection conn =new SqlConnection(Const);
            conn.Open();
            SqlCommand comm =new SqlCommand(Const,conn);
                System.Console.WriteLine("Write your name");
                string Name =Console.ReadLine();
                System.Console.WriteLine("Write your Surname");
                string Surname =Console.ReadLine();
                System.Console.WriteLine("Write your MiddleName");
                String MiddleName=Console.ReadLine();
            int count = 0;
            System.Console.WriteLine("Для того что бы получить кредит заполните анкету!");
            Console.Write("Сумма кредита");
            double sum=double.Parse(Console.ReadLine());
            System.Console.WriteLine("Sex");
            System.Console.Write("Male-1:");
           System.Console.WriteLine("Female-2");
            int sex  = int.Parse(Console.ReadLine());
            if(sex==1)
            {
                count++;
            }
           if(sex==2)
           {
               count+=2;
           }
            System.Console.WriteLine("Семейное положение:");
            System.Console.WriteLine("холост-1");
            System.Console.WriteLine("семеянин-2");
            System.Console.WriteLine("вразводе-3");
            System.Console.WriteLine("Вдовец/вдова-4");
           int Fimaly_Status  = int.Parse(Console.ReadLine());
            if(Fimaly_Status==1)count++;
            if(Fimaly_Status==2)count+=2;
            if(Fimaly_Status==3)count++;
            if(Fimaly_Status==4)count+=2;
            System.Console.WriteLine("введите свой возраст:");
            System.Console.WriteLine("До 25:-1");
            System.Console.WriteLine("от 26-35:-2");
            System.Console.WriteLine("от 36-62:-3");
            System.Console.WriteLine("старше 63:-4");
            int Age=int.Parse(Console.ReadLine());
            if(Age==1)count+=0;
            if(Age==2)count+=1;
            if(Age==3)count+=2;
            if(Age==4)count+=1;
            System.Console.WriteLine("Гражданство:");
            System.Console.WriteLine("Таджикистан-1");
            System.Console.WriteLine("Другое-2");
            int Citythenship=int.Parse(Console.ReadLine());
            if(Citythenship==1)count+=1;
            if(Citythenship==2)count+=0;
           
            System.Console.WriteLine("Цель кредита");
             System.Console.WriteLine("бытовая техника-1");
              System.Console.WriteLine("ремонт-2");
               System.Console.WriteLine("телефон-3");
                System.Console.WriteLine("прочее-4");
                int gc=int.Parse(Console.ReadLine());
                 if(gc==1)count+=2;
                 if(gc==2)count+=1;
                 if(gc==3)count+=0;
                 if(gc==4)count-=1;
            System.Console.WriteLine("Срок кредита");
            int dl=int.Parse(Console.ReadLine());
           
           System.Console.Write("Введите свою заработную плату:");
               double Salary=double.Parse(Console.ReadLine());
               if (Salary * 0.8 > sum) { count += 4; }
               if (Salary * 0.8 <= sum && Salary * 1.5 > sum) { count += 3; }
               if (Salary * 1.5 <= sum && Salary * 2.5 >= sum) { count += 2; }
               if (Salary * 2.5 < sum) { count += 1; }
                 
                if(count>11)
                {
                    System.Console.WriteLine($"Ваш бал составил: {count}");
                    System.Console.WriteLine("кредит одобрен)");

                }
                else
                {
                    System.Console.WriteLine("вам в кредите отказано( вы набрали меньше 12 балов");
                }
            string CommandText=$"INSERT INTO U_App ([Sex],[Fimaly_Status],[Age],[Citythenship],[goal_credit],[deadLine],[UId],[Salary],[sum],[status]) values({sex},{Fimaly_Status},{Age},{Citythenship},{gc},{dl},{ID},{Salary},{sum},'Decline')";
            if(count>=12){
                 CommandText=$"INSERT INTO U_App ([Sex],[Fimaly_Status],[Age],[Citythenship],[goal_credit],[deadLine],[UId],[Salary],[sum],[status],[Name],[Surname],[MiddleName]) values({sex},{Fimaly_Status},{Age},{Citythenship},{gc},{dl},{ID},{Salary},{sum},'{Name}','{Surname}', '{MiddleName}',Accepted')";
            }
           SqlCommand command=new SqlCommand(CommandText,conn);
                command=new SqlCommand(CommandText,conn);
                var result =command.ExecuteNonQuery();
                if(result>0)
                {
                    System.Console.WriteLine("Ваши данные успешно добавлены");
                    string stop=Console.ReadLine();
                    
                }
            else
            {
                System.Console.WriteLine("Error!");
            }
           // comm.ExecuteNonQuery();
             conn.Close();
             
        }

        static void SignIn(int Tel,string Password)
        {
            SqlConnection conn =new SqlConnection(Const);
              conn.Open();
            string textcommand = string.Format($"select * from U_Accaunt where Login='{Tel}' AND Password='{Password}' ");

            SqlCommand cm = new SqlCommand(textcommand, conn);
            SqlDataReader rd = cm.ExecuteReader();
            int x = 0;
            while (rd.Read())
            {
                x++;
                Console.Clear();
                Console.WriteLine("Ваши логин и пароль корректны");
                ID=Tel;
                
            }
            if (x == 0)
            {
                Console.WriteLine("Логин или пароль был введён неверно");
                 
            }
               
                
               conn.Close();
                ComplateTheForm();
        }
            static void Graph()
            {
                 Console.Clear();
                System.Console.WriteLine("Оформление кредита прошло успешно!");
                 SqlConnection conn =new SqlConnection(Const);
                conn.Open();
                System.Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("График погашения кредита");
                Console.ForegroundColor = ConsoleColor.Red;
                string com = string.Format($"select * from U_App where UId={ID} and status='Accepted'");
                SqlCommand command = new SqlCommand(com, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                     double valuepermonth = Math.Round(double.Parse(reader["sum"].ToString()) / int.Parse(reader["deadLine"].ToString()));
                     System.Console.WriteLine($"вы должны платить {valuepermonth} каждый месяц {reader["deadLine"].ToString()} месяцы. Total:{reader["sum"].ToString()}");
                     
                }
                conn.Close();
               

            }  

            static void SelectAllClients()
            {
                SqlConnection conn =new SqlConnection(Const);
                conn.Open();
           // string commandText = "Select * from UserInformation";
           // string commandText = $"SELECT u.Id, u.FirstName, u.LastName, u.MiddleName, g.Gender, u.Age, f.FamilyStatus, c.Citizen, u.LoanAmount, u.Salary, p.PurposeOfLoan, u.Status FROM UserInformation u join Gender g ON u.Gender_id = g.Id join FamilyStat f ON u.FamilyStatus_id = f.Id join Citizen c ON u.Citizen_id = c.Id join PurposeOfLoan p ON u.PurposeOfLoan_id = p.Id";
           string commandText =$"select u.Id, u.Name, u.Surname, u.MiddeName, s.Sex, f.Fimaly_Status,u.Age, c.Citythenship, g.goal_credit, u.deadLine, u.Salary, u.sum, u.status from U_App u join Sex s ON u.Sex_Id = s.Id join Fimaly_Status f ON u.Fimaly_Status_Id = f.Id join Citythenship c ON u.Citythenship_Id = c.Id join goal_credit g ON  u.goal_credit_Id = g.id";
            SqlCommand command = new SqlCommand(commandText, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"ID:{reader.GetValue("Id")}, Name:{reader.GetValue("Name")}, Surname:{reader.GetValue("Surname")}, MiddeName:{reader.GetValue("MiddeName")},Sex:{reader.GetValue("Sex")}, Fimaly_Status:{reader.GetValue("Fimaly_Status")},Age:{reader.GetValue("Age")},Citythenship:{reader.GetValue("Citythenship")}, sum:{reader.GetValue("sum")}, Salary:{reader.GetValue("Salary")},status:{reader.GetValue("status")} ");
                System.Console.WriteLine("================================================================================================================================================================================");
                Console.ReadKey();
            }
            reader.Close();
            conn.Close();
            Console.ForegroundColor = ConsoleColor.White;
            }
    }


}





