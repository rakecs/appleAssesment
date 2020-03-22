using System;
using System.Collections.Generic;

namespace Recommendation
{
    public class UnitTests
    {

        Dictionary<string, Person> _Graph;

        public UnitTests()
        {
            _Graph = Recommendor.CreateGraphwithSampleData();
        }


        //test
       
        public void BFSBasedMatchingRecommendationTest1()
        {
            Recommendor.BFSBasedMatchingRecommendation(_Graph, "P", 3);
        }

        public void BFSBasedMatchingRecommendationTest3()
        {
            Recommendor.BFSBasedMatchingRecommendation(_Graph, "A", 2);
        }
        public void BFSBasedMatchingRecommendationTest4()
        {
            Recommendor.BFSBasedMatchingRecommendation(_Graph, "C", 2);
        }
        public void BFSBasedMatchingRecommendationTest5()
        {
            Recommendor.BFSBasedMatchingRecommendation(_Graph, "D", 2);
        }
        public void BFSBasedMatchingRecommendationinTestInvalid()
        {
            Recommendor.BFSBasedMatchingRecommendation(_Graph, "E", 2);
        }
        public void BFSBasedMatchingRecommendationTestNull()
        {
            Recommendor.BFSBasedMatchingRecommendation(null, null, 2);
        }

        public void BFSBasedMatchingRecommendationTestTestZero()
        {
            Recommendor.BFSBasedMatchingRecommendation(_Graph, "B", 0);
        }

    }


}
