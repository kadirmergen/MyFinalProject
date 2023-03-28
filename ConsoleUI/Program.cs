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
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName+ " / " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            //GetProductDetailsTest();
            //ProductTest();
            //IoC
            //CategoryTest();
        }

        private static void GetProductDetailsTest()
        {
            ProductManager productManager2 = new ProductManager(new EfProductDal());

            foreach (var product in productManager2.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
            }
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

            foreach (var product in productManager.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("-----------");
            foreach (var product2 in productManager.GetByUnitPrice(20, 80).Data)
            {
                Console.WriteLine(product2.ProductName);
            }
        }
    }
}
