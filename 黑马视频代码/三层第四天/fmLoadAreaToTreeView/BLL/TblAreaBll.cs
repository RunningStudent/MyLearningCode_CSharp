using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fmLoadArea.Model;

namespace fmLoadArea.BLL
{
    public class TblAreaBll
    {
        TblAreaDal dal = new TblAreaDal();


        /// <summary>
        /// 打酱油的逻辑层方法,返回Area数据集合
        /// </summary>
        /// <param name="areaPid"></param>
        /// <returns></returns>
        public List<Area> GetAreaDataByAreaPID(int areaPid)
        {
            return dal.GetAreaDataByAreaPID(areaPid);
        }



        /// <summary>
        /// 根据areaid递归删除该数据,已经其下的数据
        /// </summary>
        /// <param name="areaId"></param>
        public void RecDeleteAreaData(int areaId)
        {
            //遍历所有AreaPid=传入参数的数据
            List<Area> list=dal.GetAreaDataByAreaPID(areaId);
            foreach (var item in list)
            {
                //再遍历每个元素下一级的元素,对其使用递归方法
                RecDeleteAreaData(item.AreaId);
            }
            //如果foreach不执行,则这个无子节点,直接删除
            dal.DeleteAreaDateByAreaId(areaId); 
        }
    }
}
