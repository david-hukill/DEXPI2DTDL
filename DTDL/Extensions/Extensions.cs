using System.Linq;
using DEXPI;

namespace DTDL.Extensions {
    public static class Extensions {
        public static bool GetAttributeValue(this DEXPI.GenericAttribute genericAttribute, string attributeName, out string attributeValue) {
            bool found = false;
            attributeValue = null;
            if ((genericAttribute != null) && (!string.IsNullOrEmpty(attributeName)) && (genericAttribute.Name == attributeName)) {
                attributeValue = genericAttribute.Value;
                found = true;
            }

            return found;
        }

        public static bool GetAttributeValue(this DEXPI.GenericAttribute[] arrGenericAttribute, string attributeName, out string attributeValue) {
            bool found = false;
            attributeValue = null;
            if (arrGenericAttribute?.Any() == true) {
                foreach (DEXPI.GenericAttribute genericAttribute in arrGenericAttribute) {
                    if (genericAttribute.GetAttributeValue(attributeName, out attributeValue)) {
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        public static bool GetAttributeValue(this DEXPI.GenericAttributes genericAttributes, string attributeName, out string attributeValue) {
            bool found = false;
            attributeValue = null;
            if ((genericAttributes != null) && (genericAttributes.GenericAttribute?.Any() == true)) {
                found = genericAttributes.GenericAttribute.GetAttributeValue(attributeName, out attributeValue);
            }

            return found;
        }

        public static bool GetAttributeValue(this DEXPI.GenericAttributes[] arrGenericAttributes, string attributeName, out string attributeValue) {
            bool found = false;
            attributeValue = null;
            if ((arrGenericAttributes != null) && (arrGenericAttributes?.Any() == true)) {
                foreach (DEXPI.GenericAttributes genericAttributes in arrGenericAttributes) {
                    if (genericAttributes.GetAttributeValue(attributeName, out attributeValue)) {
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        public static bool GetAttributeValue(this DEXPI.Equipment equipment, string attributeName, out string attributeValue) {
            bool found = false;
            attributeValue = null;
            if (equipment != null) {
                found = equipment.GenericAttributes.GetAttributeValue(attributeName, out attributeValue);
            }

            return found;
        }

        public static bool GetAttributeValue(this DTDL.EquipmentInstance equipmentInstance, string attributeName, out string attributeValue) {
            bool found = false;
            attributeValue = null;
            if (equipmentInstance != null) {
                found = equipmentInstance.Equipment.GetAttributeValue(attributeName, out attributeValue);
            }

            return found;
        }

        public static bool GetAttributeValue(this DEXPI.PipingComponent pipingComponent, string attributeName, out string attributeValue) {
            bool found = false;
            attributeValue = null;
            if (pipingComponent != null) {
                found = pipingComponent.GenericAttributes.GetAttributeValue(attributeName, out attributeValue);
            }

            return found;
        }

        public static bool GetAttributeValue(this DTDL.PipingComponentInstance pipingComponentInstance, string attributeName, out string attributeValue) {
            bool found = false;
            attributeValue = null;
            if (pipingComponentInstance != null) {
                found = pipingComponentInstance.PipingComponent.GetAttributeValue(attributeName, out attributeValue);
            }

            return found;
        }

        public static bool GetAttributeValue(this DEXPI.PipingNetworkSegment pipingNetworkSegment, string attributeName, out string attributeValue) {
            bool found = false;
            attributeValue = null;
            if (pipingNetworkSegment != null) {
                found = pipingNetworkSegment.GenericAttributes.GetAttributeValue(attributeName, out attributeValue);
            }

            return found;
        }

        public static bool GetAttributeValue(this DTDL.PipingSegmentInstance pipingNetworkSegmentInstance, string attributeName, out string attributeValue) {
            bool found = false;
            attributeValue = null;
            if (pipingNetworkSegmentInstance != null) {
                found = pipingNetworkSegmentInstance.PipingNetworkSegment.GetAttributeValue(attributeName, out attributeValue);
            }

            return found;
        }
    }
}
