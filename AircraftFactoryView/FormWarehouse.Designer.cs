
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.nameOfWarehouseLabel = new System.Windows.Forms.Label();
            this.nameOfResponsibleLabel = new System.Windows.Forms.Label();
            this.nameOfResponsibleTextBox = new System.Windows.Forms.TextBox();
            this.nameOfWarehouseTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.componentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // componentGroupBox
            // 
            this.componentGroupBox.Controls.Add(this.dataGridView);
            this.componentGroupBox.Location = new System.Drawing.Point(16, 15);
            this.componentGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.componentGroupBox.Name = "componentGroupBox";
            this.componentGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.componentGroupBox.Size = new System.Drawing.Size(296, 361);
            this.componentGroupBox.TabIndex = 0;
            this.componentGroupBox.TabStop = false;
            this.componentGroupBox.Text = "Компоненты";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 23);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(281, 326);
            this.dataGridView.TabIndex = 0;
            // 
            // nameOfWarehouseLabel
            // 
            this.nameOfWarehouseLabel.AutoSize = true;
            this.nameOfWarehouseLabel.Location = new System.Drawing.Point(333, 148);
            this.nameOfWarehouseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameOfWarehouseLabel.Name = "nameOfWarehouseLabel";
            this.nameOfWarehouseLabel.Size = new System.Drawing.Size(126, 17);
            this.nameOfWarehouseLabel.TabIndex = 2;
            this.nameOfWarehouseLabel.Text = "Название склада:";
            // 
            // nameOfResponsibleLabel
            // 
            this.nameOfResponsibleLabel.AutoSize = true;
            this.nameOfResponsibleLabel.Location = new System.Drawing.Point(333, 65);
            this.nameOfResponsibleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameOfResponsibleLabel.Name = "nameOfResponsibleLabel";
            this.nameOfResponsibleLabel.Size = new System.Drawing.Size(153, 17);
            this.nameOfResponsibleLabel.TabIndex = 1;
            this.nameOfResponsibleLabel.Text = "ФИО ответственного:";
            // 
            // nameOfResponsibleTextBox
            // 
            this.nameOfResponsibleTextBox.Location = new System.Drawing.Point(337, 105);
            this.nameOfResponsibleTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameOfResponsibleTextBox.Name = "nameOfResponsibleTextBox";
            this.nameOfResponsibleTextBox.Size = new System.Drawing.Size(168, 22);
            this.nameOfResponsibleTextBox.TabIndex = 3;
            // 
            // nameOfWarehouseTextBox
            // 
            this.nameOfWarehouseTextBox.Location = new System.Drawing.Point(337, 185);
            this.nameOfWarehouseTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameOfWarehouseTextBox.Name = "nameOfWarehouseTextBox";
            this.nameOfWarehouseTextBox.Size = new System.Drawing.Size(168, 22);
            this.nameOfWarehouseTextBox.TabIndex = 4;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(337, 241);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(169, 36);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(337, 336);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(169, 29);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 401);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.componentGroupBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nameOfResponsibleLabel);
            this.Controls.Add(this.nameOfWarehouseLabel);
            this.Controls.Add(this.nameOfWarehouseTextBox);
            this.Controls.Add(this.nameOfResponsibleTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label nameOfResponsibleLabel;
        private System.Windows.Forms.Label nameOfWarehouseLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox nameOfWarehouseTextBox;
        private System.Windows.Forms.TextBox nameOfResponsibleTextBox;
    }
}