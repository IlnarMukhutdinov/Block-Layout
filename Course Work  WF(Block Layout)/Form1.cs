using System;
using System.Drawing;
using System.Windows.Forms;
using Graph_placement_algorithm;

namespace Course_Work__WF_Block_Layout_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void local_degree_show()
        {
            Config_matrix.LocalDegreeCount();
            for (int i = 0; i < Config_matrix.N; i++)
            {
                adj_matrix_data_grid[adj_matrix_data_grid.ColumnCount - 2, i].Value = Config_matrix.LocalDegree[i];
            }
        }

        private void connectivity_show()
        {
            Algorithm.InternalLinksCount();
            Algorithm.ExternalLinksCount();
            Algorithm.ConnectivityCount();
            for (int i = 0; i < Config_matrix.N; i++)
            {
                adj_matrix_data_grid[adj_matrix_data_grid.ColumnCount - 1, i].Value = Algorithm.Connectivity[i];
            }
        }

        private void create_data_grid()
        {
            adj_matrix_data_grid.AllowUserToAddRows = false;
            adj_matrix_data_grid.ColumnCount = Config_matrix.N + 2;
            adj_matrix_data_grid.RowCount = Config_matrix.N;

            for (int i = 0; i < adj_matrix_data_grid.Columns.Count - 2; i++)
            {
                adj_matrix_data_grid.Columns[i].Name = Config_matrix.VertexShape[i + Config_matrix.Piececount * Config_matrix.M];
                adj_matrix_data_grid.Columns[i].Width = 40;
                adj_matrix_data_grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                adj_matrix_data_grid.Rows[i].HeaderCell.Value = Config_matrix.VertexShape[i + Config_matrix.Piececount * Config_matrix.M];
            }

            adj_matrix_data_grid.Columns[adj_matrix_data_grid.ColumnCount - 2].Name = "r";
            adj_matrix_data_grid.Columns[adj_matrix_data_grid.ColumnCount - 2].ReadOnly = true;
            adj_matrix_data_grid.Columns[adj_matrix_data_grid.ColumnCount - 2].Width = 40;

            adj_matrix_data_grid.Columns[adj_matrix_data_grid.ColumnCount - 1].Name = "a";
            adj_matrix_data_grid.Columns[adj_matrix_data_grid.ColumnCount - 1].Width = 40;
            adj_matrix_data_grid.Columns[adj_matrix_data_grid.ColumnCount - 1].ReadOnly = true;

            for (int i = 0; i < Config_matrix.N; i++)
            {
                adj_matrix_data_grid[i, i].ReadOnly = true;
                adj_matrix_data_grid[i, i].Style.BackColor = Color.DarkGray;
            }
            local_degree_show();
        }

        private void create_result_table()
        {
            result_table.Visible = true;
            result_table.AllowUserToAddRows = false;
            result_table.ColumnCount = 1;
            result_table.RowCount = Config_matrix.L;

            for (int i = 0; i < Config_matrix.L; i++)
            {
                result_table.Rows[i].HeaderCell.Value = "G" + (i + 1);
            }
            result_table.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btn_apply_changes_Click(object sender, EventArgs e)
        {
            Config_matrix.N = int.Parse(text_block_num_of_elem.Text);
            Config_matrix.L = int.Parse(text_block_num_of_blocks.Text);
            Config_matrix.M = int.Parse(text_block_num_of_elem_in_blocks.Text);
            Config_matrix.MatrixCreate();

            create_data_grid();
            for (int i = 0; i < adj_matrix_data_grid.ColumnCount; i++)
            {
                for (int j = 0; j < adj_matrix_data_grid.RowCount; j++)
                {
                    adj_matrix_data_grid[i, j].Value = 0;
                }
            }
            adj_matrix_data_grid.AllowUserToAddRows = false;
            btn_start_algorithm.Enabled = true;
            btn_simmetry.Enabled = true;
            create_result_table();
        }

        private void btn_start_algorithm_Click(object sender, EventArgs e)
        {
            adj_matrix_data_grid.Enabled = false;
            adj_matrix_data_grid.ForeColor = Color.Gray;
            if (Config_matrix.Piececount >= Config_matrix.L - 1)
            {
                for (int i = 0; i < Config_matrix.M; i++)
                {
                    if (i != Config_matrix.M - 1)
                        result_table[0, Config_matrix.Piececount].Value += Config_matrix.VertexShape[i + Config_matrix.M * Config_matrix.Piececount] + "; ";
                    else
                        result_table[0, Config_matrix.Piececount].Value += Config_matrix.VertexShape[i + Config_matrix.M * Config_matrix.Piececount];
                }
                btn_start_algorithm.Enabled = false;
                return;
            }

            Algorithm.InternalLinksCount();
            Algorithm.ExternalLinksCount();
            Algorithm.ConnectivityCount();
            Algorithm.DeltaCount();
            Algorithm.SwapVertex();
            for (int i = 0; i < Config_matrix.N; i++)
            {
                for (int j = 0; j < Config_matrix.N; j++)
                {
                    adj_matrix_data_grid[j, i].Value = Config_matrix.AdjMatrixC[i, j];
                }
            }

            string save = adj_matrix_data_grid.Columns[SwapResult.I].Name;
            adj_matrix_data_grid.Columns[SwapResult.I].Name = adj_matrix_data_grid.Columns[SwapResult.J + Config_matrix.M].Name;
            adj_matrix_data_grid.Columns[SwapResult.J + Config_matrix.M].Name = save;

            adj_matrix_data_grid.Rows[SwapResult.I].HeaderCell.Value = adj_matrix_data_grid.Rows[SwapResult.J + Config_matrix.M].HeaderCell.Value;
            adj_matrix_data_grid.Rows[SwapResult.J + Config_matrix.M].HeaderCell.Value = save;

            if (!SwapResult.Flag)
            {
                int[,] savearr = new int[Config_matrix.N - Config_matrix.M, Config_matrix.N - Config_matrix.M];
                for (int i = Config_matrix.M; i < Config_matrix.N; i++)
                    for (int j = Config_matrix.M; j < Config_matrix.N; j++)
                    {
                        savearr[i - Config_matrix.M, j - Config_matrix.M] = Config_matrix.AdjMatrixC[i, j];
                    }

                Config_matrix.N -= Config_matrix.M;
                Config_matrix.AdjMatrixC = new int[Config_matrix.N, Config_matrix.N];

                for (int i = 0; i < Config_matrix.N; i++)
                    for (int j = 0; j < Config_matrix.N; j++)
                    {
                        Config_matrix.AdjMatrixC[i, j] = savearr[i, j];
                    }
                
                for (int i = 0; i < Config_matrix.M; i++)
                {
                    if (i != Config_matrix.M - 1)
                        result_table[0, Config_matrix.Piececount].Value += Config_matrix.VertexShape[i + Config_matrix.M * Config_matrix.Piececount] + "; ";
                    else
                        result_table[0, Config_matrix.Piececount].Value += Config_matrix.VertexShape[i + Config_matrix.M * Config_matrix.Piececount];
                }
                

                Config_matrix.Piececount++;

                create_data_grid();
                for (int i = 0; i < Config_matrix.N; i++)
                {
                    for (int j = 0; j < Config_matrix.N; j++)
                    {
                        adj_matrix_data_grid[j, i].Value = Config_matrix.AdjMatrixC[i, j];
                    }
                }
                local_degree_show();
                connectivity_show();

                /*string ver = "";
                if (Config_matrix.Piececount == 1)
                {
                    for (int i = 0; i < Config_matrix.M; i++)
                    {
                        if (i != 2)
                            ver += Config_matrix.VertexShape[i] + "; ";
                        else
                            ver += Config_matrix.VertexShape[i];
                    }
                    label_g1.Text = "{" + ver + "}";
                    label_g1.Visible = true;
                }*/
            }
        }

        private void btn_simmetry_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Config_matrix.N; i++)
            {
                for (int j = i + 1; j < Config_matrix.N; j++)
                {
                    Config_matrix.AdjMatrixC[j, i] = Config_matrix.AdjMatrixC[i, j];
                    adj_matrix_data_grid[i, j].Value = adj_matrix_data_grid[j, i].Value;
                }
            }
            local_degree_show();
            connectivity_show();
        }

        private void adj_matrix_data_grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Config_matrix.AdjMatrixC[adj_matrix_data_grid.CurrentCell.RowIndex,
                    adj_matrix_data_grid.CurrentCell.ColumnIndex] = int.Parse(adj_matrix_data_grid.CurrentCell.Value.ToString());
                local_degree_show();

            }
            catch (NullReferenceException)
            {
                adj_matrix_data_grid.CurrentCell.Value = 0;
                Config_matrix.AdjMatrixC[adj_matrix_data_grid.CurrentCell.RowIndex,
                    adj_matrix_data_grid.CurrentCell.ColumnIndex] = int.Parse(adj_matrix_data_grid.CurrentCell.Value.ToString());
            }
            connectivity_show();
        }

        private void result_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
