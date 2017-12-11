using System;
using System.Windows.Forms;
using Graph_placement_algorithm;
using static Graph_placement_algorithm.Config_matrix;

namespace Course_Work__WF_Block_Layout_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_apply_chages_Click(object sender, EventArgs e)
        {
            Config_matrix.N = int.Parse(text_block_num_of_elem.Text);
            Config_matrix.L = int.Parse(text_block_num_of_blocks.Text);
            Config_matrix.M = int.Parse(text_block_num_of_elem_in_blocks.Text);
            
            adj_matrix_data_grid.ColumnCount = Config_matrix.N + 1;
            adj_matrix_data_grid.RowCount = Config_matrix.N;

            for (int i = 0; i < adj_matrix_data_grid.Columns.Count - 1; i++)
            {
                adj_matrix_data_grid.Columns[i].Name = "x" + (i + 1);
                adj_matrix_data_grid.Columns[i].Width = 40;
                adj_matrix_data_grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                adj_matrix_data_grid.Rows[i].HeaderCell.Value = "x" + (i + 1);
            }

            adj_matrix_data_grid.Columns[9].Name = "r";
            adj_matrix_data_grid.Columns[9].ReadOnly = true;
            adj_matrix_data_grid.Columns[9].Width = 40;

            for (int i = 0; i < adj_matrix_data_grid.ColumnCount; i++)
            {
                for (int j = 0; j < adj_matrix_data_grid.RowCount; j++)
                {
                    adj_matrix_data_grid[i, j].Value = 0;
                }
            }
            Config_matrix.MatrixCreate();
            btn_start_algorithm.Enabled = true;
        }

        private void adj_matrix_data_grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Config_matrix.AdjMatrixC[adj_matrix_data_grid.CurrentCell.RowIndex,
                    adj_matrix_data_grid.CurrentCell.ColumnIndex] = int.Parse(adj_matrix_data_grid.CurrentCell.Value.ToString());
                Config_matrix.LocalDegreeCount();
                for (int i = 0; i < adj_matrix_data_grid.RowCount; i++)
                {
                    adj_matrix_data_grid[9, i].Value = Config_matrix.LocalDegree[i];
                }

            }
            catch (NullReferenceException)
            {
                adj_matrix_data_grid.CurrentCell.Value = 0;
                Config_matrix.AdjMatrixC[adj_matrix_data_grid.CurrentCell.RowIndex,
                    adj_matrix_data_grid.CurrentCell.ColumnIndex] = int.Parse(adj_matrix_data_grid.CurrentCell.Value.ToString());
            }
        }
    }
}
