
namespace MixCharts
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnContingencyTable = new System.Windows.Forms.Button();
            this.btnBarChart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadCSV2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScatterChart = new System.Windows.Forms.Button();
            this.cmbAnno = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContingencyTable
            // 
            this.btnContingencyTable.Location = new System.Drawing.Point(387, 52);
            this.btnContingencyTable.Name = "btnContingencyTable";
            this.btnContingencyTable.Size = new System.Drawing.Size(176, 27);
            this.btnContingencyTable.TabIndex = 20;
            this.btnContingencyTable.Text = "Crea Contingency Table";
            this.btnContingencyTable.UseVisualStyleBackColor = true;
            this.btnContingencyTable.Click += new System.EventHandler(this.btnContingencyTable_Click);
            // 
            // btnBarChart
            // 
            this.btnBarChart.Location = new System.Drawing.Point(569, 52);
            this.btnBarChart.Name = "btnBarChart";
            this.btnBarChart.Size = new System.Drawing.Size(176, 27);
            this.btnBarChart.TabIndex = 22;
            this.btnBarChart.Text = "Bar Chart";
            this.btnBarChart.UseVisualStyleBackColor = true;
            this.btnBarChart.Click += new System.EventHandler(this.btnBarChart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(387, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(996, 601);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadCSV2
            // 
            this.btnLoadCSV2.Location = new System.Drawing.Point(12, 52);
            this.btnLoadCSV2.Name = "btnLoadCSV2";
            this.btnLoadCSV2.Size = new System.Drawing.Size(125, 27);
            this.btnLoadCSV2.TabIndex = 24;
            this.btnLoadCSV2.Text = "Carica CSV Gelati";
            this.btnLoadCSV2.UseVisualStyleBackColor = true;
            this.btnLoadCSV2.Click += new System.EventHandler(this.btnLoadCSV2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 85);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(363, 594);
            this.dataGridView2.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 26);
            this.label1.TabIndex = 26;
            this.label1.Text = "Statistica stagionale Ice Creams";
            // 
            // btnScatterChart
            // 
            this.btnScatterChart.Location = new System.Drawing.Point(1115, 52);
            this.btnScatterChart.Name = "btnScatterChart";
            this.btnScatterChart.Size = new System.Drawing.Size(176, 27);
            this.btnScatterChart.TabIndex = 27;
            this.btnScatterChart.Text = "Scatter Chart";
            this.btnScatterChart.UseVisualStyleBackColor = true;
            this.btnScatterChart.Click += new System.EventHandler(this.btnScatterChart_Click);
            // 
            // cmbAnno
            // 
            this.cmbAnno.FormattingEnabled = true;
            this.cmbAnno.Location = new System.Drawing.Point(1006, 55);
            this.cmbAnno.Name = "cmbAnno";
            this.cmbAnno.Size = new System.Drawing.Size(103, 21);
            this.cmbAnno.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(968, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Anno";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 706);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAnno);
            this.Controls.Add(this.btnScatterChart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnLoadCSV2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBarChart);
            this.Controls.Add(this.btnContingencyTable);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnContingencyTable;
        private System.Windows.Forms.Button btnBarChart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoadCSV2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScatterChart;
        private System.Windows.Forms.ComboBox cmbAnno;
        private System.Windows.Forms.Label label2;
    }
}

