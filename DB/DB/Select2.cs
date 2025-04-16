using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    public partial class Select2 : Form
    {
        private MySqlConnection sqlConnection = null;
        private MySqlDataAdapter adapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        public Select2()
        {
            InitializeComponent();
        }
        private void Reload_Data()
        {
            try
            {
                dataSet.Tables["Темы_дипломов"].Clear();
                adapter.Fill(dataSet, "Темы_дипломов");
                dataGridView1.DataSource = dataSet.Tables["Темы_дипломов"];
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
                adapter = new MySqlDataAdapter("SELECT s.Номер_зачетной_книжки, s.ФИО AS Студент, t.Тема_дипломной_работы, t.Код_темы " +
                                                "FROM СТУДЕНТЫ s " +
                                                "INNER JOIN ТЕМЫ t ON s.Код_темы = t.Код_темы " +
                                                "ORDER BY s.ФИО", sqlConnection);
                sqlBuilder = new MySqlCommandBuilder(adapter);
                dataSet = new DataSet();
                adapter.Fill(dataSet, "Темы_дипломов");
                dataGridView1.DataSource = dataSet.Tables["Темы_дипломов"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.SetVisibleCore(false);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Reload_Data();
        }

        private void Select2_Load(object sender, EventArgs e)
        {
            sqlConnection = new MySqlConnection("server=localhost;uid=root;pwd=root;database=project");
            sqlConnection.Open();
            Load_Data();
        }
    }
}
