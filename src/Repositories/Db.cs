using Dapper;
using EntityModel.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Npgsql;
using System.Threading.Tasks;

namespace EntityModel.Repositories
{
    public abstract class EntityKey<TType>
    {
        public TType Key { get; private set; }

        public EntityKey(TType value)
        {
            Key = value;
        }
    }

    public class Entity<TKey, TEntity>
    {
        public Entity(TKey key, TEntity value)
        {
            Key = key;
            Element = value;
        }

        public TKey Key { get; private set; }
        public TEntity Element { get; private set; }

        public static implicit operator TEntity(Entity<TKey, TEntity> entity)
        {
            return entity.Element;
        }
    }
}
