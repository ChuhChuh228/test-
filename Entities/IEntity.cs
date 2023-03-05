namespace test.Entities;

// Интерфейс, описывающий каждую сущность в базе данных
public interface IEntity
{
    Guid Id { get; set; } // id
    DateTime CreatedAt { get; set; } // время создания
}