

// Generated on 02/19/2017 13:42:17
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Mount", "com.ankamagames.dofus.datacenter.mounts")]
    [Serializable]
    public class Mount : IDataObject, IIndexedData
    {
        private String MODULE = "Mounts";
        public uint id;
        public uint familyId;
        [I18NField]
        public uint nameId;
        public String look;
        int IIndexedData.Id
        {
            get { return (int)id; }
        }
        [D2OIgnore]
        public uint Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        [D2OIgnore]
        public uint FamilyId
        {
            get { return this.familyId; }
            set { this.familyId = value; }
        }
        [D2OIgnore]
        public uint NameId
        {
            get { return this.nameId; }
            set { this.nameId = value; }
        }
        [D2OIgnore]
        public String Look
        {
            get { return this.look; }
            set { this.look = value; }
        }
    }
}