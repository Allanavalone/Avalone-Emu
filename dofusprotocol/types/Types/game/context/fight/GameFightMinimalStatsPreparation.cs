using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightMinimalStatsPreparation : GameFightMinimalStats
    {
        public const short Id = 360;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public int initiative;
        
        public GameFightMinimalStatsPreparation()
        {
        }
        
        public GameFightMinimalStatsPreparation(int lifePoints, int maxLifePoints, int baseMaxLifePoints, int permanentDamagePercent, int shieldPoints, short actionPoints, short maxActionPoints, short movementPoints, short maxMovementPoints, double summoner, bool summoned, short neutralElementResistPercent, short earthElementResistPercent, short waterElementResistPercent, short airElementResistPercent, short fireElementResistPercent, short neutralElementReduction, short earthElementReduction, short waterElementReduction, short airElementReduction, short fireElementReduction, short criticalDamageFixedResist, short pushDamageFixedResist, short pvpNeutralElementResistPercent, short pvpEarthElementResistPercent, short pvpWaterElementResistPercent, short pvpAirElementResistPercent, short pvpFireElementResistPercent, short pvpNeutralElementReduction, short pvpEarthElementReduction, short pvpWaterElementReduction, short pvpAirElementReduction, short pvpFireElementReduction, short dodgePALostProbability, short dodgePMLostProbability, short tackleBlock, short tackleEvade, short fixedDamageReflection, sbyte invisibilityState, short meleeDamageReceivedPercent, short rangedDamageReceivedPercent, short weaponDamageReceivedPercent, short spellDamageReceivedPercent, int initiative)
         : base(lifePoints, maxLifePoints, baseMaxLifePoints, permanentDamagePercent, shieldPoints, actionPoints, maxActionPoints, movementPoints, maxMovementPoints, summoner, summoned, neutralElementResistPercent, earthElementResistPercent, waterElementResistPercent, airElementResistPercent, fireElementResistPercent, neutralElementReduction, earthElementReduction, waterElementReduction, airElementReduction, fireElementReduction, criticalDamageFixedResist, pushDamageFixedResist, pvpNeutralElementResistPercent, pvpEarthElementResistPercent, pvpWaterElementResistPercent, pvpAirElementResistPercent, pvpFireElementResistPercent, pvpNeutralElementReduction, pvpEarthElementReduction, pvpWaterElementReduction, pvpAirElementReduction, pvpFireElementReduction, dodgePALostProbability, dodgePMLostProbability, tackleBlock, tackleEvade, fixedDamageReflection, invisibilityState, meleeDamageReceivedPercent, rangedDamageReceivedPercent, weaponDamageReceivedPercent, spellDamageReceivedPercent)
        {
            this.initiative = initiative;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(initiative);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            initiative = reader.ReadVarInt();
            if (initiative < 0)
                throw new Exception("Forbidden value on initiative = " + initiative + ", it doesn't respect the following condition : initiative < 0");
        }
        
        
    }
    
}