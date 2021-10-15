using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp
{
    class MyUser
    {
        public bool IsAdmin { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public int HPnumber { get; set; }
        public bool LogedIn { get; set; }
        public int NumOfTicketsBought { get; set; }

        public List<int> TicketNumbers { get; set; }

        
    }
}
