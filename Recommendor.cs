using System;
using System.Collections.Generic;
using System.Linq;

namespace Recommendation
{
    public class Recommendor
    {
        /// <summary>
        /// 
        /// </summary>
        public Recommendor()
        {
        }

        /// <summary>
        /// Print recommendation
        /// </summary>
        /// <param name="datingGraph"></param>
        /// <param name="userName"></param>
        /// <param name="topCount"></param>
        public static void BFSBasedMatchingRecommendation(Dictionary<string, Person> datingGraph, string userName, int topCount)
        {

            if (datingGraph == null) throw new SystemException("Invalid graph.");

            if (datingGraph.ContainsKey(userName) == false) throw new ApplicationException("Invalid user.");


            Person source = datingGraph[userName];

            if (source == null)
                throw new ApplicationException("Invalid Source User. Not in graph collection.");

            //Remove source from traversal
            datingGraph.Remove(userName);

            if (datingGraph.Count == 0)
                throw new ApplicationException("Bad luck!! Nothing to date. try after more users join.");


            if (source.Interests.Count <= 0)
                throw new ApplicationException("No interest to match.");


            List<Person> matchingInterest = new List<Person>();

            // Do a BFS traversal and find all intesersts connected to source
            //create a queue
            Queue<string> totraverse = new Queue<string>();

            //initalize with source interest
            foreach (string interest in source.Interests)
            {
                totraverse.Enqueue(interest);
            }


            // find matching inerest edges
            while (totraverse.Count > 0)
            {
                List<Person> matching = datingGraph.GetPersonwithInterest(totraverse.Dequeue());

                matchingInterest.AddRange(matching);
            }

            // group by matching interest node enountered during traversal count it
            var result = matchingInterest.GroupBy(p => p).Select(x => new { key = x.Key, val = x.Count() });

            // order by node by match count highest to lower
            var resfinal = result.OrderByDescending(p => p.val);

            // order by age difference
            var resage = resfinal.OrderBy(p => Math.Abs(p.key.Age - source.Age));

            // try to fnd opposite gender
            var matched = resage.Where(p => p.key.Sex != source.Sex).Take(topCount);

            if (matched == null || matched.Count() == 0)
                throw new ApplicationException("Sorry!! No match exists");

            // print here, 
            foreach (var item in matched)
            {
                Console.WriteLine(item.key.Name);
            }



        }


        /// <summary>
        ///  seed data for graph
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Person> CreateGraphwithSampleData()
        {


            /*
                      UserA - 25 - Female - Cricket,Tennis
                      UserB - 27 - Male - Cricket,Football,Movies
                      UserC - 26 - Male - C = Movies,Tennis,Football,Cricket
                      UserD - 24 - Female - C = Tennis,Football,Badminton
                      UserE - 32 - Female - C = Cricket,Football,Movies,Badminton
          */

            Dictionary<string, Person> graph = new Dictionary<string, Person>();

            graph.Add("A", new Person { Name = "A", Age = 25, Sex = "Female", Interests = { "Cricket", "Tennis" } });
            graph.Add("B", new Person { Name = "B", Age = 27, Sex = "Male", Interests = { "Cricket", "Football", "Movies" } });
            graph.Add("C", new Person { Name = "C", Age = 26, Sex = "Male", Interests = { "Movies", "Tennis", "Football", "Cricket" } });
            graph.Add("D", new Person { Name = "D", Age = 24, Sex = "Female", Interests = { "Tennis", "Football", "Badminton" } });
            graph.Add("E", new Person { Name = "E", Age = 32, Sex = "Female", Interests = { "Cricket", "Football", "Movies", "Badminton" } });


            return graph;
        }

    }


}
