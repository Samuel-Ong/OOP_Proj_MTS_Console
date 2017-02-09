//=======================================
//Student Number : S10171663,  s10171069
//Student Name   : Samuel Ong, Lim Seow Chong
//Module  Group  : IT05
//=======================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticketing_System
{
    class Order
    {
        private int orderCount { get; set; } = 1;
        private string status = "Unpaid";
        public string OrderNo { get; set; }
        public DateTime OrderDateTime { get; set; } = DateTime.Today;
        public double Amount { get; set; } = 0;
        public string Status
        {
            get { return status; }
            set
            {
                if (new List<string>() { "Unpaid", "Paid" }.Contains(value))
                {
                    status = value;
                }
            }
        }
        private List<Ticket> TicketList = new List<Ticket>();

        public Order() { OrderNo = Convert.ToString(orderCount); orderCount++; }
        public void AddTicket(Ticket ticket)
        {
            TicketList.Add(ticket);
            Amount += ticket.CalculatePrice();
        }
        public List<Ticket> GetTicketList()
        {
            return TicketList;
        }
        public override string ToString()
        {
            return "OrderNo: " + OrderNo + " OrderDateTime" + OrderDateTime + " Amount: " + Amount + " Status: " + Status;
        }
    }
}
