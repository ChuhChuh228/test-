using test.Entities;

namespace test.Contexts;

public interface IContext<T> where T : IEntity
{
    void Create(T entity);

    // Обновление сущности в базе
    void Update(T entity);

    // Удаление сущности в базе по айди
    void Delete(Guid id);

    // Удаление сущости в базе по сущности (по факту по айди)
    void Delete(T entity);

    // Получить все сущности из базы
    IEnumerable<T> GetAll();
}