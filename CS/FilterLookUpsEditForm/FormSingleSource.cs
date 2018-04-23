using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FilterLookUpsEditForm
{
    public partial class FormSingleSource : Form
    {
        public FormSingleSource()
        {
            InitializeComponent();
            gridControl1.DataSource = GetData(10);

            RepositoryItemLookUpEdit ritem = new RepositoryItemLookUpEdit(); // for Type column
            ritem.DataSource = GetLookData();
            ritem.ValueMember = "ID";
            ritem.DisplayMember = "ProductType";

            ritemProducts.ValueMember = "ID";
            ritemProducts.DisplayMember = "Name";
            originalData = GetLookUpDataForFiltering();
            ritemProducts.DataSource = originalData;

            gridView1.Columns["ProductType"].ColumnEdit = ritem;
            gridView1.Columns["Name"].ColumnEdit = ritemProducts;

            gridView1.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;
            gridView1.EditFormPrepared += new EditFormPreparedEventHandler(gridView1_EditFormPrepared);
        }

        RepositoryItemLookUpEdit ritemProducts = new RepositoryItemLookUpEdit();

        LookUpEdit filteredLookUp;
        LookUpEdit baseLookUp;
        DataView clone = null;
        DataTable originalData = null;
        void gridView1_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            baseLookUp = e.BindableControls["ProductType"] as LookUpEdit;
            filteredLookUp = e.BindableControls["Name"] as LookUpEdit;
            if (baseLookUp != null && filteredLookUp != null)
            {
                filteredLookUp.Enter -= filteredLookUp_Enter;
                filteredLookUp.Enter += filteredLookUp_Enter;
                filteredLookUp.Leave -= filteredLookUp_Leave;
                filteredLookUp.Leave += filteredLookUp_Leave;
            }
        }

        void filteredLookUp_Leave(object sender, EventArgs e)
        {
            filteredLookUp.Properties.DataSource = originalData;
            if (clone != null)
            {
                clone.Dispose();
                clone = null;
            }
        }
        void filteredLookUp_Enter(object sender, EventArgs e)
        {
            DataTable table = filteredLookUp.Properties.DataSource as DataTable;
            clone = new DataView(table);
            string country = baseLookUp.Properties.GetDisplayValueByKeyValue(baseLookUp.EditValue).ToString();
            clone.RowFilter = string.Format("[ProductType] = '{0}'", country);
            filteredLookUp.Properties.DataSource = clone;
        }

        #region Data
        DataTable GetLookData() // for LookUpEdit from the Type column
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ProductType", typeof(string));
            dt.Rows.Add(0, "Vegetable");
            dt.Rows.Add(1, "Fruit");
            return dt;
        }

        DataTable GetLookUpDataForFiltering()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ProductType", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(0, "Fruit", "Apple");
            dt.Rows.Add(1, "Vegetable", "Tomato");
            dt.Rows.Add(2, "Fruit", "Banana");
            dt.Rows.Add(3, "Fruit", "Orange");
            dt.Rows.Add(4, "Vegetable", "Onion");
            dt.Rows.Add(5, "Vegetable", "Pepper");
            dt.Rows.Add(6, "Vegetable", "Cucumber");
            dt.Rows.Add(7, "Fruit", "Peach");
            dt.Rows.Add(8, "Vegetable", "Pumpkin");
            dt.Rows.Add(9, "Fruit", "Mango");
            return dt;
        }

        DataTable GetData(int rows) // for GridControl
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductType", typeof(int));
            dt.Columns.Add("Name", typeof(int));
            for (int i = 0; i < rows; i++)
                dt.Rows.Add(1, 0);
            return dt;
        }
        #endregion
    }
}
