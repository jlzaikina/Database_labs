namespace DB
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.button_teachers = new System.Windows.Forms.Button();
            this.button_topic = new System.Windows.Forms.Button();
            this.button_student = new System.Windows.Forms.Button();
            this.button_grade = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(788, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(57, 28);
            this.toolStripButton1.Text = "Выход";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // button_teachers
            // 
            this.button_teachers.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_teachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_teachers.Location = new System.Drawing.Point(152, 131);
            this.button_teachers.Name = "button_teachers";
            this.button_teachers.Size = new System.Drawing.Size(211, 88);
            this.button_teachers.TabIndex = 2;
            this.button_teachers.Text = "Преподаватели";
            this.button_teachers.UseVisualStyleBackColor = false;
            this.button_teachers.Click += new System.EventHandler(this.button_teachers_Click);
            // 
            // button_topic
            // 
            this.button_topic.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_topic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_topic.Location = new System.Drawing.Point(463, 131);
            this.button_topic.Name = "button_topic";
            this.button_topic.Size = new System.Drawing.Size(211, 88);
            this.button_topic.TabIndex = 3;
            this.button_topic.Text = "Темы";
            this.button_topic.UseVisualStyleBackColor = false;
            this.button_topic.Click += new System.EventHandler(this.button_topic_Click);
            // 
            // button_student
            // 
            this.button_student.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_student.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_student.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button_student.Location = new System.Drawing.Point(152, 253);
            this.button_student.Name = "button_student";
            this.button_student.Size = new System.Drawing.Size(211, 88);
            this.button_student.TabIndex = 4;
            this.button_student.Text = "Cтуденты";
            this.button_student.UseVisualStyleBackColor = false;
            this.button_student.Click += new System.EventHandler(this.button_student_Click);
            // 
            // button_grade
            // 
            this.button_grade.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_grade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_grade.Location = new System.Drawing.Point(463, 253);
            this.button_grade.Name = "button_grade";
            this.button_grade.Size = new System.Drawing.Size(211, 88);
            this.button_grade.TabIndex = 5;
            this.button_grade.Text = "Отметки";
            this.button_grade.UseVisualStyleBackColor = false;
            this.button_grade.Click += new System.EventHandler(this.button_grade_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(245, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Выберите одну из таблиц";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(96, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 68);
            this.button1.TabIndex = 7;
            this.button1.Text = "Студенты и их научные руководители";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(325, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 68);
            this.button2.TabIndex = 8;
            this.button2.Text = "Студенты и их темы";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(550, 387);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 68);
            this.button3.TabIndex = 9;
            this.button3.Text = "Преподаватели и предложенные темы";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button4.Location = new System.Drawing.Point(325, 475);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(177, 70);
            this.button4.TabIndex = 10;
            this.button4.Text = "Отчет";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(788, 612);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_grade);
            this.Controls.Add(this.button_student);
            this.Controls.Add(this.button_topic);
            this.Controls.Add(this.button_teachers);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.Main_Load_1);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button button_teachers;
        private System.Windows.Forms.Button button_topic;
        private System.Windows.Forms.Button button_student;
        private System.Windows.Forms.Button button_grade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

