using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFunc;
using FFunc.WebSendAndReturnTypes;
using System.IO;

namespace MakeChangesToDB {
    public partial class Form1 : Form {
        public Form1(string assWord) {
            InitializeComponent();
            _Password = assWord;
        }

        private void Form1_Load(object sender, EventArgs e) {
            if (File.Exists("serverAdr.txt")) {
                try {
                    textBox_ServerAddress.Text = File.ReadAllText("serverAdr.txt");
                } catch {
                    textBox_ServerAddress.Text = "";
                }
            }
        }

        private string _Password;
        private int _IDOfCurrentSelectedPerson = 0;
        private Bitmap _TheImage;
        List<TypeReturnDBEntry> _AllNamesList = new List<TypeReturnDBEntry>();


        /// <summary>
        /// get db entry with this id and fill in UI
        /// </summary>
        /// <param name="_ID"></param>
        private void updateUIWithID(int _ID) {
            try {
                TypeAskDBEntry request = new TypeAskDBEntry();
                request.whereIdIs = _ID.ToString();
                request.getProfileImag = true;
                request.dontUseWhereGetAll = false;
                List<TypeReturnDBEntry> awnser = SqlAndWeb.httpPostWithErrorCheckAndPassword<List<TypeReturnDBEntry>>(request, textBox_ServerAddress.Text, _Password);
                try {
                    _TheImage = (Bitmap)Conversion.base64ToImage(awnser[0].base64profileImage);
                } catch {
                    _TheImage = null;
                }
                pictureBox_ProfileImage.Image = _TheImage;
                textBox_ID.Text = awnser[0].ID.ToString();
                textBox_Voornaam.Text = awnser[0].voorNaam;
                textBox_Achternaam.Text = awnser[0].achterNaam;
            } catch {
                pictureBox_ProfileImage.Image = null;
                textBox_ID.Text = "server connection failed";
                textBox_Voornaam.Text = "server connection failed";
                textBox_Achternaam.Text = "server connection failed";
            }
        }

        private void button_DeleteEntry_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("Sure?", "Delete DB Entry", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes) {
                TypeSendDBUpdate instruc = new TypeSendDBUpdate();
                instruc.WhereIDIs = Convert.ToInt32(textBox_ID.Text);
                instruc.deleteFromDB = true;
                TypeReturnDBChanged answer = SqlAndWeb.httpPostWithErrorCheckAndPassword<TypeReturnDBChanged>(instruc, textBox_ServerAddress.Text, _Password);
                MessageBox.Show("Lines Affected=" + answer.linesAffected, "DB Change Info");
            }
        }

        private void button_EditEntry_Click(object sender, EventArgs e) {
            textBox_Achternaam.Enabled = true;
            textBox_Voornaam.Enabled = true;
            button_SetNewProfileImage.Enabled = true;
            button_CancelChanges.Enabled = true;
            button_SaveChanges.Enabled = true;
        }

        private void button_NewEntry_Click(object sender, EventArgs e) {
            NewEntryForm F = new NewEntryForm(textBox_ServerAddress.Text, _Password);
            F.ShowDialog();
        }

        private void button_SetNewProfileImage_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK) {
                    _TheImage = (Bitmap)Image.FromFile(ofd.FileName);
                    pictureBox_ProfileImage.Image = _TheImage;
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button_SaveChanges_Click(object sender, EventArgs e) {
            TypeSendDBUpdate instruc = new TypeSendDBUpdate();
            instruc.WhereIDIs = Convert.ToInt32(textBox_ID.Text);
            instruc.newVoorNaam = textBox_Voornaam.Text;
            instruc.newAchterNaam = textBox_Achternaam.Text;
            if (_TheImage != null) {
                instruc.newBase64ProfileImage = Conversion.imageToBase64String(_TheImage);
            } else {
                instruc.newBase64ProfileImage = "GeenPlaatje";
            }
            TypeReturnDBChanged answer = SqlAndWeb.httpPostWithErrorCheckAndPassword<TypeReturnDBChanged>(instruc, textBox_ServerAddress.Text, _Password);
            MessageBox.Show("Lines Affected=" + answer.linesAffected, "DB Change Info");
            button_CancelChanges_Click(null, null); // disable buttons
        }

        private void button_CancelChanges_Click(object sender, EventArgs e) {
            textBox_Achternaam.Enabled = false;
            textBox_Voornaam.Enabled = false;
            button_SetNewProfileImage.Enabled = false;
            button_CancelChanges.Enabled = false;
            button_SaveChanges.Enabled = false;
            updateUIWithID(_IDOfCurrentSelectedPerson);
        }

        private void Button_Refresh_Click(object sender, EventArgs e) {
            File.WriteAllText("serverAdr.txt", textBox_ServerAddress.Text);
            button_EditEntry.Enabled = false;
            button_DeleteEntry.Enabled = false;
            listBox1.Items.Clear();
            _AllNamesList.Clear();
            TypeAskDBEntry reques = new TypeAskDBEntry();
            reques.dontUseWhereGetAll = true;
            reques.getProfileImag = false;
            _AllNamesList = SqlAndWeb.httpPostWithErrorCheckAndPassword<List<TypeReturnDBEntry>>(reques, textBox_ServerAddress.Text, _Password);
            foreach (var x in _AllNamesList) {
                string guyToAdd = x.ID.ToString() + " " + x.voorNaam + " " + x.achterNaam;
                listBox1.Items.Add(guyToAdd);
            }
        }

        private void SelcetedInadexChange(object sender, EventArgs e) {
            button_DeleteEntry.Enabled = true;
            button_EditEntry.Enabled = true;
            if (listBox1.Items[listBox1.SelectedIndex] != null) {
                string id = listBox1.Items[listBox1.SelectedIndex].ToString().Split(' ')[0];
                _IDOfCurrentSelectedPerson = Convert.ToInt32(id);
                updateUIWithID(_IDOfCurrentSelectedPerson);
            }

        }
    }
}
