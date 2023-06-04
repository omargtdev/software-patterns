
namespace UI.Desktop.Forms
{
    partial class FormClient
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
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.txtFilterClients = new System.Windows.Forms.TextBox();
            this.btnGetClients = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClients
            // 
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(22, 73);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.Size = new System.Drawing.Size(784, 385);
            this.dgvClients.TabIndex = 0;
            // 
            // txtFilterClients
            // 
            this.txtFilterClients.Location = new System.Drawing.Point(22, 31);
            this.txtFilterClients.Name = "txtFilterClients";
            this.txtFilterClients.Size = new System.Drawing.Size(261, 20);
            this.txtFilterClients.TabIndex = 1;
            // 
            // btnGetClients
            // 
            this.btnGetClients.Location = new System.Drawing.Point(317, 28);
            this.btnGetClients.Name = "btnGetClients";
            this.btnGetClients.Size = new System.Drawing.Size(75, 23);
            this.btnGetClients.TabIndex = 2;
            this.btnGetClients.Text = "Search";
            this.btnGetClients.UseVisualStyleBackColor = true;
            this.btnGetClients.Click += new System.EventHandler(this.btnGetClients_Click);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 470);
            this.Controls.Add(this.btnGetClients);
            this.Controls.Add(this.txtFilterClients);
            this.Controls.Add(this.dgvClients);
            this.Name = "FormClient";
            this.Text = "FormClient";
            this.Load += new System.EventHandler(this.FormClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.TextBox txtFilterClients;
        private System.Windows.Forms.Button btnGetClients;
    }
}