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

namespace toeganspuntMetKleinOverzigt {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            }

        private void button1_Click(object sender, EventArgs e) {

            TAskCurrentStateForDisplay askion = new TAskCurrentStateForDisplay();

            TReturnCurrentStateForDisplay test = webbbz.wetmyweb(textBox1.Text, textBox2.Text, askion);
            updateBox(test);

            }

        private void updateBox(TReturnCurrentStateForDisplay _Info) {
            foreach(TsubPersonInfo persoInfo in _Info.iedereen) {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();

                row.Cells["voornaam"].Value = persoInfo.naam;
                row.Cells["achternaam"].Value = persoInfo.achternaam;
                row.Cells["tijd in"].Value = persoInfo.inteken;
                row.Cells["tijd uit"].Value = persoInfo.uittenken;
                row.Cells["tijd totaal"].Value = $"{persoInfo.uutotopschoolgeweest}:{persoInfo.minutetotaalopschoolgeweest}:{persoInfo.secondetotaalopschoolgeweest}";
                //dataGridView1.Rows.Add
                }
            }

        private void Form1_Load(object sender, EventArgs e) {

            }
        }
    }
