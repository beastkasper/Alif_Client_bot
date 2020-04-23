using System;
using System.Data;
using System.Data.SqlClient;


namespace Console_Bank_Alif_C_
{

    class Program
    {

        const string Const = @"Data Source=localhost; Initial Catalog=CADB ;Integrated Security=True";
        static int id = 0;
        static void Main()
        {

            System.Console.WriteLine("Добро пожаловать в Консольный мини банк от Alif_Sa");
        Link:
            System.Console.WriteLine("Как вы предпочитайте зарегистрироваться:");

            System.Console.Write("Если как клиент нажмит 'Q' если как админ то 'A':");
            string z = Console.ReadLine();
            if (z.ToUpper() == "Q")
            {
                bool b = true;
                while (b)
                {
                    Console.Clear();
                    System.Console.WriteLine("Вы успешно зашли как Клиент!");
                    System.Console.WriteLine("если вы хотите узнать что вы можете сделать в качестве клиента наберите 'Fun' ");
                    string fun = Console.ReadLine();
                    if (fun.ToLower() == "fun")
                    {
                        System.Console.WriteLine("1.Зарегистрироваться->1");
                        System.Console.WriteLine("2.Заполнение анкеты для выдачи кредита->2");
                        System.Console.WriteLine("3.Добавление заявки на кредит клиенту");
                        System.Console.WriteLine("4.Вывод результата можно ли ему взять кредит или нет");
                        System.Console.WriteLine("5.Оформление кредита с графиком погашения");
                        System.Console.WriteLine("6.Выход из базы клиента!");
                    }
                    int n = int.Parse(Console.ReadLine());
                    if (n == 1)
                    {
                        Regestretions(3);
                    }
                    if (n == 2)
                    {
                        if (id != 0)
                        {
                            ComplateTheForm();
                        }
                        else
                        {

                        }
                    }
                    if (n == 6)
                    {
                        Console.Clear();
                        goto Link;
                    }

                }
            }

        }

        static void Regestretions(int? rid)
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
            Char sex = Char.Parse(Console.ReadLine());
            if (sex == 'M') { System.Console.WriteLine("ок"); }
            else if (sex == 'W') { System.Console.WriteLine("ок"); }

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
            SqlCommand command = new SqlCommand(Const, conn);
            command.CommandText = $"INSERT INTO U_Accaunt ([Name],[Surname],[MiddleName],[Address],[Gender],[Login],[RoleId],[Password],[ICard]) VALUES ('{Name}','{Surname}','{MiddleName}','{Address}','{sex}',{Tel},{rid},'{Password}',{ICard})";
            command.ExecuteNonQuery();

            System.Console.WriteLine("Вы успешно зарегистрировались!");
        }

        static void ComplateTheForm()
        {
            Console.Clear();
            SqlConnection conn =new SqlConnection(Const);
            conn.Open();
            SqlCommand comm =new SqlCommand(Const,conn);

            int count = 0;
            System.Console.WriteLine("Для того что бы получить кредит заполните анкету!");

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
            System.Console.WriteLine("Вдовец/вдова");
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
            System.Console.WriteLine("сумма кредита от обшего дохода:");
            System.Console.WriteLine("до 80%-1");
            System.Console.WriteLine("80-150%-2");
            System.Console.WriteLine("150-250%-3");
            System.Console.WriteLine("Свыше 250%-4");

            int cr=int.Parse(Console.ReadLine()); 
            if(cr==1)count+=4;
            if(cr==2)count+=3;
            if(cr==3)count+=2;
            if(cr==4)count+=1;
            System.Console.WriteLine("История кредита:");
            System.Console.WriteLine("более 3 закрытых историй-1");
            System.Console.WriteLine("1-2 закрытых историй-2");
            System.Console.WriteLine("нет кредитной истории-3");
            int ch=int.Parse(Console.ReadLine());
            if(ch==1)count+=2;
            if(ch==2)count+=1;
            if(ch==3)count--;
            System.Console.WriteLine("просрочка в кредитной истории");
            System.Console.WriteLine("свыше 7 раз-1");
            System.Console.WriteLine(" 5-7 раз-2");
            System.Console.WriteLine(" 4 раз-3");
            System.Console.WriteLine("до 3 раз-4");
            int Och=int.Parse(Console.ReadLine());
             if(Och==1)count-=3;
            if(Och==2)count-=2;
            if(Och==3)count-=1;
            if(Och==4)count+=0;
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
            System.Console.WriteLine("более 12 мес-1");
            System.Console.WriteLine("до 12 мес-2");
            int dl=int.Parse(Console.ReadLine());
                 if(dl==1)count+=1;
                 if(dl==2)count+=1;

            comm.CommandText=$"INSERT INTO U_App ([Sex],[Fimaly_Status],[Age],[Citythenship],[Loan amount of total income],[Credit_hitory],[Overdue credit history],[goal_credit],[deadLine])values({sex},{Fimaly_Status},{Fimaly_Status},{Age},{Citythenship},{cr},{ch},{Och},{gc},{dl})";
            comm.ExecuteReader();
        }

    }


}





