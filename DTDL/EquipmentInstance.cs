using System;
using DEXPI;
using DTDL.Extensions;

namespace DTDL {
    public sealed class EquipmentInstance : DTDLInstanceBase {
        #region Construction
        public EquipmentInstance(Equipment equipment) : base("dtmi:autodesk:dexpi:Equipment;1") {
            if (equipment == null) {
                throw new ArgumentNullException("equipment");
            }
            else {
                this.Equipment = equipment;
                this.ID = this.Equipment.ID;
                this.Attributes.ID = this.ID;
                this.Relationships = new System.Collections.Generic.List<Relationship>();
                string attributeValue = null;
                if ((this.Equipment.GenericAttributes.GetAttributeValue("Tag", out attributeValue)) ||
                    (this.Equipment.GenericAttributes.GetAttributeValue("TagNameAssignmentClass", out attributeValue))) {
                    this.TagName = attributeValue;
                }
                else {
                    this.TagName = string.Empty;
                }
                this.Attributes.Tag = this.TagName;
                if ((this.Equipment.GenericAttributes.GetAttributeValue("Description", out attributeValue)) ||
                    (this.Equipment.GenericAttributes.GetAttributeValue("EquipmentDescriptionAssignmentClass", out attributeValue))) {
                    this.Attributes.Description = attributeValue;
                }
                else {
                    this.Attributes.Description = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Manufacturer", out attributeValue)) {
                    this.Attributes.Manufacturer = attributeValue;
                }
                else {
                    this.Attributes.Manufacturer = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("ModelNumber", out attributeValue)) {
                    this.Attributes.ModelNumber = attributeValue;
                }
                else {
                    this.Attributes.ModelNumber = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Comment", out attributeValue)) {
                    this.Attributes.Comment = attributeValue;
                }
                else {
                    this.Attributes.Comment = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("FlagValue", out attributeValue)) {
                    int flagValue;
                    if (int.TryParse(attributeValue, out flagValue)) {
                        this.Attributes.FlagValue = flagValue;
                    }
                }
                else {
                    this.Attributes.FlagValue = 0;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("AcquisitionProperties", out attributeValue)) {
                    this.Attributes.AcquisitionProperties = attributeValue;
                }
                else {
                    this.Attributes.AcquisitionProperties = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Status", out attributeValue)) {
                    this.Attributes.Status = attributeValue;
                }
                else {
                    this.Attributes.Status = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("ParamOnLine", out attributeValue)) {
                    double paramOnLine;
                    if (double.TryParse(attributeValue, out paramOnLine)) {
                        this.Attributes.ParamOnLine = paramOnLine;
                    }
                }
                else {
                    this.Attributes.ParamOnLine = 0.0;
                }
                this.Attributes.ComponentName = this.Equipment.ComponentName;
                this.Attributes.ComponentClass = this.Equipment.ComponentClass;
                this.Attributes.ComponentClassURI = this.Equipment.ComponentClassURI;
                if (this.Equipment.GenericAttributes.GetAttributeValue("ClassName", out attributeValue)) {
                    this.Attributes.ClassName = attributeValue;
                }
                else {
                    this.Attributes.ClassName = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Supplier", out attributeValue)) {
                    this.Attributes.Supplier = attributeValue;
                }
                else {
                    this.Attributes.Supplier = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Type", out attributeValue)) {
                    this.Attributes.Type = attributeValue;
                }
                else {
                    this.Attributes.Type = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("EquipmentSpec", out attributeValue)) {
                    this.Attributes.EquipmentSpec = attributeValue;
                }
                else {
                    this.Attributes.EquipmentSpec = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Weight", out attributeValue)) {
                    this.Attributes.Weight = attributeValue;
                }
                else {
                    this.Attributes.Weight = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("MaterialOfConstruction", out attributeValue)) {
                    this.Attributes.MaterialOfConstruction = attributeValue;
                }
                else {
                    this.Attributes.MaterialOfConstruction = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Number", out attributeValue)) {
                    this.Attributes.Number = attributeValue;
                }
                else {
                    this.Attributes.Number = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Area", out attributeValue)) {
                    this.Attributes.Area = attributeValue;
                }
                else {
                    this.Attributes.Area = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Insulation", out attributeValue)) {
                    this.Attributes.Insulation = attributeValue;
                }
                else {
                    this.Attributes.Insulation = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("InsulationType", out attributeValue)) {
                    this.Attributes.InsulationType = attributeValue;
                }
                else {
                    this.Attributes.InsulationType = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Diameter", out attributeValue)) {
                    this.Attributes.Diameter = attributeValue;
                }
                else {
                    this.Attributes.Diameter = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Capacity", out attributeValue)) {
                    this.Attributes.Capacity = attributeValue;
                }
                else {
                    this.Attributes.Capacity = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("DesignPressure", out attributeValue)) {
                    this.Attributes.DesignPressure = attributeValue;
                }
                else {
                    this.Attributes.DesignPressure = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("DesignTemperature", out attributeValue)) {
                    this.Attributes.DesignTemperature = attributeValue;
                }
                else {
                    this.Attributes.DesignTemperature = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Trim", out attributeValue)) {
                    this.Attributes.Trim = attributeValue;
                }
                else {
                    this.Attributes.Trim = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("InsulationType", out attributeValue)) {
                    this.Attributes.InsulationType = attributeValue;
                }
                else {
                    this.Attributes.InsulationType = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Insulation", out attributeValue)) {
                    this.Attributes.Insulation = attributeValue;
                }
                else {
                    this.Attributes.Insulation = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("Width", out attributeValue)) {
                    this.Attributes.Width = attributeValue;
                }
                else {
                    this.Attributes.Width = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("OperatingPressure", out attributeValue)) {
                    this.Attributes.OperatingPressure = attributeValue;
                }
                else {
                    this.Attributes.OperatingPressure = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("OperatingTemperature", out attributeValue)) {
                    this.Attributes.OperatingTemperature = attributeValue;
                }
                else {
                    this.Attributes.OperatingTemperature = string.Empty;
                }
                if (this.Equipment.GenericAttributes.GetAttributeValue("NumberOfTrays", out attributeValue)) {
                    int numberOfTrays;
                    if (int.TryParse(attributeValue, out numberOfTrays)) {
                        this.Attributes.NumberOfTrays = numberOfTrays;
                    }
                }
                else {
                    this.Attributes.NumberOfTrays = 0;
                }
            }
        }

        private EquipmentInstance() { }
        #endregion

        #region Overrides
        public override bool ResolveRelationships(DTDLInstanceBase dtdlInstanceFrom, DTDLInstanceBase dtdlInstanceTo) {
            bool resolved = false;
            if ((dtdlInstanceFrom != null) && (!string.IsNullOrEmpty(dtdlInstanceFrom.ID))) {
                this.Relationships.Add(new Relationship(dtdlInstanceFrom, dtdlInstanceFrom.RelationshipFromName));
                resolved = true;
            }

            return resolved;
        }

        public override string RelationshipFromName {
            get { return "EquipmentConnectsTo"; }
        }
        #endregion

        #region Public Methods
        #endregion

        #region Public Properties
        public Equipment Equipment { get; private set; }

        public System.Collections.Generic.IList<Relationship> Relationships { get; private set; }
        #endregion
    }
}
