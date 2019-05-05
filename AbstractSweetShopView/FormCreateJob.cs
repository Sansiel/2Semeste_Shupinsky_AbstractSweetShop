using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;

namespace AbstractSweetShopView
{
    public partial class FormCreateJob : Form
    {
        public FormCreateJob()
        {
            InitializeComponent();
        }
        private void FormCreateJob_Load(object sender, EventArgs e)
        {
            try
            {
                List<BuyerViewModel> listB = APIClient.GetRequest<List<BuyerViewModel>>("api/Buyer/GetList");
                if (listB != null)
                {
                    comboBoxClient.DisplayMember = "BuyerFIO";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listB;
                    comboBoxClient.SelectedItem = null;
                }
                List<CandyViewModel> listC = APIClient.GetRequest<List<CandyViewModel>>("api/Candy/GetList");
                if (listC != null)
                {
                    comboBoxCandy.DisplayMember = "CandyName";
                    comboBoxCandy.ValueMember = "Id";
                    comboBoxCandy.DataSource = listC;
                    comboBoxCandy.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxCandy.SelectedValue != null &&
            !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxCandy.SelectedValue);
                    CandyViewModel Candy = APIClient.GetRequest<CandyViewModel>("api/Candy/Get/" + id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * Candy.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxCandy_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCandy.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIClient.PostRequest<JobBindingModel, bool>("api/Main/CreateJob", new JobBindingModel
                {
                    BuyerId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    CandyId = Convert.ToInt32(comboBoxCandy.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
