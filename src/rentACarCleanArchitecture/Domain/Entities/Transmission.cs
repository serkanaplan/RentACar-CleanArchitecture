﻿
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Transmission : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }
    public Transmission() => Models = [];
    public Transmission(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
