using SuperCHSU.MainModule.DataBase.Interfaces;

namespace SuperCHSU.MainModule.DataBase.Entities.Base;

public abstract class Entity : IEntity
{
    public long Id { get; set; }
}