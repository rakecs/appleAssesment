using System;
using System.Collections.Generic;
using System.Linq;

namespace Recommendation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("starting....");

            try
            {

                Dictionary<string, Person> graph = Recommendor.CreateGraphwithSampleData();


                //A graph based matching
                Recommendor.BFSBasedMatchingRecommendation(graph, "B", 2);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

    }

}
