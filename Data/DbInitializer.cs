using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CuddlyWombatContext context)
        {
            context.Database.EnsureCreated();
            if (context.Items.Any())
            {
                return;
            }
            //Items

            var items = new Item[] 
            {
            new Item {ID = Guid.NewGuid(), Name = "Cappucino", Description = "Classic Cappucino with one sugar", Quantity = 1000, Type = "Drink", Price = 3.75, DateCreated = DateTime.UtcNow },
            new Item {ID = Guid.NewGuid(), Name = "Latte", Description = "Classic Latte with one sugar", Quantity = 1000, Type = "Drink", Price = 3.65, DateCreated = DateTime.UtcNow },
            new Item {ID = Guid.NewGuid(), Name = "Grilled Chicken", Description = "Regular grilled chicken set of 3", Quantity = 600, Type = "Food", Price = 5, DateCreated = DateTime.UtcNow },
            new Item {ID = Guid.NewGuid(), Name = "Small Chips", Description = "A small bag of chips", Quantity = 600, Type = "Food", Price = 3, DateCreated = DateTime.UtcNow },
            new Item {ID = Guid.NewGuid(), Name = "Muffin", Description = "Classic blueberry muffin", Quantity = 100, Type = "Food", Price = 4, DateCreated = DateTime.UtcNow },
            new Item {ID = Guid.NewGuid(), Name = "Flat White", Description = "Classic Flat White with one sugar", Quantity = 1000, Type = "Drink", Price = 3.75, DateCreated = DateTime.UtcNow }

            };
            
           foreach(Item item in items)
            {
                context.Items.Add(item);
            }



            //Menu sets
            //Morning set with Cappucino and Muffin
            //Lunch set with Latte, small chips, and grilled chicken
            //Dinner set with Small Chips and Grilled Chicken
            var menus = new Menu[]
            {
                new Menu {ID = Guid.NewGuid(), Name = "Morning Set", Description = "Something to kickstart your morning",Price = 6, DateCreated = DateTime.UtcNow, Quantity = 1000 },
                new Menu {ID = Guid.NewGuid(), Name = "Lunch Set", Description = "Treat your tummy better for a productive afternoon", Price = 10, DateCreated = DateTime.UtcNow, Quantity = 1000 },
                new Menu {ID = Guid.NewGuid(), Name = "Dinner Set", Description = "Let's have dinner, shall we?", Price = 10, DateCreated = DateTime.UtcNow,  Quantity = 1000 }
            };

            foreach (Menu menu in menus)
            {
                context.Menus.Add(menu);
            }


            //ItemMenu connection

            var itemMenu = new ItemJMenu[]
            {
                new ItemJMenu {ID = Guid.NewGuid(),ItemID = items.Single(s => s.Name == "Cappucino").ID,
                MenuID = menus.Single(s => s.Name == "Morning Set").ID},
                new ItemJMenu {ID = Guid.NewGuid(),ItemID = items.Single(s => s.Name == "Muffin").ID,
                MenuID = menus.Single(s => s.Name == "Morning Set").ID},
                
                new ItemJMenu {ID = Guid.NewGuid(),ItemID = items.Single(s => s.Name == "Latte").ID,
                MenuID = menus.Single(s => s.Name == "Lunch Set").ID},
                new ItemJMenu {ID = Guid.NewGuid(),ItemID = items.Single(s => s.Name == "Small Chips").ID,
                MenuID = menus.Single(s => s.Name == "Lunch Set").ID},
                new ItemJMenu {ID = Guid.NewGuid(),ItemID = items.Single(s => s.Name == "Grilled Chicken").ID,
                MenuID = menus.Single(s => s.Name == "Lunch Set").ID},
                
                new ItemJMenu {ID = Guid.NewGuid(),ItemID = items.Single(s => s.Name == "Small Chips").ID,
                MenuID = menus.Single(s => s.Name == "Dinner Set").ID},
                new ItemJMenu {ID = Guid.NewGuid(),ItemID = items.Single(s => s.Name == "Grilled Chicken").ID,
                MenuID = menus.Single(s => s.Name == "Dinner Set").ID}

            };

            foreach (ItemJMenu jItemMenu in itemMenu)
            {
                context.ItemJMenus.Add(jItemMenu);
            }

            context.SaveChanges();


        }
    }
}
