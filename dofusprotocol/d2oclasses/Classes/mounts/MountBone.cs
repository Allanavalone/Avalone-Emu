

// Generated on 02/19/2017 13:42:17
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MountBone", "com.ankamagames.dofus.datacenter.mounts")]
    [Serializable]
    public class MountBone : IDataObject, IIndexedData
    {
        private String MODULE = "MountBones";
        public uint id;
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
    }
}