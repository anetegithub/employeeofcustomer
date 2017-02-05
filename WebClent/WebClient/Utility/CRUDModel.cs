using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebClient.Interfaces;
using WebClient.Repositories;

namespace WebClient
{
    public static class CRUDModel
    {
        public static bool Create<T>(this T Model)
            where T : class, ICRUDModel
        {
            using (var Repo = new CRUDRepository<T>())
            {
                return Repo.Add(Model) == 1;
            }
        }

        public static T Read<T>(this T Model, int Id)
            where T : class, ICRUDModel
        {
            using (var Repo = new CRUDRepository<T>())
            {
                return Repo.GetById(Id);
            }
        }

        public static bool Update<T>(this T Model)
            where T : class, ICRUDModel
        {
            using (var Repo = new CRUDRepository<T>())
            {
                return Repo.Update(Model) == 1;
            }
        }

        public static bool Delete<T>(this T Model)
            where T : class, ICRUDModel
        {
            using (var Repo = new CRUDRepository<T>())
            {
                return Repo.Remove(Model) == 1;
            }
        }

        public static List<T> Linq<T>(this T Model, Func<DbSet<T>, List<T>> Constraint)
            where T : class, ICRUDModel
        {
            using (var Repo = new CRUDRepository<T>())
            {
                return Repo.Linq(Constraint);
            }
        }

        public static void Query<T>(this T Model, Action<DbSet<T>> Constraint)
            where T : class, ICRUDModel
        {
            using (var Repo = new CRUDRepository<T>())
            {
                Repo.Query(Constraint);
            }
        }
    }
}