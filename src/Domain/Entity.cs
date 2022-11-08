using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Domain;

public abstract class Entity
{
    public ObjectId Id { get; set; }
}