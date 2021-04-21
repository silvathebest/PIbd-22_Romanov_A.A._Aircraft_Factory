
namespace AircraftFactoryView
{
    partial class FormWarehouse
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
            this.componentGroupBox = new System.Windows.Forms.GroupBox();
            this.nameOfWarehouseLabel = new System.Windows.Forms.Label();
            this.nameOfResponsibleLabel = new System.Windows.Forms.Label();
            this.nameOfResponsibleTextBox = new System.Windows.Forms.TextBox();
            this.nameOfWarehouseTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.Warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // componentGroupBox
            // 
            this.componentGroupBox.Controls.Add(this.dataGridView);
            this.componentGroupBox.Location = new System.Drawing.Point(12, 12);
            this.componentGroupBox.Name = "componentGroupBox";
            this.componentGroupBox.Size = new System.Drawing.Size(363, 293);
            this.componentGroupBox.TabIndex = 0;
            this.componentGroupBox.TabStop = false;
            this.componentGroupBox.Text = "Компоненты";
            // 
            // nameOfWarehouseLabel
            // 
            this.nameOfWarehouseLabel.AutoSize = true;
            this.nameOfWarehouseLabel.Location = new System.Drawing.Point(381, 119);
            this.nameOfWarehouseLabel.Name = "nameOfWarehouseLabel";
            this.nameOfWarehouseLabel.Size = new System.Drawing.Size(99, 13);
            this.nameOfWarehouseLabel.TabIndex = 2;
            this.nameOfWarehouseLabel.Text = "Название склада:";
            // 
            // nameOfResponsibleLabel
            // 
            this.nameOfResponsibleLabel.AutoSize = true;
            this.nameOfResponsibleLabel.Location = new System.Drawing.Point(381, 52);
            this.nameOfResponsibleLabel.Name = "nameOfResponsibleLabel";
            this.nameOfResponsibleLabel.Size = new System.Drawing.Size(120, 13);
            this.nameOfResponsibleLabel.TabIndex = 1;
            this.nameOfResponsibleLabel.Text = "ФИО ответственного:";
            // 
            // nameOfResponsibleTextBox
            // 
            this.nameOfResponsibleTextBox.Location = new System.Drawing.Point(384, 84);
            this.nameOfResponsibleTextBox.Name = "nameOfResponsibleTextBox";
            this.nameOfResponsibleTextBox.Size = new System.Drawing.Size(127, 20);
            this.nameOfResponsibleTextBox.TabIndex = 3;
            // 
            // nameOfWarehouseTextBox
            // 
            this.nameOfWarehouseTextBox.Location = new System.Drawing.Point(384, 149);
            this.nameOfWarehouseTextBox.Name = "nameOfWarehouseTextBox";
            this.nameOfWarehouseTextBox.Size = new System.Drawing.Size(127, 20);
            this.nameOfWarehouseTextBox.TabIndex = 4;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(384, 195);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(127, 29);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(384, 272);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(127, 24);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Warehouse
            // 
            this.Warehouse.HeaderText = "Column1";
            this.Warehouse.MinimumWidth = 6;
            this.Warehouse.Name = "Warehouse";
            this.Warehouse.Width = 125;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.component,
            this.count});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 16);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(357, 274);
            this.dataGridView.TabIndex = 0;
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "IdColumn";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Visible = false;
            // 
            // component
            // 
            this.component.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.component.HeaderText = "Компонент";
            this.component.Name = "component";
            this.component.ReadOnly = true;
            // 
            // count
            // 
            this.count.HeaderText = "Кол-во";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // FormWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 326);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.componentGroupBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nameOfResponsibleLabel);
            this.Controls.Add(this.nameOfWarehouseLabel);
            this.Controls.Add(this.nameOfWarehouseTextBox);
            this.Controls.Add(this.nameOfResponsibleTextBox);
            this.Name = "FormWarehouse";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormWarehouse_Load);
            this.componentGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox componentGroupBox;
        private System.Windows.Forms.Label nameOfResponsibleLabel;
        private System.Windows.Forms.Label nameOfWarehouseLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox nameOfWarehouseTextBox;
        private System.Windows.Forms.TextBox nameOfResponsibleTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Warehouse;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn component;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
    }
}