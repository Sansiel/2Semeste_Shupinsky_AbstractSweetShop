﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;

namespace AbstractSweetShopView
{
    public partial class FormCandyMaterial : Form
    {

        public CandyMaterialViewModel Model
        {
            set { model = value; }
            get { return model; }
        }

        private CandyMaterialViewModel model;

        public FormCandyMaterial()
        {
            InitializeComponent();
        }

        private void FormCandyMaterial_Load(object sender, EventArgs e)
        {
            try
            {
                List<MaterialViewModel> list = APIClient.GetRequest<List<MaterialViewModel>>("api/Material/GetList");
                if (list != null)
                {
                    comboBoxMaterial.DisplayMember = "MaterialName";
                    comboBoxMaterial.ValueMember = "Id";
                    comboBoxMaterial.DataSource = list;
                    comboBoxMaterial.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxMaterial.Enabled = false;
                comboBoxMaterial.SelectedValue = model.MaterialId;
                textBoxCount.Text = model.Count.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxMaterial.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new CandyMaterialViewModel
                    {
                        MaterialId = Convert.ToInt32(comboBoxMaterial.SelectedValue),
                        MaterialName = comboBoxMaterial.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxCount.Text);
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
