using System;
using System.Collections.Generic;
using DEXPI;
using DTDL.Extensions;

namespace DTDL {
    public sealed class PipingSegmentInstance : DTDLInstanceBase {
        #region Construction
        public PipingSegmentInstance(PipingNetworkSegment pipingNetworkSegment) : base("dtmi:autodesk:dexpi:PipingSegment;1") {
            if (pipingNetworkSegment == null) {
                throw new ArgumentNullException("pipingNetworkSegment");
            }
            else {
                this.PipingNetworkSegment = pipingNetworkSegment;
                this.ID = this.PipingNetworkSegment.ID;
                this.Attributes.ID = this.ID;
                string attributeValue = null;
                if ((this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Tag", out attributeValue)) ||
                    (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("TagNameAssignmentClass", out attributeValue))) {
                    this.TagName = attributeValue;
                }
                else {
                    this.TagName = string.Empty;
                }
                this.Attributes.Tag = this.TagName;
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("To", out attributeValue)) {
                    this.Attributes.To = attributeValue;
                }
                else {
                    this.Attributes.To = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("From", out attributeValue)) {
                    this.Attributes.From = attributeValue;
                }
                else {
                    this.Attributes.From = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Description", out attributeValue)) {
                    this.Attributes.Description = attributeValue;
                }
                else {
                    this.Attributes.Description = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Manufacturer", out attributeValue)) {
                    this.Attributes.Manufacturer = attributeValue;
                }
                else {
                    this.Attributes.Manufacturer = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("ModelNumber", out attributeValue)) {
                    this.Attributes.ModelNumber = attributeValue;
                }
                else {
                    this.Attributes.ModelNumber = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Comment", out attributeValue)) {
                    this.Attributes.Comment = attributeValue;
                }
                else {
                    this.Attributes.Comment = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("FlagValue", out attributeValue)) {
                    int flagValue;
                    if (int.TryParse(attributeValue, out flagValue)) {
                        this.Attributes.FlagValue = flagValue;
                    }
                }
                else {
                    this.Attributes.FlagValue = 0;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("AcquisitionProperties", out attributeValue)) {
                    this.Attributes.AcquisitionProperties = attributeValue;
                }
                else {
                    this.Attributes.AcquisitionProperties = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Status", out attributeValue)) {
                    this.Attributes.Status = attributeValue;
                }
                else {
                    this.Attributes.Status = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("ParamOnLine", out attributeValue)) {
                    double paramOnLine;
                    if (double.TryParse(attributeValue, out paramOnLine)) {
                        this.Attributes.ParamOnLine = paramOnLine;
                    }
                }
                else {
                    this.Attributes.ParamOnLine = 0.0;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Supplier", out attributeValue)) {
                    this.Attributes.Supplier = attributeValue;
                }
                else {
                    this.Attributes.Supplier = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Tracing", out attributeValue)) {
                    this.Attributes.Tracing = attributeValue;
                }
                else {
                    this.Attributes.Tracing = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("PaintCode", out attributeValue)) {
                    this.Attributes.PaintCode = attributeValue;
                }
                else {
                    this.Attributes.PaintCode = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("OperatingTemperature", out attributeValue)) {
                    this.Attributes.OperatingTemperature = attributeValue;
                }
                else {
                    this.Attributes.OperatingTemperature = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("OperatingPressure", out attributeValue)) {
                    this.Attributes.OperatingPressure = attributeValue;
                }
                else {
                    this.Attributes.OperatingPressure = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("DesignPressure", out attributeValue)) {
                    this.Attributes.DesignPressure = attributeValue;
                }
                else {
                    this.Attributes.DesignPressure = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("DesignTemperature", out attributeValue)) {
                    this.Attributes.DesignTemperature = attributeValue;
                }
                else {
                    this.Attributes.DesignTemperature = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("TestingFluid", out attributeValue)) {
                    this.Attributes.TestingFluid = attributeValue;
                }
                else {
                    this.Attributes.TestingFluid = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("TestPressure", out attributeValue)) {
                    this.Attributes.TestPressure = attributeValue;
                }
                else {
                    this.Attributes.TestPressure = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("PostWeldHeatTreatment", out attributeValue)) {
                    this.Attributes.PostWeldHeatTreatment = attributeValue;
                }
                else {
                    this.Attributes.PostWeldHeatTreatment = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Spec Part", out attributeValue)) {
                    this.Attributes.SpecPart = attributeValue;
                }
                else {
                    this.Attributes.SpecPart = string.Empty;
                }
                if (this.PipingNetworkSegment.GenericAttributes.GetAttributeValue("SpecPartGuid", out attributeValue)) {
                    this.Attributes.SpecPartGuid = attributeValue;
                }
                else {
                    this.Attributes.SpecPartGuid = string.Empty;
                }
                this.PipingComponentInstances = new Dictionary<string, PipingComponentInstance>();
            }
        }

        private PipingSegmentInstance() { }
        #endregion

        #region Overrides
        public override bool ResolveRelationships(DTDLInstanceBase dtdlInstanceFrom, DTDLInstanceBase dtdlInstanceTo) {
            bool resolved = true;
            DTDLInstanceBase dtdlInstanceSource = this;
            if ((dtdlInstanceFrom != null) && (!string.IsNullOrEmpty(dtdlInstanceFrom.ID))) {
                this.Relationship = new Relationship(dtdlInstanceFrom, dtdlInstanceFrom.RelationshipFromName);
                if (this.PipingComponentInstances.Count > 0) {
                    foreach (string pipingComponentInstanceID in this.PipingComponentInstances.Keys) {
                        DTDLInstanceBase dtdlInstanceTarget = this.PipingComponentInstances[pipingComponentInstanceID];
                        resolved = dtdlInstanceTarget.ResolveRelationships(dtdlInstanceSource, null);
                        if (resolved) {
                            dtdlInstanceSource = dtdlInstanceTarget;
                        }
                        else {
                            break;
                        }
                    }
                }

                // This will resolve either the last piping component on our list, or ourselves (if we have no piping components).
                if ((resolved) && (dtdlInstanceTo != null) && (!string.IsNullOrEmpty(dtdlInstanceTo.ID))) {
                    resolved = dtdlInstanceTo.ResolveRelationships(dtdlInstanceSource, null);
                }
            }
            else if ((dtdlInstanceTo != null) && (!string.IsNullOrEmpty(dtdlInstanceTo.ID))) {
                resolved = dtdlInstanceTo.ResolveRelationships(dtdlInstanceSource, null);
            }
            else {
                this.Relationship = null;
            }

            return resolved;
        }

        public override string RelationshipFromName {
            get { return "PipingSegmentConnectsTo"; }
        }
        #endregion

        #region Public Methods
        #endregion

        #region Public Properties
        public PipingNetworkSegment PipingNetworkSegment { get; private set; }

        public Relationship Relationship { get; private set; }

        public IDictionary<string, PipingComponentInstance> PipingComponentInstances { get; private set; }
        #endregion
    }
}