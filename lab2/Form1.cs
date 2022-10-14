using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int i;
            int N = Int32.Parse(textBox1.Text);
            DataTable matr = new DataTable("matr");
            DataColumn[] cols = new DataColumn[N];
            for(i = 0; i < N; i++)
            {
                cols[i] = new DataColumn(i.ToString());
                matr.Columns.Add(cols[i]);
            }
            for(i = 0; i < N; i++)
            {
                DataRow newRow;
                newRow = matr.NewRow();
                matr.Rows.Add(newRow);
            }
            dataGridView1.DataSource = matr;
            for (i = 0; i < N; i++)
                dataGridView1.Columns[i].Width = 50;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            int N = Int32.Parse(textBox1.Text);
            dataGridView1.Visible = false;
            MatrMake mt = new MatrMake(N);
            mt.GridToMatrix(dataGridView1);
            int delNumber = Convert.ToInt32(deleteBox.Text);
            if (mt.DelCol(delNumber))
            {
                MessageBox.Show("Колонка с номером " + delNumber.ToString() + " удалена", "Итог работы");
                dataGridView1.Visible = true;
                mt.MatrixToGrid(dataGridView1);
                btnStart.Visible = false;
            }
            else
            {
                dataGridView1.Visible = true;
                mt.MatrixToGrid(dataGridView1);
            }
        }
    }
}