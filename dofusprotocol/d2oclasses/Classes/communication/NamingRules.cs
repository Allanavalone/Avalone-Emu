using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("NamingRules", "com.ankamagames.dofus.datacenter.communication")]
    [Serializable]
    public class NamingRules : IDataObject, IIndexedData
    {
        public const String MODULE = "NamingRules";
        public int id;
        public uint minLength;
        public uint maxLength;
        public string regexp;
        int IIndexedData.Id
        {
            get { return (int)id; }
        }
        [D2OIgnore]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        [D2OIgnore]
        public uint MinLength
        {
            get { return this.minLength; }
            set { this.minLength = value; }
        }
        [D2OIgnore]
        public uint MaxLength
        {
            get { return this.maxLength; }
            set { this.maxLength = value; }
        }
        [D2OIgnore]
        public string Regexp
        {
            get { return this.regexp; }
            set { this.regexp = value; }
        }

    }
}