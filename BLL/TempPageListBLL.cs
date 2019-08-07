using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TempPageListBLL
    {
        TempPageListDAL dal = new TempPageListDAL();

        public int batchDeleteInfo(string[] array) 
        {
            return dal.batchDeleteInfo(array);
        }
    }
}
