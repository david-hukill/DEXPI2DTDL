using System;
using DEXPI;
using DTDL.Extensions;

namespace DTDL {
    public sealed class PipingComponentAttributes {
        #region Construction
        public PipingComponentAttributes(PipingComponentInstance pipingComponentInstance) {
            if (pipingComponentInstance == null) {
                throw new ArgumentNullException("pipingComponentInstance");
            }
            else {
                this.PipingComponentInstance = pipingComponentInstance;
                this.ID = this.PipingComponentInstance.ID;
                string attributeValue = null;
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Tag", out attributeValue)) {
                    this.Tag = attributeValue;
                }
                else {
                    this.Tag = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Description", out attributeValue)) {
                    this.Description = attributeValue;
                }
                else {
                    this.Description = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Manufacturer", out attributeValue)) {
                    this.Manufacturer = attributeValue;
                }
                else {
                    this.Manufacturer = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("ModelNumber", out attributeValue)) {
                    this.ModelNumber = attributeValue;
                }
                else {
                    this.ModelNumber = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Comment", out attributeValue)) {
                    this.Comment = attributeValue;
                }
                else {
                    this.Comment = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("FlagValue", out attributeValue)) {
                    int flagValue;
                    if (int.TryParse(attributeValue, out flagValue)) {
                        this.FlagValue = flagValue;
                    }
                }
                else {
                    this.FlagValue = 0;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("AcquisitionProperties", out attributeValue)) {
                    this.AcquisitionProperties = attributeValue;
                }
                else {
                    this.AcquisitionProperties = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Status", out attributeValue)) {
                    this.Status = attributeValue;
                }
                else {
                    this.Status = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("ParamOnLine", out attributeValue)) {
                    double paramOnLine;
                    if (double.TryParse(attributeValue, out paramOnLine)) {
                        this.ParamOnLine = paramOnLine;
                    }
                }
                else {
                    this.ParamOnLine = 0.0;
                }
                this.ComponentName = this.PipingComponentInstance.PipingComponent.ComponentName;
                this.ComponentClass = this.PipingComponentInstance.PipingComponent.ComponentClass;
                this.ComponentClassURI = this.PipingComponentInstance.PipingComponent.ComponentClassURI;
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("ClassName", out attributeValue)) {
                    this.ClassName = attributeValue;
                }
                else {
                    this.ClassName = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Size", out attributeValue)) {
                    this.Size = attributeValue;
                }
                else {
                    this.Size = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Spec", out attributeValue)) {
                    this.Spec = attributeValue;
                }
                else {
                    this.Spec = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Spec Part", out attributeValue)) {
                    this.SpecPart = attributeValue;
                }
                else {
                    this.SpecPart = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("SpecPartGuid", out attributeValue)) {
                    this.SpecPartGuid = attributeValue;
                }
                else {
                    this.SpecPartGuid = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("ValveCode", out attributeValue)) {
                    this.ValveCode = attributeValue;
                }
                else {
                    this.ValveCode = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Failure", out attributeValue)) {
                    this.Failure = attributeValue;
                }
                else {
                    this.Failure = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("EndConnections", out attributeValue)) {
                    this.EndConnections = attributeValue;
                }
                else {
                    this.EndConnections = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Number", out attributeValue)) {
                    this.Number = attributeValue;
                }
                else {
                    this.Number = string.Empty;
                }
                if (this.PipingComponentInstance.PipingComponent.GenericAttributes.GetAttributeValue("Code", out attributeValue)) {
                    this.Code = attributeValue;
                }
                else {
                    this.Code = string.Empty;
                }
            }
        }

        private PipingComponentAttributes() { }
        #endregion

        #region Public Properties
        [System.Text.Json.Serialization.JsonIgnore]
        public PipingComponentInstance PipingComponentInstance { get; private set; }
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
        public string Size { get; private set; }
        public string Spec { get; private set; }
        public string SpecPart  { get; private set; }
        public string SpecPartGuid { get; private set; }
        public string ValveCode { get; private set; }
        public string Failure { get; private set; }
        public string EndConnections { get; private set; }
        public string Number { get; private set; }
        public string Code { get; private set; }
        #endregion
    }
}
