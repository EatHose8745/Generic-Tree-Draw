namespace Generic_Tree
{
    partial class TreeDisplay<T>
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
            this.TreeDrawEnvironment = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TreeDrawEnvironment)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeDrawEnvironment
            // 
            this.TreeDrawEnvironment.Location = new System.Drawing.Point(-1, 0);
            this.TreeDrawEnvironment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TreeDrawEnvironment.Name = "TreeDrawEnvironment";
            this.TreeDrawEnvironment.Size = new System.Drawing.Size(803, 485);
            this.TreeDrawEnvironment.TabIndex = 0;
            this.TreeDrawEnvironment.TabStop = false;
            this.TreeDrawEnvironment.DoubleClick += new System.EventHandler(this.TreeDrawEnvironment_DoubleClick);
            // 
            // TreeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 485);
            this.Controls.Add(this.TreeDrawEnvironment);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TreeDisplay";
            this.ShowIcon = false;
            this.Text = "Tree Display";
            this.Load += new System.EventHandler(this.TreeDisplay_Load);
            this.SizeChanged += new System.EventHandler(this.TreeDisplay_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.TreeDrawEnvironment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TreeDrawEnvironment;
    }
}

