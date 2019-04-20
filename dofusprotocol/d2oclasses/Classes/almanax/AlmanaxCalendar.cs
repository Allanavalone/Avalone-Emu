

// Generated on 02/19/2017 13:42:09
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AlmanaxCalendar", "com.ankamagames.dofus.datacenter.almanax")]
    [Serializable]
    public class AlmanaxCalendar : IDataObject, IIndexedData
    {
        public const String MODULE = "AlmanaxCalendars";
        public int id;
        [I18NField]
        public uint nameId;
        [I18NField]
        public uint descId;
        public int npcId;
        public List<int> bonusesIds;
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
        public uint NameId
        {
            get { return this.nameId; }
            set { this.nameId = value; }
        }
        [D2OIgnore]
        public uint DescId
        {
            get { return this.descId; }
            set { this.descId = value; }
        }
        [D2OIgnore]
        public int NpcId
        {
            get { return this.npcId; }
            set { this.npcId = value; }
        }
        [D2OIgnore]
        public List<int> BonusesIds
        {
            get { return this.bonusesIds; }
            set { this.bonusesIds = value; }
        }
    }
}