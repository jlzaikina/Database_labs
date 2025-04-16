using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void button_teachers_Click(object sender, EventArgs e)
        {

            Teachers teachers = new Teachers();
            teachers.Show();
            this.SetVisibleCore(false);
        }

        private void button_topic_Click(object sender, EventArgs e)
        {
            Topic topic = new Topic();
            topic.Show();
            this.SetVisibleCore(false);
        }

        private void button_student_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Show();
            this.SetVisibleCore(false);
        }

        private void button_grade_Click(object sender, EventArgs e)
        {
            Grade grade = new Grade();
            grade.Show();
            this.SetVisibleCore(false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void Main_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Select1 select = new Select1();
            select.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Select2 select = new Select2();
            select.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Select3 select = new Select3();
            select.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Result res = new Result();
            res.Show();
            this.SetVisibleCore(false);
        }
    }
}
