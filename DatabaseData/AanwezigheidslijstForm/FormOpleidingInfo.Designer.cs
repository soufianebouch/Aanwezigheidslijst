namespace AanwezigheidslijstForm
{
    partial class FormOpleidingInfo
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
            this.textBoxOpleiding = new System.Windows.Forms.TextBox();
            this.textBoxOpleidingInstelling = new System.Windows.Forms.TextBox();
            this.textBoxContactpersoon = new System.Windows.Forms.TextBox();
            this.textBoxOpleidingscode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxOpleiding
            // 
            this.textBoxOpleiding.Location = new System.Drawing.Point(146, 25);
            this.textBoxOpleiding.Name = "textBoxOpleiding";
            this.textBoxOpleiding.Size = new System.Drawing.Size(100, 20);
            this.textBoxOpleiding.TabIndex = 0;
            // 
            // textBoxOpleidingInstelling
            // 
            this.textBoxOpleidingInstelling.Location = new System.Drawing.Point(146, 51);
            this.textBoxOpleidingInstelling.Name = "textBoxOpleidingInstelling";
            this.textBoxOpleidingInstelling.Size = new System.Drawing.Size(100, 20);
            this.textBoxOpleidingInstelling.TabIndex = 1;
            // 
            // textBoxContactpersoon
            // 
            this.textBoxContactpersoon.Location = new System.Drawing.Point(146, 77);
            this.textBoxContactpersoon.Name = "textBoxContactpersoon";
            this.textBoxContactpersoon.Size = new System.Drawing.Size(100, 20);
            this.textBoxContactpersoon.TabIndex = 2;
            // 
            // textBoxOpleidingscode
            // 
            this.textBoxOpleidingscode.Location = new System.Drawing.Point(146, 103);
            this.textBoxOpleidingscode.Name = "textBoxOpleidingscode";
            this.textBoxOpleidingscode.Size = new System.Drawing.Size(100, 20);
            this.textBoxOpleidingscode.TabIndex = 3;
            this.textBoxOpleidingscode.TextChanged += new System.EventHandler(this.TextBoxOpleidingscode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Opleiding";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Opleidingsinstelling ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Contactpersoon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Opleidingscode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "StartDatum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "EindDatum";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 32);
            this.button1.TabIndex = 12;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(146, 132);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 13;
            this.dateTimePicker1.Validating += new System.ComponentModel.CancelEventHandler(this.DateTimePicker1_Validating);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(146, 158);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 32);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // FormOpleidingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 259);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOpleidingscode);
            this.Controls.Add(this.textBoxContactpersoon);
            this.Controls.Add(this.textBoxOpleidingInstelling);
            this.Controls.Add(this.textBoxOpleiding);
            this.Name = "FormOpleidingInfo";
            this.Text = "OpleidingInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOpleiding;
        private System.Windows.Forms.TextBox textBoxOpleidingInstelling;
        private System.Windows.Forms.TextBox textBoxContactpersoon;
        private System.Windows.Forms.TextBox textBoxOpleidingscode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button2;
    }
}