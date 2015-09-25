using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace EFBLL
{
    public class BaseBll<TEntity> where TEntity : class
    {
        BaseDAL<TEntity> dal=new BaseDAL<TEntity>();

        public DbSet<TEntity> DbSet
        {
            get
            {
                return dal.DbSet;
            }
        }

        public List<TEntity> WhereAll()
        {
           return dal.WhereALL();
        }

        public List<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return dal.Where(predicate);
        }


        public void  Update(TEntity model,string[] props){
            dal.Update(model,props);
        }

        public void Delete(TEntity model, bool isManage)
        {
            dal.Delete(model,isManage);
        }

        public void SaveChanges()
        {
            dal.SaveChanges();
        }
    }
}
