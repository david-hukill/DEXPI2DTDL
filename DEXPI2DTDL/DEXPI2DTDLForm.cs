using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;
using DEXPI;
using DTDL;
using DTDL.Extensions;
using Microsoft.Office.Interop;
using System.Text.Json;

namespace DEXPI2DTDL {
    public partial class DEXPI2DTDLForm : Form {
        #region Construction
        static DEXPI2DTDLForm() {
            DEXPI2DTDLForm.excelColumns.Add(DEXPI2DTDLForm.excelColumnModelID, 1);
            DEXPI2DTDLForm.excelColumns.Add(DEXPI2DTDLForm.excelColumnID, 2);
            DEXPI2DTDLForm.excelColumns.Add(DEXPI2DTDLForm.excelColumnRelationshipFrom, 3);
            DEXPI2DTDLForm.excelColumns.Add(DEXPI2DTDLForm.excelColumnRelationshipName, 4);
            DEXPI2DTDLForm.excelColumns.Add(DEXPI2DTDLForm.excelColumnInitData, 5);
        }

        public DEXPI2DTDLForm() {
            // Required initialization of Form.
            this.InitializeComponent();
            this.dataGridAssets.Columns.Clear();
            this.dataGridAssets.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Export", AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 125, HeaderText = "Export", FlatStyle = FlatStyle.Standard });
            this.dataGridAssets.Columns.Add(new DataGridViewTextBoxColumn { Name = "Model ID", Width = 600 });
            this.dataGridAssets.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", Width = 250 });
            this.dataGridAssets.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tag", Width = 250 });
            this.dataGridAssets.Columns.Add(new DataGridViewTextBoxColumn { Name = "From", Width = 250 });
            this.dataGridAssets.Columns.Add(new DataGridViewTextBoxColumn { Name = "Relationship", Width = 500 });
            this.dataGridAssets.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", Width = 500 });
        }
        #endregion

        #region Event Handlers
        private void txtSchemaFile_TextChanged(object sender, EventArgs e) {
            this.setUIState(true, System.Windows.Forms.Cursors.Default);

            return;
        }

        private void btnBrowseSchemaFile_Click(object sender, EventArgs e) {
            this.openFileDialog.Filter = DEXPI2DTDLForm.schemaFileTypesForDialogs;
            this.openFileDialog.FilterIndex = 0;
            if (this.openFileDialog.ShowDialog(this) == DialogResult.OK) {
                string schemaFilePath = this.openFileDialog.FileName;
                this.txtSchemaFile.Text = schemaFilePath;
                this.openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(schemaFilePath);
                this.btnLoadSchemaFile_Click(sender, e);
            }

            return;
        }

