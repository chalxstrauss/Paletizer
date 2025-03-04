namespace Paletizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dkAltSifra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MasaPoKartonu = new System.Windows.Forms.TextBox();
            this.labelPorukaPaletizacije = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BrojKutija = new System.Windows.Forms.TextBox();
            this.labelKartonaInfo = new System.Windows.Forms.Label();
            this.MasaPoPaleti = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cmbMasine = new System.Windows.Forms.ComboBox();
            this.masinaLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSmena = new System.Windows.Forms.ComboBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.btnGotovo = new System.Windows.Forms.Button();
            this.btnIzbor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNazivProizvoda = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.datumLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelKomada = new System.Windows.Forms.Label();
            this.textKomadi = new System.Windows.Forms.TextBox();
            this.lstProizvodi = new System.Windows.Forms.ListView();
            this.sifra = new System.Windows.Forms.ColumnHeader();
            this.comment = new System.Windows.Forms.ColumnHeader();
            this.naziv = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.fndComment = new System.Windows.Forms.ComboBox();
            this.fndNaziv = new System.Windows.Forms.TextBox();
            this.fndCode = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.buttonShiftOver = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Enabled = false;
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(560, 535);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(194, 101);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "ШТАМПАЈ";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(538, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Шифра производа";
            // 
            // dkAltSifra
            // 
            this.dkAltSifra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dkAltSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkAltSifra.Location = new System.Drawing.Point(542, 211);
            this.dkAltSifra.Name = "dkAltSifra";
            this.dkAltSifra.ReadOnly = true;
            this.dkAltSifra.Size = new System.Drawing.Size(169, 29);
            this.dkAltSifra.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(806, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Masa kartona";
            this.label4.Visible = false;
            // 
            // MasaPoKartonu
            // 
            this.MasaPoKartonu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MasaPoKartonu.Location = new System.Drawing.Point(810, 222);
            this.MasaPoKartonu.Name = "MasaPoKartonu";
            this.MasaPoKartonu.ReadOnly = true;
            this.MasaPoKartonu.Size = new System.Drawing.Size(191, 29);
            this.MasaPoKartonu.TabIndex = 10;
            this.MasaPoKartonu.Visible = false;
            // 
            // labelPorukaPaletizacije
            // 
            this.labelPorukaPaletizacije.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPorukaPaletizacije.BackColor = System.Drawing.SystemColors.Info;
            this.labelPorukaPaletizacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPorukaPaletizacije.ForeColor = System.Drawing.Color.DimGray;
            this.labelPorukaPaletizacije.Location = new System.Drawing.Point(8, 3);
            this.labelPorukaPaletizacije.Name = "labelPorukaPaletizacije";
            this.labelPorukaPaletizacije.Size = new System.Drawing.Size(459, 26);
            this.labelPorukaPaletizacije.TabIndex = 12;
            this.labelPorukaPaletizacije.Text = "Изаберите производ";
            this.labelPorukaPaletizacije.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel1.Controls.Add(this.labelPorukaPaletizacije);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(534, 667);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 32);
            this.panel1.TabIndex = 13;
            // 
            // BrojKutija
            // 
            this.BrojKutija.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrojKutija.BackColor = System.Drawing.SystemColors.Info;
            this.BrojKutija.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrojKutija.Location = new System.Drawing.Point(539, 399);
            this.BrojKutija.Name = "BrojKutija";
            this.BrojKutija.ReadOnly = true;
            this.BrojKutija.Size = new System.Drawing.Size(200, 49);
            this.BrojKutija.TabIndex = 15;
            this.BrojKutija.TextChanged += new System.EventHandler(this.BrojKutija_TextChanged);
            // 
            // labelKartonaInfo
            // 
            this.labelKartonaInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKartonaInfo.AutoSize = true;
            this.labelKartonaInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKartonaInfo.ForeColor = System.Drawing.Color.Black;
            this.labelKartonaInfo.Location = new System.Drawing.Point(532, 341);
            this.labelKartonaInfo.Name = "labelKartonaInfo";
            this.labelKartonaInfo.Size = new System.Drawing.Size(207, 42);
            this.labelKartonaInfo.TabIndex = 16;
            this.labelKartonaInfo.Text = "Број кутија";
            // 
            // MasaPoPaleti
            // 
            this.MasaPoPaleti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MasaPoPaleti.Location = new System.Drawing.Point(810, 163);
            this.MasaPoPaleti.Name = "MasaPoPaleti";
            this.MasaPoPaleti.ReadOnly = true;
            this.MasaPoPaleti.Size = new System.Drawing.Size(191, 29);
            this.MasaPoPaleti.TabIndex = 18;
            this.MasaPoPaleti.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(806, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 24);
            this.label6.TabIndex = 17;
            this.label6.Text = "Masa palete";
            this.label6.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.buttonShiftOver);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.cmbMasine);
            this.panel2.Controls.Add(this.masinaLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbSmena);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 42);
            this.panel2.TabIndex = 19;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(7, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(101, 30);
            this.btnLogin.TabIndex = 21;
            this.btnLogin.Text = "Оператер";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cmbMasine
            // 
            this.cmbMasine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMasine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbMasine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMasine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMasine.FormattingEnabled = true;
            this.cmbMasine.Location = new System.Drawing.Point(780, 7);
            this.cmbMasine.Name = "cmbMasine";
            this.cmbMasine.Size = new System.Drawing.Size(198, 32);
            this.cmbMasine.TabIndex = 29;
            this.cmbMasine.SelectedIndexChanged += new System.EventHandler(this.cmbMasine_SelectedIndexChanged);
            // 
            // masinaLabel
            // 
            this.masinaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.masinaLabel.AutoSize = true;
            this.masinaLabel.BackColor = System.Drawing.Color.PowderBlue;
            this.masinaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masinaLabel.ForeColor = System.Drawing.Color.Gray;
            this.masinaLabel.Location = new System.Drawing.Point(694, 11);
            this.masinaLabel.Name = "masinaLabel";
            this.masinaLabel.Size = new System.Drawing.Size(92, 24);
            this.masinaLabel.TabIndex = 12;
            this.masinaLabel.Text = "Машина: ";
            this.masinaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(112, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "Смена";
            // 
            // cmbSmena
            // 
            this.cmbSmena.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbSmena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSmena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSmena.FormattingEnabled = true;
            this.cmbSmena.Items.AddRange(new object[] {
            "Смена I",
            "Смена II",
            "Смена III"});
            this.cmbSmena.Location = new System.Drawing.Point(188, 5);
            this.cmbSmena.Name = "cmbSmena";
            this.cmbSmena.Size = new System.Drawing.Size(198, 32);
            this.cmbSmena.TabIndex = 28;
            this.cmbSmena.SelectedIndexChanged += new System.EventHandler(this.cmbSmena_SelectedIndexChanged);
            // 
            // userLabel
            // 
            this.userLabel.BackColor = System.Drawing.Color.PowderBlue;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.userLabel.Location = new System.Drawing.Point(3, 8);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(452, 26);
            this.userLabel.TabIndex = 21;
            this.userLabel.Text = "Оператер ";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGotovo
            // 
            this.btnGotovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGotovo.Location = new System.Drawing.Point(792, 535);
            this.btnGotovo.Name = "btnGotovo";
            this.btnGotovo.Size = new System.Drawing.Size(194, 101);
            this.btnGotovo.TabIndex = 22;
            this.btnGotovo.Text = "ГОТОВО";
            this.btnGotovo.UseVisualStyleBackColor = true;
            this.btnGotovo.Visible = false;
            this.btnGotovo.Click += new System.EventHandler(this.btnGotovo_Click);
            // 
            // btnIzbor
            // 
            this.btnIzbor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIzbor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzbor.Location = new System.Drawing.Point(12, 667);
            this.btnIzbor.Name = "btnIzbor";
            this.btnIzbor.Size = new System.Drawing.Size(512, 32);
            this.btnIzbor.TabIndex = 25;
            this.btnIzbor.Text = "Изабери производ";
            this.btnIzbor.UseVisualStyleBackColor = true;
            this.btnIzbor.Click += new System.EventHandler(this.btnIzbor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(538, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 24);
            this.label7.TabIndex = 26;
            this.label7.Text = "Назив производа";
            // 
            // txtNazivProizvoda
            // 
            this.txtNazivProizvoda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNazivProizvoda.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNazivProizvoda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNazivProizvoda.Location = new System.Drawing.Point(542, 270);
            this.txtNazivProizvoda.Name = "txtNazivProizvoda";
            this.txtNazivProizvoda.ReadOnly = true;
            this.txtNazivProizvoda.Size = new System.Drawing.Size(462, 29);
            this.txtNazivProizvoda.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.PowderBlue;
            this.panel3.Controls.Add(this.datumLabel);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.userLabel);
            this.panel3.Location = new System.Drawing.Point(12, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(992, 41);
            this.panel3.TabIndex = 30;
            // 
            // datumLabel
            // 
            this.datumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datumLabel.BackColor = System.Drawing.Color.PowderBlue;
            this.datumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datumLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.datumLabel.Location = new System.Drawing.Point(436, 8);
            this.datumLabel.Name = "datumLabel";
            this.datumLabel.Size = new System.Drawing.Size(380, 26);
            this.datumLabel.TabIndex = 31;
            this.datumLabel.Text = "Датум  ";
            this.datumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(822, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy.  HH : mm : ss";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(542, 140);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(240, 29);
            this.dateTimePicker1.TabIndex = 31;
            // 
            // labelKomada
            // 
            this.labelKomada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKomada.AutoSize = true;
            this.labelKomada.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKomada.ForeColor = System.Drawing.Color.Black;
            this.labelKomada.Location = new System.Drawing.Point(744, 341);
            this.labelKomada.Name = "labelKomada";
            this.labelKomada.Size = new System.Drawing.Size(264, 42);
            this.labelKomada.TabIndex = 33;
            this.labelKomada.Text = "+ Број комада";
            // 
            // textKomadi
            // 
            this.textKomadi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textKomadi.BackColor = System.Drawing.SystemColors.Info;
            this.textKomadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textKomadi.Location = new System.Drawing.Point(776, 399);
            this.textKomadi.Name = "textKomadi";
            this.textKomadi.Size = new System.Drawing.Size(225, 49);
            this.textKomadi.TabIndex = 32;
            this.textKomadi.Text = "0";
            this.textKomadi.TextChanged += new System.EventHandler(this.textKomadi_TextChanged);
            // 
            // lstProizvodi
            // 
            this.lstProizvodi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstProizvodi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sifra,
            this.comment,
            this.naziv});
            this.lstProizvodi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstProizvodi.FullRowSelect = true;
            this.lstProizvodi.Location = new System.Drawing.Point(12, 140);
            this.lstProizvodi.MultiSelect = false;
            this.lstProizvodi.Name = "lstProizvodi";
            this.lstProizvodi.Size = new System.Drawing.Size(512, 521);
            this.lstProizvodi.TabIndex = 34;
            this.lstProizvodi.UseCompatibleStateImageBehavior = false;
            this.lstProizvodi.View = System.Windows.Forms.View.Details;
            this.lstProizvodi.SelectedIndexChanged += new System.EventHandler(this.lstProizvodi_SelectedIndexChanged_1);
            // 
            // sifra
            // 
            this.sifra.Text = "Шифра";
            this.sifra.Width = 100;
            // 
            // comment
            // 
            this.comment.Text = "Коментар";
            this.comment.Width = 90;
            // 
            // naziv
            // 
            this.naziv.Text = "Назив артикла";
            this.naziv.Width = 400;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.PowderBlue;
            this.panel4.Controls.Add(this.fndComment);
            this.panel4.Controls.Add(this.fndNaziv);
            this.panel4.Controls.Add(this.fndCode);
            this.panel4.Controls.Add(this.btnClear);
            this.panel4.Controls.Add(this.btnFind);
            this.panel4.Location = new System.Drawing.Point(12, 96);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(992, 38);
            this.panel4.TabIndex = 35;
            // 
            // fndComment
            // 
            this.fndComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fndComment.FormattingEnabled = true;
            this.fndComment.Location = new System.Drawing.Point(101, 8);
            this.fndComment.Name = "fndComment";
            this.fndComment.Size = new System.Drawing.Size(92, 24);
            this.fndComment.TabIndex = 2;
            // 
            // fndNaziv
            // 
            this.fndNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fndNaziv.Location = new System.Drawing.Point(194, 10);
            this.fndNaziv.Name = "fndNaziv";
            this.fndNaziv.Size = new System.Drawing.Size(318, 22);
            this.fndNaziv.TabIndex = 3;
            // 
            // fndCode
            // 
            this.fndCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fndCode.Location = new System.Drawing.Point(0, 10);
            this.fndCode.Name = "fndCode";
            this.fndCode.Size = new System.Drawing.Size(100, 22);
            this.fndCode.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(628, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 25);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Освежи";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(520, 7);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(99, 25);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "Пронађи";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // buttonShiftOver
            // 
            this.buttonShiftOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShiftOver.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonShiftOver.Location = new System.Drawing.Point(404, 5);
            this.buttonShiftOver.Name = "buttonShiftOver";
            this.buttonShiftOver.Size = new System.Drawing.Size(152, 30);
            this.buttonShiftOver.TabIndex = 30;
            this.buttonShiftOver.Text = "Пренос палета";
            this.buttonShiftOver.UseVisualStyleBackColor = true;
            this.buttonShiftOver.Click += new System.EventHandler(this.buttonShiftOver_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1016, 704);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lstProizvodi);
            this.Controls.Add(this.labelKomada);
            this.Controls.Add(this.textKomadi);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtNazivProizvoda);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnIzbor);
            this.Controls.Add(this.btnGotovo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MasaPoPaleti);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelKartonaInfo);
            this.Controls.Add(this.BrojKutija);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MasaPoKartonu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dkAltSifra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPreview);
            this.Name = "MainForm";
            this.Text = "ДОНКАФЕ - Палетизер";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dkAltSifra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MasaPoKartonu;
        private System.Windows.Forms.Label labelPorukaPaletizacije;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox BrojKutija;
        private System.Windows.Forms.Label labelKartonaInfo;
        private System.Windows.Forms.TextBox MasaPoPaleti;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label masinaLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGotovo;
        private System.Windows.Forms.Button btnIzbor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNazivProizvoda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSmena;
        private System.Windows.Forms.ComboBox cmbMasine;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label datumLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelKomada;
        private System.Windows.Forms.TextBox textKomadi;
        private System.Windows.Forms.ListView lstProizvodi;
        private System.Windows.Forms.ColumnHeader sifra;
        private System.Windows.Forms.ColumnHeader comment;
        private System.Windows.Forms.ColumnHeader naziv;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox fndCode;
        private System.Windows.Forms.TextBox fndNaziv;
        private System.Windows.Forms.ComboBox fndComment;
        private System.Windows.Forms.Button buttonShiftOver;
    }
}

