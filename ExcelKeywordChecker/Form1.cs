using ClosedXML.Excel;
using System.Text.RegularExpressions;

namespace ExcelKeywordChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            numIdColumn.Value = 1;
            numDescColumn.Value = 2;
            numStatusColumn.Value = 3;
        }

        private void ButRun_Click(object sender, EventArgs e)
        {
            string filePath = textBoxFilePath.Text.Trim();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Пожалуйста, выберите корректный Excel файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string keywordInput = keywordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(keywordInput))
            {
                MessageBox.Show("Введите ключевое слово для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!multiKeywordCheckBox.Checked && keywordInput.Contains(','))
            {
                var result = MessageBox.Show(
                    "Обнаружены несколько ключевых слов, разделённых запятыми. Включить режим множественного поиска?",
                    "Подсказка",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    multiKeywordCheckBox.Checked = true;
            }

            var keywords = multiKeywordCheckBox.Checked
                ? keywordInput.Split([','], StringSplitOptions.RemoveEmptyEntries).Select(k => k.Trim()).ToList()
                : [keywordInput];

            if (keywords.Count == 0)
            {
                MessageBox.Show("Не указано ни одного корректного ключевого слова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            butRun.Enabled = false;

            try
            {
                var workbook = new XLWorkbook(filePath);
                var ws = workbook.Worksheet(1);
                var lastUsedRow = ws.LastRowUsed();

                if (lastUsedRow == null)
                {
                    MessageBox.Show("Файл пустой или не содержит данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int lastRow = lastUsedRow.RowNumber();
                var rowsToDelete = new List<int>();

                int idColumn = (int)numIdColumn.Value;
                int descColumn = (int)numDescColumn.Value;
                int statusColumn = (int)numStatusColumn.Value;

                foreach (var keyword in keywords)
                {
                    var matches = new List<(int id, string description)>();
                    string pattern = $@"\b{Regex.Escape(keyword)}\b";

                    for (int row = 2; row <= lastRow; row++)
                    {
                        var idCell = ws.Cell(row, idColumn);
                        var descCell = ws.Cell(row, descColumn);
                        var statusCell = ws.Cell(row, statusColumn);

                        string idStr = idCell.GetValue<string>();
                        string desc = descCell.GetValue<string>();
                        string currentStatus = statusCell.GetValue<string>();

                        if (currentStatus.Equals("УДАЛЕННО", StringComparison.OrdinalIgnoreCase) ||
                            currentStatus.Equals("ПРОВЕРЕННО", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        if (int.TryParse(idStr, out int id) && !string.IsNullOrWhiteSpace(desc))
                        {
                            if (Regex.IsMatch(desc, pattern, RegexOptions.IgnoreCase))
                            {
                                matches.Add((id, desc));

                                if (deleteRowsCheckBox.Checked)
                                {
                                    rowsToDelete.Add(row);
                                }
                                else if (markAsDeletedCheckBox.Checked)
                                {
                                    statusCell.Value = "УДАЛЕННО";
                                }
                                else
                                {
                                    statusCell.Value = "ПРОВЕРЕННО";
                                }
                            }
                        }
                    }

                    if (matches.Count > 0)
                    {
                        string fileDirectory = Path.GetDirectoryName(filePath) ?? "";
                        string fileNamePrefix = deleteRowsCheckBox.Checked ? "deleted_" : "output_";
                        string resultFile = Path.Combine(fileDirectory, $"{fileNamePrefix}{keyword}.xlsx");

                        using (var outputWorkbook = new XLWorkbook())
                        {
                            var resultWs = outputWorkbook.AddWorksheet("Результаты");
                            resultWs.Cell(1, 1).Value = "ID";
                            resultWs.Cell(1, 2).Value = "Описание";

                            for (int i = 0; i < matches.Count; i++)
                            {
                                resultWs.Cell(i + 2, 1).Value = matches[i].id;
                                resultWs.Cell(i + 2, 2).Value = matches[i].description;
                            }

                            outputWorkbook.SaveAs(resultFile);
                        }
                    }
                }

                if (deleteRowsCheckBox.Checked && rowsToDelete.Any())
                {
                    foreach (int row in rowsToDelete.OrderByDescending(r => r))
                    {
                        ws.Row(row).Delete();
                    }
                }

                string backupPath = Path.Combine(
                Path.GetDirectoryName(filePath) ?? "",
                Path.GetFileNameWithoutExtension(filePath) + "_checked.xlsx");
                workbook.SaveAs(backupPath);
                workbook.Dispose();

                MessageBox.Show("Проверка завершена успешно.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                butRun.Enabled = true;
            }
        }

        private void MarkAsDeletedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (markAsDeletedCheckBox.Checked)
                deleteRowsCheckBox.Checked = false;
        }

        private void DeleteRowsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (deleteRowsCheckBox.Checked)
                markAsDeletedCheckBox.Checked = false;
        }

        private void ButBrowse_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new())
            {
                ofd.Filter = "Excel файлы (*.xlsx)|*.xlsx";
                ofd.Title = "Выберите Excel файл";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBoxFilePath.Text = ofd.FileName;
                }
            }
        }
    }
}