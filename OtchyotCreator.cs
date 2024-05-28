using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Форма
{
    static internal class OtchyotCreator
    {
        static public bool CreateWord(DataGridView data)
        {
            if (data.DataSource == null) return false;
            Word.Application application = new Word.Application();
            Word.Document document = application.Documents.Add();
            document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            var table = document.Tables.Add(document.Range(), data.RowCount + 1, data.ColumnCount);
            for (int i = 0;i < data.ColumnCount; i++)
                table.Cell(1, i+1).Range.Text = data.Columns[i].HeaderText;
            for (int i = 0; i < data.RowCount; i++)
            {
                for (int j = 0; j < data.ColumnCount; j++)
                {
                    if (data.Rows[i].Cells[j].Value == null)
                        table.Cell(i + 2, j + 1).Range.Text = "";
                    else
                    table.Cell(i + 2, j + 1).Range.Text = data.Rows[i].Cells[j].Value.ToString();
                }
            }
            table.Borders.Enable = 1;
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "Word Document (*.docx)|*.docx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    document.SaveAs2(saveFile.FileName);
                    MessageBox.Show("Файл успешно создан", "Успех");
                    document.Close();
                    application.Quit();
                    return true;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Непредвиденная ошибка!", "Ошибка");
                    document.Close();
                    application.Quit();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Неправильно введены данные!", "Ошибка");
                document.Close();
                application.Quit();
                return false;
            }
        }
        static public bool CreateExcel(DataGridView data)
        {
            if (data.DataSource == null) return false;
            Excel.Application application = new Excel.Application();
            Excel.Workbook book = application.Workbooks.Add();
            Excel.Worksheet ws = book.Worksheets.Add();
            for (int i = 0; i < data.ColumnCount; i++)
                ws.Cells[1, i + 1].Value = data.Columns[i].HeaderText;
            for (int i = 0; i < data.RowCount; i++)
            {
                for (int j = 0; j < data.ColumnCount; j++)
                {
                    if (data.Rows[i].Cells[j].Value == null)
                        ws.Cells[i + 2, j + 1].Value = "";
                    else
                        ws.Cells[i + 2, j + 1].Value = data.Rows[i].Cells[j].Value.ToString();
                }
            }
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel Document (*.xlsx)|*.xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ws.Columns.AutoFit();
                    ws.Rows.AutoFit();
                    book.SaveAs(saveFile.FileName);
                    book.Close();
                    application.Quit();
                    MessageBox.Show("Файл успешно создан!", "Успех");
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Непредвиденная ошибка", "Ошибка");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Неправильно введены данные!", "Ошибка");
                book.Close();
                application.Quit();
                return false;
            }
        }
    }
}
