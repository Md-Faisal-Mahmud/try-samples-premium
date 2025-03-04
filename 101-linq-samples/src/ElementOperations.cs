using System;
using System.Collections.Generic;
using System.Linq;

namespace Try101LinqSamples
{
    public class ElementOperations
    {
        public List<Product> GetProductList() => Products.ProductList;
        public List<Customer> GetCustomerList() => Customers.CustomerList;

        public int FirstElement()
        {
            #region first-element
            List<Product> products = GetProductList();

            Product product12 = (from p in products
                                 where p.ProductID == 12
                                 select p)
                                 .First();

            Console.WriteLine(product12);
            #endregion
            return 0;
        }

        public int FirstMatchingElement()
        {
            #region first-matching-element
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            #region MyRegion
            string startsWithO = strings.First(s => s[0] == 'o');
            #endregion

            Console.WriteLine($"A string starting with 'o': {startsWithO}");
            #endregion
            return 0;
        }

        public int MaybeFirstElement()
        {
            #region first-or-default
            int[] numbers = { };

            #region MyRegion
            int firstNumOrDefault = numbers.FirstOrDefault();
            #endregion

            Console.WriteLine(firstNumOrDefault);
            #endregion
            return 0;
        }

        public int MaybeFirstMatchingElement()
        {
            #region first-matching-or-default
            List<Product> products = GetProductList();

            #region MyRegion
            Product product789 = products.FirstOrDefault(p => p.ProductID == 789);
            #endregion

            Console.WriteLine($"Product 789 exists: {product789 != null}");
            #endregion
            return 0;
        }

        public int ElementAtPosition()
        {
            #region element-at
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var x = (
                from n in numbers
                where n > 5
                select n);

            int fourthLowNum = x.ElementAt(1);  // second number is index 1 because sequences use 0-based indexing

            Console.WriteLine($"Second number > 5: {fourthLowNum}");
            #endregion
            return  0;
        }
    }
}
