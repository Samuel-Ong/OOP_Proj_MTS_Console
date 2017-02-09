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
    class Screening
    {
        private static int screeningCount { get; set; } = 1001;
        public string ScreeningNo { get; set; }
        public DateTime ScreeningDateTime { get; set; }
        private string screeningType;
        public string ScreeningType
        { 
            get { return screeningType; }
            set { if (value == "2D" || value == "3D") screeningType = value; }
        }


        public int SeatsRemaining { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public Movie Movie { get; set; }

        public Screening() { }
        public Screening(DateTime screeningdatetime, string screeningtype, CinemaHall cinemahall, Movie movie)
        {
            ScreeningNo = Convert.ToString(screeningCount);
            screeningCount++;
            ScreeningDateTime = screeningdatetime;
            ScreeningType = screeningtype;
            CinemaHall = cinemahall;
            Movie = movie;
            SeatsRemaining = cinemahall.Capacity;
        }
        public override string ToString()
        {
            return "ScreeningDateTime: " + ScreeningDateTime + " Type: " + ScreeningType + " Cinema Hall: " + CinemaHall + " Movie " + Movie;
        }
    }
}
