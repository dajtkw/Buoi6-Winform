using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp13.Model;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        private StudentDBcontext context;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context = new StudentDBcontext();
            loadData();
            cmbFaculty.SelectedIndex = 0;
        }

        private void loadData()
        {
            var students = context.Students.ToList();
            dataGridView1.DataSource = students;
            dataGridView1.Columns["ID"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(cmbFaculty.Text) || !float.TryParse(txtScore.Text, out float result))
            {
                MessageBox.Show("Vui long nhap thong tin day du !!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                //dataGridView1.Rows.Add(txtID.Text, txtName.Text, cmbFaculty.Text, txtScore.Text);
                var student = new Student
                {
                    StudentID = txtID.Text,
                    Name = txtName.Text,
                    Faculty = cmbFaculty.Text,
                    Score = float.Parse(txtScore.Text)
                };
                context.Students.Add(student);
                context.SaveChanges();
                loadData();
                clearInformation();


            }
        }

    
        

        private void clearInformation()
        {
            txtID.Clear();
            txtName.Clear();
            txtScore.Clear();
            cmbFaculty.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtName.Text) ||
        string.IsNullOrEmpty(cmbFaculty.Text) || !float.TryParse(txtScore.Text, out float score))
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ và chính xác !!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
                    var student = context.Students.Find(id);
                    if (student != null)
                    {
                        student.StudentID = txtID.Text;
                        student.Name = txtName.Text;
                        student.Faculty = cmbFaculty.Text;
                        student.Score = score;
                        context.SaveChanges();
                        loadData();
                        clearInformation();
                    }
                }
                else
                {
                    MessageBox.Show("Chọn hàng để cập nhập", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
                var student = context.Students.Find(id);
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                    loadData();
                    clearInformation();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = dataGridView1.SelectedRows[0];

                txtID.Text = dgvr.Cells["StudentID"].Value?.ToString();
                txtName.Text = dgvr.Cells["Name"].Value?.ToString();
                cmbFaculty.Text = dgvr.Cells["Faculty"].Value?.ToString();
                txtScore.Text = dgvr.Cells["Score"].Value?.ToString();
            }
        }
    }
}
