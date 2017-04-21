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

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        private categoryData catData = new categoryData();
        private productData prodData = new productData();
        private productEntity _prod = new productEntity();

        private String categoryNameSelected = "";

        private void loadCategoricalItem()
        {
            var d = catData.populateCategory();
            List<string> result = new List<string>();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(d.Rows[i][0].ToString());
            }

            BindingSource categoricalItem = new BindingSource();
            categoricalItem.DataSource = result;

            categoryName.DataSource = categoricalItem;
        }

        public MainForm()
        {
            InitializeComponent();
            loadCategoricalItem();
            
            deleteProduct.Visible = false;
            updateProduct.Visible = false;
        }

        private void LoadDataGrid(string key)
        {
            dataGridView1.DataSource = prodData.ShowProducts(key);
        }

        private void categoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryNameSelected = categoryName.SelectedItem.ToString();
            LoadDataGrid(categoryNameSelected);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                _prod.prodID = Convert.ToInt32(selectedRow.Cells[0].Value);
                _prod.prodName = selectedRow.Cells[1].Value.ToString();
                _prod.itemRemaining = Convert.ToInt32(selectedRow.Cells[2].Value);
                _prod.prodExpiration = selectedRow.Cells[3].Value.ToString();
                _prod.prodPrice = Convert.ToInt32(selectedRow.Cells[4].Value);
                _prod.catName = categoryNameSelected;
            }
            else
                return;

            loadButtons();
        }

        private void loadButtons()
        {
            deleteProduct.Visible = true;
            updateProduct.Visible = true;
        }

        private void updateProduct_Click(object sender, EventArgs e)
        {
            ProductInfo productInfo = new ProductInfo(_prod, 1);
            productInfo.Show();
            //this.Hide();
        }

        private void deleteProduct_Click(object sender, EventArgs e)
        {
            if (prodData.DeleteProduct(_prod.prodID))
                LoadDataGrid(categoryNameSelected);
            else
                return;
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            _prod.catName = categoryNameSelected;
            ProductInfo productInfo = new ProductInfo(_prod, 2);
            productInfo.Show();
        }



    }
}
