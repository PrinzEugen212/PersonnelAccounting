namespace PersAccounting.Forms
{
    partial class EmployeeCard
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lSurname = new System.Windows.Forms.Label();
            this.lBirthDate = new System.Windows.Forms.Label();
            this.lGender = new System.Windows.Forms.Label();
            this.bChange = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bRaise = new System.Windows.Forms.Button();
            this.lPost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lSurname
            // 
            this.lSurname.AutoSize = true;
            this.lSurname.Location = new System.Drawing.Point(30, 64);
            this.lSurname.Name = "lSurname";
            this.lSurname.Size = new System.Drawing.Size(71, 20);
            this.lSurname.TabIndex = 0;
            this.lSurname.Text = "lSurname";
            // 
            // lBirthDate
            // 
            this.lBirthDate.AutoSize = true;
            this.lBirthDate.Location = new System.Drawing.Point(222, 64);
            this.lBirthDate.Name = "lBirthDate";
            this.lBirthDate.Size = new System.Drawing.Size(76, 20);
            this.lBirthDate.TabIndex = 1;
            this.lBirthDate.Text = "lBirthDate";
            // 
            // lGender
            // 
            this.lGender.AutoSize = true;
            this.lGender.Location = new System.Drawing.Point(406, 64);
            this.lGender.Name = "lGender";
            this.lGender.Size = new System.Drawing.Size(61, 20);
            this.lGender.TabIndex = 2;
            this.lGender.Text = "lGender";
            // 
            // bChange
            // 
            this.bChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bChange.Location = new System.Drawing.Point(904, 45);
            this.bChange.Name = "bChange";
            this.bChange.Size = new System.Drawing.Size(94, 58);
            this.bChange.TabIndex = 3;
            this.bChange.Text = "Изменить";
            this.bChange.UseVisualStyleBackColor = true;
            this.bChange.Click += new System.EventHandler(this.bChange_Click);
            // 
            // bDelete
            // 
            this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bDelete.Location = new System.Drawing.Point(1028, 45);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(94, 58);
            this.bDelete.TabIndex = 4;
            this.bDelete.Text = "Удалить";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bRaise
            // 
            this.bRaise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bRaise.Location = new System.Drawing.Point(776, 45);
            this.bRaise.Name = "bRaise";
            this.bRaise.Size = new System.Drawing.Size(94, 58);
            this.bRaise.TabIndex = 5;
            this.bRaise.Text = "Повысить";
            this.bRaise.UseVisualStyleBackColor = true;
            this.bRaise.Click += new System.EventHandler(this.bRaise_Click);
            // 
            // lPost
            // 
            this.lPost.AutoSize = true;
            this.lPost.Location = new System.Drawing.Point(546, 65);
            this.lPost.Name = "lPost";
            this.lPost.Size = new System.Drawing.Size(40, 20);
            this.lPost.TabIndex = 6;
            this.lPost.Text = "lPost";
            // 
            // EmployeeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lPost);
            this.Controls.Add(this.bRaise);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bChange);
            this.Controls.Add(this.lGender);
            this.Controls.Add(this.lBirthDate);
            this.Controls.Add(this.lSurname);
            this.Name = "EmployeeCard";
            this.Size = new System.Drawing.Size(1142, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSurname;
        private System.Windows.Forms.Label lBirthDate;
        private System.Windows.Forms.Label lGender;
        private System.Windows.Forms.Button bChange;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bRaise;
        private System.Windows.Forms.Label lPost;
    }
}
