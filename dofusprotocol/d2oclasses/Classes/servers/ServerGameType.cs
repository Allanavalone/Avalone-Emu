using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ServerGameType", "com.ankamagames.dofus.datacenter.servers")]
    [Serializable]
    public class ServerGameType : IDataObject, IIndexedData
    {
        public const String MODULE = "ServerGameTypes";
        public int id;
        public Boolean selectableByPlayer;
        [I18NField]
        public uint nameId;
        [I18NField]
        public uint rulesId;
        [I18NField]
        public uint descriptionId;
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
        public Boolean SelectableByPlayer
        {
            get { return this.selectableByPlayer; }
            set { this.selectableByPlayer = value; }
        }
        [D2OIgnore]
        public uint NameId
        {
            get { return this.nameId; }
            set { this.nameId = value; }
        }
        [D2OIgnore]
        public uint RulesId
        {
            get { return this.rulesId; }
            set { this.rulesId = value; }
        }
        [D2OIgnore]
        public uint DescriptionId
        {
            get { return this.descriptionId; }
            set { this.descriptionId = value; }
        }
    }
}