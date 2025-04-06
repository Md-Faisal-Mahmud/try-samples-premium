using System;
using System.Linq;

namespace Try101LinqSamples
{
    public class Conversions
    {
        public int ConvertToArray()
        {
            #region convert-to-array
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles = from d in doubles 
                                orderby d descending
                                select d;

            #region MyRegion
            var doublesArray = sortedDoubles.ToArray();
            #endregion
            
            Console.WriteLine("Every other double from highest to lowest:");
            for (int d = 0; d < doublesArray.Length; d += 2)
            {
                Console.WriteLine(doublesArray[d]);
            }
            #endregion
            return 0;
        }

        public int ConvertToList()
        {
            #region convert-to-list
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = from w in words 
                              orderby w
                              select w;

            #region MyRegion
            var wordList = words.OrderBy(w => w).ToList();
            #endregion

            Console.WriteLine("The sorted word list:");
            foreach (var w in wordList)
            {
                Console.WriteLine(w);
            }
            #endregion
            return 0;
        }

        public int ConvertToDictionary()
        {
            #region convert-to-dictionary
            var scoreRecords = new[]
            {
                new {Name = "Alice", Score = 50},
                new {Name = "Bob"  , Score = 40},
                new {Name = "Cathy", Score = 45}
            };

            #region MyRegion
            var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);
            #endregion

            Console.WriteLine("Bob's score: {0}", scoreRecordsDict["Bob"]);
            #endregion
            return 0;
        }

        public int ConvertSelectedItems()
        {
            #region convert-to-type
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

            #region MyRegion
            var doubles = numbers.OfType<double>();
            #endregion

            Console.WriteLine("Numbers stored as doubles:");
            foreach (var d in doubles )
            {
                Console.WriteLine(d);
            }
            #endregion
            return 0;
        }
    }
}
