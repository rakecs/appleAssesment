 This is a sample console test application wirtten in .NET C#


File description:

Program.cs: Main client sample application which consumes Recommendor APIs

Recommendor.cs: contains implementation of this dating vehavior and exposes APIs to be consumed by client application

It has following APIs

 -BFSBasedMatchingRecommendation: Contains recommncadtion matching logic, based on graph BFS travsersal. it also prints the result
 -CreateGraphwithSampleData: populate sample seeed data for graph as provided in mail

Person.cs: Person entity (graph node) definition and  Extenston method

UnitTests.cs: Contains sample unit test 


    

          