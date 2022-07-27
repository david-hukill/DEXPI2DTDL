using System;
using DEXPI;
using DTDL.Extensions;

namespace DTDL {
    public sealed class EquipmentAttributes {
        #region Construction
        public EquipmentAttributes(EquipmentInstance equipmentInstance) {
            if (equipmentInstance == null) {
                throw new ArgumentNullException("equipmentInstance");
            }
            else {
                this.EquipmentInstance = equipmentInstance;
                this.ID = this.EquipmentInstance.ID;
                string attributeValue = null;
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Tag", out attributeValue)) {
                    this.Tag = attributeValue;
                }
                else {
                    this.Tag = string.Empty;
                }
                if ((this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Description", out attributeValue)) ||
                    (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("EquipmentDescriptionAssignmentClass", out attributeValue))) {
                    this.Description = attributeValue;
                }
                else {
                    this.Description = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Manufacturer", out attributeValue)) {
                    this.Manufacturer = attributeValue;
                }
                else {
                    this.Manufacturer = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("ModelNumber", out attributeValue)) {
                    this.ModelNumber = attributeValue;
                }
                else {
                    this.ModelNumber = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Comment", out attributeValue)) {
                    this.Comment = attributeValue;
                }
                else {
                    this.Comment = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("FlagValue", out attributeValue)) {
                    int flagValue;
                    if (int.TryParse(attributeValue, out flagValue)) {
                        this.FlagValue = flagValue;
                    }
                }
                else {
                    this.FlagValue = 0;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("AcquisitionProperties", out attributeValue)) {
                    this.AcquisitionProperties = attributeValue;
                }
                else {
                    this.AcquisitionProperties = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Status", out attributeValue)) {
                    this.Status = attributeValue;
                }
                else {
                    this.Status = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("ParamOnLine", out attributeValue)) {
                    double paramOnLine;
                    if (double.TryParse(attributeValue, out paramOnLine)) {
                        this.ParamOnLine = paramOnLine;
                    }
                }
                else {
                    this.ParamOnLine = 0.0;
                }
                this.ComponentName = this.EquipmentInstance.Equipment.ComponentName;
                this.ComponentClass = this.EquipmentInstance.Equipment.ComponentClass;
                this.ComponentClassURI = this.EquipmentInstance.Equipment.ComponentClassURI;
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("ClassName", out attributeValue)) {
                    this.ClassName = attributeValue;
                }
                else {
                    this.ClassName = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Supplier", out attributeValue)) {
                    this.Supplier = attributeValue;
                }
                else {
                    this.Supplier = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Type", out attributeValue)) {
                    this.Type = attributeValue;
                }
                else {
                    this.Type = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("EquipmentSpec", out attributeValue)) {
                    this.EquipmentSpec = attributeValue;
                }
                else {
                    this.EquipmentSpec = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Weight", out attributeValue)) {
                    this.Weight = attributeValue;
                }
                else {
                    this.Weight = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("MaterialOfConstruction", out attributeValue)) {
                    this.MaterialOfConstruction = attributeValue;
                }
                else {
                    this.MaterialOfConstruction = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Number", out attributeValue)) {
                    this.Number = attributeValue;
                }
                else {
                    this.Number = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Area", out attributeValue)) {
                    this.Area = attributeValue;
                }
                else {
                    this.Area = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Insulation", out attributeValue)) {
                    this.Insulation = attributeValue;
                }
                else {
                    this.Insulation = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("InsulationType", out attributeValue)) {
                    this.InsulationType = attributeValue;
                }
                else {
                    this.InsulationType = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Diameter", out attributeValue)) {
                    this.Diameter = attributeValue;
                }
                else {
                    this.Diameter = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Capacity", out attributeValue)) {
                    this.Capacity = attributeValue;
                }
                else {
                    this.Capacity = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("DesignPressure", out attributeValue)) {
                    this.DesignPressure = attributeValue;
                }
                else {
                    this.DesignPressure = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("DesignTemperature", out attributeValue)) {
                    this.DesignTemperature = attributeValue;
                }
                else {
                    this.DesignTemperature = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Trim", out attributeValue)) {
                    this.Trim = attributeValue;
                }
                else {
                    this.Trim = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("InsulationType", out attributeValue)) {
                    this.InsulationType = attributeValue;
                }
                else {
                    this.InsulationType = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Insulation", out attributeValue)) {
                    this.Insulation = attributeValue;
                }
                else {
                    this.Insulation = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("Width", out attributeValue)) {
                    this.Width = attributeValue;
                }
                else {
                    this.Width = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("OperatingPressure", out attributeValue)) {
                    this.OperatingPressure = attributeValue;
                }
                else {
                    this.OperatingPressure = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("OperatingTemperature", out attributeValue)) {
                    this.OperatingTemperature = attributeValue;
                }
                else {
                    this.OperatingTemperature = string.Empty;
                }
                if (this.EquipmentInstance.Equipment.GenericAttributes.GetAttributeValue("NumberOfTrays", out attributeValue)) {
                    int numberOfTrays;
                    if (int.TryParse(attributeValue, out numberOfTrays)) {
                        this.NumberOfTrays = numberOfTrays;
                    }
                }
                else {
                    this.NumberOfTrays = 0;
                }
            }
        }

        private EquipmentAttributes() { }
        #endregion

        #region Public Properties
        [System.Text.Json.Serialization.JsonIgnore]
        public EquipmentInstance EquipmentInstance { get; private set; }
        public string ID { get; private set; }
        public string Tag { get; private set; }
        public string Description { get; private set; }
        public string Manufacturer { get; private set; }
        public string ModelNumber { get; private set; }
        public string Comment { get; private set; }
        public int FlagValue { get; private set; }
        public string AcquisitionProperties { get; private set; }
        public string Status { get; private set; }
        public double ParamOnLine { get; private set; }
        public string ComponentName { get; private set; }
        public string ComponentClass { get; private set; }
        public string ComponentClassURI { get; private set; }
        public string ClassName { get; private set; }
        public string Supplier { get; private set; }
        public string Type { get; private set; }
        public string EquipmentSpec { get; private set; }
        public string Weight { get; private set; }
        public string MaterialOfConstruction { get; private set; }
        public string Number { get; private set; }
        public string Area { get; private set; }
        public string Diameter { get; private set; }
        public string Capacity { get; private set; }
        public string DesignPressure { get; private set; }
        public string DesignTemperature { get; private set; }
        public string Trim { get; private set; }
        public string InsulationType { get; private set; }
        public string Insulation { get; private set; }
        public string Width { get; private set; }
        public string OperatingPressure { get; private set; }
        public string OperatingTemperature { get; private set; }
        public int NumberOfTrays { get; private set; }
        #endregion
    }
}
