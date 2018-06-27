using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Activity06.Models;
using System.Web.Helpers;
using Newtonsoft.Json;



/*
 * Activity 06
 * TCSS 559 A _ University of Washington-Tacoma
 * Farhad Shariatzadeh (1570252) 
 */


    

namespace Activity06.Controllers
{
    [RoutePrefix ("api/team")]
    public class TeamController : ApiController
    {

        static List<Player> topScoredPlayers = new List<Player>()
        {
            new Player { playerName = "Messi", goals = "24"},
            new Player { playerName = "Luis Suárez", goals = "21"},
            new Player { playerName = "Cristiano Ronaldo", goals = "18"}

        };

        static List<Team> table = new List<Team>()
        
        {
            new Team { TeamName = "Barcelona", TeamPlayed = "28", TeamPoints="72", LeagueTopScoredPlayers = topScoredPlayers},
            new Team { TeamName = "Atletico Madrid", TeamPlayed = "28", TeamPoints="64", LeagueTopScoredPlayers = topScoredPlayers},
            new Team { TeamName = "Real Madrid", TeamPlayed = "28", TeamPoints="57", LeagueTopScoredPlayers = topScoredPlayers},
            new Team { TeamName = "Valencia", TeamPlayed = "28", TeamPoints="56", LeagueTopScoredPlayers = topScoredPlayers},
            new Team { TeamName = "Sevilla", TeamPlayed = "28", TeamPoints="45", LeagueTopScoredPlayers = topScoredPlayers},
            new Team { TeamName = "Villa Real", TeamPlayed = "28", TeamPoints="44", LeagueTopScoredPlayers = topScoredPlayers},

        };


        // GET: api/Team
        public IEnumerable<Team> Get()
        {
            return table;
        }


        // GET: api/Team/5
        public Team Get(int id)
        {
            if (table[id] == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            else
            return table[id]; 

        }


        [Route("{id}/{element}")]
        // GET: api/Team/5
        public string Get(int id, int element)
        {

            string returnName;
            switch (element)
            {
                case 1:
                    returnName = table[id].TeamName;
                    break;

                case 2:
                    returnName = table[id].TeamPlayed;
                    break;

                case 3:
                    returnName = table[id].TeamPoints;
                    break;

                default:
                    returnName = "900";
                    break;
            }

            return returnName;
        }


        // POST: api/Team        
        public HttpResponseMessage Post([FromBody]Team value)
        {
            if (value == null)
            { return new HttpResponseMessage(HttpStatusCode.BadRequest); }


            value.LeagueTopScoredPlayers = topScoredPlayers;
            table.Add(value);
            return new HttpResponseMessage(HttpStatusCode.Created);

        }


        // POST: api/Team/1/4        
        [Route("{id}/{element}")]
        public HttpResponseMessage Post(int id, int element, [FromBody]Player input)
        {
            if (input == null)
            { return new HttpResponseMessage(HttpStatusCode.BadRequest); }

            Player myplayer = new Player();
            myplayer = input;

            topScoredPlayers.Add(myplayer);

            return new HttpResponseMessage(HttpStatusCode.Created);

        }



        // PUT: api/Team/5
        public HttpResponseMessage Put(int id, [FromBody]Team value)
        {
            if (value == null)
            { return new HttpResponseMessage(HttpStatusCode.BadRequest); }

            value.LeagueTopScoredPlayers = topScoredPlayers;
            table[id] = value;
            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        // DELETE: api/Team/5
        public HttpResponseMessage Delete(int id)
        {
            int count = table.Count;
            if (id > count)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            table.RemoveAt(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
