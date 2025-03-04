namespace Paletizer
{
    partial class PalleteList
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
            this.lstPallet = new System.Windows.Forms.ListView();
            this.dt = new System.Windows.Forms.ColumnHeader();
            this.barcode = new System.Windows.Forms.ColumnHeader();
            this.itemcode = new System.Windows.Forms.ColumnHeader();
            this.kolicina = new System.Windows.Forms.ColumnHeader();
            this.masina = new System.Windows.Forms.ColumnHeader();
            this.btnPrenosMagacin = new System.Windows.Forms.Button();
            this.btnDelPallet = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrenosProbat = new System.Windows.Forms.Button();
            this.kutije = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lstPallet
            // 
            this.lstPallet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPallet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dt,
            this.barcode,
            this.itemcode,
            this.kolicina,
            this.masina,
            this.kutije});
            this.lstPallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPallet.FullRowSelect = true;
            this.lstPallet.GridLines = true;
            this.lstPallet.Location = new System.Drawing.Point(12, 12);
            this.lstPallet.Name = "lstPallet";
            this.lstPallet.Size = new System.Drawing.Size(848, 680);
            this.lstPallet.TabIndex = 0;
            this.lstPallet.UseCompatibleStateImageBehavior = false;
            this.lstPallet.View = System.Windows.Forms.View.Details;
            // 
            // dt
            // 
            this.dt.Text = "Време";
            this.dt.Width = 160;
            // 
            // barcode
            // 
            this.barcode.Text = "Баркод";
            this.barcode.Width = 120;
            // 
            // itemcode
            // 
            this.itemcode.Text = "Шифра";
            this.itemcode.Width = 100;
            // 
            // kolicina
            // 
            this.kolicina.Text = "Количина";
            this.kolicina.Width = 120;
            // 
            // masina
            // 
            this.masina.Text = "Машина";
            this.masina.Width = 160;
            // 
            // btnPrenosMagacin
            // 
            this.btnPrenosMagacin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrenosMagacin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrenosMagacin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnPrenosMagacin.Location = new System.Drawing.Point(866, 12);
            this.btnPrenosMagacin.Name = "btnPrenosMagacin";
            this.btnPrenosMagacin.Size = new System.Drawing.Size(144, 46);
            this.btnPrenosMagacin.TabIndex = 5;
            this.btnPrenosMagacin.Text = "Пренос у магацин";
            this.btnPrenosMagacin.UseVisualStyleBackColor = true;
            this.btnPrenosMagacin.Click += new System.EventHandler(this.btnPrenosMagacin_Click);
            // 
            // btnDelPallet
            // 
            this.btnDelPallet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelPallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelPallet.Location = new System.Drawing.Point(866, 255);
            this.btnDelPallet.Name = "btnDelPallet";
            this.btnDelPallet.Size = new System.Drawing.Size(144, 46);
            this.btnDelPallet.TabIndex = 6;
            this.btnDelPallet.Text = "Неисправна палета";
            this.btnDelPallet.UseVisualStyleBackColor = true;
            this.btnDelPallet.Click += new System.EventHandler(this.btnDelPallet_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(866, 646);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 46);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "ЗАТВОРИ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(866, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 46);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "СНИМИ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrenosProbat
            // 
            this.btnPrenosProbat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrenosProbat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPrenosProbat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrenosProbat.ForeColor = System.Drawing.Color.DarkSalmon;
            this.btnPrenosProbat.Location = new System.Drawing.Point(866, 76);
            this.btnPrenosProbat.Name = "btnPrenosProbat";
            this.btnPrenosProbat.Size = new System.Drawing.Size(144, 46);
            this.btnPrenosProbat.TabIndex = 9;
            this.btnPrenosProbat.Text = "Пренос у ПРОБАТ";
            this.btnPrenosProbat.UseVisualStyleBackColor = true;
            this.btnPrenosProbat.Click += new System.EventHandler(this.btnPrenosProbat_Click);
            // 
            // kutije
            // 
            this.kutije.Text = "Бр.Кутија";
            this.kutije.Width = 120;
            // 
            // PalleteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1016, 704);
            this.Controls.Add(this.btnPrenosProbat);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelPallet);
            this.Controls.Add(this.btnPrenosMagacin);
            this.Controls.Add(this.lstPallet);
            this.Name = "PalleteList";
            this.Text = "Листа палета";
            this.Load += new System.EventHandler(this.PalleteList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstPallet;
        private System.Windows.Forms.Button btnPrenosMagacin;
        private System.Windows.Forms.Button btnDelPallet;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader dt;
        private System.Windows.Forms.ColumnHeader barcode;
        private System.Windows.Forms.ColumnHeader itemcode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader kolicina;
        private System.Windows.Forms.ColumnHeader masina;
        private System.Windows.Forms.Button btnPrenosProbat;
        private System.Windows.Forms.ColumnHeader kutije;
    }
}