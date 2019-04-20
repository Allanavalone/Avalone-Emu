

// Generated on 02/19/2017 13:42:20
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("FinishMove", "com.ankamagames.dofus.datacenter.spells")]
    [Serializable]
    public class FinishMove : IDataObject, IIndexedData
    {
        public const String MODULE = "FinishMoves";
        public int id;
        public int duration;
        public Boolean free;
        [I18NField]
        public uint nameId;
        public int category;
        public int spellLevel;
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
        public int Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }
        [D2OIgnore]
        public Boolean Free
        {
            get { return this.free; }
            set { this.free = value; }
        }
        [D2OIgnore]
        public uint NameId
        {
            get { return this.nameId; }
            set { this.nameId = value; }
        }
        [D2OIgnore]
        public int Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
        [D2OIgnore]
        public int SpellLevel
        {
            get { return this.spellLevel; }
            set { this.spellLevel = value; }
        }
    }
}