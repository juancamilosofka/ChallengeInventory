using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Model;

namespace Testing.Builders;
    public static class BuyBuilder
    {
        public static List<Buy> BuildBuys() => new List<Buy>{

      new Buy{
   BuyId = 1,
    Date = DateTime.Parse("2023-01-04T10:09:02.744"),
    IdType = "cc",
    Id = "123",
    ClientName = "fELIPE",
    ProductList =  new List<ProductList>{
      new ProductList{
        ProductListId = 1,
        IdProduct = 2,
        Quantity = 7
      }
    }},
 new Buy{
   BuyId = 2,
    Date = DateTime.Parse("2023-01-04T10:09:02.744"),
    IdType = "cc",
    Id = "1232345",
    ClientName = "Anastasia",
    ProductList =  new List<ProductList>{
      new ProductList{
        ProductListId = 5,
        IdProduct = 7,
        Quantity = 5
      }
    }
 },
 new Buy{
   BuyId = 3,
    Date = DateTime.Parse("2023-01-04T10:09:02.744"),
    IdType = "cc",
    Id = "12334",
    ClientName = "Ramiro",
    ProductList =  new List<ProductList>{
      new ProductList{
        ProductListId = 1,
        IdProduct = 3,
        Quantity = 9
      }
    },

            
        }};

        public static Buy BuildBuy() => 
             new Buy{
   BuyId = 3,
    Date = DateTime.Parse("2023-01-04T10:09:02.744"),
    IdType = "cc",
    Id = "123",
    ClientName = "fELIPE",
    ProductList =  new List<ProductList>{
      new ProductList{
        ProductListId = 1,
        IdProduct = 2,
        Quantity = 7
      }
    }};

                public static Buy BuildBuyToUpdate() => 
             new Buy{
   BuyId = 3,
    Date = DateTime.Parse("2023-01-04T10:09:02.744"),
    IdType = "cc",
    Id = "1232",
    ClientName = "Julian",
    ProductList =  new List<ProductList>{
      new ProductList{
        ProductListId = 1,
        IdProduct = 7,
        Quantity = 45
      }
    }
            };
    }