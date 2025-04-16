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
    public partial class Select3 : Form
    {
        private MySqlConnection sqlConnection = null;
        private MySqlDataAdapter adapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        public Select3()
        {
            InitializeComponent();
        }
        private void Reload_Data()
        {
            try
            {
                dataSet.Tables["Предложенные_темы"].Clear();
                adapter.Fill(dataSet, "Предложенные_темы");
                dataGridView1.DataSource = dataSet.Tables["Предложенные_темы"];
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
                adapter = new MySqlDataAdapter("SELECT p.Код_преподавателя, p.ФИО AS Преподаватель, t.Тема_дипломной_работы AS Предложенная_тема, t.Код_темы " +
                                                "FROM ПРЕПОДАВАТЕЛИ p " +
                                                "LEFT JOIN ТЕМЫ t ON p.Код_преподавателя = t.Код_преподавателя " +
                                                "ORDER BY p.ФИО", sqlConnection);
                sqlBuilder = new MySqlCommandBuilder(adapter);
                dataSet = new DataSet();
                adapter.Fill(dataSet, "Предложенные_темы");
                dataGridView1.DataSource = dataSet.Tables["Предложенные_темы"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Select3_Load(object sender, EventArgs e)
        {
            sqlConnection = new MySqlConnection("server=localhost;uid=root;pwd=root;database=project");
            sqlConnection.Open();
            Load_Data();
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
    }
}
