﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFASchoolManagementSystem.Information;

namespace WFASchoolManagementSystem.Admin
{
    public partial class AllStudentInformationByIDForAdmin : Form
    {
        private DataAccess da { get; set; }
        private DataSet ds { get; set; }
        public AllStudentInformationByIDForAdmin()
        {
            InitializeComponent();
            this.da = new DataAccess();

            string sql = "select * from Student;";
            this.PopulateGridView(sql);
        }
        private void PopulateGridView(string sql)
        {
            this.ds = this.da.ExecuteQuery(sql);
            // this.dataGridView1.AutoGenerateColumns = false;
            //this.dataGridView1.DataSource = this.ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select userId from AllUser where userId = '" + this.txtSearch.Text + "';";
                DataAccess da = new DataAccess();
                DataSet ds = da.ExecuteQuery(sql);


                if (ds.Tables[0].Rows.Count == 1)
                {
                    label4.Text = "";
                    formStudentInindividualInfo fsi = new formStudentInindividualInfo();
                    fsi.Username = txtSearch.Text;
                    txtSearch.Text = "";
                    fsi.TopLevel = false;
                    panel1.Controls.Add(fsi);
                    fsi.BringToFront();
                    fsi.Show();
                }
                else
                {
                    panel1.Controls.Clear();
                    label4.Text = "Invalid Student ID.";
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }
        }

        private void AllStudentInformationByIDForAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
