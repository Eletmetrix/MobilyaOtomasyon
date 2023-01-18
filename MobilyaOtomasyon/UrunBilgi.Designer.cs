namespace MobilyaOtomasyon
{
    partial class UrunBilgi
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AdresLbl = new System.Windows.Forms.Label();
            this.TeslimTarihLbl = new System.Windows.Forms.Label();
            this.SiparisTarihLbl = new System.Windows.Forms.Label();
            this.UrunIsimLbl = new System.Windows.Forms.Label();
            this.EbatListesi = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TeslimEdildiBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EbatListesi, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 65);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(875, 479);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.AdresLbl, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.TeslimTarihLbl, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.SiparisTarihLbl, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.UrunIsimLbl, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(437, 414);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // AdresLbl
            // 
            this.AdresLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdresLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AdresLbl.Location = new System.Drawing.Point(3, 150);
            this.AdresLbl.Name = "AdresLbl";
            this.AdresLbl.Size = new System.Drawing.Size(431, 264);
            this.AdresLbl.TabIndex = 5;
            this.AdresLbl.Text = "Adres:";
            // 
            // TeslimTarihLbl
            // 
            this.TeslimTarihLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeslimTarihLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TeslimTarihLbl.Location = new System.Drawing.Point(3, 100);
            this.TeslimTarihLbl.Name = "TeslimTarihLbl";
            this.TeslimTarihLbl.Size = new System.Drawing.Size(431, 50);
            this.TeslimTarihLbl.TabIndex = 4;
            this.TeslimTarihLbl.Text = "Teslim Tarihi: TESLİM EDİLMEDİ";
            this.TeslimTarihLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SiparisTarihLbl
            // 
            this.SiparisTarihLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SiparisTarihLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SiparisTarihLbl.Location = new System.Drawing.Point(3, 50);
            this.SiparisTarihLbl.Name = "SiparisTarihLbl";
            this.SiparisTarihLbl.Size = new System.Drawing.Size(431, 50);
            this.SiparisTarihLbl.TabIndex = 3;
            this.SiparisTarihLbl.Text = "Sipariş Tarihi: NULL";
            this.SiparisTarihLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UrunIsimLbl
            // 
            this.UrunIsimLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UrunIsimLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UrunIsimLbl.Location = new System.Drawing.Point(3, 0);
            this.UrunIsimLbl.Name = "UrunIsimLbl";
            this.UrunIsimLbl.Size = new System.Drawing.Size(431, 50);
            this.UrunIsimLbl.TabIndex = 2;
            this.UrunIsimLbl.Text = "Ürün İsmi: NULL";
            this.UrunIsimLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EbatListesi
            // 
            this.EbatListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EbatListesi.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EbatListesi.FormattingEnabled = true;
            this.EbatListesi.ItemHeight = 20;
            this.EbatListesi.Location = new System.Drawing.Point(440, 3);
            this.EbatListesi.Name = "EbatListesi";
            this.EbatListesi.Size = new System.Drawing.Size(432, 408);
            this.EbatListesi.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TeslimEdildiBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(25, 439);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.panel1.Size = new System.Drawing.Size(875, 65);
            this.panel1.TabIndex = 1;
            // 
            // TeslimEdildiBtn
            // 
            this.TeslimEdildiBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TeslimEdildiBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.TeslimEdildiBtn.FlatAppearance.BorderSize = 0;
            this.TeslimEdildiBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TeslimEdildiBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TeslimEdildiBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TeslimEdildiBtn.Location = new System.Drawing.Point(625, 15);
            this.TeslimEdildiBtn.Name = "TeslimEdildiBtn";
            this.TeslimEdildiBtn.Size = new System.Drawing.Size(250, 50);
            this.TeslimEdildiBtn.TabIndex = 1;
            this.TeslimEdildiBtn.Text = "Teslim Edildi Olarak İşaretle";
            this.TeslimEdildiBtn.UseVisualStyleBackColor = false;
            this.TeslimEdildiBtn.Click += new System.EventHandler(this.TeslimEdildiBtn_Click);
            // 
            // UrunBilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 529);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UrunBilgi";
            this.Padding = new System.Windows.Forms.Padding(25);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ListBox EbatListesi;
        private Label UrunIsimLbl;
        private Label AdresLbl;
        private Label TeslimTarihLbl;
        private Label SiparisTarihLbl;
        private Panel panel1;
        private Button TeslimEdildiBtn;
    }
}