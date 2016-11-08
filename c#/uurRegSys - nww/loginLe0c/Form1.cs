using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using funcZ;

namespace loginLe0c {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private List<TsubPersonInfo> elldata = new List<TsubPersonInfo>();

        private void getnewdata(object sender, EventArgs e) {
            TAskCurrentStateForDisplay askion = new TAskCurrentStateForDisplay();
            elldata = webbbz.wetmyweb(textBox1.Text, textBox2.Text, askion).iedereen;
            updateWIthSeath(null,null);
        }

        DataTable newTable() {
            DataTable dt = new DataTable();
            dt.Columns.Add("a");
            dt.Columns.Add("b");
            dt.Columns.Add("c");
            dt.Columns.Add("d");
            dt.Columns.Add("e");
            dt.Columns.Add("f");
            return dt;
        }

        private void updateDataGridWithList(List<TsubPersonInfo> putt) {
            DataTable dt = newTable();
            foreach (TsubPersonInfo test in putt) {
                DataRow dr = dt.NewRow();
                dr[0] = test.naam;
                dr[1] = test.achternaam;
                dr[2] = test.inteken.ToString();
                dr[3] = test.uittenken.ToString();

                dr[4] = $"{test.uutotopschoolgeweest}:{test.minutetotaalopschoolgeweest}:{test.secondetotaalopschoolgeweest}";
                dr[5] = test.isAanwegiz;
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }

        void updateWIthSeath(object een, object twee) {
            List<TsubPersonInfo> toinput = new List<TsubPersonInfo>();
            foreach (var ja in elldata) {
                if (ja.naam.ToLower().Contains(textBox3.Text.ToLower()) || ja.achternaam.ToLower().Contains(textBox3.Text.ToLower())) {
                    toinput.Add(ja);
                }
                updateDataGridWithList(toinput);
            }
        }      

        private void textBox3_TextChanged(object sender, EventArgs e) {
            if (checkBox1.Checked) {
                updateWIthSeath(null, null);
            }
        }

    }
}
