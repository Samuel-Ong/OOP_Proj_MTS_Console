//============================================
//Student Number : S10171663,  s10171069
//Student Name   : Samuel Ong, Lim Seow Chong
//Module  Group  : IT05
//============================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticketing_System
{
    class Adult:Ticket
    {
        public bool PopcornOffer { get; set; }

        public Adult() { }
        public Adult(Screening screening, bool popcornoffer) : base(screening)
        {
            PopcornOffer = popcornoffer;
        }
        public override double CalculatePrice()
        {
            double totalprice = 0.0;
            //Pricing for the 3D movie
            if (Screening.ScreeningType == "3D")
            {
                //Pricing for the Days Friday - Sunday
                if (new List<DayOfWeek>() { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(Screening.ScreeningDateTime.DayOfWeek))
                {
                    totalprice = 14.00;
                }
                totalprice = 11.00;
            }
            else
            //Pricing for the 2D movies
            {
                if (new List<DayOfWeek>() { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(Screening.ScreeningDateTime.DayOfWeek))
                {
                    totalprice = 12.50;
                }
                totalprice = 8.50;
            }
            //Adding of Price of Popcorn
            if (PopcornOffer)
                totalprice += 3;
            return totalprice;
        }
        public override string ToString()
        {
            return base.ToString() + " PopcornOffer: " + PopcornOffer;
        }
    }
}
