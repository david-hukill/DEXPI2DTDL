using System;
using DEXPI;
using DTDL.Extensions;

namespace DTDL {
    public sealed class PipingComponentInstance : DTDLInstanceBase {
        #region Construction
        public PipingComponentInstance(PipingComponent pipingComponent, PipingSegmentInstance parent) : base("dtmi:autodesk:dexpi:PipingComponent;1") {
            if (pipingComponent == null) {
                throw new ArgumentNullException("pipingComponent");
            }
            else if (parent == null) {
                throw new ArgumentNullException("parent");
            }
            else {
                this.PipingComponent = pipingComponent;
                this.ID = this.PipingComponent.ID;
                this.Attributes.ID = this.ID;
                this.Parent = parent;
                string attributeValue = null;
                if ((this.PipingComponent.GenericAttributes.GetAttributeValue("Tag", out attributeValue)) ||
                    (this.PipingComponent.GenericAttributes.GetAttributeValue("TagNameAssignmentClass", out attributeValue))) {
                    this.TagName = attributeValue;
                }
                else {
                    this.TagName = string.Empty;
                }
                this.Attributes.Tag = this.TagName;
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("Description", out attributeValue)) {
                    this.Attributes.Description = attributeValue;
                }
                else {
                    this.Attributes.Description = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("Manufacturer", out attributeValue)) {
                    this.Attributes.Manufacturer = attributeValue;
                }
                else {
                    this.Attributes.Manufacturer = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("ModelNumber", out attributeValue)) {
                    this.Attributes.ModelNumber = attributeValue;
                }
                else {
                    this.Attributes.ModelNumber = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("Comment", out attributeValue)) {
                    this.Attributes.Comment = attributeValue;
                }
                else {
                    this.Attributes.Comment = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("FlagValue", out attributeValue)) {
                    int flagValue;
                    if (int.TryParse(attributeValue, out flagValue)) {
                        this.Attributes.FlagValue = flagValue;
                    }
                }
                else {
                    this.Attributes.FlagValue = 0;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("AcquisitionProperties", out attributeValue)) {
                    this.Attributes.AcquisitionProperties = attributeValue;
                }
                else {
                    this.Attributes.AcquisitionProperties = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("Status", out attributeValue)) {
                    this.Attributes.Status = attributeValue;
                }
                else {
                    this.Attributes.Status = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("ParamOnLine", out attributeValue)) {
                    double paramOnLine;
                    if (double.TryParse(attributeValue, out paramOnLine)) {
                        this.Attributes.ParamOnLine = paramOnLine;
                    }
                }
                else {
                    this.Attributes.ParamOnLine = 0.0;
                }
                this.Attributes.ComponentName = this.PipingComponent.ComponentName;
                this.Attributes.ComponentClass = this.PipingComponent.ComponentClass;
                this.Attributes.ComponentClassURI = this.PipingComponent.ComponentClassURI;
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("ClassName", out attributeValue)) {
                    this.Attributes.ClassName = attributeValue;
                }
                else {
                    this.Attributes.ClassName = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("Size", out attributeValue)) {
                    this.Attributes.Size = attributeValue;
                }
                else {
                    this.Attributes.Size = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("Spec", out attributeValue)) {
                    this.Attributes.Spec = attributeValue;
                }
                else {
                    this.Attributes.Spec = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("Spec Part", out attributeValue)) {
                    this.Attributes.SpecPart = attributeValue;
                }
                else {
                    this.Attributes.SpecPart = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("SpecPartGuid", out attributeValue)) {
                    this.Attributes.SpecPartGuid = attributeValue;
                }
                else {
                    this.Attributes.SpecPartGuid = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("ValveCode", out attributeValue)) {
                    this.Attributes.ValveCode = attributeValue;
                }
                else {
                    this.Attributes.ValveCode = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("Failure", out attributeValue)) {
                    this.Attributes.Failure = attributeValue;
                }
                else {
                    this.Attributes.Failure = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("EndConnections", out attributeValue)) {
                    this.Attributes.EndConnections = attributeValue;
                }
                else {
                    this.Attributes.EndConnections = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("Number", out attributeValue)) {
                    this.Attributes.Number = attributeValue;
                }
                else {
                    this.Attributes.Number = string.Empty;
                }
                if (this.PipingComponent.GenericAttributes.GetAttributeValue("Code", out attributeValue)) {
                    this.Attributes.Code = attributeValue;
                }
                else {
                    this.Attributes.Code = string.Empty;
                }
            }
        }

        private PipingComponentInstance() { }
        #endregion

        #region Overrides
        public override bool ResolveRelationships(DTDLInstanceBase dtdlInstanceFrom, DTDLInstanceBase dtdlInstanceTo) {
            bool resolved = false;
            if ((dtdlInstanceFrom != null) && (!string.IsNullOrEmpty(dtdlInstanceFrom.ID))) {
                this.Relationship = new Relationship(dtdlInstanceFrom, dtdlInstanceFrom.RelationshipFromName);
                resolved = true;
            }
            else {
                this.Relationship = null;
            }

            return resolved;
        }

        public override string RelationshipFromName {
            get { return "PipingComponentConnectsTo"; }
        }
        #endregion

        #region Public Properties
        public PipingComponent PipingComponent { get; private set; }

        public PipingSegmentInstance Parent { get; private set; }

        public Relationship Relationship { get; private set; }
        #endregion
    }
}