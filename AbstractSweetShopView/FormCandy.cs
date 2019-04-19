using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;

namespace AbstractSweetShopView
{
    public partial class FormCandy : Form
    {

        public int Id { set { id = value; } }

        private int? id;

        private List<CandyMaterialViewModel> CandyMaterials;

        public FormCandy()
        {
            InitializeComponent();
        }

        private void FormCandy_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CandyViewModel view = APIClient.GetRequest<CandyViewModel>("api/Candy/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.CandyName;
                        textBoxPrice.Text = view.Price.ToString();
                        CandyMaterials = view.CandyMaterials;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                CandyMaterials = new List<CandyMaterialViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (CandyMaterials != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = CandyMaterials;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormCandyMaterial();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.CandyId = id.Value;
                    }
                    CandyMaterials.Add(form.Model);
                }
                LoadData();
            }
        }

        private void ButtonRed_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormCandyMaterial();
                form.Model = CandyMaterials[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CandyMaterials[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        CandyMaterials.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (CandyMaterials == null || CandyMaterials.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<CandyMaterialBindingModel> CandyMaterialBM = new List<CandyMaterialBindingModel>();
                for (int i = 0; i < CandyMaterials.Count; ++i)
                {
                    CandyMaterialBM.Add(new CandyMaterialBindingModel
                    {
                        Id = CandyMaterials[i].Id,
                        CandyId = CandyMaterials[i].CandyId,
                        MaterialId = CandyMaterials[i].MaterialId,
                        Count = CandyMaterials[i].Count
                    });
                }
                if (id.HasValue)
                {
                    APIClient.PostRequest<CandyBindingModel, bool>("api/Candy/UpdElement", new CandyBindingModel
                    {
                        Id = id.Value,
                        CandyName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CandyMaterials = CandyMaterialBM
                    });
                }
                else
                {
                    APIClient.PostRequest<CandyBindingModel, bool>("api/Candy/AddElement", new CandyBindingModel
                    {
                        CandyName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CandyMaterials = CandyMaterialBM
                    });
                }
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
