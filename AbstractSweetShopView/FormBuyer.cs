using System;
using System.Windows.Forms;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;
using System.Text.RegularExpressions;

namespace AbstractSweetShopView
{
    public partial class FormBuyer : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormBuyer()
        {
            InitializeComponent();
        }

        private void buttonSaveFIO_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string fio = textBoxFIO.Text;
                string mail = textBoxMail.Text;
                if (!string.IsNullOrEmpty(mail))
                {
                    if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                    {
                        MessageBox.Show("Неверный формат для электронной почты", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (id.HasValue)
                {
                    APIClient.PostRequest<BuyerBindingModel, bool>("api/Buyer/UpdElement", new BuyerBindingModel
                    {
                        Id = id.Value,
                        BuyerFIO = fio,
                        Mail = mail
                    });
                }
                else
                {
                    APIClient.PostRequest<BuyerBindingModel, bool>("api/Buyer/AddElement", new BuyerBindingModel
                    {
                        BuyerFIO = fio,
                        Mail = mail
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelFIO_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    BuyerViewModel view = APIClient.GetRequest<BuyerViewModel>("api/Buyer/Get/" + id.Value);
                    textBoxFIO.Text = view.BuyerFIO;
                    textBoxMail.Text = view.Mail;
                    dataGridView.DataSource = view.Messages;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
