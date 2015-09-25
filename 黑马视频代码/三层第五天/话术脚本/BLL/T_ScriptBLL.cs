using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 话术脚本.DAL;
using 话术脚本.Model;

namespace 话术脚本.BLL
{
    public class T_ScriptBLL
    {
        T_ScriptsDAL dal = new T_ScriptsDAL();
        public List<Scripts> GetSonNodesById(int id)
        {
            return dal.GetSonNodesById(id);
        }


        /// <summary>
        /// 根据节点Id获得Msg
        /// </summary>
        /// <param name="id">节点Id</param>
        /// <returns></returns>
        public string GetMsgById(int id)
        {
            return (string)dal.GetMsgById(id);
        }


        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Insert(Scripts s)
        {
            return dal.Insert(s);
        }

        /// <summary>
        /// 递归删除数据
        /// </summary>
        /// <param name="id"></param>
        public void RecDelete(int id)
        {
            List<Scripts> list = GetSonNodesById(id);
            foreach (var item in list)
            {
                RecDelete(item.ID);
            }
            Delete(id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Update(Scripts s)
        {
            return dal.Update(s);
        }
    }
}
