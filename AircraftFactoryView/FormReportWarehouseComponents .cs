using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.BusinessLogics;
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
    public partial class FormReportWarehouseComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;
        public FormReportWarehouseComponents(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void saveExcelButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveWarehousesComponentsToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormReportStoreHouseMaterials_Load(object sender, EventArgs e)
        {
            try
            {
                var warehouseComponents = logic.GetWarehouseComponent();
                if (warehouseComponents != null)
                {
                    storeHouseMaterialsDataGridView.Rows.Clear();

                    foreach (var warehouse in warehouseComponents)
                    {
                        storeHouseMaterialsDataGridView.Rows.Add(new object[] { warehouse.WarehouseName, "", "" });

                        foreach (var component in warehouse.Components)
                        {
                            storeHouseMaterialsDataGridView.Rows.Add(new object[] { "", component.Item1, component.Item2 });
                        }

                        storeHouseMaterialsDataGridView.Rows.Add(new object[] { "Итого", "", warehouse.TotalCount });
                        storeHouseMaterialsDataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
