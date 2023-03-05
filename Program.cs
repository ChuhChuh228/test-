using test.Entities;
using test.Contexts;

var context = new CoffeeContext();
context.Create(new Coffee
{
    TypeOFCofee = "Arabic",
    PricePerOneCoffe = 10,
    QuantityOfSoldCoffe = 100
});
context.Create(new Coffee
{
    TypeOFCofee = "Chernogoriy",
    PricePerOneCoffe = 15,
    QuantityOfSoldCoffe = 100
});
context.Create(new Coffee
{
    TypeOFCofee = "Peremoloty",
    PricePerOneCoffe = 12,
    QuantityOfSoldCoffe = 100
});
context.Save();
context.PrintAllSortedByPrice();