
namespace PizzaConstructor.Data.Infrastucture
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Entities;

    public class SimpleInitializer : CreateDatabaseIfNotExists<PizzaDataContext>
    {
        protected override void Seed(PizzaDataContext context)
        {

            User u1 = new User("Oleksandr Yatsenko", "yats.sasha@gmail.com");
            
            Contact c1 = new Contact(Guid.NewGuid(), "John1", "000000", "USA");
            
            Ingredient i1 = new Ingredient(Guid.NewGuid(), "Tomato", 5, "/Content/Images/Layers/TomatoLayer.png", "/Content/Images/Tomato.png", Categories.Vegetables, 30);

            Ingredient i2 = new Ingredient(Guid.NewGuid(), "Pickle", 6, "/Content/Images/Layers/PickleLayer.png", "/Content/Images/Pickle.png", Categories.Vegetables, 30);

            Ingredient i3 = new Ingredient(Guid.NewGuid(), "Onion", 2, "/Content/Images/Layers/OnionLayer.png", "/Content/Images/Onion.png", Categories.Vegetables, 30);

            Ingredient i4 = new Ingredient(Guid.NewGuid(), "Mushroom", 8, "/Content/Images/Layers/MushroomLayer.png", "/Content/Images/Mushroom.png", Categories.Vegetables, 30);

            Ingredient i5 = new Ingredient(Guid.NewGuid(), "Olivas-Black", 4, "/Content/Images/Layers/BlackOlivaLayer.png", "/Content/Images/Olivas-Black.png", Categories.Vegetables, 30);

            Ingredient i6 = new Ingredient(Guid.NewGuid(), "Olivas-Green", 4, "/Content/Images/Layers/GreenOlivaLayer.png", "/Content/Images/Olivas-Green.png", Categories.Vegetables, 30);

            Ingredient i7 = new Ingredient(Guid.NewGuid(), "Cheader", 6, "/Content/Images/Layers/ChedderLayer.png", "/Content/Images/Cheader.png", Categories.Cheese, 20);

            Ingredient i8 = new Ingredient(Guid.NewGuid(), "Mozzarella", 6, "/Content/Images/Layers/MozarellaLayer.png", "/Content/Images/Mozzarella.png", Categories.Cheese, 20);

            Ingredient i9 = new Ingredient(Guid.NewGuid(), "Pepperoni", 14, "/Content/Images/Layers/PepperoniLayer.png", "/Content/Images/Pepperoni.png", Categories.Meat, 40);

            Ingredient i10 = new Ingredient(Guid.NewGuid(), "Chicken", 12, "/Content/Images/Layers/ChickenLayer.png", "/Content/Images/Chicken.png", Categories.Meat, 40);

            Ingredient i11 = new Ingredient(Guid.NewGuid(), "Salami", 15, "/Content/Images/Layers/SalamiLayer.png", "/Content/Images/Salami.png", Categories.Meat, 40);

            Ingredient i12 = new Ingredient(Guid.NewGuid(), "Bacon", 15, "/Content/Images/Layers/BaconLayer.png", "/Content/Images/Bacon.png", Categories.Meat, 40);

            Ingredient i13 = new Ingredient(Guid.NewGuid(), "Shrimp", 20, "/Content/Images/Layers/SrimpLayer.png", "/Content/Images/Shrimp.png", Categories.SeaFood, 50);
            
            Ingredient i14 = new Ingredient(Guid.NewGuid(), "Cetchup", 1, "/Content/Images/Layers/SouseLayer.png", "/Content/Images/Cetchup.png", Categories.Souses, 10);
            
            Ingredient i15 = new Ingredient(Guid.NewGuid(), "Dough", 10, "/Content/Images/Layers/DoughLayer.png", "/Content/Images/Dough.png", Categories.Dough, 5);

            Ingredient i16 = new Ingredient(Guid.NewGuid(), "Pineapple", 6, "/Content/Images/Layers/PineappleLayer.png", "/Content/Images/Pineapple.png", Categories.Vegetables, 30);
            
            PizzaTemplate p2 = new PizzaTemplate(Guid.NewGuid(), "Margarita Template", "URL here", 27);
            p2.Ingredients.Add(i7);
            p2.Ingredients.Add(i1);
            p2.Ingredients.Add(i2);
            p2.Ingredients.Add(i15);

            PizzaTemplate p3 = new PizzaTemplate(Guid.NewGuid(), "Meat Bomb Template", string.Empty, 35);
            p3.Ingredients.Add(i8);
            p3.Ingredients.Add(i5);
            p3.Ingredients.Add(i4);
            p3.Ingredients.Add(i3);
            p3.Ingredients.Add(i1);
            p3.Ingredients.Add(i15);

            PizzaTemplate p4 = new PizzaTemplate(Guid.NewGuid(), "Vegan Dream", string.Empty, 33);
            p4.Ingredients.Add(i7);
            p4.Ingredients.Add(i6);
            p4.Ingredients.Add(i2);
            p4.Ingredients.Add(i1);
            p4.Ingredients.Add(i15);

            context.Ingredients.Add(i1);
            context.Ingredients.Add(i2);
            context.Ingredients.Add(i3);
            context.Ingredients.Add(i4);
            context.Ingredients.Add(i5);
            context.Ingredients.Add(i6);
            context.Ingredients.Add(i7);
            context.Ingredients.Add(i8);
            context.Ingredients.Add(i9);
            context.Ingredients.Add(i10);
            context.Ingredients.Add(i11);
            context.Ingredients.Add(i12);
            context.Ingredients.Add(i13);
            context.Ingredients.Add(i14);
            context.Ingredients.Add(i15);
            context.Ingredients.Add(i16);
            context.Templates.Add(p2);
            context.Templates.Add(p3);
            context.Templates.Add(p4);
            context.Users.Add(u1);
            context.Contacts.Add(c1);

            base.Seed(context);
        }
    }
}
