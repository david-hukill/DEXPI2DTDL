namespace DEXPI2DTDL {
    partial class DEXPI2DTDLForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnAuthenticate = new System.Windows.Forms.Button();
            this.lblDEXPIFile = new System.Windows.Forms.Label();
            this.txtDEXPIFile = new System.Windows.Forms.TextBox();
            this.btnBrowseDEXPIFile = new System.Windows.Forms.Button();
            this.btnLoadDEXPIFile = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageSchemaToModel = new System.Windows.Forms.TabPage();
            this.btnBrowseSchemaFile = new System.Windows.Forms.Button();
            this.btnLoadSchemaFile = new System.Windows.Forms.Button();
            this.txtSchemaFile = new System.Windows.Forms.TextBox();
            this.lblSchemaFile = new System.Windows.Forms.Label();
            this.tabPageImportExport = new System.Windows.Forms.TabPage();
            this.btnSelectAllEquipment = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.dataGridAssets = new System.Windows.Forms.DataGridView();
            this.tabPageAzure = new System.Windows.Forms.TabPage();
            this.tabControlMain.SuspendLayout();
            this.tabPageSchemaToModel.SuspendLayout();
            this.tabPageImportExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAssets)).BeginInit();
            this.tabPageAzure.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAuthenticate
            // 
            this.btnAuthenticate.Location = new System.Drawing.Point(1854, 491);
            this.btnAuthenticate.Name = "btnAuthenticate";
            this.btnAuthenticate.Size = new System.Drawing.Size(224, 58);
            this.btnAuthenticate.TabIndex = 0;
            this.btnAuthenticate.Text = "Authenticate";
            this.btnAuthenticate.UseVisualStyleBackColor = true;
            this.btnAuthenticate.Click += new System.EventHandler(this.btnAuthenticate_Click);
            // 
            // lblDEXPIFile
            // 
            this.lblDEXPIFile.AutoSize = true;
            this.lblDEXPIFile.Location = new System.Drawing.Point(27, 32);
            this.lblDEXPIFile.Name = "lblDEXPIFile";
            this.lblDEXPIFile.Size = new System.Drawing.Size(150, 41);
            this.lblDEXPIFile.TabIndex = 1;
            this.lblDEXPIFile.Text = "DEXPI File";
            // 
            // txtDEXPIFile
            // 
            this.txtDEXPIFile.Location = new System.Drawing.Point(196, 29);
            this.txtDEXPIFile.Name = "txtDEXPIFile";
            this.txtDEXPIFile.Size = new System.Drawing.Size(1460, 47);
            this.txtDEXPIFile.TabIndex = 2;
            this.txtDEXPIFile.TextChanged += new System.EventHandler(this.txtDEXPIFile_TextChanged);
            // 
            // btnBrowseDEXPIFile
            // 
            this.btnBrowseDEXPIFile.Location = new System.Drawing.Point(1683, 23);
            this.btnBrowseDEXPIFile.Name = "btnBrowseDEXPIFile";
            this.btnBrowseDEXPIFile.Size = new System.Drawing.Size(188, 58);
            this.btnBrowseDEXPIFile.TabIndex = 3;
            this.btnBrowseDEXPIFile.Text = "Browse...";
            this.btnBrowseDEXPIFile.UseVisualStyleBackColor = true;
            this.btnBrowseDEXPIFile.Click += new System.EventHandler(this.btnBrowseDEXPIFile_Click);
            // 
            // btnLoadDEXPIFile
            // 
            this.btnLoadDEXPIFile.Enabled = false;
            this.btnLoadDEXPIFile.Location = new System.Drawing.Point(2742, 23);
            this.btnLoadDEXPIFile.Name = "btnLoadDEXPIFile";
            this.btnLoadDEXPIFile.Size = new System.Drawing.Size(240, 58);
            this.btnLoadDEXPIFile.TabIndex = 4;
            this.btnLoadDEXPIFile.Text = "Load";
            this.btnLoadDEXPIFile.UseVisualStyleBackColor = true;
            this.btnLoadDEXPIFile.Click += new System.EventHandler(this.btnLoadDEXPIFile_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageSchemaToModel);
            this.tabControlMain.Controls.Add(this.tabPageImportExport);
            this.tabControlMain.Controls.Add(this.tabPageAzure);
            this.tabControlMain.Location = new System.Drawing.Point(29, 29);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(3029, 1914);
            this.tabControlMain.TabIndex = 5;
            // 
            // tabPageSchemaToModel
            // 
            this.tabPageSchemaToModel.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSchemaToModel.Controls.Add(this.btnBrowseSchemaFile);
            this.tabPageSchemaToModel.Controls.Add(this.btnLoadSchemaFile);
            this.tabPageSchemaToModel.Controls.Add(this.txtSchemaFile);
            this.tabPageSchemaToModel.Controls.Add(this.lblSchemaFile);
            this.tabPageSchemaToModel.Location = new System.Drawing.Point(10, 58);
            this.tabPageSchemaToModel.Name = "tabPageSchemaToModel";
            this.tabPageSchemaToModel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchemaToModel.Size = new System.Drawing.Size(3009, 1846);
            this.tabPageSchemaToModel.TabIndex = 0;
            this.tabPageSchemaToModel.Text = "DEXPI Schema to DTDL Model";
            // 
            // btnBrowseSchemaFile
            // 
            this.btnBrowseSchemaFile.Location = new System.Drawing.Point(1683, 23);
            this.btnBrowseSchemaFile.Name = "btnBrowseSchemaFile";
            this.btnBrowseSchemaFile.Size = new System.Drawing.Size(188, 58);
            this.btnBrowseSchemaFile.TabIndex = 3;
            this.btnBrowseSchemaFile.Text = "Browse...";
            this.btnBrowseSchemaFile.UseVisualStyleBackColor = true;
            this.btnBrowseSchemaFile.Click += new System.EventHandler(this.btnBrowseSchemaFile_Click);
            // 
            // btnLoadSchemaFile
            // 
            this.btnLoadSchemaFile.Enabled = false;
            this.btnLoadSchemaFile.Location = new System.Drawing.Point(1886, 23);
            this.btnLoadSchemaFile.Name = "btnLoadSchemaFile";
            this.btnLoadSchemaFile.Size = new System.Drawing.Size(188, 58);
            this.btnLoadSchemaFile.TabIndex = 2;
            this.btnLoadSchemaFile.Text = "Load";
            this.btnLoadSchemaFile.UseVisualStyleBackColor = true;
            this.btnLoadSchemaFile.Click += new System.EventHandler(this.btnLoadSchemaFile_Click);
            // 
            // txtSchemaFile
            // 
            this.txtSchemaFile.Location = new System.Drawing.Point(219, 29);
            this.txtSchemaFile.Name = "txtSchemaFile";
            this.txtSchemaFile.Size = new System.Drawing.Size(1440, 47);
            this.txtSchemaFile.TabIndex = 1;
            this.txtSchemaFile.TextChanged += new System.EventHandler(this.txtSchemaFile_TextChanged);
            // 
            // lblSchemaFile
            // 
            this.lblSchemaFile.AutoSize = true;
            this.lblSchemaFile.Location = new System.Drawing.Point(27, 32);
            this.lblSchemaFile.Name = "lblSchemaFile";
            this.lblSchemaFile.Size = new System.Drawing.Size(175, 41);
            this.lblSchemaFile.TabIndex = 0;
            this.lblSchemaFile.Text = "Schema File";
            // 
            // tabPageImportExport
            // 
            this.tabPageImportExport.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageImportExport.Controls.Add(this.btnSelectAllEquipment);
            this.tabPageImportExport.Controls.Add(this.btnExportToExcel);
            this.tabPageImportExport.Controls.Add(this.dataGridAssets);
            this.tabPageImportExport.Controls.Add(this.lblDEXPIFile);
            this.tabPageImportExport.Controls.Add(this.btnLoadDEXPIFile);
            this.tabPageImportExport.Controls.Add(this.txtDEXPIFile);
            this.tabPageImportExport.Controls.Add(this.btnBrowseDEXPIFile);
            this.tabPageImportExport.Location = new System.Drawing.Point(10, 58);
            this.tabPageImportExport.Name = "tabPageImportExport";
            this.tabPageImportExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImportExport.Size = new System.Drawing.Size(3009, 1846);
            this.tabPageImportExport.TabIndex = 1;
            this.tabPageImportExport.Text = "DEXPI Import/Export";
            // 
            // btnSelectAllEquipment
            // 
            this.btnSelectAllEquipment.Enabled = false;
            this.btnSelectAllEquipment.Location = new System.Drawing.Point(2742, 185);
            this.btnSelectAllEquipment.Name = "btnSelectAllEquipment";
            this.btnSelectAllEquipment.Size = new System.Drawing.Size(240, 58);
            this.btnSelectAllEquipment.TabIndex = 7;
            this.btnSelectAllEquipment.Text = "Select All";
            this.btnSelectAllEquipment.UseVisualStyleBackColor = true;
            this.btnSelectAllEquipment.Click += new System.EventHandler(this.btnSelectAllEquipment_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Enabled = false;
            this.btnExportToExcel.Location = new System.Drawing.Point(2742, 103);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(240, 58);
            this.btnExportToExcel.TabIndex = 6;
            this.btnExportToExcel.Text = "Export to Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // dataGridAssets
            // 
            this.dataGridAssets.AllowUserToAddRows = false;
            this.dataGridAssets.AllowUserToDeleteRows = false;
            this.dataGridAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAssets.Location = new System.Drawing.Point(27, 103);
            this.dataGridAssets.Name = "dataGridAssets";
            this.dataGridAssets.RowHeadersVisible = false;
            this.dataGridAssets.RowHeadersWidth = 102;
            this.dataGridAssets.RowTemplate.Height = 49;
            this.dataGridAssets.Size = new System.Drawing.Size(2475, 1705);
            this.dataGridAssets.StandardTab = true;
            this.dataGridAssets.TabIndex = 5;
            this.dataGridAssets.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAssets_CellValueChanged);
            // 
            // tabPageAzure
            // 
            this.tabPageAzure.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAzure.Controls.Add(this.btnAuthenticate);
            this.tabPageAzure.Location = new System.Drawing.Point(10, 58);
            this.tabPageAzure.Name = "tabPageAzure";
            this.tabPageAzure.Size = new System.Drawing.Size(3009, 1846);
            this.tabPageAzure.TabIndex = 2;
            this.tabPageAzure.Text = "Azure";
            // 
            // DEXPI_To_DTDL_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3336, 2020);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DEXPI_To_DTDL_Form";
            this.Text = "DEXPI To DTDL";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageSchemaToModel.ResumeLayout(false);
            this.tabPageSchemaToModel.PerformLayout();
            this.tabPageImportExport.ResumeLayout(false);
            this.tabPageImportExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAssets)).EndInit();
            this.tabPageAzure.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAuthenticate;
        private System.Windows.Forms.Label lblDEXPIFile;
        private System.Windows.Forms.TextBox txtDEXPIFile;
        private System.Windows.Forms.Button btnBrowseDEXPIFile;
        private System.Windows.Forms.Button btnLoadDEXPIFile;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageSchemaToModel;
        private System.Windows.Forms.TabPage tabPageImportExport;
        private System.Windows.Forms.TabPage tabPageAzure;
        private System.Windows.Forms.Label lblSchemaFile;
        private System.Windows.Forms.Button btnBrowseSchemaFile;
        private System.Windows.Forms.Button btnLoadSchemaFile;
        private System.Windows.Forms.TextBox txtSchemaFile;
        private System.Windows.Forms.DataGridView dataGridAssets;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button btnSelectAllEquipment;
    }
}
