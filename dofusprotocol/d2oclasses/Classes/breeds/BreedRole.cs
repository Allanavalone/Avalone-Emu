

// Generated on 02/19/2017 13:42:10
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("BreedRole", "com.ankamagames.dofus.datacenter.breeds")]
    [Serializable]
    public class BreedRole : IDataObject, IIndexedData
    {
        public const String MODULE = "BreedRoles";
        public int id;
        [I18NField]
        public uint nameId;
        [I18NField]
        public uint descriptionId;
        public int assetId;
        public int color;
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
        public uint DescriptionId
        {
            get { return this.descriptionId; }
            set { this.descriptionId = value; }
        }
        [D2OIgnore]
        public int AssetId
        {
            get { return this.assetId; }
            set { this.assetId = value; }
        }
        [D2OIgnore]
        public int Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
    }
}