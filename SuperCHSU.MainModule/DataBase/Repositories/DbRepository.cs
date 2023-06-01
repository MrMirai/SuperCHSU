using System;
using System.Collections.Generic;
using System.Linq;
using SuperCHSU.MainModule.DataBase.Context;
using SuperCHSU.MainModule.DataBase.Entities.Base;
using SuperCHSU.MainModule.DataBase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SuperCHSU.MainModule.DataBase.Repositories;

public class DbRepository<T> : IRepository<T> where T : Entity, new()
{
    private readonly ScheduleContext _db;
    private readonly DbSet<T> _set;

    public bool AutoSaveChanges { get; set; } = true;

    public DbRepository(ScheduleContext db)
    {
        _db = db;
        _set = db.Set<T>();
    }

    public virtual IQueryable<T> Items => _set;
    public T Get(int id) => Items.SingleOrDefault(item => item.Id == id)!;

    public T Add(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        _db.Entry(item).State = EntityState.Added;
        if (AutoSaveChanges)
        {
            _db.SaveChanges();
        }

        return item;
    }

    public void Update(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        _db.Entry(item).State = EntityState.Modified;
        if (AutoSaveChanges)
        {
            _db.SaveChanges();
        }
    }

    public void Remove(int id)
    {
        //var item = Get(id);
        //if (item is null) return;
        //_db.Entry(item);

        var item = _set.Local.FirstOrDefault(i => i.Id == id) ?? new T { Id = id };

        _db.Remove(item);

        if (AutoSaveChanges)
            _db.SaveChanges();
    }
}