using System;
using System.Collections.Generic;
using System.Linq;

namespace Recommendation
{
    public class Person
    {
        //node attributes
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }

        // edges 
        public List<string> Interests { get; }

        public Person()
        {
            Interests = new List<string>();
        }

    }


    /// <summary>
    /// extension mehtod
    /// </summary>
    public static class Ext
    {
        // travere via interest edges
        //find matching interest across node to edges
        public static List<Person> GetPersonwithInterest(this Dictionary<string, Person> persons, string interst)
        {
            // find all the edges from source interest
            return persons.Values.Where(p => p.Interests.Contains(interst)).ToList<Person>();

        }

    }
}
