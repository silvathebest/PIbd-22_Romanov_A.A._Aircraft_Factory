
namespace AircraftFactoryView
{
    partial class FormWarehouseFill
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
            this.warehouseLabel = new System.Windows.Forms.Label();
            this.componentLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.warehouseComboBox = new System.Windows.Forms.ComboBox();
            this.componentsComboBox = new System.Windows.Forms.ComboBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // warehouseLabel
            // 
            this.warehouseLabel.AutoSize = true;
            this.warehouseLabel.Location = new System.Drawing.Point(36, 25);
            this.warehouseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.warehouseLabel.Name = "warehouseLabel";
            this.warehouseLabel.Size = new System.Drawing.Size(52, 17);
            this.warehouseLabel.TabIndex = 0;
            this.warehouseLabel.Text = "Склад:";
            // 
            // componentLabel
            // 
            this.componentLabel.AutoSize = true;
            this.componentLabel.Location = new System.Drawing.Point(36, 92);
            this.componentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.componentLabel.Name = "componentLabel";
            this.componentLabel.Size = new System.Drawing.Size(78, 17);
            this.componentLabel.TabIndex = 1;
            this.componentLabel.Text = "Материал:";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(36, 161);
            this.countLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(90, 17);
            this.countLabel.TabIndex = 2;
            this.countLabel.Text = "Количество:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(39, 221);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(128, 32);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(40, 261);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(128, 30);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // warehouseComboBox
            // 
            this.warehouseComboBox.FormattingEnabled = true;
            this.warehouseComboBox.Location = new System.Drawing.Point(40, 44);
            this.warehouseComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.warehouseComboBox.Name = "warehouseComboBox";
            this.warehouseComboBox.Size = new System.Drawing.Size(160, 24);
            this.warehouseComboBox.TabIndex = 5;
            // 
            // componentsComboBox
            // 
            this.componentsComboBox.FormattingEnabled = true;
            this.componentsComboBox.Location = new System.Drawing.Point(40, 112);
            this.componentsComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.componentsComboBox.Name = "componentsComboBox";
            this.componentsComboBox.Size = new System.Drawing.Size(160, 24);
            this.componentsComboBox.TabIndex = 6;
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(40, 182);
            this.countTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(160, 22);
            this.countTextBox.TabIndex = 7;
            // 
            // FormWarehouseFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 302);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.componentsComboBox);
            this.Controls.Add(this.warehouseComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.componentLabel);
            this.Controls.Add(this.warehouseLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormWarehouseFill";
            this.Text = "Пополнение склада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label warehouseLabel;
        private System.Windows.Forms.Label componentLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox warehouseComboBox;
        private System.Windows.Forms.ComboBox componentsComboBox;
        private System.Windows.Forms.TextBox countTextBox;
    }
}