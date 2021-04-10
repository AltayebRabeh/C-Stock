﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock.BL;

namespace Stock.PL.Categories
{
    public partial class All : Form
    {
        public All()
        {
            InitializeComponent();
            All_Activated(null, null);
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("هل تريد الحذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dr == DialogResult.Yes) {
                    int i = BL.Categories.Delete(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                    All_Activated(null, null);
                    MessageBox.Show("نم حذف عدد " + i + " من الاصناف");
                }
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Add frm = new Add(true);
            frm.MdiParent = this.MdiParent;
            frm.CatID = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            frm.txt_name.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            frm.rh_desc.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            frm.Show();
        }

        private void All_Activated(object sender, EventArgs e)
        {
            dgv.DataSource = BL.Categories.All();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            dgv.DataSource = BL.Categories.Search(txt_search.Text);
        }
    }
}
