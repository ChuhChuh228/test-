namespace test.Entities;

public class Coffee : IEntity
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string TypeOFCofee { get; set; } 
    public int PricePerOneCoffe { get; set; }
    public int QuantityOfSoldCoffe { get; set; }

}