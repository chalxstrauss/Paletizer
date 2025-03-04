using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Paletizer
{
    public partial class LoginForm : Form
    {
        DataModule dm = new DataModule();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (!dkPallet.probatCanUserLogin())
            {
                DialogResult = DialogResult.None;
                return;
            }

            if (UserName.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Морате унети корисничко име и лозинку!",
                    "ДОНКАФЕ - Палетизер", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                DialogResult = DialogResult.None;
                return;
            }

            if (cmbSmena.SelectedIndex < 0)
            {
                MessageBox.Show("Морате изабрати смену!",
                    "ДОНКАФЕ - Палетизер", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            DataModule.smena = cmbSmena.SelectedIndex;

            if (!dm.login(UserName.Text, Password.Text))
            {
                MessageBox.Show("Неисправно корисничко име или лозинка! Покушајте поново.",
                    "ДОНКАФЕ - Палетизер", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                DialogResult = DialogResult.None;
                return;
            }

            dkMasina dk_masina = (dkMasina)cmbMasina.SelectedItem;
            if (dk_masina.id != DataModule.dk_masina.id)
            {
                DataModule.dk_masina = dk_masina;
                DataModule.dk_masina.saveAsDefault();
            }
            DataModule.saveSmena(cmbSmena.SelectedIndex);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
            dm.LoadMasine();
            
            DataModule.dk_masina.loadDefault();
            foreach (dkMasina item in (dm.dkMasine_list))
            {
                cmbMasina.Items.Add(item);
                if (DataModule.dk_masina.id == item.id)
                {
                    cmbMasina.SelectedItem = item;
                }
            }
            DataModule.readSmena();
            if (DataModule.smena >= 0)
                cmbSmena.SelectedIndex = DataModule.smena ;
            else
                cmbSmena.SelectedIndex = 0;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DataModule.dk_user.id > 0)
            {
                return;
            }
            if (MessageBox.Show("Да ли сте сигурни да желите угасити програм?",
                        "ДОНКАФЕ - Палетизер", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                DialogResult = DialogResult.None;
                return;
            }
           
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (DataModule.dk_user.id > 0)
            {
                return;
            }
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }

            if (MessageBox.Show("Да ли сте сигурни да желите угасити програм?",
                        "ДОНКАФЕ - Палетизер", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            
            DialogResult = DialogResult.Cancel;
            //Application.Exit();
        }

    }
}