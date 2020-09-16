# Zoological API

The Zoological API was created to house information about Zoos across the United States. The API has three primary database tables in addition to the user data. The main zoo table houses the basic information of the zoo pertaining to the name, location, size, and other basic info of the facility. The attraction table contains the details pertaining to the animals and other entertainment offerings of the zoo. The third main data table pertains to reviews of the zoo where a user can rate the zoo on a scale of 1 to 5, leave text comments, and recommend the zoo. 

This API is written in C#, an object-oriented programming language from Microsoft designed to work with their .Net platform. 



## Installation

Feel free to clone and explore the application:
Use the package manager [GitHub]( https://github.com/gth-softdev/ZooBlueBadge/) to install the Zoo API. Follow instructions on their page for various ways to clone this project or simply use your command prompt/terminal to navigate to the folder you wish to house the program and enter the line below.

Use Git or checkout with SVN using the web URL:
```bash
$ git clone https://github.com/gth-softdev/ZooBlueBadge.git
```



## Usage Directions

For the best experience using the Zoo API we recommend opening the program in the IDE or code editor of your choice, we utilize [Visual Studio Code]( https://code.visualstudio.com/). 

Next, run the program according to your IDE which will open the Zoo API Home Page within your designated web browser.

By clicking the API button in the top left of the navbar, the ASP.NET Web API Help Page will manifest and list all API endpoints and routes. We also have our endpoints listed per controller below, for simple ease of navigation. 

After this we utilize an API client for creating and reading the HTTP/s requests and responses. Our team enjoys the platform [Postman]( https://www.postman.com/) offers for API navigation and testing.

Utilize the base API address: https://localhost:44322 along with the endpoints listed below.

Explore the API at your whimsy!

**Note:** A console application is currently in the works and included in the solution. Please excuse the mess, finished Console TBD.



## Zoo API Database Endpoints

**Base Address:** https://localhost:44322

**Zoo** 
1) /api/Zoo -- 'POST' -- Create a "Zoo", the basic zoo information
2) /api/Zoo -- 'GET' -- Returns all zoos and their corresponding data, does not include attached attraction and review data
3) /api/Zoo/{id} -- 'GET' -- Returns a singular zoo and its data, includes attached attraction and review data
4) /api/Zoo -- 'PUT' -- Updates a zoo's information
5) /api/Zoo/{id} -- 'DELETE' -- Deletes the zoo specified by the ZooId

**Attraction** 

6) /api/attraction -- 'POST' -- Create an "Attraction", the data set pertaining to attractions at a singular zoo
7) /api/Attraction -- 'GET' -- Returns all attractions in the database
8) /api/Attraction/{id} -- 'GET' -- Returns a singular attraction and its data
9) /api/Attraction -- 'PUT' -- Updates the attraction's information
10) /api/Attraction/{id} -- 'DELETE' -- Delete attraction by the AttId


**Review**

11) /api/Review -- 'POST' -- Create a "Review", the information pertaining to guest experience
12) /api/Review -- 'GET' -- Get all reviews
13) /api/Review/{id} -- 'GET' -- Get a singular review
14) /api/Review -- 'PUT' -- Update a review's data
15) /api/Review/{id} -- 'DELETE' -- Delete a review by ReviewId



## Contributing
Pull requests are always welcome. For major changes to the API, please open an issue beforehand to discuss the changes you intend to make or feel the API needs.
Wiki repository being developed for more detailed documentation.



## License
[MIT](https://github.com/gth-softdev/ZooBlueBadge/blob/kate/MIT%20License.md)



## Authors of the Zoo API

* **Drew Graber** 
Drew is a hardworking and encouraging team player, who is currently enrolled in [Eleven Fifty Academy’s](https://elevenfifty.org/) Software Development Program. He has a flexible and dynamic skill set in C# which makes him an incredible asset to any software project. He also takes the time to support his teammates and create a beneficially fun environment for ideas and code creativity.

  Currently looking for any Software Web Dev job opportunities and experience.

  **LinkedIn:** [Drew Graber]( https://www.linkedin.com/in/drew-graber/)   **Portfolio:** [Drew Graber](https://dgraber27.github.io/Portfolio/)

* **Gary Holman**
Currently progressing through the [Eleven Fifty Academy]( https://elevenfifty.org/) Software Development program as well, Gary is an incredible member of any team. No matter what arises in the code or team dynamic, he can stead the ship. His knowledge of C# is always expanding as no challenge is too much for his work ethic and determination.

  Interested in any Software Web Dev job opportunities and experience.

  **LinkedIn:** [Gary Holman](https://www.linkedin.com/in/gary-holman-soft-dev/)   **Portfolio:** [Gary Holman](https://gth-softdev.github.io/Portfolio/)

* **Kate Lockhart**
A recent [Eleven Fifty Academy]( https://elevenfifty.org/) front end web development graduate, continuing her education with their software development program. She plays hard and works harder to always get the job done. She thrives in a solo or team dynamic, but enjoys the power in working together to create a well coded program.

   On the search for any Software or Front End Web Dev job opportunities and experience. 

   **LinkedIn:** [Kate Lockhart](https://www.linkedin.com/in/katelynlockhart/)   **Portfolio:** [Kate Lockhart](https://katelockhart.github.io/MyPortfolio/)

