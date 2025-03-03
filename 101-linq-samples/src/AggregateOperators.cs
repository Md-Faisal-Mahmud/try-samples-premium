using System;
using System.Collections.Generic;
using System.Linq;

namespace Try101LinqSamples
{
    public class AggregateOperators
    {
        public List<Product> GetProductList() => Products.ProductList;
        public List<Customer> GetCustomerList() => Customers.CustomerList;

        public int CountSyntax()
        {
            #region count-syntax
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            #region MyRegion
            int uniqueFactors = factorsOf300.Distinct().Count();
            #endregion


            Console.WriteLine($"There are {uniqueFactors} unique factors of 300.");
            #endregion
            return 0;
        }   

        public int CountConditional()
        {
            #region count-conditional
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #region 
            int oddNumbers = numbers.Count(n => n % 2 == 1);
            #endregion
            //Use Select when you need to transform or modify elements.
            //Use Where when you need to filter elements.

            Console.WriteLine("There are {0} odd numbers in the list.", oddNumbers);
            #endregion
            return 0;
        }

        public int NestedCount()
        {
            #region nested-count
            List<Customer> customers = GetCustomerList();

            #region MyRegion
            var orderCounts = from c in customers
                              select (c.CustomerID, OrderCount: c.Orders.Count());
            #endregion

            foreach (var customer in orderCounts)
            {
                Console.WriteLine($"ID: {customer.CustomerID}, count: {customer.OrderCount}");
            }

            #endregion
            return 0;
        }

        public int GroupedCount()
        {
            #region grouped-count
            List<Product> products = GetProductList();

            #region MyRegion
            var categoryCounts = from p in products
                                 group p by p.Category into g
                                 select (Category: g.Key, ProductCount: g.Count());
            var categoryCounts1 = products.GroupBy(x => x.Category).Select(x => (x.Key, x.Count()));
            #endregion

            foreach (var c in categoryCounts)
            {
                Console.WriteLine($"Category: {c.Category}: Product count: {c.ProductCount}");
            }

            #endregion
            return 0;
        }

        public int SumSyntax()
        {
            #region sum-syntax
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #region MyRegion
            var numSum = numbers.Sum();
            #endregion

            Console.WriteLine($"The sum of the numbers is {numSum}");
            #endregion
            return 0;
        }

        public int SumProjection()
        {
            #region sum-of-projection
            string[] words = { "cherry", "apple", "blueberry" };
            #region MyRegion
            double totalChars = words.Sum(w => w.Length);
            #endregion

            Console.WriteLine($"There are a total of {totalChars} characters in these words.");
            #endregion
            return 0;
        }

        public int SumGrouped()
        {
            #region grouped-sum
            List<Product> products = GetProductList();

            #region MyRegion
            var categoriesWithStock = from p in products
                             group p by p.Category into g
                             select (Category: g.Key, TotalUnitsInStock: g.Sum(p => p.UnitsInStock));
            #endregion

            //var categoriesWithStock1 = products.
            foreach (var pair in categoriesWithStock)
            {
                Console.WriteLine($"Category: {pair.Category}, Units in stock: {pair.TotalUnitsInStock}");
            }
            #endregion
            return 0;
        }

        public int MinSyntax()
        {
            #region min-syntax
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #region MyRegion
            int minNum = numbers.Min();
            #endregion

            Console.WriteLine($"The minimum number is {minNum}");
            #endregion
            return 0;
        }

        public int MinProjection()
        {
            #region min-projection
            string[] words = { "cherry", "apple", "blueberry" };

            #region MyRegion
            int shortestWord = words.Min(w => w.Length);
            #endregion

            Console.WriteLine($"The shortest word is {shortestWord} characters long.");
            #endregion
            return 0;
        }

        public int MinGrouped()
        {
            #region min-grouped
            List<Product> products = GetProductList();

            #region MyRegion
            var categories = from p in products
                             group p by p.Category into g
                             select (Category: g.Key, CheapestPrice: g.Min(p => p.UnitPrice));
            #endregion

            foreach (var c in categories)
            {
                Console.WriteLine($"Category: {c.Category}, Lowest price: {c.CheapestPrice}");
            }
            #endregion
            return 0;
        }

