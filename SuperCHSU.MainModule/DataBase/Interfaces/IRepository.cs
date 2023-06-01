using System.Collections.Generic;
using System.Linq;

namespace SuperCHSU.MainModule.DataBase.Interfaces;

public interface IRepository<T> where T : class, IEntity, new()
{
    IQueryable<T> Items { get; }

    T Get(int id);

    T Add(T item);

    void Update(T item);

    void Remove(int id);
}