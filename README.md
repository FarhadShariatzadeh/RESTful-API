## Service API Description

This is a Web Service API to create a League-table with associated information. It is useful when you play any games with your friends and would like to keep tracking of teams' scores and best players. The API includes the typical CRUD operations including GET, POST, DELETE, and PUT. There is 2 levels granularity for GET and POST methods. Also, overloaded methods have been provided for GET and POST methods.

## GET Method

http://localhost:54662/api/team/ 
By sleceting GET method, this URI connects to the typical GET method which returns all the information available in the table-list.

## Overloaded GET Method

http://localhost:54662/api/team/1 
By sleceting GET method, this URI connects to the overloaded GET method which returns information about a specific team.

## Two-level granularity GET Method

http://localhost:54662/api/team/1/2 
By sleceting GET method, this URI connects to the two-level granularity GET method which returns a specific information about a specific team. First granularity level is assigned to a team in the table and the second granularity level is assigned to a property of the selected team.

## POST Method

http://localhost:54662/api/team/ 
By sleceting POST method, this URI connects to the typical POST method, by which you can add a new team to the table-list. NOTE: table-list consists of object-type "Team". The "Team" object also has a List named "LeagueTopScoredPlayers" which includes type "Player". By creating a new team, a copy of the list "LeagueTopScoredPlayers" will be added to the team properties automatically. So, you can write a json-format script in the Body like below to add a new team: example --> { "TeamName" : "Real Sociedad", "TeamPlayed" : "28", "TeamPoints":"33"}

## Over loaded POST Method

http://localhost:54662/api/team/1/4 
By sleceting POST method, this URI connects to the overloaded POST method, by which you can add a new top-scored player to the "topScoredPlayers" list. NOTE: The first granulairty level, which in this case is "1", assignes to a team in the table and can be picked randomly as all teams have "topScoredPlayers" list. The second granularity level should be "4" as this is assagned to the forth property of a "Team" object which is "topScoredPlayers" list. example --> { "playerName" : "Farhad", "goals" : "30" }

## PUT Method

http://localhost:54662/api/team/1/ 
By sleceting PUT method, this URI connects to the PUT method, by which you can update properties of the selected team.

## DELETE Method

http://localhost:54662/api/team/1/ 
By sleceting DELETE method, this URI connects to the DELETE method, by which you can remove the selected team from the table-list.
