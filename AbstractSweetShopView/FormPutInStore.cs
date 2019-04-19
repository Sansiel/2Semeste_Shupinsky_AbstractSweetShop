﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;

namespace AbstractSweetShopView
{
    public partial class FormPutInStore : Form
    {
        public FormPutInStore()
        {
            InitializeComponent();
        }

        private void FormPutInStore_Load(object sender, EventArgs e)
        {
            try
            {
                List<MaterialViewModel> listM = APIClient.GetRequest<List<MaterialViewModel>>("api/Material/GetList");
                if (listM != null)
                {
                    comboBoxMaterial.DisplayMember = "MaterialName";
                    comboBoxMaterial.ValueMember = "Id";
                    comboBoxMaterial.DataSource = listM;
                    comboBoxMaterial.SelectedItem = null;
                }
                List<StoreViewModel> listS = APIClient.GetRequest<List<StoreViewModel>>("api/Store/GetList");
                if (listS != null)
                {
                    comboBoxStore.DisplayMember = "StoreName";
                    comboBoxStore.ValueMember = "Id";
                    comboBoxStore.DataSource = listS;
                    comboBoxStore.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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
            if (comboBoxStore.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIClient.PostRequest<StoreMaterialBindingModel, bool>("api/StoreMaterial/PutMaterialInStore", new StoreMaterialBindingModel
                {
                    MaterialId = Convert.ToInt32(comboBoxMaterial.SelectedValue),
                    StoreId = Convert.ToInt32(comboBoxStore.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
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
