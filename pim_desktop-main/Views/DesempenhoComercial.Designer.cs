namespace pim_desktop.Views
{
    partial class DesempenhoComercial
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imprimirBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.anoInput = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.mesInput = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaGreen;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(864, 56);
            this.panel4.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(864, 56);
            this.label5.TabIndex = 13;
            this.label5.Text = "DESEMPENHO DA EMPRESA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(585, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESCOLHE O MÊS/ANO PARA GERAR O RELATÓRIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.imprimirBtn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.anoInput);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.mesInput);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(153, 93);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 303);
            this.panel1.TabIndex = 6;
            // 
            // imprimirBtn
            // 
            this.imprimirBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.imprimirBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.imprimirBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.imprimirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imprimirBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.imprimirBtn.Location = new System.Drawing.Point(183, 205);
            this.imprimirBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imprimirBtn.Name = "imprimirBtn";
            this.imprimirBtn.Size = new System.Drawing.Size(240, 53);
            this.imprimirBtn.TabIndex = 7;
            this.imprimirBtn.Text = "IMPRIMIR";
            this.imprimirBtn.UseVisualStyleBackColor = false;
            this.imprimirBtn.Click += new System.EventHandler(this.imprimirBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(321, 97);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 27);
            this.panel2.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(48, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "ANO";
            // 
            // anoInput
            // 
            this.anoInput.BackColor = System.Drawing.Color.White;
            this.anoInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.anoInput.Location = new System.Drawing.Point(321, 131);
            this.anoInput.MaxLength = 4;
            this.anoInput.Name = "anoInput";
            this.anoInput.PlaceholderText = "AAAA";
            this.anoInput.Size = new System.Drawing.Size(167, 34);
            this.anoInput.TabIndex = 22;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.label15);
            this.panel9.Controls.Add(this.label16);
            this.panel9.Location = new System.Drawing.Point(128, 97);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(168, 27);
            this.panel9.TabIndex = 21;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(45, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 28);
            this.label15.TabIndex = 7;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 23);
            this.label16.TabIndex = 6;
            this.label16.Text = "MÊS";
            // 
            // mesInput
            // 
            this.mesInput.BackColor = System.Drawing.Color.White;
            this.mesInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mesInput.Location = new System.Drawing.Point(128, 131);
            this.mesInput.MaxLength = 2;
            this.mesInput.Name = "mesInput";
            this.mesInput.PlaceholderText = "MM";
            this.mesInput.Size = new System.Drawing.Size(167, 34);
            this.mesInput.TabIndex = 20;
            // 
            // DesempenhoComercial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 561);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DesempenhoComercial";
            this.Text = "DesempenhoComercial";
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel4;
        private Label label5;
        private Label label1;
        private Panel panel1;
        private Button imprimirBtn;
        private Panel panel2;
        private Label label3;
        private Label label4;
        private TextBox anoInput;
        private Panel panel9;
        private Label label15;
        private Label label16;
        private TextBox mesInput;
    }
}