

// Generated on 02/19/2017 13:42:15
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("LivingObjectSkinJntMood", "com.ankamagames.dofus.datacenter.livingObjects")]
    [Serializable]
    public class LivingObjectSkinJntMood : IDataObject, IIndexedData
    {
        public const String MODULE = "LivingObjectSkinJntMood";
        public int skinId;
        public List<List<int>> moods;
        int IIndexedData.Id
        {
            get { return (int)skinId; }
        }
        [D2OIgnore]
        public int SkinId
        {
            get { return this.skinId; }
            set { this.skinId = value; }
        }
        [D2OIgnore]
        public List<List<int>> Moods
        {
            get { return this.moods; }
            set { this.moods = value; }
        }
    }
}