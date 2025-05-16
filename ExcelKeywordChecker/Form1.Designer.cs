namespace ExcelKeywordChecker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            keywordTextBox = new TextBox();
            butRun = new Button();
            multiKeywordCheckBox = new CheckBox();
            markAsDeletedCheckBox = new CheckBox();
            deleteRowsCheckBox = new CheckBox();
            numIdColumn = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            numDescColumn = new NumericUpDown();
            label4 = new Label();
            numStatusColumn = new NumericUpDown();
            groupBox1 = new GroupBox();
            textBoxFilePath = new TextBox();
            butBrowse = new Button();
            ((System.ComponentModel.ISupportInitialize)numIdColumn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDescColumn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStatusColumn).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 56);
            label1.Name = "label1";
            label1.Size = new Size(381, 20);
            label1.TabIndex = 0;
            label1.Text = "Ключевые слова (одно или несколько, чере запятую)";
            // 
            // keywordTextBox
            // 
            keywordTextBox.Location = new Point(12, 79);
            keywordTextBox.Name = "keywordTextBox";
            keywordTextBox.Size = new Size(378, 27);
            keywordTextBox.TabIndex = 1;
            // 
            // butRun
            // 
            butRun.Location = new Point(12, 370);
            butRun.Name = "butRun";
            butRun.Size = new Size(381, 42);
            butRun.TabIndex = 2;
            butRun.Text = "Запуск";
            butRun.UseVisualStyleBackColor = true;
            butRun.Click += ButRun_Click;
            // 
            // multiKeywordCheckBox
            // 
            multiKeywordCheckBox.AutoSize = true;
            multiKeywordCheckBox.Location = new Point(12, 174);
            multiKeywordCheckBox.Name = "multiKeywordCheckBox";
            multiKeywordCheckBox.Size = new Size(329, 24);
            multiKeywordCheckBox.TabIndex = 3;
            multiKeywordCheckBox.Text = "Несколько ключевых слов (через запятую)";
            multiKeywordCheckBox.UseVisualStyleBackColor = true;
            // 
            // markAsDeletedCheckBox
            // 
            markAsDeletedCheckBox.AutoSize = true;
            markAsDeletedCheckBox.Location = new Point(12, 114);
            markAsDeletedCheckBox.Name = "markAsDeletedCheckBox";
            markAsDeletedCheckBox.Size = new Size(221, 24);
            markAsDeletedCheckBox.TabIndex = 4;
            markAsDeletedCheckBox.Text = "Пометить как \"УДАЛЕННО\"\r\n";
            markAsDeletedCheckBox.UseVisualStyleBackColor = true;
            markAsDeletedCheckBox.CheckedChanged += MarkAsDeletedCheckBox_CheckedChanged;
            // 
            // deleteRowsCheckBox
            // 
            deleteRowsCheckBox.AutoSize = true;
            deleteRowsCheckBox.Location = new Point(12, 144);
            deleteRowsCheckBox.Name = "deleteRowsCheckBox";
            deleteRowsCheckBox.Size = new Size(217, 24);
            deleteRowsCheckBox.TabIndex = 5;
            deleteRowsCheckBox.Text = "Удалить строку полностью";
            deleteRowsCheckBox.UseVisualStyleBackColor = true;
            deleteRowsCheckBox.CheckedChanged += DeleteRowsCheckBox_CheckedChanged;
            // 
            // numIdColumn
            // 
            numIdColumn.Location = new Point(19, 36);
            numIdColumn.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIdColumn.Name = "numIdColumn";
            numIdColumn.Size = new Size(82, 27);
            numIdColumn.TabIndex = 7;
            numIdColumn.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 38);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 8;
            label2.Text = "- столбец ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(107, 74);
            label3.Name = "label3";
            label3.Size = new Size(147, 20);
            label3.TabIndex = 10;
            label3.Text = "- столбец описание";
            // 
            // numDescColumn
            // 
            numDescColumn.Location = new Point(19, 72);
            numDescColumn.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDescColumn.Name = "numDescColumn";
            numDescColumn.Size = new Size(82, 27);
            numDescColumn.TabIndex = 9;
            numDescColumn.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(107, 109);
            label4.Name = "label4";
            label4.Size = new Size(163, 20);
            label4.TabIndex = 12;
            label4.Text = "- столбец для отметки";
            // 
            // numStatusColumn
            // 
            numStatusColumn.Location = new Point(19, 107);
            numStatusColumn.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numStatusColumn.Name = "numStatusColumn";
            numStatusColumn.Size = new Size(82, 27);
            numStatusColumn.TabIndex = 11;
            numStatusColumn.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numIdColumn);
            groupBox1.Controls.Add(numDescColumn);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(numStatusColumn);
            groupBox1.Location = new Point(12, 204);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(378, 151);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Настройка колонок";
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(12, 12);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.Size = new Size(320, 27);
            textBoxFilePath.TabIndex = 14;
            // 
            // butBrowse
            // 
            butBrowse.Location = new Point(338, 12);
            butBrowse.Name = "butBrowse";
            butBrowse.Size = new Size(55, 27);
            butBrowse.TabIndex = 15;
            butBrowse.Text = "...";
            butBrowse.UseVisualStyleBackColor = true;
            butBrowse.Click += ButBrowse_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 424);
            Controls.Add(butBrowse);
            Controls.Add(textBoxFilePath);
            Controls.Add(groupBox1);
            Controls.Add(markAsDeletedCheckBox);
            Controls.Add(deleteRowsCheckBox);
            Controls.Add(multiKeywordCheckBox);
            Controls.Add(butRun);
            Controls.Add(keywordTextBox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Excel Keyword Filter";
            ((System.ComponentModel.ISupportInitialize)numIdColumn).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDescColumn).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStatusColumn).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox keywordTextBox;
        private Button butRun;
        private CheckBox multiKeywordCheckBox;
        private CheckBox markAsDeletedCheckBox;
        private CheckBox deleteRowsCheckBox;
        private NumericUpDown numIdColumn;
        private Label label2;
        private Label label3;
        private NumericUpDown numDescColumn;
        private Label label4;
        private NumericUpDown numStatusColumn;
        private GroupBox groupBox1;
        private TextBox textBoxFilePath;
        private Button butBrowse;
    }
}
