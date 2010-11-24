using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Paletizer
{
    public partial class ProbatPasswordForm : Form
    {
        public bool PasswordMessage = false;
        public ProbatPasswordForm()
        {
            InitializeComponent();
            CenterToParent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                CheckProbatPassword();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        void CheckProbatPassword()
        {
            PasswordMessage = true;
            string txt = textPassword.Text.Trim();

            if (txt.Length == 0)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            string pass = "";
            try
            {
                pass = ConfigurationManager.AppSettings["probat_pass"];
            }
            catch
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            long ln = 0;
            try
            {
                ln = long.Parse(txt);
            }
            catch
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
            
            if (Base36.encodeBase36(ln) != pass)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            // heh :)
            DialogResult = DialogResult.OK;
        }
    }
}