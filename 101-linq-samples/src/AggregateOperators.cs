using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Try101LinqSamples
{
    public class AggregateOperators // .COM
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
            var categoryCounts1 = products.GroupBy(x => x.Category).Select(g => (g.Key, g.Count()));
            #endregion

            /* by which we groupBy, that is the key. then you can select the key of the group and 
            * project the value of the of the group
            */

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

            var categoriesWithStock1 = products
                                        .GroupBy(prod => prod.Category)
                                        .Select(g => (g.Key, g.Sum(prod => prod.UnitsInStock)));
            //g implements IEnumerable<TElement>, meaning it is a collection of Product elements.
            //IGrouping<TKey, TElement> Implements IEnumerable<TElement>
            //Since IGrouping<TKey, TElement> is iterable, you can apply LINQ methods like .Sum(), .Where(), or.Select() to iterate over its TElement collection.
            //Why Doesn't g.Key Affect Iteration?
            //When you call.Sum(), LINQ treats g as IEnumerable<Product>, so it completely ignores g.Key and only iterates over the products inside g.
            #endregion

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

            var categoriesMine = products.GroupBy(prod => prod.Category)
                            .Select(g => (g.Key, g.Min(prod => prod.UnitPrice)));
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

            var categoriesMine = products.GroupBy(prod => prod.Category)
                            .Select(g =>
                            {
                                var minPrice = g.Min(prod => prod.UnitPrice);
                                return (g.Key, g.Where(prod => prod.UnitPrice == minPrice));
                            });
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

            #region statement-boded lamda, expresssion-bodied lamda, anonymous type
            var x = products.GroupBy(x => x.Category)
                            .Select(g =>
                            {
                                var maxPrice = g.Max(x => x.UnitPrice);
                                return (g.Key, maxPrice);
                            });
            var y = products.GroupBy(x => x.Category)
                            .Select(g => (g.Key, g.Max(x => x.UnitPrice)));

            var z = products.GroupBy(x => x.Category)
                            .Select(g => new
                            {
                                Category = g.Key,
                                MostExpensivePrice = g.Max(x => x.UnitPrice)
                            });
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

            var categoriesMine = products.GroupBy(x => x.Category)
                                        .Select(g =>
                                        {
                                            var maxPrice = g.Max(x => x.UnitPrice);
                                            return (Category: g.Key, MaxPrice: maxPrice);
                                        });
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
            var x = doubles.Aggregate((acc, num) => acc * num);
            //that means value first come here(acc, num) then next => step?
            //Yes, The first two values from the array are initially assigned to acc(accumulator) and num(next number in the sequence)
            Console.WriteLine($"Total product of all numbers: {product}");
            #endregion
            return 0;
        }

        public int AggregateSyntax1()
        {
            int[] numbers = { 2, 3, 4, 5 };

            int product = numbers.Aggregate((acc, num) =>
            {
                Console.WriteLine($"acc: {acc}, num: {num}, result: {acc * num}");
                return acc * num;
            });

            Console.WriteLine($"Final result: {product}");
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
            var x = attemptedWithdrawals
                .Aggregate(startBalance,
                (balance, nextWithdrawal) =>
                {
                    Console.Write($"balance: {balance}, nextWithdrawal: {nextWithdrawal}, ");
                    if (nextWithdrawal <= balance)
                    {
                        Console.WriteLine($"Result: {balance - nextWithdrawal}");
                        return balance - nextWithdrawal;
                    }
                    else
                    {
                        Console.WriteLine($"Result: {balance}");
                        return balance;
                    }
                });
            Console.WriteLine($"Ending balance: {endBalance}");
            #endregion
            return 0;
        }
    }
}
