

// Generated on 02/19/2017 13:42:18
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AchievementObjective", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class AchievementObjective : IDataObject, IIndexedData
    {
        public const String MODULE = "AchievementObjectives";
        public uint id;
        public uint achievementId;
        public uint order;
        [I18NField]
        public uint nameId;
        public String criterion;
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
        public uint AchievementId
        {
            get { return this.achievementId; }
            set { this.achievementId = value; }
        }
        [D2OIgnore]
        public uint Order
        {
            get { return this.order; }
            set { this.order = value; }
        }
        [D2OIgnore]
        public uint NameId
        {
            get { return this.nameId; }
            set { this.nameId = value; }
        }
        [D2OIgnore]
        public String Criterion
        {
            get { return this.criterion; }
            set { this.criterion = value; }
        }
    }
}