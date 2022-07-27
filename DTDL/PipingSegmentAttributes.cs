using System;
using DEXPI;
using DTDL.Extensions;

namespace DTDL {
    public sealed class PipingSegmentAttributes {
        #region Construction
        public PipingSegmentAttributes(PipingSegmentInstance pipingSegmentInstance) {
            if (pipingSegmentInstance == null) {
                throw new ArgumentNullException("pipingSegmentInstance");
            }
            else {
                this.PipingSegmentInstance = pipingSegmentInstance;
                this.ID = this.PipingSegmentInstance.ID;
                string attributeValue = null;
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Tag", out attributeValue)) {
                    this.Tag = attributeValue;
                }
                else {
                    this.Tag = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("To", out attributeValue)) {
                    this.To = attributeValue;
                }
                else {
                    this.To = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("From", out attributeValue)) {
                    this.From = attributeValue;
                }
                else {
                    this.From = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Description", out attributeValue)) {
                    this.Description = attributeValue;
                }
                else {
                    this.Description = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Manufacturer", out attributeValue)) {
                    this.Manufacturer = attributeValue;
                }
                else {
                    this.Manufacturer = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("ModelNumber", out attributeValue)) {
                    this.ModelNumber = attributeValue;
                }
                else {
                    this.ModelNumber = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Comment", out attributeValue)) {
                    this.Comment = attributeValue;
                }
                else {
                    this.Comment = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("FlagValue", out attributeValue)) {
                    int flagValue;
                    if (int.TryParse(attributeValue, out flagValue)) {
                        this.FlagValue = flagValue;
                    }
                }
                else {
                    this.FlagValue = 0;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("AcquisitionProperties", out attributeValue)) {
                    this.AcquisitionProperties = attributeValue;
                }
                else {
                    this.AcquisitionProperties = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Status", out attributeValue)) {
                    this.Status = attributeValue;
                }
                else {
                    this.Status = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("ParamOnLine", out attributeValue)) {
                    double paramOnLine;
                    if (double.TryParse(attributeValue, out paramOnLine)) {
                        this.ParamOnLine = paramOnLine;
                    }
                }
                else {
                    this.ParamOnLine = 0.0;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Supplier", out attributeValue)) {
                    this.Supplier = attributeValue;
                }
                else {
                    this.Supplier = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Tracing", out attributeValue)) {
                    this.Tracing = attributeValue;
                }
                else {
                    this.Tracing = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("PaintCode", out attributeValue)) {
                    this.PaintCode = attributeValue;
                }
                else {
                    this.PaintCode = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("OperatingTemperature", out attributeValue)) {
                    this.OperatingTemperature = attributeValue;
                }
                else {
                    this.OperatingTemperature = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("OperatingPressure", out attributeValue)) {
                    this.OperatingPressure = attributeValue;
                }
                else {
                    this.OperatingPressure = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("DesignPressure", out attributeValue)) {
                    this.DesignPressure = attributeValue;
                }
                else {
                    this.DesignPressure = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("DesignTemperature", out attributeValue)) {
                    this.DesignTemperature = attributeValue;
                }
                else {
                    this.DesignTemperature = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("TestingFluid", out attributeValue)) {
                    this.TestingFluid = attributeValue;
                }
                else {
                    this.TestingFluid = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("TestPressure", out attributeValue)) {
                    this.TestPressure = attributeValue;
                }
                else {
                    this.TestPressure = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("PostWeldHeatTreatment", out attributeValue)) {
                    this.PostWeldHeatTreatment = attributeValue;
                }
                else {
                    this.PostWeldHeatTreatment = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("Spec Part", out attributeValue)) {
                    this.SpecPart = attributeValue;
                }
                else {
                    this.SpecPart = string.Empty;
                }
                if (this.PipingSegmentInstance.PipingNetworkSegment.GenericAttributes.GetAttributeValue("SpecPartGuid", out attributeValue)) {
                    this.SpecPartGuid = attributeValue;
                }
                else {
                    this.SpecPartGuid = string.Empty;
                }
            }
        }

        private PipingSegmentAttributes() { }
        #endregion

        #region Public Properties
        [System.Text.Json.Serialization.JsonIgnore]
        public PipingSegmentInstance PipingSegmentInstance { get; private set; }
        public string ID { get; private set; }
        public string Tag { get; private set; }
        public string To { get; private set; }
        public string From { get; private set; }
        public string Description { get; private set; }
        public string Manufacturer { get; private set; }
        public string ModelNumber { get; private set; }
        public string Comment { get; private set; }
        public int FlagValue { get; private set; }
        public string AcquisitionProperties { get; private set; }
        public string Status { get; private set; }
        public double ParamOnLine { get; private set; }
        public string Supplier { get; private set; }
        public string Tracing { get; private set; }
        public string PaintCode { get; private set; }
        public string OperatingTemperature { get; private set; }
        public string OperatingPressure { get; private set; }
        public string DesignPressure { get; private set; }
        public string DesignTemperature { get; private set; }
        public string TestingFluid { get; private set; }
        public string TestPressure { get; private set; }
        public string PostWeldHeatTreatment { get; private set; }
        public string SpecPart { get; private set; }
        public string SpecPartGuid { get; private set; }
        #endregion
    }
}
