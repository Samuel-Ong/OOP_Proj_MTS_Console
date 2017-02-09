﻿//=======================================
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
    abstract class Ticket
    {
        public Screening Screening { get; set; }

        public Ticket() { }
        public Ticket(Screening screening)
        {
            Screening = screening;
        }
        public abstract double CalculatePrice();
        public override string ToString()
        {
            return "Ticket Screening:\n" + Screening.ToString();
        }
    }
}
