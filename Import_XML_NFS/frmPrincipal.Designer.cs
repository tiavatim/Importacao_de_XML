
namespace Import_XML_NFS
{
    partial class frmPrincipal
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
            this.btnImportarXml = new System.Windows.Forms.Button();
            this.btnImportarSPED = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportarXml
            // 
            this.btnImportarXml.BackColor = System.Drawing.Color.White;
            this.btnImportarXml.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImportarXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarXml.Location = new System.Drawing.Point(119, 78);
            this.btnImportarXml.Name = "btnImportarXml";
            this.btnImportarXml.Size = new System.Drawing.Size(251, 61);
            this.btnImportarXml.TabIndex = 4;
            this.btnImportarXml.Text = "Importar XML";
            this.btnImportarXml.UseVisualStyleBackColor = false;
            this.btnImportarXml.Click += new System.EventHandler(this.btnImportarXml_Click);
            // 
            // btnImportarSPED
            // 
            this.btnImportarSPED.BackColor = System.Drawing.Color.White;
            this.btnImportarSPED.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImportarSPED.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarSPED.Location = new System.Drawing.Point(119, 170);
            this.btnImportarSPED.Name = "btnImportarSPED";
            this.btnImportarSPED.Size = new System.Drawing.Size(251, 63);
            this.btnImportarSPED.TabIndex = 5;
            this.btnImportarSPED.Text = "Importar SPED";
            this.btnImportarSPED.UseVisualStyleBackColor = false;
            this.btnImportarSPED.Visible = false;
            this.btnImportarSPED.Click += new System.EventHandler(this.btnImportarSPED_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Import_XML_NFS.Properties.Resources.logoAvatim;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 976;
            this.pictureBox1.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 316);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnImportarSPED);
            this.Controls.Add(this.btnImportarXml);
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportarXml;
        private System.Windows.Forms.Button btnImportarSPED;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}