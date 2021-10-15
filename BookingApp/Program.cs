using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp
{
    class Program
    {
        public static List<MyUser> userList = new List<MyUser>();
        public static Dictionary<int, int> ticketNumDict = new Dictionary<int, int>();
        //key = the number of tickets 
        //value == the ticket number
        static void Main(string[] args)
        {
            InstantiateAdmin();
            InstatiateUser();

            Console.WriteLine("1) Set total num of tickets 2) User Log in 3) Buy Tickets 4) See individual user's ticket detail");
            int res = Int32.Parse(Console.ReadLine());
            if (res == 1)
            {
                SetTotalNumOfTickets();
            }
            else if (res == 2)
            {
                UserLogin();
            }
            else if(res == 3)
            {
                if (BuyTicket())
                {
                    Console.WriteLine("succesfull");
                }
                else
                {
                    Console.WriteLine("Access Denied!");
                }
            }

            Console.ReadLine();

        }

        public static void SetTotalNumOfTickets()
        {
            //only by Admin
            MyTicket ticket = new MyTicket();

            foreach (MyUser item in userList)
            {
                if (item.IsAdmin)
                {
                    Console.WriteLine("please assign number of tickets");
                    int num = Int32.Parse(Console.ReadLine());
                    ticket.TotalNumOfAvailTickets = num;

                    int ticketNum = 100;

                    //create dictionary for ticets and their ticketNumbers
                    for (int i = 1; i <= num; i++)
                    {
                        ticketNum++;
                        ticketNumDict.Add(i, ticketNum);
                    }
                    
                
                }
                else
                {
                    Console.WriteLine("you are not admin! access denied!");
                }
            }
        }
        public static void UserLogin()
        {
            //after checking Email and Phone number 
            Console.WriteLine("--------LOGING IN-----------");
            Console.WriteLine("user ID?");
            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("user HP number?");
            int hp = Int32.Parse(Console.ReadLine());

            Console.WriteLine("user email?");
            string email = Console.ReadLine();

            foreach (MyUser item in userList)
            {
                if (item.UserId == id)
                {
                    if (item.HPnumber == hp  && item.Email == email)
                    {
                        item.LogedIn = true;
                        Console.WriteLine("log in!");
                    }
                    else
                    {
                        Console.WriteLine("log in fail. Accces Denied!");
                    }
                }
            }


        }
        public static bool BuyTicket()
        {
            Console.WriteLine("--------buying ticket---------------");
            Console.WriteLine("user ID?");
            int id = Int32.Parse(Console.ReadLine());

            foreach (MyUser item in userList)
            {
                if (item.LogedIn && item.UserId == id)
                {
                    //logged in =>proceed to buy tickets

                    Console.WriteLine("How many tickets would you like to buy?");
                    int num = Int32.Parse(Console.ReadLine());
                    if (num > 3)
                    {
                        Console.WriteLine("max number or tickets reached.");
                        return false;
                    }
                    else
                    {
                        item.NumOfTicketsBought = num;
                        for (int i = 1 ; i <= num; i++)
                        {
                            int ticketNum;
                            //assign the seat num
                            ticketNumDict.TryGetValue(i, out ticketNum);  //not producing the ticket number from the dictionary
                            Console.WriteLine("your ticket number: " + ticketNum);

                            //minus the ticket from ticket available
                            ticketNumDict.Remove(i);

                            //add tickets to user
                            item.TicketNumbers.Add(ticketNum);
                        }
                        return true;
                    }

                }
            }
            return false;
        }
        public static void InstantiateAdmin()
        {
            MyUser user = new MyUser { IsAdmin = true, UserId = 1, LogedIn = true };
            userList.Add(user);
            
        }
        public static void InstatiateUser()
        {
            MyUser user1 = new MyUser 
            { IsAdmin = false, UserId = 2, Email = "person@gmail.com", HPnumber= 902313, LogedIn = true };
            userList.Add(user1);
        }

        public static void SeeUserBookingDetails()
        {
            //is user Admin check
            Console.WriteLine("User ID to check: ");
            int id = Int32.Parse(Console.ReadLine());

            foreach (MyUser item in userList)
            {
                if (item.UserId == id)
                {
                    int numofTicks = item.NumOfTicketsBought;
                    Console.WriteLine("Number of tickets bought by user: " + numofTicks);
                    for (int i = 1; i <= numofTicks; i++)
                    {
                        Console.WriteLine("Ticket number: " + item.TicketNumbers[i]);
                    }
                   
                }
            }
        }
    }
}