        private void btnLoadSchemaFile_Click(object sender, EventArgs e) {
            System.IO.StreamReader streamReader = null;
            try {
                // Set our UI state while processing.
                this.setUIState(false, System.Windows.Forms.Cursors.WaitCursor);
            }
            catch (System.Exception x) {
                System.Windows.Forms.Clipboard.SetText(x.Message);
                this.showMessageBox(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                // Cleanup.
                if (streamReader != null) {
                    streamReader.Dispose();
                }

                // Reset our UI state.
                this.setUIState(true, System.Windows.Forms.Cursors.Default);
            }

            return;
        }

        private void txtDEXPIFile_TextChanged(object sender, EventArgs e) {
            this.setUIState(true, System.Windows.Forms.Cursors.Default);

            return;
        }

        private void btnBrowseDEXPIFile_Click(object sender, EventArgs e) {
            this.openFileDialog.Filter = DEXPI2DTDLForm.dexpiFileTypesForDialogs;
            this.openFileDialog.FilterIndex = 0;
            if (this.openFileDialog.ShowDialog(this) == DialogResult.OK) {
                string dexpiFilePath = this.openFileDialog.FileName;
                this.txtDEXPIFile.Text = dexpiFilePath;
                this.openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(dexpiFilePath);
                this.btnLoadDEXPIFile_Click(sender, e);
            }

            return;
        }

        private void btnLoadDEXPIFile_Click(object sender, EventArgs e) {
            System.IO.StreamReader streamReader = null;
            PlantModel plantModel = null;
            IDictionary<string, EquipmentInstance> masterEquipmentList = new Dictionary<string, EquipmentInstance>();
            IDictionary<string, PipingSegmentInstance> masterPipingSegmentList = new Dictionary<string, PipingSegmentInstance>();
            try {
                // Set our UI state while processing.
                this.setUIState(false, System.Windows.Forms.Cursors.WaitCursor);

                // Clear any previously imported items.
                this.clearEquipmentDataGrid();

                // Initialize stream to read from the file.
                streamReader = new System.IO.StreamReader(this.txtDEXPIFile.Text.Trim());

                // Deserialize into PlantModel instance.
                plantModel = (PlantModel)DEXPI2DTDLForm.plantModelXMLSerializer.Deserialize(streamReader);

                // Iterate through any Equipment instances, and store them by ID.
                if (plantModel.Equipment?.Any() == true) {
                    foreach (Equipment equipment in plantModel.Equipment) {
                        string key = equipment.ID;
                        var equipmentInstance = new EquipmentInstance(equipment);
                        if (!masterEquipmentList.ContainsKey(key)) {
                            masterEquipmentList.Add(key, equipmentInstance);
                        }
                        else if (this.showMessageBox(string.Format("Equipment list already contains key: {0} for TagName: {1}.{2}Continue?", key, equipmentInstance.TagName, System.Environment.NewLine), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                            break;
                        }
                    }
                }

                // TODO: check for duplicate equipment tag names.

                // Iterate through any PipingNetworkSystem instances, get the PipingNetworkSegment instances, and store them by ID.
                if (plantModel.PipingNetworkSystem?.Any() == true) {
                    var currentPipingSegmentList = new Dictionary<string, PipingSegmentInstance>();
                    foreach (PipingNetworkSystem pipingNetworkSystem in plantModel.PipingNetworkSystem) {
                        currentPipingSegmentList.Clear();
                        if (pipingNetworkSystem.PipingNetworkSegment?.Any() == true) {
                            foreach (PipingNetworkSegment pipingSegment in pipingNetworkSystem.PipingNetworkSegment) {
                                string key = pipingSegment.ID;
                                var pipingSegmentInstance = new PipingSegmentInstance(pipingSegment);
                                if (!masterPipingSegmentList.ContainsKey(key)) {
                                    masterPipingSegmentList.Add(key, pipingSegmentInstance);
                                    currentPipingSegmentList.Add(key, pipingSegmentInstance);

                                    // Get any piping components associated with this segment.
                                    foreach (DEXPI.Component component in pipingSegment.Items) {
                                        if (component is PipingComponent) {
                                            var pipingComponent = component as PipingComponent;
                                            key = pipingComponent.ID;
                                            var pipingComponentInstance = new PipingComponentInstance(pipingComponent, pipingSegmentInstance);
                                            if (!pipingSegmentInstance.PipingComponentInstances.ContainsKey(key)) {
                                                pipingSegmentInstance.PipingComponentInstances.Add(key, pipingComponentInstance);
                                            }
                                            else if (this.showMessageBox(string.Format("Piping Component list already contains key: {0} for TagName.{2}Continue?: {1}", key, pipingComponentInstance.TagName, System.Environment.NewLine), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (this.showMessageBox(string.Format("Piping Segment list already contains key: {0} for TagName.{2}Continue?: {1}", key, pipingSegmentInstance.TagName, System.Environment.NewLine), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                                    break;
                                }
                            }

                            // Now that we're finished with this network segment, resolve the relationships.
                            IList<string> errors = null;
                            if (!Relationship.ResolveRelationships(masterEquipmentList, currentPipingSegmentList, out errors)) {
                                var sb = new StringBuilder();
                                foreach (string error in errors) {
                                    sb.AppendLine(error);
                                }
                                //#if !DEBUG
                                if (this.showMessageBox(string.Format("Unresolved relationships discovered:{0}{1}Continue?{0}", System.Environment.NewLine, sb.ToString()), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No) {
                                    break;
                                }
                                //#endif
                            }
                        }
                    }
                }

                // TODO: check for duplicate piping network segment tag names.

                // Finally, add all items to the display list.
                foreach (string equipmentID in masterEquipmentList.Keys) {
                    this.addDataGridViewRow(this.createDataGridViewRow(masterEquipmentList[equipmentID]));
                }
                foreach (string pipingSegmentId in masterPipingSegmentList.Keys) {
                    PipingSegmentInstance pipingSegmentInstance = masterPipingSegmentList[pipingSegmentId];
                    this.addDataGridViewRow(this.createDataGridViewRow(pipingSegmentInstance));
                    foreach (string pipingComponentInstanceID in pipingSegmentInstance.PipingComponentInstances.Keys) {
                        PipingComponentInstance pipingComponentInstance = pipingSegmentInstance.PipingComponentInstances[pipingComponentInstanceID];
                        this.addDataGridViewRow(this.createDataGridViewRow(pipingComponentInstance));
                    }
                }
            }
            catch (System.Exception x) {
                System.Windows.Forms.Clipboard.SetText(x.Message);
                this.showMessageBox(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                // Cleanup.
                if (streamReader != null) {
                    streamReader.Dispose();
                }

                // Reset our UI state.
                this.setUIState(true, System.Windows.Forms.Cursors.Default);
            }

            return;
        }

        private void dataGridAssets_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            this.setUIState(true, System.Windows.Forms.Cursors.Default);

            return;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e) {
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            System.IO.StreamWriter streamWriter = null;
            try {
                // Set our UI state while processing.
                this.setUIState(false, System.Windows.Forms.Cursors.WaitCursor);

                // Prompt for file to save.
                //this.saveFileDialog.Filter = DEXPI2DTDLForm.csvFileTypesForDialogs;
                this.saveFileDialog.Filter = DEXPI2DTDLForm.excelFileTypesForDialogs;
                if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK) {
                    string fileName = this.saveFileDialog.FileName;
                    if (System.IO.File.Exists(fileName)) {
                        System.IO.File.Delete(fileName);
                    }

                    // Method to write to an Excel cell.
                    System.Action<Microsoft.Office.Interop.Excel._Worksheet, int, int, string> writeCell = (worksheet, rowIndex, cellIndex, cellValue) => {
                        worksheet.Cells[rowIndex, cellIndex].Value = cellValue;
                        //System.Threading.Thread.Sleep(50);

                        return;
                    };

                    // Open Excel Application.
                    excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.DefaultSaveFormat = Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault;
                    excel.Visible = false;
                    var workbooks = excel.Workbooks;
                    workbook = workbooks.Add();
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1];
                    int excelRowIndex = 1;

                    // Add table headers.
                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnModelID], DEXPI2DTDLForm.excelColumnModelID);
                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnID], DEXPI2DTDLForm.excelColumnID);
                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnRelationshipFrom], DEXPI2DTDLForm.excelColumnRelationshipFrom);
                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnRelationshipName], DEXPI2DTDLForm.excelColumnRelationshipName);
                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnInitData], DEXPI2DTDLForm.excelColumnInitData);

