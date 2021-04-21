using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.BusinessLogics;
using AircraftFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AircraftFactoryView
{
    public partial class FormWarehouseFill : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int StoreHouserId
        {
            get => Convert.ToInt32(warehouseComboBox.SelectedValue);
            set => warehouseComboBox.SelectedValue = value;
        }

        public int MaterialId
        {
            get => Convert.ToInt32(componentsComboBox.SelectedValue);
            set => componentsComboBox.SelectedValue = value;
        }

        public int Count
        {
            get => Convert.ToInt32(countTextBox.Text);
            set => countTextBox.Text = value.ToString();
        }

        private readonly WarehouseLogic warehouseLogic;

        public FormWarehouseFill(WarehouseLogic warehouseLogic, ComponentLogic componentsLogic)
        {
            InitializeComponent();
            this.warehouseLogic = warehouseLogic;
            List<ComponentViewModel> componentsViews = componentsLogic.Read(null);
            if (componentsViews != null)
            {
                componentsComboBox.DisplayMember = "ComponentName";
                componentsComboBox.ValueMember = "Id";
                componentsComboBox.DataSource = componentsViews;
                componentsComboBox.SelectedItem = null;
            }

            List<WarehouseViewModel> warehouseViews = warehouseLogic.Read(null);
            if (warehouseViews != null)
            {
                warehouseComboBox.DisplayMember = "WarehouseName";
                warehouseComboBox.ValueMember = "Id";
                warehouseComboBox.DataSource = warehouseViews;
                warehouseComboBox.SelectedItem = null;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(countTextBox.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (componentsComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите материал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (warehouseComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            warehouseLogic.AddMaterial(new AddComponentsBindingModel
            {
                ComponentId = Convert.ToInt32(componentsComboBox.SelectedValue),
                WarehouseId = Convert.ToInt32(warehouseComboBox.SelectedValue),
                Count = Convert.ToInt32(countTextBox.Text)
            });

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
