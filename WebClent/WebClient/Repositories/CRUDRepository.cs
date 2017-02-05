using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebClient.Contexts;
using WebClient.Interfaces;

namespace WebClient.Repositories
{
    public class CRUDRepository<T> : IRepository<T>, IDisposable
       where T : class, ICRUDModel
    {
        SiteDbContext db = new SiteDbContext();

        public T GetById(int Id)
        {
            return Determine((Entity) =>
            {
                var Object = Entity
                    .Where(x => x.Id == Id)
                    .First();
                return Object;
            });
        }

        public static object GetById(int Id, string TName)
        {
            using (var db = new SiteDbContext())
            {
                foreach (var Property in typeof(SiteDbContext).GetProperties())
                {
                    if (Property.PropertyType.Name.Contains("DbSet"))
                        if (Property.PropertyType.GetGenericArguments()
                            .Where(x => x.Name == TName)
                            .Count() > 0)
                        {
                            var Entity = Property.GetValue(db) as DbSet<T>;
                            return Entity.Where(x => x.Id == Id)
                                .FirstOrDefault();
                        }
                }
                return default(T);
            }
        }

        public int Add(T Model)
        {
            int SaveCode = 0;

            Determine((Entity) =>
            {
                Model.Created = DateTime.Now;
                Model.Changed = DateTime.Now;
                Entity.Add(Model);
                SaveCode = db.SaveChanges();
                return default(T);
            });

            return SaveCode;
        }

        public int Update(T Model)
        {
            int SaveCode = 0;

            Determine((Entity) =>
            {
                Model.Changed = DateTime.Now;
                var Entry = db.Entry(Model);
                Entry.State = EntityState.Modified;
                SaveCode = db.SaveChanges();
                return default(T);
            });

            return SaveCode;
        }

        public int Remove(T Model)
        {
            int SaveCode = 0;

            Determine((Entity) =>
            {
                Model.Changed = DateTime.Now;
                Model.Deleted = true;
                Entity.Attach(Model);
                Entity.Remove(Model);
                SaveCode = db.SaveChanges();
                return default(T);
            });

            return SaveCode;
        }

        public List<T> Linq(Func<DbSet<T>, List<T>> Constraint)
        {
            List<T> Data = new List<T>();

            Determine((Entity) =>
            {
                Data = Constraint(Entity);
                return default(T);
            });

            return Data;
        }

        public void Query(Action<DbSet<T>> Constraint)
        {
            Determine((db) =>
            {
                Constraint(db);
                return default(T);
            });
        }

        public List<T> All(System.Linq.Expressions.Expression<Func<T, bool>> Constraint)
        {
            List<T> Data = new List<T>();

            Determine((Entity) =>
            {
                Data = Entity
                    .Where(Constraint)
                    .ToList();
                return default(T);
            });

            return Data;
        }

        private T Determine(Func<DbSet<T>, T> EntityProcess)
        {
            foreach (var Property in typeof(SiteDbContext).GetProperties())
            {
                if (Property.PropertyType.Name.Contains("DbSet"))
                    if (Property.PropertyType.GetGenericArguments()
                        .Where(x => x == typeof(T))
                        .Count() > 0)
                    {
                        var Entity = Property.GetValue(db) as DbSet<T>;
                        return EntityProcess(Entity);
                    }
            }
            return default(T);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}