                    // Increment our excel index.
                    excelRowIndex++;

                    // Write each selected Equipment row.
                    for (int dataGridViewRowIndex = 0; dataGridViewRowIndex < this.dataGridAssets.Rows.Count; dataGridViewRowIndex++) {
                        var dataGridViewRow = this.dataGridAssets.Rows[dataGridViewRowIndex];
                        DataGridViewCheckBoxCell dataGridViewCheckBoxCell = dataGridViewRow.Cells[0] as DataGridViewCheckBoxCell;
                        if ((dataGridViewCheckBoxCell.Value != null) && ((bool)dataGridViewCheckBoxCell.Value)) {
                            if (dataGridViewRow.Tag is EquipmentInstance) {
                                var equipmentInstance = dataGridViewRow.Tag as EquipmentInstance;
                                writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnModelID], equipmentInstance.ModelID);
                                writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnID], equipmentInstance.ID);
                                if (equipmentInstance.Relationships.Count > 0) {
                                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnRelationshipFrom], equipmentInstance.Relationships[0].RelationshipFrom.ID);
                                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnRelationshipName], equipmentInstance.Relationships[0].RelationshipName);
                                }
                                string jsonAttributes = JsonSerializer.Serialize(equipmentInstance.Attributes);
                                if (!string.IsNullOrEmpty(jsonAttributes)) {
                                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnInitData], jsonAttributes);
                                }
                                if (equipmentInstance.Relationships.Count > 1) {
                                    for (int relationshipIndex = 1; relationshipIndex < equipmentInstance.Relationships.Count; relationshipIndex++) {
                                        // Increment our excel index.
                                        excelRowIndex++;

                                        Relationship relationship = equipmentInstance.Relationships[relationshipIndex];
                                        writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnID], equipmentInstance.ID);
                                        writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnRelationshipFrom], relationship.RelationshipFrom.ID);
                                        writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnRelationshipName], relationship.RelationshipName);
                                    }
                                }

                                // Increment our excel index.
                                excelRowIndex++;
                            }
                            else if (dataGridViewRow.Tag is PipingSegmentInstance) {
                                var pipingSegmentInstance = dataGridViewRow.Tag as PipingSegmentInstance;
                                writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnModelID], pipingSegmentInstance.ModelID);
                                writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnID], pipingSegmentInstance.ID);
                                if (pipingSegmentInstance.Relationship != null) {
                                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnRelationshipFrom], pipingSegmentInstance.Relationship.RelationshipFrom.ID);
                                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnRelationshipName], pipingSegmentInstance.Relationship.RelationshipName);
                                }
                                string jsonAttributes = JsonSerializer.Serialize(pipingSegmentInstance.Attributes);
                                if (!string.IsNullOrEmpty(jsonAttributes)) {
                                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnInitData], jsonAttributes);
                                }

                                // Increment our excel index.
                                excelRowIndex++;
                            }
                            else if (dataGridViewRow.Tag is PipingComponentInstance) {
                                var pipingComponentInstance = dataGridViewRow.Tag as PipingComponentInstance;
                                writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnModelID], pipingComponentInstance.ModelID);
                                writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnID], pipingComponentInstance.ID);
                                if (pipingComponentInstance.Relationship != null) {
                                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnRelationshipFrom], pipingComponentInstance.Relationship.RelationshipFrom.ID);
                                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnRelationshipName], pipingComponentInstance.Relationship.RelationshipName);
                                }
                                string jsonAttributes = JsonSerializer.Serialize(pipingComponentInstance.Attributes);
                                if (!string.IsNullOrEmpty(jsonAttributes)) {
                                    writeCell(worksheet, excelRowIndex, DEXPI2DTDLForm.excelColumns[DEXPI2DTDLForm.excelColumnInitData], jsonAttributes);
                                }

                                // Increment our excel index.
                                excelRowIndex++;
                            }
                        }
                    }

                    // Save the file.
                    workbook.SaveAs2(fileName);

                    /*
                    // Open file to write.
                    streamWriter = new System.IO.StreamWriter(fileName);

                    // Method to write a row to the file.
                    System.Action<string> writeRowToFile = (rowToWrite) => {
                        streamWriter.WriteLine(rowToWrite);
                        streamWriter.Flush();

                        return;
                    };

                    // Write header row.
                    writeRowToFile(string.Format("ModelID{0}ID (must be unique){0}Relationship (From){0}Relationship Name{0}Init Data", DEXPI2DTDLForm.csvDelimeter));

                    // Write each selected Equipment row.
                    foreach (DataGridViewRow dataGridViewRow in this.dataGridEquipment.Rows) {
                        DataGridViewCheckBoxCell dataGridViewCheckBoxCell = dataGridViewRow.Cells[0] as DataGridViewCheckBoxCell;
                        if ((dataGridViewCheckBoxCell.Value != null) && ((bool)dataGridViewCheckBoxCell.Value)) {
                            var equipmentInstance = dataGridViewRow.Tag as EquipmentInstance;
                            var pipingSegmentInstance = dataGridViewRow.Tag as PipingSegmentInstance;
                            if (equipmentInstance != null) {
                                string jsonAttributes = JsonSerializer.Serialize(equipmentInstance.EquipmentAttributes);
                                writeRowToFile(string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}"
                                                            ,DEXPI2DTDLForm.csvDelimeter
                                                            ,equipmentInstance.ModelID
                                                            ,equipmentInstance.ID
                                                            ,(equipmentInstance.Relationships.Count > 0) ? equipmentInstance.Relationships[0].RelationshipFrom : string.Empty
                                                            ,(equipmentInstance.Relationships.Count > 0) ? equipmentInstance.Relationships[0].RelationshipName : string.Empty
                                                            ,jsonAttributes));
                                if (equipmentInstance.Relationships.Count > 1) {
                                    for (int index = 1; index < equipmentInstance.Relationships.Count; index++) {
                                        Relationship relationship = equipmentInstance.Relationships[index];
                                        writeRowToFile(string.Format("{0}{1}{0}{2}{0}{3}{0}"
                                                                    ,DEXPI2DTDLForm.csvDelimeter
                                                                    ,equipmentInstance.ID
                                                                    ,relationship.RelationshipFrom
                                                                    ,relationship.RelationshipName));
                                    }
                                }
                            }
                            else if (pipingSegmentInstance != null) {
                                string jsonAttributes = JsonSerializer.Serialize(pipingSegmentInstance.PipingSegmentAttributes);
                                writeRowToFile(string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}"
                                                            ,DEXPI2DTDLForm.csvDelimeter
                                                            ,pipingSegmentInstance.ModelID
                                                            ,pipingSegmentInstance.ID
                                                            ,(pipingSegmentInstance.Relationship != null) ? pipingSegmentInstance.Relationship.RelationshipFrom : string.Empty
                                                            ,(pipingSegmentInstance.Relationship != null) ? pipingSegmentInstance.Relationship.RelationshipName : string.Empty
                                                            ,jsonAttributes));
                            }
                        }
                    }
                    */
                    // Inform the user that the export completed.
                    this.showMessageBox(string.Format("Export successful to:{0}{1}", System.Environment.NewLine, fileName), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Exception x) {
                System.Windows.Forms.Clipboard.SetText(x.Message);
                this.showMessageBox(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                // Cleanup.
                if (workbook != null) {
                    workbook.Close(false);
                }
                if (excel != null) {
                    excel.Quit();
                }
                if (streamWriter != null) {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }

                // Reset our UI state.
                this.setUIState(true, System.Windows.Forms.Cursors.Default);
            }

            return;
        }

        private void btnSelectAllEquipment_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow dataGridViewRow in this.dataGridAssets.Rows) {
                DataGridViewCheckBoxCell dataGridViewCheckBoxCell = dataGridViewRow.Cells[0] as DataGridViewCheckBoxCell;
                dataGridViewCheckBoxCell.Value = true;
            }

            return;
        }

        private void btnAuthenticate_Click(object sender, EventArgs e) {
            var client = new SecretClient(
                new Uri("https://myvault.vault.azure.net/"),
                new InteractiveBrowserCredential()
            );

            return;
        }
        #endregion

        #region Private Members
        private static readonly System.Xml.Serialization.XmlSerializer plantModelXMLSerializer = new System.Xml.Serialization.XmlSerializer(typeof(PlantModel));
        private static readonly Dictionary<string, int> excelColumns = new Dictionary<string, int>();
        private const string excelColumnModelID = "ModelID";
        private const string excelColumnID = "ID (must be unique)";
        private const string excelColumnRelationshipFrom = "Relationship (From)";
        private const string excelColumnRelationshipName = "Relationship Name";
        private const string excelColumnInitData = "Init Data";
        private const string csvDelimeter = ",";
        private const string dexpiFileTypesForDialogs = "DEXPI Files (*.xml)|*.xml|All Files (*.*)|*.*";
        private const string schemaFileTypesForDialogs = "XSD Files (*.xsd)|*.xsd|All Files (*.*)|*.*";
        private const string csvFileTypesForDialogs = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
        private const string excelFileTypesForDialogs = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
        private readonly OpenFileDialog openFileDialog = new OpenFileDialog();
        private readonly SaveFileDialog saveFileDialog = new SaveFileDialog { FilterIndex = 0, OverwritePrompt = true };
        #endregion

        #region Private Methods
        private void setUIState(bool enabled, System.Windows.Forms.Cursor cursor) {
            if (this.InvokeRequired) {
                this.Invoke(new System.EventHandler(delegate { this.setUIState(enabled, cursor); }));
            }
            else {
                this.Cursor = cursor;
                if (enabled) {
                    this.lblSchemaFile.Enabled =
                        this.txtSchemaFile.Enabled =
                        this.btnBrowseSchemaFile.Enabled =
                        this.lblDEXPIFile.Enabled =
                        this.txtDEXPIFile.Enabled =
                        this.btnBrowseDEXPIFile.Enabled =
                        this.btnAuthenticate.Enabled = true;
                    this.btnLoadSchemaFile.Enabled = System.IO.File.Exists(this.txtSchemaFile.Text.Trim());
                    this.btnLoadDEXPIFile.Enabled = System.IO.File.Exists(this.txtDEXPIFile.Text.Trim());
                    this.btnExportToExcel.Enabled = this.isAnyEquipmentChecked();
                    this.btnSelectAllEquipment.Enabled = this.dataGridAssets.Rows.Count > 0;
                }
                else {
                    this.lblSchemaFile.Enabled =
                        this.txtSchemaFile.Enabled =
                        this.btnBrowseSchemaFile.Enabled =
                        this.btnLoadSchemaFile.Enabled =
                        this.lblDEXPIFile.Enabled =
                        this.txtDEXPIFile.Enabled =
                        this.btnBrowseDEXPIFile.Enabled =
                        this.btnLoadDEXPIFile.Enabled =
                        this.btnExportToExcel.Enabled =
                        this.btnSelectAllEquipment.Enabled =
                        this.btnAuthenticate.Enabled = false;
                }
            }
        }

        private DialogResult showMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icons) {
            DialogResult dialogResult = System.Windows.Forms.DialogResult.None;
            if (this.InvokeRequired) {
                this.Invoke(new System.EventHandler(delegate { dialogResult = this.showMessageBox(message, title, buttons, icons); }));
            }
            else {
                dialogResult = MessageBox.Show(this, message, title, buttons, icons);
            }

            return dialogResult;
        }

        private void addDataGridViewRow(DataGridViewRow dataGridViewRow) {
            if (this.InvokeRequired) {
                this.Invoke(new System.EventHandler(delegate { this.addDataGridViewRow(dataGridViewRow); }));
            }
            else {
                this.dataGridAssets.Rows.Add(dataGridViewRow);
            }

            return;
        }

        private DataGridViewRow createDataGridViewRow(EquipmentInstance equipmentInstance) {
            DataGridViewRow dataGridViewRow = new DataGridViewRow { Height = 44, Tag = equipmentInstance };
            dataGridViewRow.Cells.Add(new DataGridViewCheckBoxCell { FlatStyle = FlatStyle.Standard });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = equipmentInstance.ModelID });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = equipmentInstance.ID });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = equipmentInstance.TagName });
            if ((equipmentInstance.Relationships != null) && (equipmentInstance.Relationships.Count > 0)) {
                var relationshipIDs = new StringBuilder();
                var relationshipNames = new StringBuilder();
                bool firstRelationship = true;
                foreach (Relationship relationship in equipmentInstance.Relationships) {
                    if (!firstRelationship) {
                        relationshipIDs.Append(", ");
                        relationshipNames.Append(", ");
                    }
                    else {
                        firstRelationship = false;
                    }
                    relationshipIDs.Append(relationship.RelationshipFrom.ID);
                    relationshipNames.Append(relationship.RelationshipName);
                }
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = relationshipIDs.ToString() });
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = relationshipNames.ToString() });
            }
            else {
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = string.Empty });
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = string.Empty });
            }
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = equipmentInstance.Attributes.Description ?? string.Empty });

            return dataGridViewRow;
        }

        private DataGridViewRow createDataGridViewRow(PipingSegmentInstance pipingSegmentInstance) {
            DataGridViewRow dataGridViewRow = new DataGridViewRow { Height = 44, Tag = pipingSegmentInstance };
            dataGridViewRow.Cells.Add(new DataGridViewCheckBoxCell { FlatStyle = FlatStyle.Standard });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = pipingSegmentInstance.ModelID });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = pipingSegmentInstance.ID });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = pipingSegmentInstance.TagName });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = (pipingSegmentInstance.Relationship != null) ? pipingSegmentInstance.Relationship.RelationshipFrom.ID : string.Empty });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = (pipingSegmentInstance.Relationship != null) ? pipingSegmentInstance.Relationship.RelationshipName : string.Empty });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = pipingSegmentInstance.Attributes.Description ?? string.Empty });

            return dataGridViewRow;
        }

        private DataGridViewRow createDataGridViewRow(PipingComponentInstance pipingComponentInstance) {
            DataGridViewRow dataGridViewRow = new DataGridViewRow { Height = 44, Tag = pipingComponentInstance };
            dataGridViewRow.Cells.Add(new DataGridViewCheckBoxCell { FlatStyle = FlatStyle.Standard });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = pipingComponentInstance.ModelID });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = pipingComponentInstance.ID });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = pipingComponentInstance.TagName });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = (pipingComponentInstance.Relationship != null) ? pipingComponentInstance.Relationship.RelationshipFrom.ID : string.Empty });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = (pipingComponentInstance.Relationship != null) ? pipingComponentInstance.Relationship.RelationshipName : string.Empty });
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = pipingComponentInstance.Attributes.Description ?? string.Empty });

            return dataGridViewRow;
        }

        private void clearEquipmentDataGrid() {
            if (this.InvokeRequired) {
                this.Invoke(new System.EventHandler(delegate { this.clearEquipmentDataGrid(); }));
            }
            else {
                this.dataGridAssets.Rows.Clear();
            }

            return;
        }

        private bool isAnyEquipmentChecked() {
            bool result = false;
            if (this.InvokeRequired) {
                this.Invoke(new System.EventHandler(delegate { result = this.isAnyEquipmentChecked(); }));
            }
            else {
                foreach (DataGridViewRow dataGridViewRow in this.dataGridAssets.Rows) {
                    DataGridViewCheckBoxCell dataGridViewCheckBoxCell = dataGridViewRow.Cells[0] as DataGridViewCheckBoxCell;
                    if ((dataGridViewCheckBoxCell.Value != null) && ((bool)dataGridViewCheckBoxCell.Value)) {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        #endregion
    }
}