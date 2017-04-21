using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Framework;
using System.Data;
using System.Data.SqlClient;


namespace DataLayer
{
    public class categoryData
    {
        private DataAccess ObjectOfDataAccess = new DataAccess();

        public DataTable populateCategory()
        {
            string checkCommand = "SELECT catName FROM  category;";

            SqlCommand command = new SqlCommand(checkCommand);

            var d = ObjectOfDataAccess.Query(command);
            if (d.Rows.Count > 0)
            {
                return d;
            }
            else
            {
                return null;
            }
        }

    }
}
