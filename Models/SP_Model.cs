using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SubSonic.Schema;

namespace Bodh.Models
{
    public class SP_Model
    {
        public static DataSet SP_Dashboard()
        {
            StoredProcedure sp = new StoredProcedure("SP_Dashboard");
            DataSet dt = sp.ExecuteDataSet();
            return dt;
        }
    }
}