using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.BLL
{
    public partial class HKSJ_USERS
    {
        public bool Delete(News.Model.HKSJ_USERS user)
        {
            return dal.Delete(user.ID);
        }

        public int GetCount()
        {
            return dal.GetRecordCount(string.Empty);
        }

        public List<News.Model.HKSJ_USERS> GetUserList(int maximumRows, int startRowIndex)
        {
            var userDataSet=dal.GetListByPage(string.Empty, "ID", startRowIndex + 1, startRowIndex + maximumRows);
            return DataTableToList(userDataSet.Tables[0]);
        }
    }
}