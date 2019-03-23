namespace AbstractSweetShopView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientFIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.candyIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.candyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateImplementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCreateJob = new System.Windows.Forms.Button();
            this.buttonTakeJobInWork = new System.Windows.Forms.Button();
            this.buttonJobReady = new System.Windows.Forms.Button();
            this.buttonPayJob = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem,
            this.отчётыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(995, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.складыToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.clientIdDataGridViewTextBoxColumn,
            this.clientFIODataGridViewTextBoxColumn,
            this.candyIdDataGridViewTextBoxColumn,
            this.candyNameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.dateCreateDataGridViewTextBoxColumn,
            this.dateImplementDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.JobViewModelBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(10, 34);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(730, 403);
            this.dataGridView.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // clientIdDataGridViewTextBoxColumn
            // 
            this.clientIdDataGridViewTextBoxColumn.DataPropertyName = "BuyerId";
            this.clientIdDataGridViewTextBoxColumn.HeaderText = "BuyerId";
            this.clientIdDataGridViewTextBoxColumn.Name = "clientIdDataGridViewTextBoxColumn";
            // 
            // clientFIODataGridViewTextBoxColumn
            // 
            this.clientFIODataGridViewTextBoxColumn.DataPropertyName = "BuyerFIO";
            this.clientFIODataGridViewTextBoxColumn.HeaderText = "BuyerFIO";
            this.clientFIODataGridViewTextBoxColumn.Name = "clientFIODataGridViewTextBoxColumn";
            // 
            // candyIdDataGridViewTextBoxColumn
            // 
            this.candyIdDataGridViewTextBoxColumn.DataPropertyName = "CandyId";
            this.candyIdDataGridViewTextBoxColumn.HeaderText = "CandyId";
            this.candyIdDataGridViewTextBoxColumn.Name = "candyIdDataGridViewTextBoxColumn";
            // 
            // candyNameDataGridViewTextBoxColumn
            // 
            this.candyNameDataGridViewTextBoxColumn.DataPropertyName = "CandyName";
            this.candyNameDataGridViewTextBoxColumn.HeaderText = "CandyName";
            this.candyNameDataGridViewTextBoxColumn.Name = "candyNameDataGridViewTextBoxColumn";
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Count";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            this.sumDataGridViewTextBoxColumn.HeaderText = "Sum";
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // dateCreateDataGridViewTextBoxColumn
            // 
            this.dateCreateDataGridViewTextBoxColumn.DataPropertyName = "DateCreate";
            this.dateCreateDataGridViewTextBoxColumn.HeaderText = "DateCreate";
            this.dateCreateDataGridViewTextBoxColumn.Name = "dateCreateDataGridViewTextBoxColumn";
            // 
            // dateImplementDataGridViewTextBoxColumn
            // 
            this.dateImplementDataGridViewTextBoxColumn.DataPropertyName = "DateImplement";
            this.dateImplementDataGridViewTextBoxColumn.HeaderText = "DateImplement";
            this.dateImplementDataGridViewTextBoxColumn.Name = "dateImplementDataGridViewTextBoxColumn";
            // 
            // JobViewModelBindingSource
            // 
            this.JobViewModelBindingSource.DataSource = typeof(AbstractSweetShopServiceDAL.ViewModels.JobViewModel);
            // 
            // buttonCreateJob
            // 
            this.buttonCreateJob.Location = new System.Drawing.Point(771, 62);
            this.buttonCreateJob.Name = "buttonCreateJob";
            this.buttonCreateJob.Size = new System.Drawing.Size(200, 32);
            this.buttonCreateJob.TabIndex = 2;
            this.buttonCreateJob.Text = "Создать заказ";
            this.buttonCreateJob.UseVisualStyleBackColor = true;
            this.buttonCreateJob.Click += new System.EventHandler(this.buttonCreateJob_Click);
            // 
            // buttonTakeJobInWork
            // 
            this.buttonTakeJobInWork.Location = new System.Drawing.Point(772, 123);
            this.buttonTakeJobInWork.Name = "buttonTakeJobInWork";
            this.buttonTakeJobInWork.Size = new System.Drawing.Size(198, 32);
            this.buttonTakeJobInWork.TabIndex = 3;
            this.buttonTakeJobInWork.Text = "Отдать на выполнение";
            this.buttonTakeJobInWork.UseVisualStyleBackColor = true;
            this.buttonTakeJobInWork.Click += new System.EventHandler(this.buttonTakeJobInWork_Click);
            // 
            // buttonJobReady
            // 
            this.buttonJobReady.Location = new System.Drawing.Point(775, 192);
            this.buttonJobReady.Name = "buttonJobReady";
            this.buttonJobReady.Size = new System.Drawing.Size(195, 36);
            this.buttonJobReady.TabIndex = 4;
            this.buttonJobReady.Text = "Заказ готов";
            this.buttonJobReady.UseVisualStyleBackColor = true;
            this.buttonJobReady.Click += new System.EventHandler(this.buttonJobReady_Click);
            // 
            // buttonPayJob
            // 
            this.buttonPayJob.Location = new System.Drawing.Point(778, 268);
            this.buttonPayJob.Name = "buttonPayJob";
            this.buttonPayJob.Size = new System.Drawing.Size(192, 37);
            this.buttonPayJob.TabIndex = 5;
            this.buttonPayJob.Text = "Заказ оплачен";
            this.buttonPayJob.UseVisualStyleBackColor = true;
            this.buttonPayJob.Click += new System.EventHandler(this.buttonPayJob_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(779, 350);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(191, 35);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Обновить список";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 459);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonPayJob);
            this.Controls.Add(this.buttonJobReady);
            this.Controls.Add(this.buttonTakeJobInWork);
            this.Controls.Add(this.buttonCreateJob);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Главаня";
            this.Load += new System.EventHandler(this.LoadData);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateJob;
        private System.Windows.Forms.Button buttonTakeJobInWork;
        private System.Windows.Forms.Button buttonJobReady;
        private System.Windows.Forms.Button buttonPayJob;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientFIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn candyIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn candyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateImplementDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource JobViewModelBindingSource;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
    }
}

