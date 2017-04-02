﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using NewCrossFunctions;

namespace NewNewAdmin {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e) {
            NetComunicationTypesAndFunctions.ServerResponse response;

            try {
                response = NetComunicationTypesAndFunctions.WebRequest(new NetComunicationTypesAndFunctions.ServerRequestSqlDateTime(), textBoxUserName.Text, textBoxPassword.Text, textBoxApiAddres.Text);
                if (response.IsErrorOccurred) {
                    if (MessageBox.Show(response.ErrorInfo.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK) {
                        //buttonStart_Click(null, null); nee
                        return;
                    }
                }

            } catch {
                if (MessageBox.Show("Kan Niet Met Server Verbinden", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop) == DialogResult.Retry) {
                    buttonStart_Click(null, null);
                } else {
                    return;
                }
                return;
            }

            try {
                formInterme form = new formInterme(JsonConvert.DeserializeObject<DateTime>(JsonConvert.SerializeObject(response.Response)), textBoxUserName.Text, textBoxPassword.Text, textBoxApiAddres.Text);
                Visible = false;
                form.ShowDialog();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "dit had niet moeten gebeuren...");
            }
        }
    }
}
