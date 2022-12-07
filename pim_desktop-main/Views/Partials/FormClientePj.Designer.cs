namespace pim_desktop.Views.Partials
{
    partial class FormClientePj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientePj));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cnpjInput = new System.Windows.Forms.MaskedTextBox();
            this.dtCriacaoPicker = new System.Windows.Forms.DateTimePicker();
            this.cepInput = new System.Windows.Forms.MaskedTextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.searchById = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.logradouroInput = new System.Windows.Forms.TextBox();
            this.telefoneInput = new System.Windows.Forms.MaskedTextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ctSocialInput = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.razaoSocialInput = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.cnpjInput);
            this.panel1.Controls.Add(this.dtCriacaoPicker);
            this.panel1.Controls.Add(this.cepInput);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.searchById);
            this.panel1.Controls.Add(this.panel14);
            this.panel1.Controls.Add(this.idBox);
            this.panel1.Controls.Add(this.logradouroInput);
            this.panel1.Controls.Add(this.telefoneInput);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.emailInput);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.ctSocialInput);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.razaoSocialInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 397);
            this.panel1.TabIndex = 0;
            // 
            // cnpjInput
            // 
            this.cnpjInput.AsciiOnly = true;
            this.cnpjInput.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.cnpjInput.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cnpjInput.Location = new System.Drawing.Point(16, 162);
            this.cnpjInput.Mask = "99.999.999/9999-99";
            this.cnpjInput.Name = "cnpjInput";
            this.cnpjInput.Size = new System.Drawing.Size(219, 29);
            this.cnpjInput.TabIndex = 152;
            this.cnpjInput.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // dtCriacaoPicker
            // 
            this.dtCriacaoPicker.CalendarFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtCriacaoPicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtCriacaoPicker.CustomFormat = "dd/mm/yyyy";
            this.dtCriacaoPicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtCriacaoPicker.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtCriacaoPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCriacaoPicker.Location = new System.Drawing.Point(240, 228);
            this.dtCriacaoPicker.MaxDate = new System.DateTime(2030, 12, 1, 0, 0, 0, 0);
            this.dtCriacaoPicker.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dtCriacaoPicker.Name = "dtCriacaoPicker";
            this.dtCriacaoPicker.Size = new System.Drawing.Size(158, 29);
            this.dtCriacaoPicker.TabIndex = 151;
            // 
            // cepInput
            // 
            this.cepInput.AsciiOnly = true;
            this.cepInput.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.cepInput.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cepInput.Location = new System.Drawing.Point(16, 294);
            this.cepInput.Mask = "99999-999";
            this.cepInput.Name = "cepInput";
            this.cepInput.Size = new System.Drawing.Size(131, 29);
            this.cepInput.TabIndex = 145;
            this.cepInput.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.BackColor = System.Drawing.Color.Transparent;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idLabel.Location = new System.Drawing.Point(16, 8);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(22, 17);
            this.idLabel.TabIndex = 150;
            this.idLabel.Text = "ID";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.Controls.Add(this.label21);
            this.panel12.Controls.Add(this.label22);
            this.panel12.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel12.Location = new System.Drawing.Point(16, 270);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(130, 20);
            this.panel12.TabIndex = 144;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Left;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(33, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 21);
            this.label21.TabIndex = 7;
            this.label21.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Left;
            this.label22.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(0, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(33, 17);
            this.label22.TabIndex = 6;
            this.label22.Text = "CEP";
            // 
            // searchById
            // 
            this.searchById.BackColor = System.Drawing.Color.White;
            this.searchById.FlatAppearance.BorderSize = 0;
            this.searchById.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchById.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchById.Image = ((System.Drawing.Image)(resources.GetObject("searchById.Image")));
            this.searchById.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchById.Location = new System.Drawing.Point(100, 32);
            this.searchById.Name = "searchById";
            this.searchById.Padding = new System.Windows.Forms.Padding(1);
            this.searchById.Size = new System.Drawing.Size(153, 29);
            this.searchById.TabIndex = 149;
            this.searchById.Text = "PESQUISAR ID";
            this.searchById.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchById.UseMnemonic = false;
            this.searchById.UseVisualStyleBackColor = false;
            this.searchById.Visible = false;
            this.searchById.Click += new System.EventHandler(this.searchById_Click);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Transparent;
            this.panel14.Controls.Add(this.label25);
            this.panel14.Controls.Add(this.label26);
            this.panel14.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel14.Location = new System.Drawing.Point(151, 269);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(144, 20);
            this.panel14.TabIndex = 143;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Dock = System.Windows.Forms.DockStyle.Left;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(105, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 21);
            this.label25.TabIndex = 7;
            this.label25.Text = "*";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Dock = System.Windows.Forms.DockStyle.Left;
            this.label26.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label26.Location = new System.Drawing.Point(0, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(105, 17);
            this.label26.TabIndex = 6;
            this.label26.Text = "LOGRADOURO";
            // 
            // idBox
            // 
            this.idBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.idBox.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.idBox.Location = new System.Drawing.Point(16, 32);
            this.idBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(68, 29);
            this.idBox.TabIndex = 148;
            // 
            // logradouroInput
            // 
            this.logradouroInput.BackColor = System.Drawing.Color.White;
            this.logradouroInput.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logradouroInput.Location = new System.Drawing.Point(151, 294);
            this.logradouroInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logradouroInput.Name = "logradouroInput";
            this.logradouroInput.Size = new System.Drawing.Size(310, 29);
            this.logradouroInput.TabIndex = 142;
            // 
            // telefoneInput
            // 
            this.telefoneInput.AsciiOnly = true;
            this.telefoneInput.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.telefoneInput.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.telefoneInput.Location = new System.Drawing.Point(240, 162);
            this.telefoneInput.Mask = "(99)9 9999-9999";
            this.telefoneInput.Name = "telefoneInput";
            this.telefoneInput.Size = new System.Drawing.Size(219, 29);
            this.telefoneInput.TabIndex = 141;
            this.telefoneInput.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Controls.Add(this.label17);
            this.panel10.Controls.Add(this.label18);
            this.panel10.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel10.Location = new System.Drawing.Point(16, 203);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(163, 20);
            this.panel10.TabIndex = 147;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(55, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 21);
            this.label17.TabIndex = 7;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 17);
            this.label18.TabIndex = 6;
            this.label18.Text = "E-MAIL";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.Controls.Add(this.label23);
            this.panel13.Controls.Add(this.label24);
            this.panel13.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel13.Location = new System.Drawing.Point(240, 136);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(163, 20);
            this.panel13.TabIndex = 140;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Dock = System.Windows.Forms.DockStyle.Left;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(76, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 21);
            this.label23.TabIndex = 7;
            this.label23.Text = "*";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Left;
            this.label24.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label24.Location = new System.Drawing.Point(0, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(76, 17);
            this.label24.TabIndex = 6;
            this.label24.Text = "TELEFONE";
            // 
            // emailInput
            // 
            this.emailInput.BackColor = System.Drawing.Color.White;
            this.emailInput.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.emailInput.Location = new System.Drawing.Point(16, 228);
            this.emailInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(219, 29);
            this.emailInput.TabIndex = 146;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.label15);
            this.panel9.Controls.Add(this.label16);
            this.panel9.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel9.Location = new System.Drawing.Point(240, 202);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(219, 20);
            this.panel9.TabIndex = 141;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(132, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 21);
            this.label15.TabIndex = 7;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 17);
            this.label16.TabIndex = 6;
            this.label16.Text = "DATA DE CRIAÇÃO";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel6.Location = new System.Drawing.Point(16, 137);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(163, 20);
            this.panel6.TabIndex = 139;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(42, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 21);
            this.label9.TabIndex = 7;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "CNPJ";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel5.Location = new System.Drawing.Point(240, 76);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(163, 20);
            this.panel5.TabIndex = 137;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(137, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "CONTRATO SOCIAL";
            // 
            // ctSocialInput
            // 
            this.ctSocialInput.BackColor = System.Drawing.Color.White;
            this.ctSocialInput.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ctSocialInput.Location = new System.Drawing.Point(240, 101);
            this.ctSocialInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctSocialInput.Name = "ctSocialInput";
            this.ctSocialInput.Size = new System.Drawing.Size(219, 29);
            this.ctSocialInput.TabIndex = 136;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(16, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(163, 20);
            this.panel3.TabIndex = 135;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(107, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "RAZAO SOCIAL";
            // 
            // razaoSocialInput
            // 
            this.razaoSocialInput.BackColor = System.Drawing.Color.White;
            this.razaoSocialInput.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.razaoSocialInput.Location = new System.Drawing.Point(16, 101);
            this.razaoSocialInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.razaoSocialInput.Name = "razaoSocialInput";
            this.razaoSocialInput.Size = new System.Drawing.Size(219, 29);
            this.razaoSocialInput.TabIndex = 134;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSubmit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 341);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 56);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(332, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(159, 31);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "CANCELAR";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.AutoSize = true;
            this.btnSubmit.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSubmit.Location = new System.Drawing.Point(173, 25);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(159, 31);
            this.btnSubmit.TabIndex = 37;
            this.btnSubmit.Text = "OK";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // FormClientePj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(492, 397);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormClientePj";
            this.Text = "FormClientePj";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel10;
        private Label label17;
        private Label label18;
        private TextBox emailInput;
        private Panel panel9;
        private Label label15;
        private Label label16;
        private Panel panel6;
        private Label label9;
        private Label label10;
        private Panel panel5;
        private Label label7;
        private Label label8;
        private TextBox ctSocialInput;
        private Panel panel3;
        private Label label5;
        private Label label6;
        private TextBox razaoSocialInput;
        private Label idLabel;
        private Button searchById;
        private TextBox idBox;
        private MaskedTextBox cepInput;
        private Panel panel12;
        private Label label21;
        private Label label22;
        private Panel panel14;
        private Label label25;
        private Label label26;
        private TextBox logradouroInput;
        private MaskedTextBox telefoneInput;
        private Panel panel13;
        private Label label23;
        private Label label24;
        private DateTimePicker dtCriacaoPicker;
        private MaskedTextBox cnpjInput;
        private Button btnCancel;
        private Button btnSubmit;
    }
}