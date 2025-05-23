using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public class Datagrid
    {
        public static void DataGridView(DataGridView grid, DataTable data)
        {
            
            BindingSource bindingSource = new BindingSource();
            grid.Visible = true;
            grid.DataSource = null;

            HeaderColons(data);

            bindingSource.DataSource = data;
            grid.DataSource = bindingSource;
            
            grid.Columns[0].HeaderText = "Ekip";
            grid.Columns[1].HeaderText = "Sürüm No";
            grid.Columns[2].HeaderText = "Güncelleme Tarihi";
            grid.Columns[3].HeaderText = "Tip";
            grid.Columns[4].HeaderText = "Açıklama";
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            grid.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            grid.MultiSelect = true;
            grid.Columns[1].ReadOnly = true;
            grid.Dock = DockStyle.None;
            grid.AllowUserToAddRows = false;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.Sort(grid.Columns[2], ListSortDirection.Descending);
            grid.Columns[4].DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
            grid.Refresh();
        }
        

        public static void HeaderColons(DataTable data)
        {
            if (data.Columns.Count == 0)
            {
                data.Columns.Add("teams", typeof(string));
                data.Columns.Add("version", typeof(string)); 
                data.Columns.Add("updateTime", typeof(DateTime)); 
                data.Columns.Add("type", typeof(string)); 
                data.Columns.Add("description", typeof(string)); 
                
            }
        }

        public static void SetColor(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    switch (row.Cells[3].Value.ToString())
                    {
                        case "Hata":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240);
                            break;
                        case "Yeni":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
                            break;
                    }
                }
            }
        }
    } }

