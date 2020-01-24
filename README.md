IT LAB Easter Challenge – Source Code and Structure

About the Visual Studio Project Structure

1) Projects that make up the Easter Engine:

1.1) ITLab.Challenges.EasterChallengeInfra

The heart of the Easter calculation engine. 

I’ve adapted the C# fragment that can be found at https://pt.wikipedia.org/wiki/C%C3%A1lculo_da_P%C3%A1scoa to fit my domain structure.

1.2) ITLab.Challenges.EasterChallengeModels

Project that contains domain classes.

1.3) ITLab.Challenges.EasterChallengeUtils

Project that contains utility classes.

In there, you can find “Result”, a unit-test-compliance class (although I did not write unit tests for this project). “Result” hosts atomic functions in order to follow the single responsibility principle.

2) Projects that uses the Easter Engine:

2.1) ITLab.Challenges.EasterChallengeConsoleApp

Console application that asks for a valid year to call the Calculator engine. 

Usage:

Right-click the Console Application project and choose "Set as StartUp Project" from the context-sensitive menu that is displayed. 

Run the Project.

The screen will show a simple shell in where you can put a valid year to perform the Easter calculation.


2.2) ITLab.Challenges.EasterChallengeWebService

ASP.NET XML-based Web service (ASMX) that performs a call for the Calculator engine.

Usage:

Right-click the WebService project and choose "Set as StartUp Project" from the context-sensitive menu that is displayed. 

Set “EasterChallenge.asmx” as StartUp file. 

Run the Project.

At the test form, put a valid year to perform the Easter calculation.

2.3) ITLab.Challenges.EasterChallengeWebApi

ASP.NET RESTful service that performs a call for the Calculator engine.

Usage:

Right-click the Web API project and choose "Set as StartUp Project" from the context-sensitive menu that is displayed. 

Run the Project.

Make sure the address contains the route api/v1/easterchallenge/calculate/{year} (where {year} is a valid year to perform the calculation).

3) What does it mean a “valid year”?

The calculator engine assumes that the range of valid years begins on the year Easter was stablished by the First Council of Nicaea (AD 325) and ends on 2120 (the end of the world according to Windows 10 Calendar). Hint: try put numbers outside the range.

Thank you, and I wish you have a good time evaluating my code 😊
