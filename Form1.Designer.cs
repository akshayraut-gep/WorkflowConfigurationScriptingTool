namespace WorkflowConfigurationScriptingTool
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.cbQueryTypes = new System.Windows.Forms.ComboBox();
            this.dgvQueries = new System.Windows.Forms.DataGridView();
            this.tbQueries = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbJobID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStepName = new System.Windows.Forms.TextBox();
            this.cbExistingStep = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSequence = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSequence)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(602, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbQueryTypes
            // 
            this.cbQueryTypes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbQueryTypes.FormattingEnabled = true;
            this.cbQueryTypes.Location = new System.Drawing.Point(155, 12);
            this.cbQueryTypes.Name = "cbQueryTypes";
            this.cbQueryTypes.Size = new System.Drawing.Size(441, 40);
            this.cbQueryTypes.TabIndex = 1;
            // 
            // dgvQueries
            // 
            this.dgvQueries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueries.Location = new System.Drawing.Point(12, 60);
            this.dgvQueries.Name = "dgvQueries";
            this.dgvQueries.RowHeadersWidth = 62;
            this.dgvQueries.Size = new System.Drawing.Size(843, 266);
            this.dgvQueries.TabIndex = 2;
            this.dgvQueries.Text = "dataGridView1";
            // 
            // tbQueries
            // 
            this.tbQueries.Location = new System.Drawing.Point(12, 498);
            this.tbQueries.Multiline = true;
            this.tbQueries.Name = "tbQueries";
            this.tbQueries.Size = new System.Drawing.Size(843, 182);
            this.tbQueries.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(601, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(254, 48);
            this.button2.TabIndex = 0;
            this.button2.Text = "Generate SQL query";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Query Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Job ID";
            // 
            // tbJobID
            // 
            this.tbJobID.Location = new System.Drawing.Point(155, 355);
            this.tbJobID.Name = "tbJobID";
            this.tbJobID.Size = new System.Drawing.Size(254, 31);
            this.tbJobID.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Step name";
            // 
            // tbStepName
            // 
            this.tbStepName.Location = new System.Drawing.Point(155, 404);
            this.tbStepName.Name = "tbStepName";
            this.tbStepName.Size = new System.Drawing.Size(254, 31);
            this.tbStepName.TabIndex = 5;
            // 
            // cbExistingStep
            // 
            this.cbExistingStep.AutoSize = true;
            this.cbExistingStep.Location = new System.Drawing.Point(415, 406);
            this.cbExistingStep.Name = "cbExistingStep";
            this.cbExistingStep.Size = new System.Drawing.Size(156, 29);
            this.cbExistingStep.TabIndex = 6;
            this.cbExistingStep.Text = "Existing Step ? ";
            this.cbExistingStep.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sequence";
            // 
            // nudSequence
            // 
            this.nudSequence.Location = new System.Drawing.Point(155, 456);
            this.nudSequence.Name = "nudSequence";
            this.nudSequence.Size = new System.Drawing.Size(254, 31);
            this.nudSequence.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 692);
            this.Controls.Add(this.nudSequence);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbExistingStep);
            this.Controls.Add(this.tbStepName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbJobID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbQueries);
            this.Controls.Add(this.dgvQueries);
            this.Controls.Add(this.cbQueryTypes);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSequence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbQueryTypes;
        private System.Windows.Forms.DataGridView dgvQueries;
        private System.Windows.Forms.TextBox tbQueries;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbJobID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStepName;
        private System.Windows.Forms.CheckBox cbExistingStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSequence;
    }
}

