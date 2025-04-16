using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace DB
{
    public partial class Teachers : Form
    {
        private MySqlConnection sqlConnection = null;
        private MySqlDataAdapter adapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        private bool newRowAdding = false;
        public Teachers()
        {
            InitializeComponent();
        }


        private void Load_Data()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT *, 'Delete' AS 'Команда' FROM Преподаватели", sqlConnection);
                sqlBuilder = new MySqlCommandBuilder(adapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                dataSet = new DataSet();
                adapter.Fill(dataSet, "Преподаватели");
                dataGridView1.DataSource = dataSet.Tables["Преподаватели"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reload_Data()
        {
            try
            {
                dataSet.Tables["Преподаватели"].Clear();
                adapter.Fill(dataSet, "Преподаватели");
                dataGridView1.DataSource = dataSet.Tables["Преподаватели"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            sqlConnection = new MySqlConnection("server=localhost;uid=root;pwd=root;database=project");
            sqlConnection.Open();
            Load_Data();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Reload_Data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Преподаватели"].Rows[rowIndex].Delete();
                            adapter.Update(dataSet, "Преподаватели");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Преподаватели"].NewRow();
                        row["Код_преподавателя"] = dataGridView1.Rows[rowIndex].Cells["Код_преподавателя"].Value;
                        row["ФИО"] = dataGridView1.Rows[rowIndex].Cells["ФИО"].Value;
                        row["Степень"] = dataGridView1.Rows[rowIndex].Cells["Степень"].Value;
                        row["Звание"] = dataGridView1.Rows[rowIndex].Cells["Звание"].Value;
                        row["Кафедра"] = dataGridView1.Rows[rowIndex].Cells["Кафедра"].Value;
                        row["Телефон"] = dataGridView1.Rows[rowIndex].Cells["Телефон"].Value;
                        row["Email"] = dataGridView1.Rows[rowIndex].Cells["Email"].Value;

                        dataSet.Tables["Преподаватели"].Rows.Add(row);
                        dataSet.Tables["Преподаватели"].Rows.RemoveAt(dataSet.Tables["Преподаватели"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[7].Value = "Delete";

                        adapter.Update(dataSet, "Преподаватели");
                        newRowAdding = false;

                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        dataSet.Tables["Преподаватели"].Rows[r]["Код_преподавателя"] = dataGridView1.Rows[r].Cells["Код_преподавателя"].Value;
                        dataSet.Tables["Преподаватели"].Rows[r]["ФИО"] = dataGridView1.Rows[r].Cells["ФИО"].Value;
                        dataSet.Tables["Преподаватели"].Rows[r]["Степень"] = dataGridView1.Rows[r].Cells["Степень"].Value;
                        dataSet.Tables["Преподаватели"].Rows[r]["Звание"] = dataGridView1.Rows[r].Cells["Звание"].Value;
                        dataSet.Tables["Преподаватели"].Rows[r]["Кафедра"] = dataGridView1.Rows[r].Cells["Кафедра"].Value;
                        dataSet.Tables["Преподаватели"].Rows[r]["Телефон"] = dataGridView1.Rows[r].Cells["Телефон"].Value;
                        dataSet.Tables["Преподаватели"].Rows[r]["Email"] = dataGridView1.Rows[r].Cells["Email"].Value;

                        adapter.Update(dataSet, "Преподаватели");

                        dataGridView1.Rows[e.RowIndex].Cells[7].Value = "Delete";


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
                    dataGridView1[7, lastRow] = linkCell;
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
                    dataGridView1[7, rowIndex] = linkCell;
                    editRow.Cells["Команда"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Main main = new Main();
            main.Show();
            this.SetVisibleCore(false);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if(dataGridView1.CurrentCell.ColumnIndex == 5)
            {
                TextBox textBox = e.Control as TextBox;
                if(textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }
    }
}
