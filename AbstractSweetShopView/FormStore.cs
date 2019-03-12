﻿using System;
using System.Windows.Forms;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.Interfaces;
using AbstractSweetShopServiceDAL.ViewModels;
using Unity;

namespace AbstractSweetShopView
{
    public partial class FormStore : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IStoreService service;

        private int? id;

        public FormStore(IStoreService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormStore_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StoreViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.StoreName;
                        dataGridView.DataSource = view.StoreMaterials;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
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
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new StoreBindingModel
                    {
                        Id = id.Value,
                        StoreName = textBoxName.Text
                    });
                }
                else
                {
                    service.AddElement(new StoreBindingModel
                    {
                        StoreName = textBoxName.Text
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
