using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    public partial class Grade : Form
    {
        private MySqlConnection sqlConnection = null;
        private MySqlDataAdapter adapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        private bool newRowAdding = false;
        public Grade()
        {
            InitializeComponent();
        }

        private void Grade_Load(object sender, EventArgs e)
        {
            sqlConnection = new MySqlConnection("server=localhost;uid=root;pwd=root;database=project");
            sqlConnection.Open();
            Load_Data();
        }
        private void Reload_Data()
        {
            try
            {
                dataSet.Tables["Отметки"].Clear();
                adapter.Fill(dataSet, "Отметки");
                dataGridView1.DataSource = dataSet.Tables["Отметки"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Load_Data()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT *, 'Delete' AS 'Команда' FROM Отметки", sqlConnection);
                sqlBuilder = new MySqlCommandBuilder(adapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                dataSet = new DataSet();
                adapter.Fill(dataSet, "Отметки");
                dataGridView1.DataSource = dataSet.Tables["Отметки"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Reload_Data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Отметки"].Rows[rowIndex].Delete();
                            adapter.Update(dataSet, "Отметки");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Отметки"].NewRow();
                        row["Номер_зачетной_книжки"] = dataGridView1.Rows[rowIndex].Cells["Номер_зачетной_книжки"].Value;
                        row["Оценка_за_госэкзамен"] = dataGridView1.Rows[rowIndex].Cells["Оценка_за_госэкзамен"].Value;
                        row["Оценка_за_защиту_диплома"] = dataGridView1.Rows[rowIndex].Cells["Оценка_за_защиту_диплома"].Value;
                        dataSet.Tables["Отметки"].Rows.Add(row);
                        dataSet.Tables["Отметки"].Rows.RemoveAt(dataSet.Tables["Отметки"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = "Delete";

                        adapter.Update(dataSet, "Отметки");
                        newRowAdding = false;

                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        dataSet.Tables["Отметки"].Rows[r]["Номер_зачетной_книжки"] = dataGridView1.Rows[r].Cells["Номер_зачетной_книжки"].Value;
                        dataSet.Tables["Отметки"].Rows[r]["Оценка_за_госэкзамен"] = dataGridView1.Rows[r].Cells["Оценка_за_госэкзамен"].Value;
                        dataSet.Tables["Отметки"].Rows[r]["Оценка_за_защиту_диплома"] = dataGridView1.Rows[r].Cells["Оценка_за_защиту_диплома"].Value;
                        adapter.Update(dataSet, "Отметки");

                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = "Delete";
                    }
                    Reload_Data();
                }
            }
            catch (Exception ex)
            {
                newRowAdding = false;
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dataGridView1.Rows.Count - 2;
                    DataGridViewRow row = dataGridView1.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, lastRow] = linkCell;
                    row.Cells["Команда"].Value = "Insert";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow editRow = dataGridView1.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, rowIndex] = linkCell;
                    editRow.Cells["Команда"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridView1.CurrentCell.ColumnIndex == 0 || dataGridView1.CurrentCell.ColumnIndex == 1 || dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }
        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Main main = new Main();
            main.Show();
            this.SetVisibleCore(false);
        }
    }
}
