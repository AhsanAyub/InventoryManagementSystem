using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataLayer;
using Entity;
using Framework;

namespace InventoryManagementSystem
{
    public partial class ProductInfo : Form
    {
        private productData prodDate = new productData();
        private productEntity _prod = new productEntity();


        int id = 0;

        public ProductInfo(productEntity tempObject, int id /* 1 = insert & 2 = update*/)
        {
            InitializeComponent();

            this.id = id;
            _prod = tempObject;

            catID.Enabled = false;
            prodID.Enabled = false;

            fillData();
        }

        private void fillData()
        {
            catID.Text = _prod.catName;

            if (id == 1)
            {
                prodID.Text = _prod.prodID.ToString();
                expirationDate.Value = Convert.ToDateTime(_prod.prodExpiration);
                prodName.Text = _prod.prodName.ToString();
                prodPrice.Text = _prod.prodPrice.ToString();
                productItem.Text = _prod.itemRemaining.ToString();
            }
            else //no action for insert
                return;
        }

        private void getData()
        { 
            // product name
            _prod.prodName = prodName.Text.ToString();

            // product price
            try
            {
                string price = prodPrice.Text.ToString();
                _prod.prodPrice = Convert.ToInt32(price);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            // item
            try
            {
                string item = productItem.Text.ToString();
                _prod.itemRemaining = Convert.ToInt32(item);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        
            // expiration date
            string date = expirationDate.Value.ToString();
            date = date.Substring(0, 9);
            //MessageBox.Show(date);
            _prod.prodExpiration = date;
        }

        private bool checkInsertedItems()
        {
            
            if(string.IsNullOrWhiteSpace(prodName.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(prodPrice.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(productItem.Text))
            {
                return false;
            }
            getData();
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInsertedItems())
            {
                if (id == 1) //update
                {
                    if (prodDate.UpdateProduct(_prod))
                    {
                        MessageBox.Show("Update Successful!");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Update FAILURE!");
                }
                if (id == 2) //insert
                {
                    if (prodDate.InsertProduct(_prod))
                    {
                        MessageBox.Show("Insert Successful!");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Insert FAILURE!");
                }
            }
            else
            {
                MessageBox.Show("Textfields blanks");
                return;
            }
                    
        }

        private void prodName_TextChanged(object sender, EventArgs e)
        {
            //_prod.prodName = prodName.ToString();
        }

        private void productItem_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    _prod.itemRemaining = Convert.ToInt32(productItem.ToString());
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message);
            //}
        }

        private void prodPrice_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    _prod.prodPrice = Convert.ToInt32(prodPrice.ToString());
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message);
            //}
        }

        private void expirationDate_ValueChanged(object sender, EventArgs e)
        {
            //_prod.prodExpiration = Convert.ToString(expirationDate);
        }
    }
}
