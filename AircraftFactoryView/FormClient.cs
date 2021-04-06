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
    public partial class FormClient : Form
    {
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ClientLogic logic;

        private int? id;

        public FormClient(ClientLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new ClientBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxFIO.Text = view.FIO;
                        textBoxEmail.Text = view.Email;
                        textBoxPassword.Text = view.Password;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text) || string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new ClientBindingModel
                {
                    Id = id,
                    FIO = textBoxFIO.Text,
                    Email = textBoxEmail.Text,
                    Password = textBoxPassword.Text,
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
