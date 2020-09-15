using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        //forces the program to be running 
        private bool _keepRunning = true;
        //creates bool for being logged in/out, start as out to force login
        private static bool _isLoggedIn = false;

        //HttpClient field needed to carry the auth and hold changes to the client
        private static readonly HttpClient _client = new HttpClient();

        //dclaring token for use in auth
        private static string _token;

        public void Run()
        {
            while (!_isLoggedIn)
                LoginMenu();
            MainMenu();
        }

        //A login menu to first run before MainMenu
        private void LoginMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "/n" +
                "/n" +
                "/n" +
                "Zoological API/n" +
                "/n" +
                "The API full of information on zoos around the country." +
                "/n" +
                "/n" +
                "/n" +
                "1. Create an Account/n" +
                "2. Login to Your Account/n" +
                "3. Exit Application/n" +
                "/n");

            Console.Write("Enter menu number: ");

            switch(Console.ReadLine())
            {
                case "1":
                    CreateAnAccount();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    Console.WriteLine("Goodbye");
                    _keepRunning = false;
                    break;
                default:
                    break;
            }
        }

        private void CreateAnAccount()
        {
            Console.Clear();
            Console.WriteLine("To create an account we need some basic information./n" +
                "Please enter your information below:" +
                "/n");

            Console.Write("Enter your Email: ");
            Dictionary<string, string> register = new Dictionary<string, string>
            {
                {"Email", Console.ReadLine() }
            };

            Console.Write("Create a Password: ");
            register.Add("Password", Console.ReadLine());

            Console.Write("Confirm your Password: ");
            register.Add("Password", Console.ReadLine());

            var registerNewAcct = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44322/api/Account/Register");
            registerNewAcct.Content = new FormUrlEncodedContent(register.AsEnumerable());
            var response = _client.SendAsync(registerNewAcct);

            if (response.IsCompleted)
                Console.WriteLine("/n" +
                    "You have created an account!/n" +
                    "Please return to the previous menu and login./n");
            else
                Console.WriteLine("/n" +
                    "I'm sorry, something went wrong while created your account./n" +
                    "Please try again./n");
            return;
        }

        private static async Task Login()
        {
            Console.Clear();
            Dictionary<string, string> login = new Dictionary<string, string>
            {
                {"grant_type", "password" }
            };

            Console.Write("Email: ");
            login.Add("Username", Console.ReadLine());

            Console.Write("Password: ");
            login.Add("Password", Console.ReadLine());

            //HttpClient httpClient = new HttpClient();
            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44331/token");
            tokenRequest.Content = new FormUrlEncodedContent(login.AsEnumerable());
            var response = await _client.SendAsync(tokenRequest);
            var tokenString = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<Token>(tokenString).Value;
            _token = token;
            tokenRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("\n" +
                    "Success, you are currrently logged in with a token.");
                //If loggin is successful using token to authorize http client
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                _isLoggedIn = true;
            }
            else
                Console.WriteLine("\n" +
                    "Login failed, please try again.");
            return;
        }

        //Class needed to etablish a token for login in the ConsoleUI
        public class Token
        {
            [JsonProperty("access_token")]
            public string Value { get; set; }
        }

        public void MainMenu()
        {
            while (_keepRunning)
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
                        _keepRunning = false;
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
