﻿namespace SuperShop.Presentation
{
    partial class frmUnitNew
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
            this.txtPrimaryQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 158);
            this.btnSave.TabIndex = 3;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(214, 158);
            this.btnExit.TabIndex = 4;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtPrimaryQuantity
            // 
            this.txtPrimaryQuantity.Location = new System.Drawing.Point(12, 118);
            this.txtPrimaryQuantity.Name = "txtPrimaryQuantity";
            this.txtPrimaryQuantity.Size = new System.Drawing.Size(277, 20);
            this.txtPrimaryQuantity.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "Primary Quantity";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 73);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(277, 20);
            this.txtDescription.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 69;
            this.label5.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(277, 20);
            this.txtName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Name";
            // 
            // frmUnitNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(309, 193);
            this.Controls.Add(this.txtPrimaryQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Name = "frmUnitNew";
            this.ShowIcon = false;
            this.Text = "Unit New";
            this.Load += new System.EventHandler(this.frmUnitNew_Load);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtPrimaryQuantity, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrimaryQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
    }
}
