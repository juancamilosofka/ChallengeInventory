using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Model;

namespace Testing.Builders;
    public static class ProductBuilder
    {
        public static PaginationProduct BuildPaginationProduct() => new PaginationProduct{

        Pages = 10 ,
        CurrentPage = 1,
        PageSize = 1,
        products  = {
            new Product{
                IdProduct = 1,
                Name = "KartofelSaft",
                inInventory = 200 ,
                enabled = true ,
                min = 5 ,
                max = 20
        },
            
      new Product{
      IdProduct = 92,
      Name = "Appetizer - Mushroom Tart",
      inInventory = 14,
      enabled = true,
      min = 19,
      max = 63
    },
    new Product{
      IdProduct =  93,
      Name = "Pickles - Gherkins",
      inInventory = 183,
     enabled = true,
      min = 18,
      max = 85
    },
    new Product{
      IdProduct =  94,
      Name = "Shrimp - 31/40",
      inInventory = 287,
      enabled = true,
      min = 12,
      max = 67
    },
    new Product{
      IdProduct =  95,
      Name = "Oven Mitts 17 Inch",
      inInventory = 821,
      enabled = true,
      min = 1,
      max = 49
    },
    new Product{
      IdProduct =  96,
      Name = "Chicken - Leg / Back Attach",
      inInventory = 344,
      enabled = true,
      min = 13,
      max = 77
    },
    new Product{
      IdProduct =  97,
      Name = "Coriander - Ground",
      inInventory = 354,
      enabled = true,
      min = 12,
      max = 86
    },
    new Product{
      IdProduct = 98,
      Name = "Onions - Dried, Chopped",
      inInventory = 93,
      enabled = true,
      min = 17,
      max = 48
    },
    new Product{
      IdProduct = 99,
      Name = "Wine - Zonnebloem Pinotage",
      inInventory = 966,
      enabled = true,
      min = 13,
      max = 46
    },
    new Product{
      IdProduct = 100,
      Name = "Mahi Mahi",
      inInventory = 356,
      enabled = true,
      min = 12,
      max = 21
    },
    new Product{
      IdProduct = 101,
      Name = "Contreau",
      inInventory = 771,
      enabled = true,
      min = 7,
      max = 89
    }

            }
        };

        public static Product BuildProduct() => 
            new Product{
                IdProduct = 1,
                Name = "KartofelSaft",
                inInventory = 200 ,
                enabled = true ,
                min = 5 ,
                max = 20
            };

                public static Product BuildProductToUpdate() => 
            new Product{
                IdProduct = 1,
                Name = "Zitronen Saft",
                inInventory = 100 ,
                enabled = true ,
                min = 5 ,
                max = 20
            };
    }

