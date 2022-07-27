using System;
using System.Collections.Generic;
using System.Linq;
using DTDL.Extensions;

namespace DTDL {
    public sealed class Relationship {
        #region Construction
        public Relationship(DTDLInstanceBase relationShipFrom, string relationshipName) {
            if (relationShipFrom == null) {
                throw new ArgumentNullException("relationShipFrom");
            }
            else if (string.IsNullOrEmpty(relationshipName)) {
                throw new ArgumentNullException("relationshipName");
            }
            else {
                this.RelationshipFrom = relationShipFrom;
                this.RelationshipName = relationshipName;
            }
        }

        private Relationship() { }
        #endregion

        #region Public Methods
        public static bool ResolveRelationships(IDictionary<string, EquipmentInstance> equipmentList, IDictionary<string, PipingSegmentInstance> pipingSegmentList, out IList<string> errors) {
            errors = new List<string>();
            bool resolved = true;
            foreach (string pipingSegmentId in pipingSegmentList.Keys) {
                PipingSegmentInstance currentPipingSegmentInstance = pipingSegmentList[pipingSegmentId];
                DTDLInstanceBase dtdlInstanceTo = null;
                DTDLInstanceBase dtdlInstanceFrom = null;
                string toTagName = currentPipingSegmentInstance.Attributes.To;
                if (!string.IsNullOrEmpty(toTagName)) {
                    // Check if the To value is a PipingNetworkSegment or Equipment.
                    if (pipingSegmentList.Values.Any(instance => instance.TagName == toTagName)) {
                        dtdlInstanceTo = pipingSegmentList.Values.First(instance => instance.TagName == toTagName);
                    }
                    else if (equipmentList.Values.Any(instance => instance.TagName == toTagName)) {
                        dtdlInstanceTo = equipmentList.Values.First(instance => instance.TagName == toTagName);
                    }
                }
                string fromTagName = currentPipingSegmentInstance.Attributes.From;
                if (!string.IsNullOrEmpty(fromTagName)) {
                    // Check if the From value is a PipingNetworkSegment or Equipment.
                    if (pipingSegmentList.Values.Any(instance => instance.TagName == fromTagName)) {
                        dtdlInstanceFrom = pipingSegmentList.Values.First(instance => instance.TagName == fromTagName);
                    }
                    else if (equipmentList.Values.Any(instance => instance.TagName == fromTagName)) {
                        dtdlInstanceFrom = equipmentList.Values.First(instance => instance.TagName == fromTagName);
                    }
                }

                // Now resolve the relationships for this piping segment.
                if (!currentPipingSegmentInstance.ResolveRelationships(dtdlInstanceFrom, dtdlInstanceTo)) {
                    errors.Add(string.Format("Piping Network Segment: {0}; To: {1}; From: {2}{3}", pipingSegmentId, toTagName ?? "<None>", fromTagName  ?? "<None>", System.Environment.NewLine));
                    resolved = false;
                }
            }

            return resolved;
        }
        #endregion

        #region Public Properties
        public DTDLInstanceBase RelationshipFrom { get; private set; }

        public string RelationshipName { get; private set; }
        #endregion
    }
}
