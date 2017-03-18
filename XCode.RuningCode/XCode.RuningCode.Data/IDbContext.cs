using System.Data.Entity;

namespace XCode.RuningCode.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        int ExecuteSqlCommand(string sql,params object[] parameters);
    }
}
