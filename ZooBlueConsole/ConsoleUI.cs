using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using ZooBlue.Data;
using ZooBlue.Models.ZooModels;

namespace ZooBlueConsole
{
    public class ConsoleUI
    {
        HttpClient _client = new HttpClient();
        public void Run()
        {
            MainMenu();
        }

        public void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the ZooBlue API Console Application! Select an option below for your desired ZooLogical information! \n\n" +
                    "1. Zoo Information\n" +
                    "2. Attractions Information\n" +
                    "3. Reviews Information\n" +
                    "4. Help\n" +
                    "5. Exit\n");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ZooMenu();
                        break;
                    case "2":
                        AttractionMenu();
                        break;
                    case "3":
                        ReviewMenu();
                        break;
                    case "4":
                        HelpMenu();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ZooMenu()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("You can view all Zoos, view a specific Zoo, Add update or remove Zoos in the database!\n\n" +
                "1. View All Zoos\n" +
                "2. View Zoo By Id\n" +
                "3. Add New Zoo\n" +
                "4. Update Existing Zoo\n" +
                "5. Remove a Zoo from existence\n" +
                "6. Return to Main Menu\n" +
                "7. Exit\n");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewAllZoos();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        MainMenu();
                        break;
                    case "7":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                }
                Console.Clear();
            }
        }

        public void ViewAllZoos()
        {


            _client.BaseAddress = new Uri("https://localhost:44322/api/Zoo/");

            var responseTask = _client.GetAsync("Zoo");
            responseTask.Wait();
            var result = responseTask.Result;
            //Task<HttpResponseMessage> getTask = client.GetAsync("https://localhost:44322/api/Zoo/");
            //HttpResponseMessage result = getTask.Result;
            if (result.IsSuccessStatusCode)
            {
                //List<ZooListItems> zoos = client.GetAsync("https://localhost:44322/api/Zoo/").Result.Content.ReadAsAsync<List<ZooListItems>>().Result;
                var readTask = result.Content.ReadAsAsync<ZooListItems[]>();
                readTask.Wait();
                var zoos = readTask.Result;


                foreach (var zoo in zoos)
                {
                    Console.WriteLine($"Zoo ID: {zoo.ZooId}\n" +
                        $"Name: {zoo.ZooName}\n" +
                        $"Size: {zoo.ZooSize}\n" +
                        $"Location: {zoo.Location}\n" +
                        $"Admission: {zoo.Admission}\n" +
                        $"AZA Accredited: {zoo.AZAAccredited}\n" +
                        $"Average Rating: {zoo.AverageRating}\n");
                }

            }
            Console.ReadKey();
        }
        public void ViewZooById()
        {
            Console.Write("Enter Zoo ID: ");
            int userInput = int.Parse(Console.ReadLine());
            var readTask = _client.GetAsync("https://localhost:44322/api/Zoo/");
            var response = readTask.Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Clear();
                ZooListItems zoo = _client.GetAsync($"https://localhost:44322/api/Zoo/{userInput}").Result.Content.ReadAsAsync<ZooListItems>().Result;
                if(zoo !=null)
                        {
                    Console.WriteLine($"Zoo ID: {zoo.ZooId}\n" +
                        $"Name: {zoo.ZooName}\n" +
                        $"Size: {zoo.ZooSize}\n" +
                        $"Location: {zoo.Location}\n" +
                        $"Admission: {zoo.Admission}\n" +
                        $"AZA Accredited: {zoo.AZAAccredited}\n" +
                        $"Average Rating: {zoo.AverageRating}\n" +
                        $"{zoo.AttractionDetails}\n" +
                        $"{zoo.AllZooReviews}");
                }
            }
        }
        public void AttractionMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("You can view all Attractions, view a specific Attractions, Add update or remove Attractions in the database! Our attractions are a 1:1 Ratio with our Zoos, so we request you only create one Attraction per zoo. \n\n" +
                    "1. View All Attractions\n" +
                    "2. View Attractions By Id\n" +
                    "3. Add New Attraction\n" +
                    "4. Update Existing Attraction\n" +
                    "5. Remove a Attraction from existence\n" +
                    "6. Return to Main Menu\n" +
                    "7. Exit\n");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        MainMenu();
                        break;
                    case "7":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                }
                Console.Clear();
            }
        }
        public void ReviewMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("You can view all Review, view reviews for a specific Zoo, Add update or remove Reviews in the database!\n\n" +
                    "1. View All Reviews\n" +
                    "2. View Reviews By Zoo Id\n" +
                    "3. Add New Zoo Review\n" +
                    "4. Update Existing Review\n" +
                    "5. Remove a Review from existence\n" +
                    "6. Return to Main Menu\n" +
                    "7. Exit\n");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        MainMenu();
                        break;
                    case "7":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                }
                Console.Clear();
            }
        }

        public void HelpMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

            }
        }
    }
}
