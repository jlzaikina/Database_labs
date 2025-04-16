using OfficeOpenXml.Style;
using OfficeOpenXml;
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
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace DB
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите значение факультета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Generate(name);
        }
        public void Generate(string faculty_name)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection("server=localhost;uid=root;pwd=root;database=project"))
            {
                sqlConnection.Open();

                // Запрос данных с информацией о группе
                MySqlDataAdapter adapter = new MySqlDataAdapter(
                    "SELECT Группа, ФИО AS 'Ф.И.О. студента', " +
                    "Оценка_за_госэкзамен AS 'Оценка на госэкзамене', " +
                    "Оценка_за_защиту_диплома AS 'Оценка на защите дипломной работы', " +
                    "(Оценка_за_госэкзамен + Оценка_за_защиту_диплома) / 2.0 AS 'Средний балл' " +
                    "FROM ОТМЕТКИ " +
                    "INNER JOIN СТУДЕНТЫ ON ОТМЕТКИ.Номер_зачетной_книжки = СТУДЕНТЫ.Номер_зачетной_книжки " +
                    "WHERE Факультет = @facultyName " +
                    "ORDER BY Группа, ФИО", sqlConnection);

                adapter.SelectCommand.Parameters.AddWithValue("@facultyName", faculty_name);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show($"Данные для факультета отсутствуют");
                    return;
                }

                // Создание нового Excel файла
                using (ExcelPackage excel = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("Отчет");

                    worksheet.Cells[1, 1].Value = "Ведомость успеваемости студентов БГЭУ";
                    worksheet.Cells[2, 1].Value = $"{faculty_name}";

                    // Объединяем ячейки для заголовка и задаем стиль
                    worksheet.Cells["A1:D1"].Merge = true;
                    worksheet.Cells["A2:D2"].Merge = true;
                    worksheet.Cells["A1:A2"].Style.Font.Bold = true;
                    worksheet.Cells["A1:A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    // Настройка шрифта для заголовка
                    worksheet.Cells["A1"].Style.Font.Size = 14;
                    worksheet.Cells["A2"].Style.Font.Size = 12;
                    worksheet.Cells["A3"].Style.Font.Size = 12;
                    int currentRow = 5;

                    // Настройка заголовков
                    worksheet.Cells[currentRow, 1].Value = "Группа / Ф.И.О. студента";
                    worksheet.Cells[currentRow, 2].Value = "Оценка на госэкзамене";
                    worksheet.Cells[currentRow, 3].Value = "Оценка на защите дипломной работы";
                    worksheet.Cells[currentRow, 4].Value = "Средний балл";

                    worksheet.Row(1).Style.Font.Bold = true;

                    currentRow = 6;
                    string currentGroup = null;
                    double groupTotalScore = 0;
                    int groupCount = 0;
                    double facultyTotalScore = 0;
                    int facultyCount = 0;

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string group = row["Группа"].ToString();
                        string studentName = row["Ф.И.О. студента"].ToString();
                        double examScore = Convert.ToDouble(row["Оценка на госэкзамене"]);
                        double diplomaScore = Convert.ToDouble(row["Оценка на защите дипломной работы"]);
                        double averageScore = Convert.ToDouble(row["Средний балл"]);

                        // Если группа изменилась, добавляем строку с результатами по группе
                        if (currentGroup != group)
                        {
                            if (currentGroup != null)
                            {
                                // Добавляем строку со средним баллом по группе
                                worksheet.Cells[currentRow, 1].Value = $"Средний балл по группе {currentGroup}";
                                worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                                worksheet.Cells[currentRow, 4].Value = groupCount > 0 ? groupTotalScore / groupCount : 0;
                                worksheet.Cells[currentRow, 4].Style.Font.Bold = true;
                                currentRow++;
                                currentRow++;
                            }

                            // Обнуляем показатели для новой группы
                            currentGroup = group;
                            groupTotalScore = 0;
                            groupCount = 0;

                            // Добавляем строку с названием группы
                            worksheet.Cells[currentRow, 1].Value = $"Группа {group}";
                            worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                            currentRow++;
                        }

                        // Добавляем строку с данными студента
                        worksheet.Cells[currentRow, 1].Value = studentName;
                        worksheet.Cells[currentRow, 2].Value = examScore;
                        worksheet.Cells[currentRow, 3].Value = diplomaScore;
                        worksheet.Cells[currentRow, 4].Value = averageScore;

                        currentRow++;

                        // Обновляем накопительные значения для группы и факультета
                        groupTotalScore += averageScore;
                        groupCount++;
                        facultyTotalScore += averageScore;
                        facultyCount++;
                    }
                    // Добавляем последнюю строку для средней оценки по последней группе
                    if (currentGroup != null)
                    {
                        worksheet.Cells[currentRow, 1].Value = $"Средний балл по группе {currentGroup}";
                        worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                        worksheet.Cells[currentRow, 4].Value = groupCount > 0 ? groupTotalScore / groupCount : 0;
                        worksheet.Cells[currentRow, 4].Style.Font.Bold = true;
                        currentRow++;
                        currentRow++;
                    }

                    // Добавляем строку для среднего балла по факультету
                    worksheet.Cells[currentRow, 1].Value = "Средний балл по факультету";
                    worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                    worksheet.Cells[currentRow, 4].Value = facultyCount > 0 ? facultyTotalScore / facultyCount : 0;
                    worksheet.Cells[currentRow, 4].Style.Font.Bold = true;
                    worksheet.Cells[currentRow, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[currentRow, 4].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

                    // Автоматическое подстраивание ширины колонок
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Сохранение файла Excel
                    string filePath = "Отчет.xlsx";
                    FileInfo file = new FileInfo(filePath);
                    excel.SaveAs(file);

                    MessageBox.Show($"Отчет успешно сохранен в файл: {filePath}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Result_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.SetVisibleCore(false);
        }
    }
}
