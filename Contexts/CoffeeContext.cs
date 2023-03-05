using test.Entities;
using System.Text.Json;

namespace test.Contexts;

public class CoffeeContext : IContext<Coffee>
{
    private string _fileName = "coffees.json"; // название файла
    private List<Coffee> _coffees;

    public CoffeeContext()
    {
        if (!File.Exists(_fileName))
            File.Create(_fileName);
        var reader = new StreamReader(_fileName);
        string fileContent = reader.ReadToEnd();
        reader.Close();
        if (fileContent.Length < 2)
            _coffees = new List<Coffee>();
        else

            _coffees = JsonSerializer.Deserialize<List<Coffee>>(fileContent);
    }

    public void Save()
    {
        // Лист пользователей превращаю в json строку
        string json = JsonSerializer.Serialize(_coffees);

        // Перезаписываю файл с юзерами новой json строкой
        var writer = new StreamWriter(_fileName);
        writer.Write(json);
        writer.Close();
    }
    public void Create(Coffee entity)
    {
        _coffees.Add(entity);
    }

    public void Delete(Guid id)
    {
        _coffees.RemoveAll(Coffee => Coffee.Id == id);
    }

    public void Delete(Coffee entity)
    {
        Delete(entity.Id);
    }

     public IEnumerable<Coffee> GetAll()
    {
        return _coffees;
    }

    public void Update(Coffee entity)
    {
        // Ищу в списке пользователя с таким id
        var coffee = _coffees.FirstOrDefault(coffee => coffee.Id == entity.Id);

        // Если такого пользователя нет - выдать ошибку
        if (coffee is null)
            throw new ArgumentException("Update error. User not found");

        coffee.TypeOFCofee = entity.TypeOFCofee;
        coffee.PricePerOneCoffe = entity.PricePerOneCoffe;
        coffee.QuantityOfSoldCoffe = entity.QuantityOfSoldCoffe;
    }

    public void PrintAllSortedByDate() //ну или так-же как и 4-тое, просто там заменить на 146 строчке PricePerOneCoffe на CreatedAt 
    {
        for (int i = 0; i < _coffees.Count- 1; i++)
            for (int j = 0; j < _coffees.Count - i - 1; j++)
            {
                var cofnew = _coffees[j];
                var cofnext = _coffees[j + 1];
                if (cofnew.CreatedAt > cofnext.CreatedAt)
                {
                    _coffees[j] = cofnext;
                    _coffees[j + 1] = cofnew;
                }
            } 
        
        for (int i = 0; i < _coffees.Count; i++)
        {
            var TEMP = _coffees[i];
            Console.WriteLine("_____");
            Console.WriteLine(TEMP.TypeOFCofee);
            Console.WriteLine(TEMP.PricePerOneCoffe);
            Console.WriteLine(TEMP.QuantityOfSoldCoffe);
            Console.WriteLine(TEMP.CreatedAt);
        }

    }

    public void PrintAllSortedByPrice()
    {
        for (int i = 0; i < _coffees.Count- 1; i++)
            for (int j = 0; j < _coffees.Count - i - 1; j++)
            {
                var cofnew = _coffees[j];
                var cofnext = _coffees[j + 1];
                if (cofnew.PricePerOneCoffe > cofnext.PricePerOneCoffe)
                {
                    _coffees[j] = cofnext;
                    _coffees[j + 1] = cofnew;
                }
            } 
        
        for (int i = 0; i < _coffees.Count; i++)
        {
            var TEMP = _coffees[i];
            Console.WriteLine("_____");
            Console.WriteLine(TEMP.TypeOFCofee);
            Console.WriteLine(TEMP.PricePerOneCoffe);
            Console.WriteLine(TEMP.QuantityOfSoldCoffe);
        }
        
    }

    public double GetAllMoneyFromCoffee()
    {
        double AllMoney = 0;
        foreach(var cof in _coffees)
            AllMoney += cof.QuantityOfSoldCoffe * cof.PricePerOneCoffe;
        return AllMoney;
    }



}