

// Generated on 02/19/2017 13:42:21
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Phoenix", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class Phoenix : IDataObject, IIndexedData
    {
        public const String MODULE = "Phoenixes";
        public uint mapId;
        int IIndexedData.Id
        {
            get { return (int)mapId; }
        }
        [D2OIgnore]
        public uint MapId
        {
            get { return this.mapId; }
            set { this.mapId = value; }
        }
    }
}