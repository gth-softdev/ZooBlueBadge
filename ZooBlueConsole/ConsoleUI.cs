using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using ZooBlue.Data;
using ZooBlue.Models;
using ZooBlue.Models.AttractionModels;
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
                Console.WriteLine("Welcome to the Zoo API Console Application! Select an option below for your desired ZooLogical information! \n\n" +
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
                        ViewZooById();
                        break;
                    case "3":
                        CreateNewZoo();
                        break;
                    case "4":
                        UpdateZoo();
                        break;
                    case "5":
                        DeleteZoo();
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
                if (zoo != null)
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
        public void CreateNewZoo()
        {
            Dictionary<string, string> newZoo = new Dictionary<string, string>();
            //Console.Write("Zoo ID: ");
            //string zooId = Console.ReadLine(); // Need to figure out how to make it automatically use the key  method for ZooId
            //newZoo.Add("ZooId", zooId);

            Console.Write("Name: ");
            string zooName = Console.ReadLine();
            newZoo.Add("Name", zooName);

            Console.Write("Size: ");
            int zooSize = int.Parse(Console.ReadLine());
            newZoo.Add("Size", zooSize.ToString());

            Console.Write("Location: ");
            string zooLocation = Console.ReadLine();
            newZoo.Add("Location", zooLocation);

            Console.Write("Admission: ");
            double zooAdmission = double.Parse(Console.ReadLine());
            newZoo.Add("Admission", zooAdmission.ToString());

            Console.Write("AZA Accredited: ");
            bool zooAZA = bool.Parse(Console.ReadLine());
            newZoo.Add("AZA Accredited", zooAZA.ToString());

            HttpContent newZooHTTP = new FormUrlEncodedContent(newZoo);

            var response = _client.PostAsync("https://localhost:44322/api/Zoo/", newZooHTTP);
            if (response.Result.IsSuccessStatusCode) { Console.WriteLine("Zoo Successfully Create"); }
            else { Console.WriteLine("Failed to create Zoo."); }
            Console.ReadKey();
        }

        public void UpdateZoo()
        {
            Console.Clear();
            Console.Write("Enter the Zoo ID for the Zoo You'd like to update: ");
            int id = int.Parse(Console.ReadLine());
            var getTask = _client.GetAsync("https://localhost:44322/api/Zoo/");
            var response = getTask.Result;
            ZooListItems oldZoo = new ZooListItems();
            if (response.IsSuccessStatusCode)
            {
                Console.Clear();
                oldZoo = _client.GetAsync("https://localhost:44322/api/Zoo/{id}").Result.Content.ReadAsAsync<ZooListItems>().Result;
                if (oldZoo != null)
                {
                    Console.WriteLine($"Zoo ID: {oldZoo.ZooId}\n" +
                        $"Name: {oldZoo.ZooName}\n" +
                        $"Size: {oldZoo.ZooSize}\n" +
                        $"Location: {oldZoo.Location}\n" +
                        $"Admission: {oldZoo.Admission}\n" +
                        $"AZA Accredited: {oldZoo.AZAAccredited}\n" +
                        $"Average Rating: {oldZoo.AverageRating}\n" +
                        $"{oldZoo.AttractionDetails}\n" +
                        $"{oldZoo.AllZooReviews}");
                }
                else { Console.WriteLine("The animals must have been hungry and ate that ID, please enter a valid Zoo ID."); }
            }
            Dictionary<string, string> newZoo = new Dictionary<string, string>();
            //Console.Write("Zoo ID: ");
            //string zooId = Console.ReadLine(); // Need to figure out how to make it automatically use the key  method for ZooId
            //newZoo.Add("ZooId", zooId);

            Console.Write("Name: ");
            string zooName = Console.ReadLine();
            newZoo.Add("Name", zooName);

            Console.Write("Size: ");
            int zooSize = int.Parse(Console.ReadLine());
            newZoo.Add("Size", zooSize.ToString());

            Console.Write("Location: ");
            string zooLocation = Console.ReadLine();
            newZoo.Add("Location", zooLocation);

            Console.Write("Admission: ");
            double zooAdmission = double.Parse(Console.ReadLine());
            newZoo.Add("Admission", zooAdmission.ToString());

            Console.Write("AZA Accredited: ");
            bool zooAZA = bool.Parse(Console.ReadLine());
            newZoo.Add("AZA Accredited", zooAZA.ToString());

            HttpContent newZooHTTP = new FormUrlEncodedContent(newZoo);

            var putResponse = _client.PostAsync("https://localhost:44322/api/Zoo/", newZooHTTP);
            if (putResponse.Result.IsSuccessStatusCode) { Console.WriteLine("Zoo Successfully Create"); }
            else { Console.WriteLine("Failed to create Zoo."); }
            Console.ReadKey();
        }

        public void DeleteZoo()
        {
            Console.Clear();
            Console.Write("Enter Zoo ID of the Zoo you'd like to delete.");
            int id = int.Parse(Console.ReadLine());
            var deleteTask = _client.DeleteAsync("https://localhost:44322/api/Zoo/{id}");
            var response = deleteTask.Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Zoo has been eliminated. Now the animals have no home. Are you happy now?");
            }
            else { Console.WriteLine("The animals must have been hungry and ate that ID, please enter a valid Zoo ID."); }
            Console.ReadKey();
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
                        ViewAllAttractions();
                        break;
                    case "2":
                        ViewAttractionById();
                        break;
                    case "3":
                        CreateNewAttraction();
                        break;
                    case "4":
                        UpdateAttraction();
                        break;
                    case "5":
                        DeleteAttraction();
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
        public void ViewAllAttractions()
        {

            _client.BaseAddress = new Uri("https://localhost:44322/api/Attraction/");

            var responseTask = _client.GetAsync("Attraction");
            responseTask.Wait();
            var result = responseTask.Result;
            //Task<HttpResponseMessage> getTask = client.GetAsync("https://localhost:44322/api/Attraction/");
            //HttpResponseMessage result = getTask.Result;
            if (result.IsSuccessStatusCode)
            {
                //List<ZooListItems> zoos = client.GetAsync("https://localhost:44322/api/Attraction/").Result.Content.ReadAsAsync<List<ZooListItems>>().Result;
                var readTask = result.Content.ReadAsAsync<AttractionListItems[]>();
                readTask.Wait();
                var attractions = readTask.Result;

                foreach (var attraction in attractions)
                {
                    Console.WriteLine($"Attraction ID: {attraction.AttId}\n" +
                        $"Zoo ID {attraction.ZooId}" +
                        $"Animals: {attraction.Animals}\n" +
                        $"Experiences: {attraction.Experiences}\n" +
                        $"Seasonal Attractions: {attraction.SeasonalAttractions}\n" +
                        $"Aquarium: {attraction.HasAquaticExhibit}\n" +
                        $"Garden: {attraction.HasGarden}\n");
                }
            }
            Console.ReadKey();
        }
        public void ViewAttractionById()
        {
            Console.Write("Enter Attraction ID: ");
            int userInput = int.Parse(Console.ReadLine());
            var readTask = _client.GetAsync("https://localhost:44322/api/Attraction/");
            var response = readTask.Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Clear();
                AttractionListItems attraction = _client.GetAsync($"https://localhost:44322/api/Attraction/{userInput}").Result.Content.ReadAsAsync<AttractionListItems>().Result;
                if (attraction != null)
                {
                    Console.WriteLine($"Attraction ID: {attraction.AttId}\n" +
                        $"Zoo ID {attraction.ZooId}" +
                        $"Animals: {attraction.Animals}\n" +
                        $"Experiences: {attraction.Experiences}\n" +
                        $"Seasonal Attractions: {attraction.SeasonalAttractions}\n" +
                        $"Aquarium: {attraction.HasAquaticExhibit}\n" +
                        $"Garden: {attraction.HasGarden}\n");
                }
            }
        }
        public void CreateNewAttraction()
        {
            Dictionary<string, string> newAttraction = new Dictionary<string, string>();
            Console.Write("Zoo ID: ");
            int zooId = int.Parse(Console.ReadLine());
            newAttraction.Add("ZooId", zooId.ToString());

            Console.Write("Animals: ");
            string animals = Console.ReadLine();
            newAttraction.Add("Animals", animals);

            Console.Write("Experiences: ");
            string experiences = Console.ReadLine();
            newAttraction.Add("Location", experiences);

            Console.Write("Seasonal Attractions: ");
            string seasonalAttractions = Console.ReadLine();
            newAttraction.Add("Seasonal Attractions", seasonalAttractions);

            Console.Write("Aquarium: ");
            bool aquarium = bool.Parse(Console.ReadLine());
            newAttraction.Add("Aquarium", aquarium.ToString());

            Console.Write("Garden: ");
            bool garden = bool.Parse(Console.ReadLine());
            newAttraction.Add("Garden", garden.ToString());

            HttpContent newAttractionHTTP = new FormUrlEncodedContent(newAttraction);

            var response = _client.PostAsync("https://localhost:44322/api/Attraction/", newAttractionHTTP);
            if (response.Result.IsSuccessStatusCode) { Console.WriteLine("Attraction Successfully Create"); }
            else { Console.WriteLine("Failed to create Attraction."); }
            Console.ReadKey();
        }

        public void UpdateAttraction()
        {
            Console.Clear();
            Console.Write("Enter the Zoo ID for the Zoo You'd like to update: ");
            int id = int.Parse(Console.ReadLine());
            var getTask = _client.GetAsync("https://localhost:44322/api/Attraction/");
            var response = getTask.Result;
            AttractionListItems oldAttraction = new AttractionListItems();
            if (response.IsSuccessStatusCode)
            {
                Console.Clear();
                oldAttraction = _client.GetAsync("https://localhost:44322/api/Atraction/{id}").Result.Content.ReadAsAsync<AttractionListItems>().Result;
                if (oldAttraction != null)
                {
                    Console.WriteLine($"Attraction ID: {oldAttraction.AttId}\n" +
                        $"Zoo ID {oldAttraction.ZooId}" +
                        $"Animals: {oldAttraction.Animals}\n" +
                        $"Experiences: {oldAttraction.Experiences}\n" +
                        $"Seasonal Attractions: {oldAttraction.SeasonalAttractions}\n" +
                        $"Aquarium: {oldAttraction.HasAquaticExhibit}\n" +
                        $"Garden: {oldAttraction.HasGarden}\n");
                }
                else { Console.WriteLine("The animals must have been hungry and ate that ID, please enter a valid Zoo ID."); }
            }
            Dictionary<string, string> newAttraction = new Dictionary<string, string>();
            //Console.Write("Zoo ID: ");
            //string zooId = Console.ReadLine(); // Need to figure out how to make it automatically use the key  method for ZooId
            //newZoo.Add("ZooId", zooId);

            Console.Write("Zoo ID: ");
            int zooId = int.Parse(Console.ReadLine());
            newAttraction.Add("ZooId", zooId.ToString());

            Console.Write("Animals: ");
            string animals = Console.ReadLine();
            newAttraction.Add("Animals", animals);

            Console.Write("Experiences: ");
            string experiences = Console.ReadLine();
            newAttraction.Add("Location", experiences);

            Console.Write("Seasonal Attractions: ");
            string seasonalAttractions = Console.ReadLine();
            newAttraction.Add("Seasonal Attractions", seasonalAttractions);

            Console.Write("Aquarium: ");
            bool aquarium = bool.Parse(Console.ReadLine());
            newAttraction.Add("Aquarium", aquarium.ToString());

            Console.Write("Garden: ");
            bool garden = bool.Parse(Console.ReadLine());
            newAttraction.Add("Garden", garden.ToString());

            HttpContent newAttractionHTTP = new FormUrlEncodedContent(newAttraction);

            var putResponse = _client.PostAsync("https://localhost:44322/api/Attraction/", newAttractionHTTP);
            if (putResponse.Result.IsSuccessStatusCode) { Console.WriteLine("Attraction Successfully Create"); }
            else { Console.WriteLine("Failed to create Attraction."); }
            Console.ReadKey();
        }

        public void DeleteAttraction()
        {
            Console.Clear();
            Console.Write("Enter Attraction ID of the Attraction you'd like to delete.");
            int id = int.Parse(Console.ReadLine());
            var deleteTask = _client.DeleteAsync("https://localhost:44322/api/Attraction/{id}");
            var response = deleteTask.Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Attraction has been eliminated. Now the zoo is empty and depressing.");
            }
            else { Console.WriteLine("The animals must have been hungry and ate that ID, please enter a valid Attraction ID."); }
            Console.ReadKey();
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
                        ViewAllReviews();
                        break;
                    case "2":
                        ViewReviewById();
                        break;
                    case "3":
                        CreateNewReview();
                        break;
                    case "4":
                        UpdateReview();
                        break;
                    case "5":
                        DeleteReview();
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
        public void ViewAllReviews()
        {

            _client.BaseAddress = new Uri("https://localhost:44322/api/Review/");

            var responseTask = _client.GetAsync("Review");
            responseTask.Wait();
            var result = responseTask.Result;
            //Task<HttpResponseMessage> getTask = client.GetAsync("https://localhost:44322/api/Review/");
            //HttpResponseMessage result = getTask.Result;
            if (result.IsSuccessStatusCode)
            {
                //List<ZooListItems> zoos = client.GetAsync("https://localhost:44322/api/Review/").Result.Content.ReadAsAsync<List<ZooListItems>>().Result;
                var readTask = result.Content.ReadAsAsync<ReviewDetail[]>();
                readTask.Wait();
                var reviews = readTask.Result;

                foreach (var review in reviews)
                {
                    Console.WriteLine($"Review ID: {review.ReviewId}\n" +
                        $"Zoo ID {review.ZooId}" +
                        $"Rating: {review.Rating}\n" +
                        $"Review Text: {review.ReviewText}\n" +
                        $"VisitDate: {review.VisitDate}\n");
                }
            }
            Console.ReadKey();
        }
        public void ViewReviewById()
        {
            Console.Write("Enter Zoo ID: ");
            int userInput = int.Parse(Console.ReadLine());
            var readTask = _client.GetAsync("https://localhost:44322/api/Review/");
            var response = readTask.Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Clear();
                ReviewDetail review = _client.GetAsync($"https://localhost:44322/api/Review/{userInput}").Result.Content.ReadAsAsync<ReviewDetail>().Result;
                if (review != null)
                {
                    Console.WriteLine($"Review ID: {review.ReviewId}\n" +
                        $"Zoo ID {review.ZooId}" +
                        $"Rating: {review.Rating}\n" +
                        $"Review Text: {review.ReviewText}\n" +
                        $"VisitDate: {review.VisitDate}\n");
                }
            }
        }
        public void CreateNewReview()
        {
            Dictionary<string, string> newReview = new Dictionary<string, string>();
            Console.Write("Zoo ID: ");
            int zooId = int.Parse(Console.ReadLine());
            newReview.Add("ZooId", zooId.ToString());

            Console.Write("Rating: ");
            int rating = int.Parse(Console.ReadLine());
            newReview.Add("Rating", rating.ToString());

            Console.Write("Review Text: ");
            string reviewText = Console.ReadLine();
            newReview.Add("Review Text", reviewText);

            Console.Write("Date of Visit: ");
            DateTime visitDate = DateTime.Parse(Console.ReadLine());
            newReview.Add("Date of Visit", visitDate.ToString()) ;

            HttpContent newReviewHTTP = new FormUrlEncodedContent(newReview);

            var response = _client.PostAsync("https://localhost:44322/api/Review/", newReviewHTTP);
            if (response.Result.IsSuccessStatusCode) { Console.WriteLine("Review Successfully Create"); }
            else { Console.WriteLine("Failed to create Review."); }
            Console.ReadKey();
        }

        public void UpdateReview()
        {
            Console.Clear();
            Console.Write("Enter the Review ID for the Review You'd like to update: ");
            int id = int.Parse(Console.ReadLine());
            var getTask = _client.GetAsync("https://localhost:44322/api/Review/");
            var response = getTask.Result;
            ReviewDetail oldReview = new ReviewDetail();
            if (response.IsSuccessStatusCode)
            {
                Console.Clear();
                oldReview = _client.GetAsync("https://localhost:44322/api/Review/{id}").Result.Content.ReadAsAsync<ReviewDetail>().Result;
                if (oldReview != null)
                {
                    Console.WriteLine($"Review ID: {oldReview.ReviewId}\n" +
                        $"Zoo ID {oldReview.ZooId}" +
                        $"Rating: {oldReview.Rating}\n" +
                        $"Review Text: {oldReview.ReviewText}\n" +
                        $"VisitDate: {oldReview.VisitDate}\n");
                }
                else { Console.WriteLine("The animals must have been hungry and ate that ID, please enter a valid Review ID."); }
            }
            //Console.Write("Zoo ID: ");
            //string zooId = Console.ReadLine(); // Need to figure out how to make it automatically use the key  method for ZooId
            //newZoo.Add("ZooId", zooId);

            Dictionary<string, string> newReview = new Dictionary<string, string>();
            Console.Write("Zoo ID: ");
            int zooId = int.Parse(Console.ReadLine());
            newReview.Add("ZooId", zooId.ToString());

            Console.Write("Rating: ");
            int rating = int.Parse(Console.ReadLine());
            newReview.Add("Rating", rating.ToString());

            Console.Write("Review Text: ");
            string reviewText = Console.ReadLine();
            newReview.Add("Review Text", reviewText);

            Console.Write("Date of Visit: ");
            DateTime visitDate = DateTime.Parse(Console.ReadLine());
            newReview.Add("Date of Visit", visitDate.ToString());

            HttpContent newReviewHTTP = new FormUrlEncodedContent(newReview);

            var putResponse = _client.PostAsync("https://localhost:44322/api/Review/", newReviewHTTP);
            if (putResponse.Result.IsSuccessStatusCode) { Console.WriteLine("Review Successfully Created."); }
            else { Console.WriteLine("Failed to create Review."); }
            Console.ReadKey();
        }

        public void DeleteReview()
        {
            Console.Clear();
            Console.Write("Enter Review ID of the Review you'd like to delete.");
            int id = int.Parse(Console.ReadLine());
            var deleteTask = _client.DeleteAsync("https://localhost:44322/api/Review/{id}");
            var response = deleteTask.Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Review has been eliminated. No one will ever no about that missed comma.");
            }
            else { Console.WriteLine("The animals must have been hungry and ate that ID, please enter a valid Review ID."); }
            Console.ReadKey();
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
