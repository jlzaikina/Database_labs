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
    public partial class Select1 : Form
    {
        private MySqlConnection sqlConnection = null;
        private MySqlDataAdapter adapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        public Select1()
        {
            InitializeComponent();
        }

        private void Select1_Load(object sender, EventArgs e)
        {
            sqlConnection = new MySqlConnection("server=localhost;uid=root;pwd=root;database=project");
            sqlConnection.Open();
            Load_Data();
        }
        private void Reload_Data()
        {
            try
            {
                dataSet.Tables["Научные руководители"].Clear();
                adapter.Fill(dataSet, "Научные руководители");
                dataGridView1.DataSource = dataSet.Tables["Научные руководители"];
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
                adapter = new MySqlDataAdapter("SELECT s.Номер_зачетной_книжки, s.ФИО AS Студент, p.ФИО AS Преподаватель, p.Код_преподавателя " +
                                                "FROM СТУДЕНТЫ s " +
                                                "INNER JOIN ТЕМЫ t ON s.Код_темы = t.Код_темы " +
                                                "INNER JOIN ПРЕПОДАВАТЕЛИ p ON t.Код_преподавателя = p.Код_преподавателя " +
                                                "ORDER BY s.ФИО", sqlConnection);
                sqlBuilder = new MySqlCommandBuilder(adapter);
                dataSet = new DataSet();
                adapter.Fill(dataSet, "Научные руководители");
                dataGridView1.DataSource = dataSet.Tables["Научные руководители"];
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            this.SetVisibleCore(false);
        }
    }
}
