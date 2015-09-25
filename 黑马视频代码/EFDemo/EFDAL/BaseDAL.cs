using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL
{
    public class BaseDAL<TEntity> where TEntity : class
    {
        DalBaseEntities db = new DalBaseEntities();

        DbSet<TEntity> _dbSet;

        public BaseDAL()
        {
            _dbSet = db.Set<TEntity>();
        }

        #region  包装表对象,供外部使用
        public DbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }
        #endregion

        #region 查询

        /// <summary>
        /// 获得所有数据
        /// </summary>
        /// <returns></returns>
        public List<TEntity> WhereALL()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// 获得指定数据
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns></returns>
        public List<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        #endregion

        #region 新增

        public void Add(TEntity model)
        {
            _dbSet.Add(model);
        }

        #endregion

        #region 编辑


        /// <summary>
        /// 规定调用这个方法,说明,实体对象未被EF管理,如果被管理了,直接在对象上改,并SaveChange.
        /// </summary>
        /// <param name="model">被修改的Model,model内的主键必须有值</param>
        /// <param name="propertys">要修改的属性</param>
        public void Update(TEntity model, string[] propertys)
        {
            if (propertys == null || propertys.Length == 0)
            {
                throw new Exception("要指定更新的属性名");
            }

            DbEntityEntry entry = db.Entry<TEntity>(model);


            entry.State = EntityState.Unchanged;
            db.Configuration.ValidateOnSaveEnabled = false;

            foreach (var item in propertys)
            {
                entry.Property(item).IsModified = true;
            }
        }

        #endregion

        #region  删除
        public void Delete(TEntity model, bool isManage)
        {
            if (isManage)
            {
                //如果对象没有被管理,那么下面这句使之被EF管理
                _dbSet.Attach(model);
            }
            _dbSet.Remove(model);
        }
        #endregion

        #region 保存

        public void SaveChanges()
        {
            db.SaveChanges();
        }
        #endregion

    }
}
