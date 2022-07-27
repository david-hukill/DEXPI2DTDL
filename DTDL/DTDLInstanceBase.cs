using System;
using System.Dynamic;

namespace DTDL {
    public abstract class DTDLInstanceBase {
        #region Construction
        public DTDLInstanceBase(string modelID) {
            if (string.IsNullOrEmpty(modelID)) {
                throw new ArgumentNullException("modelID");
            }
            else {
                this.ModelID = modelID;
                this.Attributes = new ExpandoObject();
            }
        }

        public DTDLInstanceBase() { }
        #endregion

        #region Abstract Methods
        public abstract bool ResolveRelationships(DTDLInstanceBase dtdlInstanceFrom, DTDLInstanceBase dtdlInstanceTo);
        public abstract string RelationshipFromName { get; }
        #endregion

        #region Public Properties
        public string ModelID { get; private set; }

        public string ID { get; protected set; }

        public string TagName { get; protected set; }

        public string TagID {
            get {
                return this.TagName + "_" + this.ID;
            }
        }
        #endregion

        #region Public Properties
        public dynamic Attributes { get; private set; }
        #endregion
    }
}
