using System;
using System.Linq;

namespace Try101LinqSamples
{
    public class Generators
    {
        public int RangeOfIntegers()
        {
            #region generate-range
            #region MyRegion
            var numbers = from n in Enumerable.Range(100, 50)
                          select (Number: n, OddEven: n % 2 == 1 ? "odd" : "even");

            var x = Enumerable
                .Range(0, 10)
                .Select(x =>
                {
                    if (x % 2 == 1)
                        return (x, "odd");
                    else
                        return (x, "even");
                });
            #endregion

            foreach (var n in numbers)
            {
                Console.WriteLine("The number {0} is {1}.", n.Number, n.OddEven);
            }
            #endregion
            return 0;
        }

        public int RepeatNumber()
        {
            #region generate-repeat
            #region MyRegion
            var numbers = Enumerable.Repeat(7, 10);
            #endregion

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
            #endregion
            return 0;
        }
    }
}
