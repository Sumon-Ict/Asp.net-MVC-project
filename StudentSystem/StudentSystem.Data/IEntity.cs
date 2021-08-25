using System;

namespace StudentSystem.Data
{
    public interface IEntity<T>
    {

        T Id { get; set; }

    }
}
