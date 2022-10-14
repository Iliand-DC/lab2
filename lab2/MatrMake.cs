using System;
using System.Windows.Forms;
using System.Data;

namespace lab2
{
    internal class MatrMake
    {
        int n_str, //Количество строк
            n_col; //Количество столбцов
        int[,] matrix; //Матрица, которую обрабатывают
        public MatrMake(int n) //Конструктор матрицы
        {
            n_str = n;
            n_col = n;
            matrix = new int[n, n];
        }
        public void GridToMatrix(DataGridView dgv)
        {
            DataGridViewCell txtCell;
            for(int i = 0; i < n_str; i++)
            {
                for(int j = 0; j < n_col; j++)
                {
                    txtCell = dgv.Rows[i].Cells[j];
                    string s = txtCell.Value.ToString();
                    if (s == "")
                        matrix[i, j] = 0;
                    else
                        matrix[i, j] = Int32.Parse(s);
                }
            }
        }
        public void MatrixToGrid(DataGridView dgv)
        {
            int i;
            DataTable matr = new DataTable("matr");
            DataColumn[] cols = new DataColumn[n_col];
            for(i = 0; i < n_col; i++)
            {
                cols[i] = new DataColumn(i.ToString());
                matr.Columns.Add(cols[i]);
            }
            for(i = 0; i < n_str; i++)
            {
                DataRow newRow;
                newRow = matr.NewRow();
                matr.Rows.Add(newRow);
            }
            dgv.DataSource = matr;
            for (i = 0; i < n_col; i++)
                dgv.Columns[i].Width = 50;
            DataGridViewCell txtCell;
            for(i = 0; i < n_str; i++)
            {
                for(int j = 0; j < n_col; j++)
                {
                    txtCell = dgv.Rows[i].Cells[j];
                    txtCell.Value = matrix[i, j].ToString();
                }
            }
        }
        public bool DelCol(int del_number)
        {
            int i, j;
            bool ok;
            ok = true;
            for (j = 0; j < n_col && ok; j++)
                if (j == del_number)
                    ok = false;
            if (!ok)
            {
                for (i = 0; i < n_str; i++)
                    for (j = del_number; j < n_col-1; j++)
                        matrix[i, j] = matrix[i, j+1];
                n_col--;
                ok = true;
            }
            return ok;
        }
    }
}
