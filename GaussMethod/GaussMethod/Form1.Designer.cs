namespace GaussMethod
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.varNumber = new System.Windows.Forms.Label();
            this.moreButton = new System.Windows.Forms.Button();
            this.lessButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.autoFill = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(168)))), ((int)(((byte)(164)))));
            this.panel1.Controls.Add(this.varNumber);
            this.panel1.Controls.Add(this.moreButton);
            this.panel1.Controls.Add(this.lessButton);
            this.panel1.Location = new System.Drawing.Point(372, 187);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 54);
            this.panel1.TabIndex = 0;
            // 
            // varNumber
            // 
            this.varNumber.AutoSize = true;
            this.varNumber.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.varNumber.Location = new System.Drawing.Point(64, 12);
            this.varNumber.Name = "varNumber";
            this.varNumber.Size = new System.Drawing.Size(25, 29);
            this.varNumber.TabIndex = 2;
            this.varNumber.Text = "2";
            // 
            // moreButton
            // 
            this.moreButton.BackgroundImage = global::GaussMethod.Properties.Resources.moreButton;
            this.moreButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moreButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.moreButton.Location = new System.Drawing.Point(99, 0);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(50, 50);
            this.moreButton.TabIndex = 1;
            this.moreButton.UseVisualStyleBackColor = true;
            this.moreButton.Click += new System.EventHandler(this.moreButton_Click);
            // 
            // lessButton
            // 
            this.lessButton.BackgroundImage = global::GaussMethod.Properties.Resources.lessButton;
            this.lessButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lessButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lessButton.Location = new System.Drawing.Point(3, 1);
            this.lessButton.Name = "lessButton";
            this.lessButton.Size = new System.Drawing.Size(50, 50);
            this.lessButton.TabIndex = 0;
            this.lessButton.UseVisualStyleBackColor = true;
            this.lessButton.Click += new System.EventHandler(this.lessButton_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(168)))), ((int)(((byte)(164)))));
            this.panel2.Location = new System.Drawing.Point(113, 320);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 280);
            this.panel2.TabIndex = 1;
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = global::GaussMethod.Properties.Resources.exitButton1;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.Location = new System.Drawing.Point(850, 19);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(50, 50);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackgroundImage = global::GaussMethod.Properties.Resources.helpButton1;
            this.buttonHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHelp.Location = new System.Drawing.Point(850, 75);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(50, 50);
            this.buttonHelp.TabIndex = 3;
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.BackgroundImage = global::GaussMethod.Properties.Resources.CulculateButton;
            this.calculateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.calculateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calculateButton.Location = new System.Drawing.Point(339, 657);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(242, 74);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // autoFill
            // 
            this.autoFill.BackgroundImage = global::GaussMethod.Properties.Resources.FillButton;
            this.autoFill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.autoFill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autoFill.Location = new System.Drawing.Point(152, 666);
            this.autoFill.Name = "autoFill";
            this.autoFill.Size = new System.Drawing.Size(156, 54);
            this.autoFill.TabIndex = 5;
            this.autoFill.UseVisualStyleBackColor = true;
            this.autoFill.Click += new System.EventHandler(this.autoFill_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackgroundImage = global::GaussMethod.Properties.Resources.ClearButton;
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.Location = new System.Drawing.Point(609, 667);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(156, 54);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(168)))), ((int)(((byte)(164)))));
            this.buttonSave.BackgroundImage = global::GaussMethod.Properties.Resources.SaveButton;
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Location = new System.Drawing.Point(152, 187);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(156, 54);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(168)))), ((int)(((byte)(164)))));
            this.buttonShow.BackgroundImage = global::GaussMethod.Properties.Resources.ShowResultButton;
            this.buttonShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShow.Location = new System.Drawing.Point(594, 188);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(156, 54);
            this.buttonShow.TabIndex = 8;
            this.buttonShow.UseVisualStyleBackColor = false;
            this.buttonShow.Visible = false;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(168)))), ((int)(((byte)(164)))));
            this.BackgroundImage = global::GaussMethod.Properties.Resources.backHigh;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(907, 783);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.autoFill);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Метод Гаусса";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button moreButton;
        private System.Windows.Forms.Button lessButton;
        private System.Windows.Forms.Label varNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button autoFill;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonShow;
    }
}

