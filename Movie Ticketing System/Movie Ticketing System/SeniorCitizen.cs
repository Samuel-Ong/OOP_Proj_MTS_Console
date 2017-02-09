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
    class SeniorCitizen:Ticket
    {
        public int YearOfBirth { get; set; }

        public SeniorCitizen() { }
        public SeniorCitizen(Screening screening, int yearofbirth) : base(screening)
        {
            YearOfBirth = yearofbirth;
        }
        public override double CalculatePrice()
        {
            //Check if Screening is 7 days before Movie opening
            if ((Screening.ScreeningDateTime - Screening.Movie.OpeningDate).TotalDays <= 7)
            {
                //Pricing for the 3D screening
                if (Screening.ScreeningType == "3D")
                {
                    //Pricing for the Days Friday - Sunday
                    if (new List<DayOfWeek>() { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(Screening.ScreeningDateTime.DayOfWeek))
                    {
                        return 14.00;
                    }
                    return 11.00;
                }
                //Pricing for the 2D screening
                else
                {
                    if (new List<DayOfWeek>() { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(Screening.ScreeningDateTime.DayOfWeek))
                    {
                        return 12.50;
                    }
                    return 8.50;
                }
            }
            //Screening more than 7 days after Movie opening
            else
            {
                if (Screening.ScreeningType == "3D")
                {
                    if (new List<DayOfWeek>() { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(Screening.ScreeningDateTime.DayOfWeek))
                    {
                        return 14.00;
                    }
                    return 6.00;
                }
                else
                {
                    if (new List<DayOfWeek>() { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(Screening.ScreeningDateTime.DayOfWeek))
                    {
                        return 12.50;
                    }
                    return 5.00;
                }
            }
        }
        public override string ToString()
        {
            return base.ToString() + " YearOfBirth: " + YearOfBirth;
        }
    }
}
