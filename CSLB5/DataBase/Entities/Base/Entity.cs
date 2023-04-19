using CSLB5.DataBase.Interfaces;

namespace CSLB5.DataBase.Entities.Base;

public abstract class Entity : IEntity
{
    public long Id { get; set; }
}