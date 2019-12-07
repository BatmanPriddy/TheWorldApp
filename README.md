![alt-text](http://www.clarity-ventures.com/portals/0/images/resources/dotnetlogo.png "ASP.NET Logo")

# The World App

Welcome fellow GitHub aficionado!

This demo application will allow you to plan for trips around the world.  Feel free to clone this repository and modify in any way you'd like.

The corresponding Pluralsight tutorial for this demo can be found [here](https://app.pluralsight.com/library/courses/aspdotnet-5-ef7-bootstrap-angular-web-app/table-of-contents).

### Tools/Frameworks
* Visual Studio Community Edition 2015 (IDE)
* ASP.NET 5 (.NET Framework RC1)
* MVC 6 (Lastest version of Microsoft's port of the MVC Design Pattern)
* Web API (Now merged with MVC 6, uses HTTP verbs for HTTP Requests/Responses)
* Entity Framework 7 (Latest pre-release version of EF from Microsoft)
* Bootstrap (Version 3.3.6, for page layout)
* Font Awesome (Version 4.5, for page icons)
* Bing Maps API (To determine longitude and latitude values based on location entered)
* AngularJS (Version 1.5, for communicating with the Web API and displaying results)
* JSON (Format for transmitted and received data)

### Installation Instructions

In order to successfully run this web application, you must install the following:
* [Visual Studio Community Edition 2015](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx)
* The latest release of the [ASP.NET 5 Framework (RC1)](https://go.microsoft.com/fwlink/?LinkId=627627)
* For detailed installation instructions of the previous two items, please see [this](http://docs.asp.net/en/latest/getting-started/installing-on-windows.html) documentation

#### Check Runtime Engines Via The .NET Version Manager

Once the ASP.NET 5 Framework is installed, open your command prompt and run the command `dnvm list`.  You should see a list similar to the one below:

![alt-text](https://i.imgur.com/DhFcOhx.png "System Properties")

If you do not have at least Version `1.0.0-rc1-update1` with the Runtime `clr` and Architecture `x64`, you will need to install that version for this application to function.  You may install that version of the runtime with the following command:

`dnvm install 1.0.0-rc1-update1 -r clr -arch x64 -p`    
(`-p` signifies to keep the version active and persistent even after the command prompt window is closed)

### Configuration Instructions

#### Bing Maps Key Creation
Once you have successfully installed the required IDE and Framework, the last requirement will be to obtain a Bing Maps Key, for use with their geolocation API.

You may create your Bing Maps Key [here](https://www.bingmapsportal.com/).

#### Bing Maps Key Configuration
The Bing Maps key must be added as an environment variable on your Windows system, by performing the following steps:

Step 1: Depending on your version of the Windows OS, search for `Environment Variables`

Step 2: Once the `System Properties` dialog box opens, click the `Environment Variables` button

![alt-text](https://i.imgur.com/gbuET2q.png "System Properties")

Step 3: In the top section, click the `New...` button

![alt text](https://i.imgur.com/VmPFQpJ.png "Environment Variables")

Step 4:

For the `Variable name` enter `AppSettings:BingKey`   
For the `Variable value` enter the Bing Key that you created with your Bing Maps account.

![alt text](https://i.imgur.com/oPvzKXu.png "Environment Variables Values")

### Running the application

Once everything is up and running, you can simply open the web application in Visual Studio Community Edition 2015 and run the application via the IIS Express run button.

![alt text](https://i.imgur.com/bPr69P7.png "IIS Express Run Button")

Once the application loads in your browser of your choice, you may login with the following credentials:
* Username: `samhastings` (**all lowercase**)
* Password: `P@ssw0rd1`

If you encounter any issues at all, please feel free to contact me anytime at [jason_priddy@yahoo.com](mailto:jason_priddy@yahoo.com?subject=Help%20with%20TheWorld%20app), or message me here on GitHub.

**TO DO**

1. Publish web application to free Azure account.

Thank you and enjoy!