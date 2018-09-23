using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Repository;
using BOL;

namespace ConsoleAppUnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProductBLL BLL = new ProductBLL())
            {
                // Example1
                //var products = unitOfWork.Products.GetAll(x => x.Price == 120);

                // Example2
                var products = BLL.GetAllProduct();

                //// Example3
                //var author = unitOfWork.Authors.GetAuthorWithCourses(1);
                //unitOfWork.Courses.RemoveRange(author.Courses);
                //unitOfWork.Authors.Remove(author);

                foreach (var product in products)
                {
                    Console.WriteLine(product.Id +" "+ product.Name +" "+ product.Price +" ");
                }

                Console.ReadLine();
            }
        }
    }
}
