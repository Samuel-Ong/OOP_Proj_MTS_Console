//Student Number : S10171663,  s10171069
//Student name   : Samuel Ong, Seow Chong
//Module Group   : IT05
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



            while (true)
            {
                Menu();
                int option;
                try { option = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e) { Console.WriteLine("Invalid input"); continue; }
                switch (option)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Option1. List All Movies");
                        DisplayAllMovies(movieList);
                        Console.WriteLine();
                        break;
                    case 2:

                        int movieindex, cinemahallindex;
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Option 2. Add Movie Screening");
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
                        break;
                    case 3:
                        int movieChosen;
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Option3.List Movie Screenings");
                            Console.WriteLine();
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
                            foreach (Screening s in screeningList)
                            {
                                if (s.Movie.Title == movieList[movieChosen].Title)
                                {
                                    Console.WriteLine("{0,-15}{1,-6}{2,-25}{3}", s.CinemaHall.Name, s.ScreeningType, s.ScreeningDateTime.ToString("dd-MMM-yy hh:mm:ss tt", CultureInfo.InvariantCulture), s.SeatsRemaining);
                                }
                            }
                            Console.WriteLine();
                            break;
                        }
                        break;
                    case 4:
                        List<string> screennoList = new List<string>();
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Option4.Delete Movie Screening");
                            Console.WriteLine();
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
                            int e;
                            if (!int.TryParse(screenno, out e))
                            {
                                Console.WriteLine("Invalid Input");
                                continue;
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
    }
}
