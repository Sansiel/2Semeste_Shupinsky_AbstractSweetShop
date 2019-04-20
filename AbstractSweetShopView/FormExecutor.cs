﻿using System;
using System.Windows.Forms;
using AbstractSweetShopServiceDAL.BindingModels;
using AbstractSweetShopServiceDAL.ViewModels;

namespace AbstractSweetShopView
{
    public partial class FormExecutor : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormExecutor()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
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
                    APIClient.PostRequest<ExecutorBindingModel, bool>("api/Executor/UpdElement", new ExecutorBindingModel
                    {
                        Id = id.Value,
                        ExecutorFIO = textBoxFIO.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<ExecutorBindingModel, bool>("api/Executor/AddElement", new ExecutorBindingModel
                    {
                        ExecutorFIO = textBoxFIO.Text
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormExecutor_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ExecutorViewModel view = APIClient.GetRequest<ExecutorViewModel>("api/Executor/Get/" + id.Value);
                    textBoxFIO.Text = view.ExecutorFIO;
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
