using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract_20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void unitsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.unitsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.unitsAccountDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "unitsAccountDataSet.Units". При необходимости она может быть перемещена или удалена.
            this.unitsTableAdapter.Fill(this.unitsAccountDataSet.Units);

        }

        private void AddRecord_Click(object sender, EventArgs e)
        {
            AddRecord add = new AddRecord();
            add.ShowDialog();
            this.unitsTableAdapter.Fill(this.unitsAccountDataSet.Units);
        }

        private void ChangeRecord_Click(object sender, EventArgs e)
        {
            ChangeRecord change = new ChangeRecord();
            change.ShowDialog();

        }

        private void ShowRecord_Click(object sender, EventArgs e)
        {
            ShowRecord show = new ShowRecord();
            show.ShowDialog();
        }

        private void DeleteRecord_Click(object sender, EventArgs e)
        {
            DialogResult result;
            try
            {
                result = MessageBox.Show("Вы действительно хотите удалить запись из базы данных?", "Удаление записи", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    unitsBindingSource.RemoveCurrent();
                    unitsTableAdapter.Update(this.unitsAccountDataSet.Units);
                }
            }
            catch
            {
                MessageBox.Show("Таблица пуста", "Ошибка");
                return;
            }
            
        }
    }
}
