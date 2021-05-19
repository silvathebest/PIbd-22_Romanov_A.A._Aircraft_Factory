using AircraftFactoryBusinessLogic.BindingModels;
using AircraftFactoryBusinessLogic.BusinessLogics;
using Microsoft.Reporting.WinForms;
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
    public partial class FormReportOrdersAllDates : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportOrdersAllDates(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void createOrdersListButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetOrdersForAllDates();
                ReportDataSource source = new ReportDataSource("DataSet", dataSource);
                OrdersReportViewer.LocalReport.DataSources.Add(source);
                OrdersReportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        [Obsolete]
        private void saveToPdfButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveOrdersAllDatesToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
            }
        }

        private void FormReportOrdersAllDates_Load(object sender, EventArgs e)
        {

        }
    }
}
