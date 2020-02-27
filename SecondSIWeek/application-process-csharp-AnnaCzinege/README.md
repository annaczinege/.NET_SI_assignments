# Practice .NET LINQ queries - Application process assignment - Basic LINQ

LINQ stands for **L**anguage **IN**tegrated **Q**uery which is a really convinient way of
writing queries regardless of the data source. It could be a list, a real database or an XML file.

In this exercise you should create some basic queries to make work our application process app.
May this exercise is familiar to you from the web module ;)

## Task 1

First of all you have to implement the basic functionality using an in-memory repository.
You should extend the [*Program.cs*](src/ApplicationProcess.Console/Program.cs) to create the menu and write the proper queries in the [*InMemoryRepository*](src/ApplicationProcess.Console/Data/InMemoryRepository.cs) class.

## Task 2

There is an XML data source named [*Backup.xml*](src/ApplicationProcess.Console/Resources/Backup.xml).
Create a new *XMLRepository* class in the Data folder which implements the [IApplicationRepository](src/ApplicationProcess.Console/Data/IApplicationRepository.cs) interface.
You should use the referred xml file as a data source in this implementation.

> HINT: Use relative path for accessing the file.
> Don't worry, it will be copied into the bin folder when you build the solution.

The way of data source should be given as command line argument.
If the first command line argument is `xml` then the program should use the xml resource.
Otherwise the application use the InMemory repository by default.

# Extra task

Give multiple options to the user to define the repository type:

*  In configuration file by setting the path for the XML file
*  In command line argument
*  New menu option in console