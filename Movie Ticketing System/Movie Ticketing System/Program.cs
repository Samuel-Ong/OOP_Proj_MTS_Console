﻿//=======================================
//Student Number : S10171663,  s10171069
//Student name   : Samuel Ong, Seow Chong
//Module Group   : IT05
//=======================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Movie_Ticketing_System
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CinemaHall> cinemaHallList = new List<CinemaHall>()
            {
                new CinemaHall("Singa North", 1, 30),
                new CinemaHall("Singa North", 2, 10),
                new CinemaHall("Singa West", 1, 50),
                new CinemaHall("Singa East", 1, 5),
                new CinemaHall("Singa Central", 1, 20),
                new CinemaHall("Singa Central", 2, 15)
            };

            List<Movie> movieList = new List<Movie>()
            {
                new Movie("The Great Wall", 103, "NC16", new DateTime(2016, 12, 29), new List<string>() { "Action", "Adventure" }),
                new Movie("Rouge One: A Star Wars Story", 134, "PG13", new DateTime(2016, 12, 15), new List<string>() { "Action", "Adventure" }),
                new Movie("Office Christmas Party", 106, "M18", new DateTime(2017, 01, 15), new List<string>() { "Comedy" }),
                new Movie("Power Rangers", 120, "G", new DateTime(2017, 01, 31), new List<string>() { "Fantasy", "Thriller" })
            };

            List<Screening> screeningList = new List<Screening>()
            {
                new Screening(new DateTime(2016, 12, 29, 15, 00, 00), "3D", cinemaHallList[2], movieList[0]),
                new Screening(new DateTime(2017, 01, 03, 13, 00, 00), "2D", cinemaHallList[3], movieList[1]),
                new Screening(new DateTime(2017, 01, 31, 19, 00, 00), "3D", cinemaHallList[0], movieList[3]),
                new Screening(new DateTime(2017, 02, 02, 15, 00, 00), "2D", cinemaHallList[1], movieList[3])
            };
            List<string> screennoList = new List<string>();
            foreach (Screening s in screeningList)
            {
                screennoList.Add(s.ScreeningNo);
            }

            List<Order> orderList = new List<Order>();
            while (true)
            {
                Menu();
                int option;
                try { option = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e) { Console.WriteLine("Invalid input"); continue; }
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nOption1. List All Movies\n");
                        DisplayAllMovies(movieList);
                        Console.WriteLine();
                        break;
                    case 2:
                        AddMovieScreening(movieList, screeningList, cinemaHallList);
                        break;
                    case 3:
                        ListMovieScreenings(movieList, screeningList);
                        break;
                    case 4:
                        DeleteMovieScreening(movieList, screeningList, screennoList);
                        break;
                    case 5:
                        OrderTicket(movieList, screeningList, orderList, screennoList);
                        break;
                    case 6:
                        AddMovieRating(movieList);
                        break;
                    case 7:
                        ViewRatingComment(movieList);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }



        static void Menu()
        {
            Console.Write(@"      Movie Ticketing System
=================================
1.  List all movies
2.  Add a movie screening session
3.  List movie screenings
4.  Delete a movie screening session
5.  Order movie ticket/s
6.  Add a movie rating
7.  View movie ratings and comments
8.  Recommend movies
0.  Exit
=================================
Enter your option:");
        }


        static void DisplayAllMovies(List<Movie> movieList)
        {
            Console.WriteLine("{0,-4}{1,-30}{2,-10}{3,-20}{4,-16}{5}", "No", "Title", "Duration", "Genre", "Classification", "Opening Date");
            string moviegenre;
            for (int i = 0; i < movieList.Count; i++)
            {
                moviegenre = movieList[i].GenreList[0];
                for (int ii = 1; ii < movieList[i].GenreList.Count; ii++)
                {
                    moviegenre += ", " + movieList[i].GenreList[ii];
                }
                Console.WriteLine("{0,-4}{1,-30}{2,-10}{3,-20}{4,-16}{5}", i + 1, movieList[i].Title, movieList[i].Duration, moviegenre, movieList[i].Classification, movieList[i].OpeningDate.ToString("dd-MMM-yy", CultureInfo.InvariantCulture));
            }
        }


        static void DisplayAllCinemaHall(List<CinemaHall> cinemaHallList)
        {
            Console.WriteLine("{0,-3}{1,-14}{2,-9}{3}", "No", "Cinema Name", "HallNo", "Capacity");
            for (int i = 0; i < cinemaHallList.Count; i++)
            {
                Console.WriteLine("{0,-3}{1,-14}{2,-9}{3}", i + 1, cinemaHallList[i].Name, cinemaHallList[i].HallNo, cinemaHallList[i].Capacity);
            }
        }

        static void DisplayScreenings(List<Screening> screeningList)
        {
            Console.WriteLine("{0,-6}{1,-15}{2,-10}{3,-30}{4}", "No", "Location", "Hall No", "Title", "Date/Time");
            for (int i = 0; i < screeningList.Count; i++)
            {
                Console.WriteLine("{0,-6}{1,-15}{2,-10}{3,-30}{4}", i + 1001, screeningList[i].CinemaHall.Name, screeningList[i].CinemaHall.HallNo, screeningList[i].Movie.Title, screeningList[i].ScreeningDateTime.ToString("dd-MMM-yy hh:mm:ss tt", CultureInfo.InvariantCulture));
            }
        }

        static void AddMovieScreening(List<Movie> movieList, List<Screening> screeningList, List<CinemaHall> cinemaHallList)
        {
            while (true)
            {
                int cinemahallindex, movieindex;
                Console.WriteLine("\nOption 2. Add Movie Screening\n");
                DisplayAllCinemaHall(cinemaHallList);
                Console.Write("Select a cinema hall: ");
                try { cinemahallindex = Convert.ToInt32(Console.ReadLine()) - 1; }
                catch (Exception e)
                {
                    Console.WriteLine("Cinema Hall Only");
                    continue;
                }
                if (0 > cinemahallindex || cinemahallindex >= cinemaHallList.Count)
                {
                    Console.WriteLine("Invalid Cinema Hall");
                    continue;
                }

                Console.WriteLine();
                DisplayAllMovies(movieList);
                Console.Write("Select a movie: ");
                try { movieindex = Convert.ToInt32(Console.ReadLine()) - 1; }
                catch (Exception e)
                {
                    Console.WriteLine("MovieNo Only");
                    continue;
                };
                if (0 > movieindex || movieindex >= movieList.Count)
                {
                    Console.WriteLine("Invalid Movie");
                    continue;
                }

                Console.Write("\nSelect a screening type [2D/3D]: ");
                string Type = Console.ReadLine();
                if (Type != "2D" && Type != "3D")
                {
                    Console.WriteLine("Invalid Screening Type");
                    continue;
                }

                Console.Write("Enter a screening date and time [e.g. 01/01/2017 18:59](24 Hour format): ");
                DateTime Sdatetime;
                try { Sdatetime = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture); }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }

                Screening s = new Screening(Sdatetime, Type, cinemaHallList[cinemahallindex], movieList[movieindex]);
                screeningList.Add(s);
                Console.WriteLine("Movie screening successfully created.");
                break;
            }
        }

        static void ListMovieScreenings(List<Movie> movieList, List<Screening> screeningList)
        {
            while (true)
            {
                int movieChosen;
                Console.WriteLine("\nOption3.List Movie Screenings\n");
                DisplayAllMovies(movieList);
                Console.Write("Select a movie: ");
                try { movieChosen = Convert.ToInt32(Console.ReadLine()) - 1; }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                if (0 > movieChosen || movieChosen >= movieList.Count)
                {
                    Console.WriteLine("Invalid Movie");
                    continue;
                }
                Console.WriteLine();
                Console.WriteLine("{0,-15}{1,-6}{2,-25}{3}", "Location", "Type", "Date/Time", "Seats Remaining");
                bool found = false;
                foreach (Screening s in screeningList)
                {
                    if (s.Movie.Title == movieList[movieChosen].Title)
                    {
                        Console.WriteLine("{0,-15}{1,-6}{2,-25}{3}", s.CinemaHall.Name, s.ScreeningType, s.ScreeningDateTime.ToString("dd-MMM-yy hh:mm:ss tt", CultureInfo.InvariantCulture), s.SeatsRemaining);
                        found = true;
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("No screenings available");
                    break;
                }
                Console.WriteLine();
                break;
            }
        }

        static void DeleteMovieScreening(List<Movie> movieList, List<Screening> screeningList, List<string> screennoList)
        {
            while (true)
            {
                Console.WriteLine("\nOption4.Delete Movie Screening\n");
                Console.WriteLine("{0,-6}{1,-15}{2,-8}{3,-30}{4}", "No", "Location", "Hall No", "Title", "Date/Time");
                foreach (Screening s in screeningList)
                {
                    if (s.SeatsRemaining == s.CinemaHall.Capacity)
                    {
                        screennoList.Add(s.ScreeningNo);
                        Console.WriteLine("{0,-6}{1,-15}{2,-8}{3,-30}{4}", s.ScreeningNo, s.CinemaHall.Name, s.CinemaHall.HallNo, s.Movie.Title, s.ScreeningDateTime.ToString("dd-MMM-yy hh:mm:ss tt", CultureInfo.InvariantCulture));
                    }
                }
                Console.Write("Enter a screening number to delete: ");
                string screenno = Console.ReadLine();
                int temp;
                if (!int.TryParse(screenno, out temp))
                {
                    Console.WriteLine("Invalid Session");
                }
                if (screennoList.Contains(screenno))
                {
                    screeningList.RemoveAt(screennoList.IndexOf(screenno));
                    Console.WriteLine("Screening Deleted");
                }
                else
                {
                    Console.WriteLine("Invalid Screening");
                    continue;
                }
                Console.WriteLine();
                break;
            }
        }

        static void OrderTicket(List<Movie> movieList, List<Screening> screeningList, List<Order> orderList, List<string> screennoList)
        {
            while (true)
            {
                int movieChosen, noticket;
                List<Ticket> ticketList = new List<Ticket>();
                Screening screening;
                //Movie
                Console.WriteLine("\nOption5. Order Movie Tickets\n");
                DisplayAllMovies(movieList);
                Console.Write("Select a movie: ");
                try { movieChosen = Convert.ToInt32(Console.ReadLine()) - 1; }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                if (0 > movieChosen || movieChosen >= movieList.Count)
                {
                    Console.WriteLine("Invalid Movie");
                    continue;
                }

                //Screening
                Console.WriteLine("\n{0,-15}{1,-6}{2,-25}{3}", "Location", "Type", "Date/Time", "Seats Remaining");
                bool found = false;
                foreach (Screening s in screeningList)
                {
                    if (s.Movie.Title == movieList[movieChosen].Title)
                    {
                        if (s.SeatsRemaining > 0)
                        {
                            Console.WriteLine("{0,-7}{1,-15}{2,-6}{3,-25}{4}", s.ScreeningNo, s.CinemaHall.Name, s.ScreeningType, s.ScreeningDateTime.ToString("dd-MMM-yy hh:mm:ss tt", CultureInfo.InvariantCulture), s.SeatsRemaining);
                            found = true;
                        }
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("No screenings available");
                    continue;
                }
                Console.Write("Select a session: ");
                string screenno = Console.ReadLine();
                int temp;
                if (!int.TryParse(screenno, out temp))
                {
                    Console.WriteLine("Invalid Session");
                    continue;
                }
                if (!screennoList.Contains(screenno))
                {
                    Console.WriteLine("Invalid Screening");
                    continue;
                }
                else { screening = screeningList[screennoList.IndexOf(screenno)]; }

                //Ticket
                Console.Write("Please enter number of tickets you wish to purchase: ");
                try { noticket = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                Console.Write("The movie classification is " + movieList[movieChosen].Classification + ". Does every ticket holder meet the age requirements [Y/N]? ");
                string requirements = Console.ReadLine();
                if (requirements != "Y" && requirements != "N")
                {
                    Console.WriteLine("Invalid Response");
                    continue;
                }
                if (requirements == "N")
                {
                    Console.WriteLine("Unable to order tickets from this movie. Try another movie.");
                    continue;
                }

                Order CurrOrder = new Order();
                for (int i = 0; i < noticket; i++)
                {
                    while (true)
                    {
                        Console.WriteLine("Ticket #{0}", i + 1);
                        Console.Write("Type of ticket to purchase [Student/Senior/Adult]: ");
                        string cat = Console.ReadLine();
                        if (cat == "Senior")
                        {
                            SeniorTicket(CurrOrder, screening, i + 1);
                        }
                        else if (cat == "Student")
                        {
                            StudentTicket(CurrOrder, screening, i + 1);
                        }
                        else if (cat == "Adult")
                        {
                            AdultTicket(CurrOrder, screening, i + 1);
                        }
                        else { Console.WriteLine("Invalid option"); continue; }
                        Console.WriteLine();
                        break;
                    }
                }
                Console.Write("Order #{0}\n=========\nMovie Title: {1}\nCinema: {2}\nHall: {3}\nDate/Time: {4}\n\nTotal: ${5:0.00}\n=========\nPress any key to make payment...", CurrOrder.OrderNo, CurrOrder.GetTicketList()[0].Screening.Movie.Title, CurrOrder.GetTicketList()[0].Screening.CinemaHall.Name, CurrOrder.GetTicketList()[0].Screening.CinemaHall.HallNo, CurrOrder.GetTicketList()[0].Screening.ScreeningDateTime, CurrOrder.Amount);
                Console.ReadLine();
                Console.WriteLine("Thank you for visiting Singa Cineplexes. Have a great movie!");
                break;
            }
        }

        static void SeniorTicket(Order CurrOrder, Screening screening, int ticketno)
        {
            while (true)
            {
                Console.Write("Please enter year of birth [YYYY]: ");
                DateTime YOB;
                try { YOB = DateTime.ParseExact(Console.ReadLine(), "yyyy", CultureInfo.InvariantCulture); }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Year Of Birth");
                    continue;
                }
                if (DateTime.Today.Year - YOB.Year < 55)
                {
                    Console.WriteLine("Only ages 55 and above are considered Elderly\nYou'll be considered as an Adult");
                    AdultTicket(CurrOrder, screening, ticketno);
                    break;
                }
                CurrOrder.AddTicket(new SeniorCitizen(screening, YOB.Year));
                Console.WriteLine("Ticket #{0} has been ordered successfully", ticketno);
                break;
            }
        }

        static void StudentTicket(Order CurrOrder, Screening screening, int ticketno)
        {
            while (true)
            {
                Console.Write("Please enter the level of study[Primary/Secondary/Teriary]: ");
                string levelofStudy = Console.ReadLine();
                if (!new List<string>() { "Primary", "Secondary", "Teriary"}.Contains(levelofStudy)) { Console.WriteLine("Invalid level of study"); continue; }
                CurrOrder.AddTicket(new Student(screening, levelofStudy));
                Console.WriteLine("Ticket #{0} has been ordered successfully", ticketno);
                break;
            }
        }

        static void AdultTicket(Order CurrOrder, Screening screening, int ticketno)
        {
            while (true)
            {
                bool buyPopcorn = false;
                Console.Write("You're entitled to a $3 discount off the Popcorn Set.\n Do you want to purchase the Popcorn Set? [Y/N] ");
                string userinput = Console.ReadLine();
                if ( userinput == "Y") { buyPopcorn = true; }
                else if (userinput != "N") { Console.WriteLine("Invalid input"); continue; }
                CurrOrder.AddTicket(new Adult(screening, buyPopcorn));
                Console.WriteLine("Ticket #{0} has been ordered successfully", ticketno);
                break;
            }
        }

        static void AddMovieRating(List<Movie> movieList)
        {
            while (true)
            {
                int movieNo, rating;
                Console.WriteLine("\nOption 6. Add Movie Rating\n");
                DisplayAllMovies(movieList);
                Console.Write("\nEnter a movie number to review the movie: ");
                try { movieNo = Convert.ToInt32(Console.ReadLine()) - 1; }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                if (0 > movieNo || movieNo >= movieList.Count)
                {
                    Console.WriteLine("Invalid Movie");
                    continue;
                }
                Console.WriteLine("The current rating for {0} is {1}", movieList[movieNo].Title, movieList[movieNo].Rating);
                Console.Write("\nPlease enter a rating [0=Very bad; 5=Very good]: ");
                try { rating = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter the rating number");
                    continue;
                }
                if (rating < 0 || rating > 5)
                {
                    Console.WriteLine("Please enter a rating from 0 to 5 only");
                    continue;
                }
                Console.Write("Please enter comments about the movie: ");
                movieList[movieNo].Rating = (movieList[movieNo].Rating * movieList[movieNo].CommentList.Count() + rating) / (movieList[movieNo].CommentList.Count() + 1);
                movieList[movieNo].CommentList.Add(Console.ReadLine());
                Console.WriteLine("\nThank you for your submission");
                Console.WriteLine("The new rating for the movie is {0}", movieList[movieNo].Rating);
                break;
            }
        }
        
        static void ViewRatingComment(List<Movie> movieList)
        {
            while (true)
            {
                int movieNo;
                Console.WriteLine("\nOption 7. View Movie Ratings and Comments\n");
                DisplayAllMovies(movieList);
                Console.WriteLine();
                Console.Write("Enter a movie number to review the movie: ");
                try { movieNo = Convert.ToInt32(Console.ReadLine()) - 1; }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                if (0 > movieNo || movieNo >= movieList.Count)
                {
                    Console.WriteLine("Invalid Movie");
                    continue;
                }
                Console.WriteLine("The rating for {0} is {1}", movieList[movieNo].Title, movieList[movieNo].Rating);
                for (int i = 0; i < movieList[movieNo].CommentList.Count; i++)
                {
                    Console.WriteLine("Comment #{0} : {1}", i + 1, movieList[movieNo].CommentList[i]);
                }
                Console.WriteLine();
                break;
            }
        }
    }
}
