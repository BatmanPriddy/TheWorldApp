# The World App

Welcome fellow GitHub aficionado!

This demo application will allow you to plan for trips around the world.  Feel free to clone this repository and modify in any way you'd like.

It was built with the following:
* Visual Studio 2015 (IDE)
* ASP.NET 5 (.NET Framework RC1)
* MVC 6 (Lastest version of Microsoft's port of the MVC Design Pattern)
* Web API (Now merged with MVC 6, uses HTTP verbs for HTTP Requests/Responses)
* Entity Framework 7 (Latest pre-release version of EF from Microsoft)
* Bootstrap (Version 3.3.6, for page layout)
* Font Awesome (Version 4.5, for page icons)
* Bing Maps API (To determine longitude and latitude values based on location entered)
* AngularJS (Version 1.5, for communicating with the Web API and displaying results)
* JSON (Format for transmitted and received data)

The web application requires the installation of [Visual Studio Community Edition 2015](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx), and the latest release of the [ASP.NET 5 Framework (RC1)](https://go.microsoft.com/fwlink/?LinkId=627627).  

For detailed installation instructions, please see [this](http://docs.asp.net/en/latest/getting-started/installing-on-windows.html) documentation.

One last requirement is the creation of a free Bing Maps key, for use with their geolocation API.  You may create your Bing Maps Key [here](https://www.bingmapsportal.com/).

The Bing Maps key must be added as an environment variable on your Windows system, by performing the following steps:

Step 1: Depending on your version of the Windows OS, search for _Environment Variables_

Step 2: Once the _System Properties_ dialog box opens, click the _Environment Variables_ button

![alt-text](http://www.jasonpriddy.com/images/SystemProperties.png "System Properties")

Step 3: In the top section, click the _New..._ button

![alt text](http://www.jasonpriddy.com/images/EnvironmentVariables.png "Environment Variables")

Step 4:

For the _Variable name_ enter **AppSettings:BingKey**   
For the _Variable value_ enter the Bing Key that you created with your Bing Maps account.

![alt text](http://www.jasonpriddy.com/images/EnvironmentVariablesValues.png "Environment Variables Values")

**TODO**
1. Create directives for use with the AngularJS portion of the demo app.
2. Create routes in AngularJS for use in displaying stop data on a third party map.
3. Publish web application to free Azure account.

Thank you and enjoy!