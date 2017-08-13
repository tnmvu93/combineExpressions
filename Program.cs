using LinqSearchTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqSearchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Customer name: ");
            //var customerName = Console.ReadLine();

            //Console.Write("Product name: ");
            //var productName = Console.ReadLine();

            //Console.Write("Order date: ");
            //var orderDate = Console.ReadLine();
            //DateTime.TryParse(orderDate, out DateTime date);

            //var result = BuildQuery(customerName, productName, date);
            DateTime.TryParse("2012-07-04", out DateTime date);
            var result = BuildQuery("Maria", "Chartreuse verte", date);
        }

        public static List<OrderItem> BuildQuery(string customerName, string productName, DateTime? orderDate)
        {
            Expression<Func<OrderItem, bool>> query = x => true;
            var doQuery = false;

            

            if (!string.IsNullOrEmpty(customerName))
            {
                doQuery = true;
                Expression<Func<OrderItem, bool>> subQuery = x => x.Order.Customer.FirstName == customerName;
                //query = CombineExpression(query, subQuery);
                query = query.And(subQuery);

            }
            if (!string.IsNullOrEmpty(productName))
            {
                doQuery = true;
                Expression<Func<OrderItem, bool>> subQuery = x => x.Product.ProductName == productName;
                query = query.And(subQuery);
            }

            doQuery = false;
            query = query.And(x => doQuery);


            List<OrderItem> orderItems;
            using (var db = new AppDbContext())
            {
                orderItems = db.OrderItems.Where(query).ToList();
            }

            return orderItems;
        }

        public static Expression<Func<OrderItem, bool>> CombineExpression(Expression<Func<OrderItem, bool>> left, Expression<Func<OrderItem, bool>> right)
        {
            var combined = Expression.Lambda<Func<OrderItem, bool>>(
                Expression.Or(left.Body, right.Body), left.Parameters);
            return combined;
        }
    }
}
