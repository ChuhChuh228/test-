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

    //это я пытаюсь 3 сделать через bogosort )))))))))
    //public void PrintAllSortedByDate()
    //{
    //    List<Coffee> _coffeeSorted = _coffees;
//
    //    int SizeOfList = 0;
//
    //    foreach(var cof in _coffeeSorted)
    //    {
    //        SizeOfList += 1;
    //    }
//
    //    while (true)
    //    {
    //        int[] ArrayOfNumbers = new int[SizeOfList];
    //        int TEMP = 0;
    //        Random ran = new Random();
    //        bool Swithcer = false;
    //        for (int i = 0; i < SizeOfList; i++)
    //        {
    //            ArrayOfNumbers[i] = i;
    //        }
    //        for (int i = 0; i < SizeOfList; i++)
    //        {
    //            while (Swithcer == false)
    //            {
    //                TEMP = ran.Next(0, SizeOfList);
    //                for (int j = 0; j < SizeOfList;j++)
    //                {
    //                    if (TEMP == ArrayOfNumbers[j])
    //                    {
    //                        ArrayOfNumbers[j] = 666;
    //                        Swithcer = true;
    //                        break;
    //                    }
    //                }
    //            }
    //            _coffeeSorted[i] = _coffees[TEMP];
    //        }
    //        for (int i = 0; i < SizeOfList; i++)
    //        {
    //            for 
    //        }
    //    }
//
    //}

    public void PrintAllSortedByPrice()
    {
        List<Coffee> _coffeeSorted = _coffees;
        int SizeOfList = 0;
        foreach(var cof in _coffeeSorted)
        {
            SizeOfList += 1;
        }
        for (int i = 0; i < SizeOfList- 1; i++)
            for (int j = 0; j < SizeOfList - i - 1; j++)
            {
                var cofnew = _coffeeSorted[j];
                var cofnext = _coffeeSorted[j + 1];
                if (cofnew.PricePerOneCoffe > cofnext.PricePerOneCoffe)
                {
                    _coffeeSorted[j] = cofnext;
                    _coffeeSorted[j + 1] = cofnew;
                }
            }
        
        for (int i = 0; i < SizeOfList; i++)
        {
            var TEMP = _coffeeSorted[i];
            Console.WriteLine("_____");
            Console.WriteLine(TEMP.TypeOFCofee);
            Console.WriteLine(TEMP.PricePerOneCoffe);
            Console.WriteLine(TEMP.QuantityOfSoldCoffe);
        }
        
    }

}