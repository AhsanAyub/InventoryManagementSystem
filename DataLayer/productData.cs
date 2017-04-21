using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using Entity;
using Framework;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class productData
    {
        private DataAccess ObjectOfDataAccess = new DataAccess();

        public DataTable ShowProducts(String key)
        {
            string checkCommand = "SELECT prodID AS ID, prodName AS Name, itemRemaining AS Item, prodExpiration AS Expiration, prodPrice AS Price FROM  product where catName = '" + key + "';";

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

        public bool DeleteProduct(int key)
        {
            string checkCommand = "DELETE FROM product WHERE prodID = " + key;

            SqlCommand command = new SqlCommand(checkCommand);

            if (ObjectOfDataAccess.ExecuteCommand(command) == 1)
            {
                return true;
            }
            else
                return false;

        }
        public bool UpdateProduct(productEntity product)
        {
            string checkCommand = "UPDATE product SET prodName = '" + product.prodName + "', itemRemaining = " + product.itemRemaining + ", prodPrice = " + product.prodPrice + ", prodExpiration = '" + product.prodExpiration + "' WHERE prodID = " + product.prodID;
            SqlCommand command = new SqlCommand(checkCommand);

            if (ObjectOfDataAccess.ExecuteCommand(command) == 1)
                return true;
            else
                return false;
        }

        public bool InsertProduct(productEntity product)
        {
            //INSERT INTO product (prodName, itemRemaining, prodPrice, prodExpiration, catName)
            //VALUES ('Savlon', 20, 30,'01-Nov-16', 'Soaps');
            //string checkCommand = "UPDATE product SET prodName = '" + product.prodName + "', itemRemaining = " + product.itemRemaining + ", prodPrice = " + product.prodPrice + ", prodExpiration = '" + product.prodExpiration + "' WHERE prodID = " + product.prodID;
            string checkCommand =   "INSERT INTO product (prodName, itemRemaining, prodPrice, prodExpiration, catName) " +
                                    "VALUES ('" + product.prodName +"', " + product.itemRemaining +", " + product.prodPrice + ",'" + product.prodExpiration +"', '" + product.catName + "');";

            SqlCommand command = new SqlCommand(checkCommand);

            if (ObjectOfDataAccess.ExecuteCommand(command) == 1)
                return true;
            else
                return false;
        }
    }
}