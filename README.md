# Lab11 - Time Persons of the Year
> Simple MVC web application that renders a web page with two page views - an Index page that displays a rough mockup of the Time magazine cover with a year range input form, and a Results page that displays Time's persons of the year for that range.

This web application is built on ASP.NET MVC principles. All "page" views are in fact requests to the same server, which uses the a Controller to route the requests, a Model to hold and manipulate data, and Views to create and send HTML markup and content to a user's web browser. 
 
## Navigating the site
Navigating to the Home page displays a simple mockup of a Time magazine cover, with a search form allowing users to input a start year and an end year. 

![Image of home page](https://github.com/RickFlinn/Lab11-MyFirstMVCApp/blob/master/assets/TimeMVC(1).png "")


When the user enters a range and clicks Submit, they will be redirected to a results page view that displays a table of information on the Time persons of the year for that year range. For each person displayed in this table, information on the year they were Person of the Year, the honor they were given, their name, country of origin, the years they lived, their title, the category of the award and any context that helps explain why they were selected. 


![Image of search results page](https://github.com/RickFlinn/Lab11-MyFirstMVCApp/blob/master/assets/TimeMVC(2).png "")

## Nuts and Bolts
Whenever the user puts in a search range, the Controller takes in the user's input, validates it, and then attempts to build a List object for every entry that matches the given year search range. It does this by reading a .csv file into an array of strings, with each string being a single comma-separated entry corresponding to a Time person of the year. It then queries this array, converting each line into a TimePerson object and filtering for the correct year range. Once this List is constructed, it is passed to the Results page view, which uses that list to generate a table filled with the data contained in each TimePerson object in the list. 
