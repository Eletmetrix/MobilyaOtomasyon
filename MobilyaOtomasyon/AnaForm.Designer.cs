namespace MobilyaOtomasyon
{
    partial class AnaForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.KapatBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UrunBilgisiBtn = new System.Windows.Forms.Button();
            this.MusteriBilgisiBtn = new System.Windows.Forms.Button();
            this.UrunEkleBtn = new System.Windows.Forms.Button();
            this.MusteriEkleBtn = new System.Windows.Forms.Button();
            this.AnaSayfaBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.AnaLabel = new System.Windows.Forms.Label();
            this.FormPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.KapatBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 10);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // KapatBtn
            // 
            this.KapatBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.KapatBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.KapatBtn.FlatAppearance.BorderSize = 0;
            this.KapatBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KapatBtn.Location = new System.Drawing.Point(1115, 0);
            this.KapatBtn.Name = "KapatBtn";
            this.KapatBtn.Size = new System.Drawing.Size(10, 10);
            this.KapatBtn.TabIndex = 0;
            this.KapatBtn.UseVisualStyleBackColor = false;
            this.KapatBtn.Click += new System.EventHandler(this.KapatBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.UrunBilgisiBtn);
            this.panel2.Controls.Add(this.MusteriBilgisiBtn);
            this.panel2.Controls.Add(this.UrunEkleBtn);
            this.panel2.Controls.Add(this.MusteriEkleBtn);
            this.panel2.Controls.Add(this.AnaSayfaBtn);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 629);
            this.panel2.TabIndex = 1;
            // 
            // UrunBilgisiBtn
            // 
            this.UrunBilgisiBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.UrunBilgisiBtn.FlatAppearance.BorderSize = 0;
            this.UrunBilgisiBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UrunBilgisiBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UrunBilgisiBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.UrunBilgisiBtn.Location = new System.Drawing.Point(0, 360);
            this.UrunBilgisiBtn.Name = "UrunBilgisiBtn";
            this.UrunBilgisiBtn.Padding = new System.Windows.Forms.Padding(10);
            this.UrunBilgisiBtn.Size = new System.Drawing.Size(200, 65);
            this.UrunBilgisiBtn.TabIndex = 6;
            this.UrunBilgisiBtn.Text = "Ürün Bilgisi";
            this.UrunBilgisiBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UrunBilgisiBtn.UseVisualStyleBackColor = true;
            this.UrunBilgisiBtn.Click += new System.EventHandler(this.PanelButtonsClick);
            // 
            // MusteriBilgisiBtn
            // 
            this.MusteriBilgisiBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.MusteriBilgisiBtn.FlatAppearance.BorderSize = 0;
            this.MusteriBilgisiBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MusteriBilgisiBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MusteriBilgisiBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MusteriBilgisiBtn.Location = new System.Drawing.Point(0, 295);
            this.MusteriBilgisiBtn.Name = "MusteriBilgisiBtn";
            this.MusteriBilgisiBtn.Padding = new System.Windows.Forms.Padding(10);
            this.MusteriBilgisiBtn.Size = new System.Drawing.Size(200, 65);
            this.MusteriBilgisiBtn.TabIndex = 5;
            this.MusteriBilgisiBtn.Text = "Müşteri Bilgisi";
            this.MusteriBilgisiBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MusteriBilgisiBtn.UseVisualStyleBackColor = true;
            this.MusteriBilgisiBtn.Click += new System.EventHandler(this.PanelButtonsClick);
            // 
            // UrunEkleBtn
            // 
            this.UrunEkleBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.UrunEkleBtn.FlatAppearance.BorderSize = 0;
            this.UrunEkleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UrunEkleBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UrunEkleBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.UrunEkleBtn.Location = new System.Drawing.Point(0, 230);
            this.UrunEkleBtn.Name = "UrunEkleBtn";
            this.UrunEkleBtn.Padding = new System.Windows.Forms.Padding(10);
            this.UrunEkleBtn.Size = new System.Drawing.Size(200, 65);
            this.UrunEkleBtn.TabIndex = 4;
            this.UrunEkleBtn.Text = "Ürün Ekle";
            this.UrunEkleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UrunEkleBtn.UseVisualStyleBackColor = true;
            this.UrunEkleBtn.Click += new System.EventHandler(this.PanelButtonsClick);
            // 
            // MusteriEkleBtn
            // 
            this.MusteriEkleBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.MusteriEkleBtn.FlatAppearance.BorderSize = 0;
            this.MusteriEkleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MusteriEkleBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MusteriEkleBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MusteriEkleBtn.Location = new System.Drawing.Point(0, 165);
            this.MusteriEkleBtn.Name = "MusteriEkleBtn";
            this.MusteriEkleBtn.Padding = new System.Windows.Forms.Padding(10);
            this.MusteriEkleBtn.Size = new System.Drawing.Size(200, 65);
            this.MusteriEkleBtn.TabIndex = 3;
            this.MusteriEkleBtn.Text = "Müşteri Ekle";
            this.MusteriEkleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MusteriEkleBtn.UseVisualStyleBackColor = true;
            this.MusteriEkleBtn.Click += new System.EventHandler(this.PanelButtonsClick);
            // 
            // AnaSayfaBtn
            // 
            this.AnaSayfaBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnaSayfaBtn.FlatAppearance.BorderSize = 0;
            this.AnaSayfaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnaSayfaBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AnaSayfaBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.AnaSayfaBtn.Location = new System.Drawing.Point(0, 100);
            this.AnaSayfaBtn.Name = "AnaSayfaBtn";
            this.AnaSayfaBtn.Padding = new System.Windows.Forms.Padding(10);
            this.AnaSayfaBtn.Size = new System.Drawing.Size(200, 65);
            this.AnaSayfaBtn.TabIndex = 2;
            this.AnaSayfaBtn.Text = "Ana Sayfa";
            this.AnaSayfaBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AnaSayfaBtn.UseVisualStyleBackColor = true;
            this.AnaSayfaBtn.Click += new System.EventHandler(this.PanelButtonsClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mobilya Otomasyonu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.AnaLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(200, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(925, 100);
            this.panel4.TabIndex = 2;
            // 
            // AnaLabel
            // 
            this.AnaLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AnaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnaLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AnaLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AnaLabel.Location = new System.Drawing.Point(0, 0);
            this.AnaLabel.Name = "AnaLabel";
            this.AnaLabel.Size = new System.Drawing.Size(925, 100);
            this.AnaLabel.TabIndex = 1;
            this.AnaLabel.Text = "Ana Sayfa";
            this.AnaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPanel
            // 
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPanel.Location = new System.Drawing.Point(200, 110);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(925, 529);
            this.FormPanel.TabIndex = 3;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 639);
            this.Controls.Add(this.FormPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnaForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button UrunBilgisiBtn;
        private Button MusteriBilgisiBtn;
        private Button UrunEkleBtn;
        private Button MusteriEkleBtn;
        private Button AnaSayfaBtn;
        private Panel panel3;
        private Label label1;
        private Panel panel4;
        private Button KapatBtn;
        private Label AnaLabel;
        private Panel FormPanel;
    }
}