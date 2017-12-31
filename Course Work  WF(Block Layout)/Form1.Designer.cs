namespace Course_Work__WF_Block_Layout_
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.main_container = new System.Windows.Forms.SplitContainer();
            this.btn_open_result = new System.Windows.Forms.Button();
            this.btn_simmetry = new System.Windows.Forms.Button();
            this.btn_start_algorithm = new System.Windows.Forms.Button();
            this.btn_aplly_changes = new System.Windows.Forms.Button();
            this.text_block_num_of_elem_in_blocks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_block_num_of_blocks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_block_num_of_elem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.result_table = new System.Windows.Forms.DataGridView();
            this.adj_matrix_data_grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.main_container)).BeginInit();
            this.main_container.Panel1.SuspendLayout();
            this.main_container.Panel2.SuspendLayout();
            this.main_container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.result_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adj_matrix_data_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // main_container
            // 
            this.main_container.BackColor = System.Drawing.Color.White;
            this.main_container.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.main_container, "main_container");
            this.main_container.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.main_container.Name = "main_container";
            // 
            // main_container.Panel1
            // 
            this.main_container.Panel1.BackColor = System.Drawing.Color.White;
            this.main_container.Panel1.Controls.Add(this.btn_open_result);
            this.main_container.Panel1.Controls.Add(this.btn_simmetry);
            this.main_container.Panel1.Controls.Add(this.btn_start_algorithm);
            this.main_container.Panel1.Controls.Add(this.btn_aplly_changes);
            this.main_container.Panel1.Controls.Add(this.text_block_num_of_elem_in_blocks);
            this.main_container.Panel1.Controls.Add(this.label3);
            this.main_container.Panel1.Controls.Add(this.text_block_num_of_blocks);
            this.main_container.Panel1.Controls.Add(this.label2);
            this.main_container.Panel1.Controls.Add(this.text_block_num_of_elem);
            this.main_container.Panel1.Controls.Add(this.label1);
            this.main_container.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // main_container.Panel2
            // 
            this.main_container.Panel2.Controls.Add(this.result_table);
            this.main_container.Panel2.Controls.Add(this.adj_matrix_data_grid);
            resources.ApplyResources(this.main_container.Panel2, "main_container.Panel2");
            // 
            // btn_open_result
            // 
            resources.ApplyResources(this.btn_open_result, "btn_open_result");
            this.btn_open_result.Name = "btn_open_result";
            this.btn_open_result.UseVisualStyleBackColor = true;
            this.btn_open_result.Click += new System.EventHandler(this.btn_open_result_Click);
            // 
            // btn_simmetry
            // 
            resources.ApplyResources(this.btn_simmetry, "btn_simmetry");
            this.btn_simmetry.Name = "btn_simmetry";
            this.btn_simmetry.UseVisualStyleBackColor = true;
            this.btn_simmetry.Click += new System.EventHandler(this.btn_simmetry_Click);
            // 
            // btn_start_algorithm
            // 
            resources.ApplyResources(this.btn_start_algorithm, "btn_start_algorithm");
            this.btn_start_algorithm.Name = "btn_start_algorithm";
            this.btn_start_algorithm.UseVisualStyleBackColor = true;
            this.btn_start_algorithm.Click += new System.EventHandler(this.btn_start_algorithm_Click);
            // 
            // btn_aplly_changes
            // 
            resources.ApplyResources(this.btn_aplly_changes, "btn_aplly_changes");
            this.btn_aplly_changes.Name = "btn_aplly_changes";
            this.btn_aplly_changes.UseVisualStyleBackColor = true;
            this.btn_aplly_changes.Click += new System.EventHandler(this.btn_apply_changes_Click);
            // 
            // text_block_num_of_elem_in_blocks
            // 
            resources.ApplyResources(this.text_block_num_of_elem_in_blocks, "text_block_num_of_elem_in_blocks");
            this.text_block_num_of_elem_in_blocks.Name = "text_block_num_of_elem_in_blocks";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // text_block_num_of_blocks
            // 
            resources.ApplyResources(this.text_block_num_of_blocks, "text_block_num_of_blocks");
            this.text_block_num_of_blocks.Name = "text_block_num_of_blocks";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // text_block_num_of_elem
            // 
            resources.ApplyResources(this.text_block_num_of_elem, "text_block_num_of_elem");
            this.text_block_num_of_elem.Name = "text_block_num_of_elem";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // result_table
            // 
            resources.ApplyResources(this.result_table, "result_table");
            this.result_table.BackgroundColor = System.Drawing.Color.White;
            this.result_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.result_table.Name = "result_table";
            // 
            // adj_matrix_data_grid
            // 
            resources.ApplyResources(this.adj_matrix_data_grid, "adj_matrix_data_grid");
            this.adj_matrix_data_grid.BackgroundColor = System.Drawing.Color.White;
            this.adj_matrix_data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adj_matrix_data_grid.Cursor = System.Windows.Forms.Cursors.Default;
            this.adj_matrix_data_grid.Name = "adj_matrix_data_grid";
            this.adj_matrix_data_grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.adj_matrix_data_grid_CellEndEdit);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.main_container);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.main_container.Panel1.ResumeLayout(false);
            this.main_container.Panel1.PerformLayout();
            this.main_container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_container)).EndInit();
            this.main_container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.result_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adj_matrix_data_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer main_container;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_block_num_of_elem;
        private System.Windows.Forms.TextBox text_block_num_of_blocks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_block_num_of_elem_in_blocks;
        private System.Windows.Forms.DataGridView adj_matrix_data_grid;
        private System.Windows.Forms.Button btn_aplly_changes;
        private System.Windows.Forms.Button btn_start_algorithm;
        private System.Windows.Forms.Button btn_simmetry;
        private System.Windows.Forms.DataGridView result_table;
        private System.Windows.Forms.Button btn_open_result;
    }
}

