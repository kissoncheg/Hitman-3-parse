
namespace Hitman_3_parse
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сборкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.импортTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.сборкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 411);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ИД";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "English";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Russian";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // сборкаToolStripMenuItem
            // 
            this.сборкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортTxtToolStripMenuItem,
            this.экспортTxtToolStripMenuItem,
            this.toolStripSeparator1,
            this.экспортCsvToolStripMenuItem,
            this.импортCsvToolStripMenuItem});
            this.сборкаToolStripMenuItem.Name = "сборкаToolStripMenuItem";
            this.сборкаToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.сборкаToolStripMenuItem.Text = "Сборка";
            // 
            // экспортCsvToolStripMenuItem
            // 
            this.экспортCsvToolStripMenuItem.Name = "экспортCsvToolStripMenuItem";
            this.экспортCsvToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.экспортCsvToolStripMenuItem.Text = "Экспорт csv";
            this.экспортCsvToolStripMenuItem.Click += new System.EventHandler(this.экспортCsvToolStripMenuItem_Click);
            // 
            // импортCsvToolStripMenuItem
            // 
            this.импортCsvToolStripMenuItem.Name = "импортCsvToolStripMenuItem";
            this.импортCsvToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.импортCsvToolStripMenuItem.Text = "Импорт csv";
            this.импортCsvToolStripMenuItem.Click += new System.EventHandler(this.импортCsvToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // импортTxtToolStripMenuItem
            // 
            this.импортTxtToolStripMenuItem.Name = "импортTxtToolStripMenuItem";
            this.импортTxtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.импортTxtToolStripMenuItem.Text = "Импорт txt";
            this.импортTxtToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // экспортTxtToolStripMenuItem
            // 
            this.экспортTxtToolStripMenuItem.Name = "экспортTxtToolStripMenuItem";
            this.экспортTxtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.экспортTxtToolStripMenuItem.Text = "Экспорт txt";
            this.экспортTxtToolStripMenuItem.Click += new System.EventHandler(this.экспортTxtToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hitman 3 translate parser v.0.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStripMenuItem сборкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортTxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортTxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

