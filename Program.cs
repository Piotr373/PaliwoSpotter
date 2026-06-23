using Azure.Core;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PaliwoSpotter
{
    internal class Program
    {
        public static T Verify<T>(string message) where T : ISpanParsable<T>
        {
            DisplayInCenter(message);
            while(true)
            {
                string? input = Console.ReadLine();
                if(!T.TryParse(input, null, out T? result))
                {
                    Console.WriteLine("Nieprawidlowy format danych."); 
                }
                else return result;
            }
        }
        public static void DisplayInCenter(string message)
        {
            int consoleWidth = Console.WindowWidth;
            int messageWidth = message.Length;
            int padding = (consoleWidth - messageWidth) / 2;
            Console.WriteLine(new string(' ', padding) + message);
        }
        public static void AddStation()
        {
            DisplayInCenter("Dodaj stację:");
            string adress = Verify<string>("Podaj adres:");
            string city = Verify<string>("Podaj miasto:");
            int brandID = Verify<int>("Podaj ID marki:");
            double latitude = Verify<double>("Podaj szerokość geograficzną:");
            double longitude = Verify<double>("Podaj długość geograficzną:");

            Station newStation = new Station
            {
                Adress = adress,
                City = city,
                BrandID = brandID,
                Location = new NetTopologySuite.Geometries.Point(longitude, latitude)
            };

            using var db = new AppDbContext();
            db.Stations.Add(newStation);
            db.SaveChanges();
            Console.WriteLine("Stacja została dodana pomyślnie!");


        }
        public static void RemoveStation()
        {
            DisplayInCenter("Usuń stację:");
            int stationID = Verify<int>("Podaj ID stacji do usunięcia:");
            using var db = new AppDbContext();
            var stationToRemove = db.Stations.Find(stationID);
            if (stationToRemove != null)
            {
                db.Stations.Remove(stationToRemove);
                db.SaveChanges();
                Console.WriteLine("Stacja została usunięta pomyślnie!");
            }
            else
            {
                Console.WriteLine("Nie znaleziono stacji o podanym ID.");
            }
        }
        public static void ReportFuelPrice()
        {
            DisplayInCenter("Raportuj cenę paliwa:");
            int stationID = Verify<int>("Podaj ID stacji:");
            int fuelTypeID = Verify<int>("Podaj ID rodzaju paliwa:");
            decimal price = Verify<decimal>("Podaj cenę paliwa:");
            PriceReport newReport = new PriceReport
            {
                StationID = stationID,
                FuelTypeID = fuelTypeID,
                Price = price,
                ReportedAt = DateTime.Now,
                ConfidenceScore = 1
            };
            using var db = new AppDbContext();
            db.PriceReports.Add(newReport);
            db.SaveChanges();
            Console.WriteLine("Cena paliwa została zgłoszona pomyślnie!");
        }
        public static void OverrideReportedPrice()
        {
            DisplayInCenter("Nadpisz zgłoszoną cenę paliwa:");
            int reportID = Verify<int>("Podaj ID raportu do nadpisania:");
            decimal newPrice = Verify<decimal>("Podaj nową cenę paliwa:");
            using var db = new AppDbContext();
            var reportToUpdate = db.PriceReports.Find(reportID);
            if (reportToUpdate != null)
            {
                reportToUpdate.Price = newPrice;
                db.SaveChanges();
                Console.WriteLine("Cena paliwa została nadpisana pomyślnie!");
            }
            else
            {
                Console.WriteLine("Nie znaleziono raportu o podanym ID.");
            }
        }
        public static void DisplayStations()
        {
            DisplayInCenter("Wyświetl stacje:");
            using var db = new AppDbContext();
            var stations = db.Stations.ToList();
            foreach (var station in stations)
            {
                Console.WriteLine($"ID: {station.StationID}, Adres: {station.Adress}, Miasto: {station.City}, Marka ID: {station.BrandID}, Lokalizacja: ({station.Location.X}, {station.Location.Y})");
            }
        }
        public static void DisplayFuelPrices()
        {
            DisplayInCenter("Wyświetl ceny paliw:");
            using var db = new AppDbContext();
            var reports = db.PriceReports.ToList();
            foreach (var report in reports)
            {
                Console.WriteLine($"ID Raportu: {report.PriceReportID}, ID Stacji: {report.StationID}, ID Rodzaju Paliwa: {report.FuelTypeID}, Cena: {report.Price}, Zgłoszono: {report.ReportedAt}");
            }
        }
        static void Main(string[] args)
        {
            DisplayInCenter("Main menu:");
            DisplayInCenter("1 - Dodaj pozycję");
            DisplayInCenter("2 - Raportuj cene:");
            DisplayInCenter("3 - Nadpisz zgłoszoną cenę");
            DisplayInCenter("4 - Usuń pozycję");
            DisplayInCenter("5 - Wyświetl stacje");
            DisplayInCenter("6 - Wyświetl ceny paliw");
            DisplayInCenter("7 - Wyjdź");

           
            while (true)
            {
                int a = Verify<int>("Wybierz opcje:");

                switch (a)
                {
                    case 1:
                        AddStation();
                        break;
                    case 2:
                        ReportFuelPrice();
                        break;
                    case 3:
                        OverrideReportedPrice();
                        break;
                    case 4:
                        RemoveStation();
                        break;
                    case 5:
                        DisplayStations();
                        break;
                    case 6:
                        DisplayFuelPrices();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Niepoprawna opcja");
                        break;
                }
            }
        }
        
}
}
