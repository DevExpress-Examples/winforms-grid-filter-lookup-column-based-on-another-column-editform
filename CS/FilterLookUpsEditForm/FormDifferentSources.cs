using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilterLookUpsEditForm
{
    public partial class FormDifferentSources : Form
    {
        public FormDifferentSources()
        {
            InitializeComponent(); gridControl1.DataSource = GetData(10);

            RepositoryItemLookUpEdit ritem = new RepositoryItemLookUpEdit(); // for Type column
            ritem.DataSource = GetLookData();
            ritem.ValueMember = "ID";
            ritem.DisplayMember = "Type";

            ritemFruits.ValueMember = "ID";
            ritemFruits.DisplayMember = "Fruit";
            ritemFruits.DataSource = GetFruits();

            ritemVegetables.ValueMember = "ID";
            ritemVegetables.DisplayMember = "Vegetable";
            ritemVegetables.DataSource = GetVegetables();

            gridView1.Columns["Type"].ColumnEdit = ritem;
            gridView1.Columns["Value"].ColumnEdit = ritemVegetables;

            gridView1.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;
            gridView1.CustomRowCellEdit += new CustomRowCellEditEventHandler(gridView1_CustomRowCellEdit);
            gridView1.EditFormPrepared += new EditFormPreparedEventHandler(gridView1_EditFormPrepared);
        }

        RepositoryItemLookUpEdit ritemVegetables = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit ritemFruits = new RepositoryItemLookUpEdit();

        LookUpEdit filteredLookUp;
        LookUpEdit baseLookUp;
        void gridView1_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            baseLookUp = e.BindableControls["Type"] as LookUpEdit;
            filteredLookUp = e.BindableControls["Value"] as LookUpEdit;
            if (baseLookUp != null && filteredLookUp != null)
            {
                baseLookUp.EditValueChanged -= baseLookUp_EditValueChanged;
                baseLookUp.EditValueChanged += baseLookUp_EditValueChanged;
            }
        }

        void baseLookUp_EditValueChanged(object sender, EventArgs e)
        {
            string type = baseLookUp.EditValue.ToString();
            if (type == "0") filteredLookUp.Properties.Assign(ritemVegetables);
            if (type == "1") filteredLookUp.Properties.Assign(ritemFruits);
        }


        void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Value")
            {
                GridView view = sender as GridView;
                string type = view.GetRowCellValue(e.RowHandle, "Type").ToString();
                if (type == "0") e.RepositoryItem = ritemVegetables;
                if (type == "1") e.RepositoryItem = ritemFruits;
            }
        }

        #region Data
        DataTable GetLookData() // for LookUpEdit from the Type column
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Type", typeof(string));
            dt.Rows.Add(0, "Vegetable");
            dt.Rows.Add(1, "Fruit");
            return dt;
        }

        DataTable GetVegetables()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Vegetable", typeof(string));
            dt.Rows.Add(0, "Tomato");
            dt.Rows.Add(1, "Onion");
            dt.Rows.Add(2, "Pepper");
            dt.Rows.Add(3, "Cucumber");
            dt.Rows.Add(4, "Pumpkin");
            return dt;
        }

        DataTable GetFruits()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Fruit", typeof(string));
            dt.Rows.Add(0, "Apple");
            dt.Rows.Add(1, "Banana");
            dt.Rows.Add(2, "Orange");
            dt.Rows.Add(3, "Peach");
            dt.Rows.Add(4, "Mango");
            return dt;
        }

        DataTable GetData(int rows) // for GridControl
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Type", typeof(int));
            dt.Columns.Add("Value", typeof(int));
            for (int i = 0; i < rows; i++)
                dt.Rows.Add(i % 2, i % 5);
            return dt;
        }
        #endregion
    }
}
