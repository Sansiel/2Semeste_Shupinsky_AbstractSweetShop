using System;
using System.Windows.Forms;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;

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
                if (id.HasValue)
                {
                    APIClient.PostRequest<BuyerBindingModel, bool>("api/Buyer/UpdElement", new BuyerBindingModel
                    {
                        Id = id.Value,
                        BuyerFIO = textBoxFIO.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<BuyerBindingModel, bool>("api/Buyer/AddElement", new BuyerBindingModel
                    {
                        BuyerFIO = textBoxFIO.Text
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
