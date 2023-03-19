using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle
    internal class Program
    {
        static void Main(string[] args)
        {
            

            ProductManager productManager2 = new ProductManager(new EfProductDal());

            foreach (var product in productManager2.GetProductDetails())
            {
                Console.WriteLine(product.ProductName+" / "+product.CategoryName);
            }

            //ProductTest();
            //IoC
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("-----------");
            foreach (var product2 in productManager.GetByUnitPrice(20, 80))
            {
                Console.WriteLine(product2.ProductName);
            }
        }
    }
}
