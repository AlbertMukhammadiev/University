namespace AssemblyViewer
{
    partial class Viewer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.button_exe = new System.Windows.Forms.Button();
            this.button_dll = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tip = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.viewerBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Font = new System.Drawing.Font("NFS font", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(352, 224);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(82, 68);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OnButtonOKClick);
            // 
            // button_exe
            // 
            this.button_exe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_exe.Font = new System.Drawing.Font("NFS font", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exe.Location = new System.Drawing.Point(266, 151);
            this.button_exe.Name = "button_exe";
            this.button_exe.Size = new System.Drawing.Size(80, 67);
            this.button_exe.TabIndex = 1;
            this.button_exe.Text = ".exe";
            this.button_exe.UseVisualStyleBackColor = true;
            this.button_exe.Click += new System.EventHandler(this.OnButton_exeClick);
            // 
            // button_dll
            // 
            this.button_dll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_dll.Font = new System.Drawing.Font("NFS font", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dll.Location = new System.Drawing.Point(352, 151);
            this.button_dll.Name = "button_dll";
            this.button_dll.Size = new System.Drawing.Size(82, 67);
            this.button_dll.TabIndex = 2;
            this.button_dll.Text = ".dll";
            this.button_dll.UseVisualStyleBackColor = true;
            this.button_dll.Click += new System.EventHandler(this.OnButton_dllClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tip, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nameBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_exe, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonOK, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_dll, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.viewerBox, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 298);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.tip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tip.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.SetColumnSpan(this.tip, 2);
            this.tip.Font = new System.Drawing.Font("NFS font", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tip.Location = new System.Drawing.Point(266, 3);
            this.tip.Name = "label1";
            this.tableLayoutPanel1.SetRowSpan(this.tip, 2);
            this.tip.Size = new System.Drawing.Size(168, 145);
            this.tip.TabIndex = 3;
            this.tip.Text = "label1";
            // 
            // textBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(6, 6);
            this.nameBox.Multiline = true;
            this.nameBox.Name = "textBox";
            this.nameBox.Size = new System.Drawing.Size(254, 52);
            this.nameBox.TabIndex = 4;
            // 
            // viewerBox
            // 
            this.viewerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewerBox.Location = new System.Drawing.Point(6, 64);
            this.viewerBox.Multiline = true;
            this.viewerBox.Name = "viewerBox";
            this.tableLayoutPanel1.SetRowSpan(this.viewerBox, 3);
            this.viewerBox.Size = new System.Drawing.Size(254, 228);
            this.viewerBox.TabIndex = 5;
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 322);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Viewer";
            this.Text = "My Viewer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button button_exe;
        private System.Windows.Forms.Button button_dll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox viewerBox;
    }
}