        public int MinEachGroup()
        {
            #region min-each-group
            List<Product> products = GetProductList();

            #region MyRegion
            var categories = from p in products
                             group p by p.Category into g
                             let minPrice = g.Min(p => p.UnitPrice)
                             select (Category: g.Key, CheapestProducts: g.Where(p => p.UnitPrice == minPrice));
            #endregion

            foreach (var c in categories)
            {
                Console.WriteLine($"Category: {c.Category}");
                foreach(var p in c.CheapestProducts)
                {
                    Console.WriteLine($"\tProduct: {p}");
                }
            }
            #endregion
            return 0;
        }

        public int MaxSyntax()
        {
            #region max-syntax
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #region MyRegion
            int maxNum = numbers.Max();
            #endregion

            Console.WriteLine($"The maximum number is {maxNum}");
            #endregion
            return 0;
        }

        public int MaxProjection()
        {
            #region max-projection
            string[] words = { "cherry", "apple", "blueberry" };

            #region MyRegion
            int longestLength = words.Max(w => w.Length);
            #endregion

            Console.WriteLine($"The longest word is {longestLength} characters long.");
            #endregion
            return 0;
        }

        public int MaxGrouped()
        {
            #region max-grouped
            List<Product> products = GetProductList();

            #region MyRegion
            var categories = from p in products
                             group p by p.Category into g
                             select (Category: g.Key, MostExpensivePrice: g.Max(p => p.UnitPrice));
            #endregion

            foreach (var c in categories)
            {
                Console.WriteLine($"Category: {c.Category} Most expensive product: {c.MostExpensivePrice}");
            }
            #endregion
            return 0;
        }

        public int MaxEachGroup()
        {
            #region max-each-group
            List<Product> products = GetProductList();

            #region MyRegion
            var categories = from p in products
                             group p by p.Category into g
                             let maxPrice = g.Max(p => p.UnitPrice)
                             select (Category: g.Key, MostExpensiveProducts: g.Where(p => p.UnitPrice == maxPrice));
            #endregion

            foreach (var c in categories)
            {
                Console.WriteLine($"Category: {c.Category}");
                foreach (var p in c.MostExpensiveProducts)
                {
                    Console.WriteLine($"\t{p}");
                }
            }
            #endregion
            return 0;
        }

        public int AverageSyntax()
        {
            #region average-syntax
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #region MyRegion
            double averageNum = numbers.Average();
            #endregion

            Console.WriteLine($"The average number is {averageNum}.");
            #endregion
            return 0;
        }

        public int AverageProjection()
        {
            #region average-projection
            string[] words = { "cherry", "apple", "blueberry" };

            #region MyRegion
            double averageLength = words.Average(w => w.Length);
            #endregion

            Console.WriteLine($"The average word length is {averageLength} characters.");
            #endregion
            return 0;
        }

        public int AverageGrouped()
        {
            #region average-grouped
            List<Product> products = GetProductList();

            #region MyRegion
            var categories = from p in products
                             group p by p.Category into g
                             select (Category: g.Key, AveragePrice: g.Average(p => p.UnitPrice));
            #endregion

            foreach (var c in categories)
            {
                Console.WriteLine($"Category: {c.Category}, Average price: {c.AveragePrice}");
            }
            #endregion
            return 0;
        }

        public int AggregateSyntax()
        {
            #region aggregate-syntax
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            #region MyRegion
            double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);
            #endregion

            Console.WriteLine($"Total product of all numbers: {product}");
            #endregion
            return 0;
        }

        public int SeededAggregate()
        {
            #region aggregate-seeded
            double startBalance = 100.0;

            int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };

            #region MyRegion
            double endBalance =
                attemptedWithdrawals.Aggregate(startBalance,
                    (balance, nextWithdrawal) =>
                        ((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance));
            #endregion

            Console.WriteLine($"Ending balance: {endBalance}");
            #endregion
            return 0;
        }
    }
}
