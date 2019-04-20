

// Generated on 02/19/2017 13:42:13
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Item", "com.ankamagames.dofus.datacenter.items")]
    [Serializable]
    public class Item : IDataObject, IIndexedData
    {
        public const String MODULE = "Items";
        public const uint EQUIPEMENT_CATEGORY = 0;
        public const uint CONSUMABLES_CATEGORY = 1;
        public const uint RESSOURCES_CATEGORY = 2;
        public const uint QUEST_CATEGORY = 3;
        public const uint OTHER_CATEGORY = 4;
        public const int MAX_JOB_LEVEL_GAP = 100;
        public int id;
        [I18NField]
        public uint nameId;
        public uint typeId;
        [I18NField]
        public uint descriptionId;
        public int iconId;
        public uint level;
        public uint realWeight;
        public Boolean cursed;
        public int useAnimationId;
        public Boolean usable;
        public Boolean targetable;
        public Boolean exchangeable;
        public double price;
        public Boolean twoHanded;
        public Boolean etheral;
        public int itemSetId;
        public String criteria;
        public String criteriaTarget;
        public Boolean hideEffects;
        public Boolean enhanceable;
        public Boolean nonUsableOnAnother;
        public uint appearanceId;
        public Boolean secretRecipe;
        public List<uint> dropMonsterIds;
        public uint recipeSlots;
        public List<uint> recipeIds;
        public Boolean bonusIsSecret;
        public List<EffectInstance> possibleEffects;
        public List<uint> favoriteSubAreas;
        public uint favoriteSubAreasBonus;
        public int craftXpRatio;
        public Boolean needUseConfirm;
        public Boolean isDestructible;
        public List<List<double>> nuggetsBySubarea;
        public List<uint> containerIds;
        public List<List<int>> resourcesBySubarea;
        public uint weight;
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
        public uint TypeId
        {
            get { return this.typeId; }
            set { this.typeId = value; }
        }
        [D2OIgnore]
        public uint DescriptionId
        {
            get { return this.descriptionId; }
            set { this.descriptionId = value; }
        }
        [D2OIgnore]
        public int IconId
        {
            get { return this.iconId; }
            set { this.iconId = value; }
        }
        [D2OIgnore]
        public uint Level
        {
            get { return this.level; }
            set { this.level = value; }
        }
        [D2OIgnore]
        public uint RealWeight
        {
            get { return this.realWeight; }
            set { this.realWeight = value; }
        }
        [D2OIgnore]
        public Boolean Cursed
        {
            get { return this.cursed; }
            set { this.cursed = value; }
        }
        [D2OIgnore]
        public int UseAnimationId
        {
            get { return this.useAnimationId; }
            set { this.useAnimationId = value; }
        }
        [D2OIgnore]
        public Boolean Usable
        {
            get { return this.usable; }
            set { this.usable = value; }
        }
        [D2OIgnore]
        public Boolean Targetable
        {
            get { return this.targetable; }
            set { this.targetable = value; }
        }
        [D2OIgnore]
        public Boolean Exchangeable
        {
            get { return this.exchangeable; }
            set { this.exchangeable = value; }
        }
        [D2OIgnore]
        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        [D2OIgnore]
        public Boolean TwoHanded
        {
            get { return this.twoHanded; }
            set { this.twoHanded = value; }
        }
        [D2OIgnore]
        public Boolean Etheral
        {
            get { return this.etheral; }
            set { this.etheral = value; }
        }
        [D2OIgnore]
        public int ItemSetId
        {
            get { return this.itemSetId; }
            set { this.itemSetId = value; }
        }
        [D2OIgnore]
        public String Criteria
        {
            get { return this.criteria; }
            set { this.criteria = value; }
        }
        [D2OIgnore]
        public String CriteriaTarget
        {
            get { return this.criteriaTarget; }
            set { this.criteriaTarget = value; }
        }
        [D2OIgnore]
        public Boolean HideEffects
        {
            get { return this.hideEffects; }
            set { this.hideEffects = value; }
        }
        [D2OIgnore]
        public Boolean Enhanceable
        {
            get { return this.enhanceable; }
            set { this.enhanceable = value; }
        }
        [D2OIgnore]
        public Boolean NonUsableOnAnother
        {
            get { return this.nonUsableOnAnother; }
            set { this.nonUsableOnAnother = value; }
        }
        [D2OIgnore]
        public uint AppearanceId
        {
            get { return this.appearanceId; }
            set { this.appearanceId = value; }
        }
        [D2OIgnore]
        public Boolean SecretRecipe
        {
            get { return this.secretRecipe; }
            set { this.secretRecipe = value; }
        }
        [D2OIgnore]
        public List<uint> DropMonsterIds
        {
            get { return this.dropMonsterIds; }
            set { this.dropMonsterIds = value; }
        }
        [D2OIgnore]
        public uint RecipeSlots
        {
            get { return this.recipeSlots; }
            set { this.recipeSlots = value; }
        }
        [D2OIgnore]
        public List<uint> RecipeIds
        {
            get { return this.recipeIds; }
            set { this.recipeIds = value; }
        }
        [D2OIgnore]
        public Boolean BonusIsSecret
        {
            get { return this.bonusIsSecret; }
            set { this.bonusIsSecret = value; }
        }
        [D2OIgnore]
        public List<EffectInstance> PossibleEffects
        {
            get { return this.possibleEffects; }
            set { this.possibleEffects = value; }
        }
        [D2OIgnore]
        public List<uint> FavoriteSubAreas
        {
            get { return this.favoriteSubAreas; }
            set { this.favoriteSubAreas = value; }
        }
        [D2OIgnore]
        public uint FavoriteSubAreasBonus
        {
            get { return this.favoriteSubAreasBonus; }
            set { this.favoriteSubAreasBonus = value; }
        }
        [D2OIgnore]
        public int CraftXpRatio
        {
            get { return this.craftXpRatio; }
            set { this.craftXpRatio = value; }
        }
        [D2OIgnore]
        public Boolean NeedUseConfirm
        {
            get { return this.needUseConfirm; }
            set { this.needUseConfirm = value; }
        }
        [D2OIgnore]
        public Boolean IsDestructible
        {
            get { return this.isDestructible; }
            set { this.isDestructible = value; }
        }
        [D2OIgnore]
        public List<List<double>> NuggetsBySubarea
        {
            get { return this.nuggetsBySubarea; }
            set { this.nuggetsBySubarea = value; }
        }
        [D2OIgnore]
        public List<uint> ContainerIds
        {
            get { return this.containerIds; }
            set { this.containerIds = value; }
        }
        [D2OIgnore]
        public List<List<int>> ResourcesBySubarea
        {
            get { return this.resourcesBySubarea; }
            set { this.resourcesBySubarea = value; }
        }
        [D2OIgnore]
        public uint Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
    }
}