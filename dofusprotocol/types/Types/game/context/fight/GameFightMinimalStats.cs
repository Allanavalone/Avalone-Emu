using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightMinimalStats
    {
        public const short Id = 31;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int lifePoints;
        public int maxLifePoints;
        public int baseMaxLifePoints;
        public int permanentDamagePercent;
        public int shieldPoints;
        public short actionPoints;
        public short maxActionPoints;
        public short movementPoints;
        public short maxMovementPoints;
        public double summoner;
        public bool summoned;
        public short neutralElementResistPercent;
        public short earthElementResistPercent;
        public short waterElementResistPercent;
        public short airElementResistPercent;
        public short fireElementResistPercent;
        public short neutralElementReduction;
        public short earthElementReduction;
        public short waterElementReduction;
        public short airElementReduction;
        public short fireElementReduction;
        public short criticalDamageFixedResist;
        public short pushDamageFixedResist;
        public short pvpNeutralElementResistPercent;
        public short pvpEarthElementResistPercent;
        public short pvpWaterElementResistPercent;
        public short pvpAirElementResistPercent;
        public short pvpFireElementResistPercent;
        public short pvpNeutralElementReduction;
        public short pvpEarthElementReduction;
        public short pvpWaterElementReduction;
        public short pvpAirElementReduction;
        public short pvpFireElementReduction;
        public short dodgePALostProbability;
        public short dodgePMLostProbability;
        public short tackleBlock;
        public short tackleEvade;
        public short fixedDamageReflection;
        public sbyte invisibilityState;
        public short meleeDamageReceivedPercent;
        public short rangedDamageReceivedPercent;
        public short weaponDamageReceivedPercent;
        public short spellDamageReceivedPercent;

        public GameFightMinimalStats()
        {
        }
        
        public GameFightMinimalStats(int lifePoints, int maxLifePoints, int baseMaxLifePoints, int permanentDamagePercent, int shieldPoints, short actionPoints, short maxActionPoints, short movementPoints, short maxMovementPoints, double summoner, bool summoned, short neutralElementResistPercent, short earthElementResistPercent, short waterElementResistPercent, short airElementResistPercent, short fireElementResistPercent, short neutralElementReduction, short earthElementReduction, short waterElementReduction, short airElementReduction, short fireElementReduction, short criticalDamageFixedResist, short pushDamageFixedResist, short pvpNeutralElementResistPercent, short pvpEarthElementResistPercent, short pvpWaterElementResistPercent, short pvpAirElementResistPercent, short pvpFireElementResistPercent, short pvpNeutralElementReduction, short pvpEarthElementReduction, short pvpWaterElementReduction, short pvpAirElementReduction, short pvpFireElementReduction, short dodgePALostProbability, short dodgePMLostProbability, short tackleBlock, short tackleEvade, short fixedDamageReflection, sbyte invisibilityState, short meleeDamageReceivedPercent, short rangedDamageReceivedPercent, short weaponDamageReceivedPercent, short spellDamageReceivedPercent)
        {
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
            this.baseMaxLifePoints = baseMaxLifePoints;
            this.permanentDamagePercent = permanentDamagePercent;
            this.shieldPoints = shieldPoints;
            this.actionPoints = actionPoints;
            this.maxActionPoints = maxActionPoints;
            this.movementPoints = movementPoints;
            this.maxMovementPoints = maxMovementPoints;
            this.summoner = summoner;
            this.summoned = summoned;
            this.neutralElementResistPercent = neutralElementResistPercent;
            this.earthElementResistPercent = earthElementResistPercent;
            this.waterElementResistPercent = waterElementResistPercent;
            this.airElementResistPercent = airElementResistPercent;
            this.fireElementResistPercent = fireElementResistPercent;
            this.neutralElementReduction = neutralElementReduction;
            this.earthElementReduction = earthElementReduction;
            this.waterElementReduction = waterElementReduction;
            this.airElementReduction = airElementReduction;
            this.fireElementReduction = fireElementReduction;
            this.criticalDamageFixedResist = criticalDamageFixedResist;
            this.pushDamageFixedResist = pushDamageFixedResist;
            this.pvpNeutralElementResistPercent = pvpNeutralElementResistPercent;
            this.pvpEarthElementResistPercent = pvpEarthElementResistPercent;
            this.pvpWaterElementResistPercent = pvpWaterElementResistPercent;
            this.pvpAirElementResistPercent = pvpAirElementResistPercent;
            this.pvpFireElementResistPercent = pvpFireElementResistPercent;
            this.pvpNeutralElementReduction = pvpNeutralElementReduction;
            this.pvpEarthElementReduction = pvpEarthElementReduction;
            this.pvpWaterElementReduction = pvpWaterElementReduction;
            this.pvpAirElementReduction = pvpAirElementReduction;
            this.pvpFireElementReduction = pvpFireElementReduction;
            this.dodgePALostProbability = dodgePALostProbability;
            this.dodgePMLostProbability = dodgePMLostProbability;
            this.tackleBlock = tackleBlock;
            this.tackleEvade = tackleEvade;
            this.fixedDamageReflection = fixedDamageReflection;
            this.invisibilityState = invisibilityState;
            this.meleeDamageReceivedPercent = meleeDamageReceivedPercent;
            this.rangedDamageReceivedPercent = rangedDamageReceivedPercent;
            this.weaponDamageReceivedPercent = weaponDamageReceivedPercent;
            this.spellDamageReceivedPercent = spellDamageReceivedPercent;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(lifePoints);
            writer.WriteVarInt(maxLifePoints);
            writer.WriteVarInt(baseMaxLifePoints);
            writer.WriteVarInt(permanentDamagePercent);
            writer.WriteVarInt(shieldPoints);
            writer.WriteVarShort(actionPoints);
            writer.WriteVarShort(maxActionPoints);
            writer.WriteVarShort(movementPoints);
            writer.WriteVarShort(maxMovementPoints);
            writer.WriteDouble(summoner);
            writer.WriteBoolean(summoned);
            writer.WriteVarShort(neutralElementResistPercent);
            writer.WriteVarShort(earthElementResistPercent);
            writer.WriteVarShort(waterElementResistPercent);
            writer.WriteVarShort(airElementResistPercent);
            writer.WriteVarShort(fireElementResistPercent);
            writer.WriteVarShort(neutralElementReduction);
            writer.WriteVarShort(earthElementReduction);
            writer.WriteVarShort(waterElementReduction);
            writer.WriteVarShort(airElementReduction);
            writer.WriteVarShort(fireElementReduction);
            writer.WriteVarShort(criticalDamageFixedResist);
            writer.WriteVarShort(pushDamageFixedResist);
            writer.WriteVarShort(pvpNeutralElementResistPercent);
            writer.WriteVarShort(pvpEarthElementResistPercent);
            writer.WriteVarShort(pvpWaterElementResistPercent);
            writer.WriteVarShort(pvpAirElementResistPercent);
            writer.WriteVarShort(pvpFireElementResistPercent);
            writer.WriteVarShort(pvpNeutralElementReduction);
            writer.WriteVarShort(pvpEarthElementReduction);
            writer.WriteVarShort(pvpWaterElementReduction);
            writer.WriteVarShort(pvpAirElementReduction);
            writer.WriteVarShort(pvpFireElementReduction);
            writer.WriteVarShort(dodgePALostProbability);
            writer.WriteVarShort(dodgePMLostProbability);
            writer.WriteVarShort(tackleBlock);
            writer.WriteVarShort(tackleEvade);
            writer.WriteVarShort(fixedDamageReflection);
            writer.WriteSByte(invisibilityState);
            writer.WriteVarShort(meleeDamageReceivedPercent);
            writer.WriteVarShort(rangedDamageReceivedPercent);
            writer.WriteVarShort(weaponDamageReceivedPercent);
            writer.WriteVarShort(spellDamageReceivedPercent);
        }
        

        public virtual void Deserialize(IDataReader reader)
        {
            lifePoints = reader.ReadVarInt();
            if (lifePoints < 0)
                throw new Exception("Forbidden value on lifePoints = " + lifePoints + ", it doesn't respect the following condition : lifePoints < 0");
            maxLifePoints = reader.ReadVarInt();
            if (maxLifePoints < 0)
                throw new Exception("Forbidden value on maxLifePoints = " + maxLifePoints + ", it doesn't respect the following condition : maxLifePoints < 0");
            baseMaxLifePoints = reader.ReadVarInt();
            if (baseMaxLifePoints < 0)
                throw new Exception("Forbidden value on baseMaxLifePoints = " + baseMaxLifePoints + ", it doesn't respect the following condition : baseMaxLifePoints < 0");
            permanentDamagePercent = reader.ReadVarInt();
            if (permanentDamagePercent < 0)
                throw new Exception("Forbidden value on permanentDamagePercent = " + permanentDamagePercent + ", it doesn't respect the following condition : permanentDamagePercent < 0");
            shieldPoints = reader.ReadVarInt();
            if (shieldPoints < 0)
                throw new Exception("Forbidden value on shieldPoints = " + shieldPoints + ", it doesn't respect the following condition : shieldPoints < 0");
            actionPoints = reader.ReadVarShort();
            maxActionPoints = reader.ReadVarShort();
            movementPoints = reader.ReadVarShort();
            maxMovementPoints = reader.ReadVarShort();
            summoner = reader.ReadDouble();
            if (summoner < -9007199254740990 || summoner > 9007199254740990)
                throw new Exception("Forbidden value on summoner = " + summoner + ", it doesn't respect the following condition : summoner < -9007199254740990 || summoner > 9007199254740990");
            summoned = reader.ReadBoolean();
            neutralElementResistPercent = reader.ReadVarShort();
            earthElementResistPercent = reader.ReadVarShort();
            waterElementResistPercent = reader.ReadVarShort();
            airElementResistPercent = reader.ReadVarShort();
            fireElementResistPercent = reader.ReadVarShort();
            neutralElementReduction = reader.ReadVarShort();
            earthElementReduction = reader.ReadVarShort();
            waterElementReduction = reader.ReadVarShort();
            airElementReduction = reader.ReadVarShort();
            fireElementReduction = reader.ReadVarShort();
            criticalDamageFixedResist = reader.ReadVarShort();
            pushDamageFixedResist = reader.ReadVarShort();
            pvpNeutralElementResistPercent = reader.ReadVarShort();
            pvpEarthElementResistPercent = reader.ReadVarShort();
            pvpWaterElementResistPercent = reader.ReadVarShort();
            pvpAirElementResistPercent = reader.ReadVarShort();
            pvpFireElementResistPercent = reader.ReadVarShort();
            pvpNeutralElementReduction = reader.ReadVarShort();
            pvpEarthElementReduction = reader.ReadVarShort();
            pvpWaterElementReduction = reader.ReadVarShort();
            pvpAirElementReduction = reader.ReadVarShort();
            pvpFireElementReduction = reader.ReadVarShort();
            dodgePALostProbability = reader.ReadVarShort();
            if (dodgePALostProbability < 0)
                throw new Exception("Forbidden value on dodgePALostProbability = " + dodgePALostProbability + ", it doesn't respect the following condition : dodgePALostProbability < 0");
            dodgePMLostProbability = reader.ReadVarShort();
            if (dodgePMLostProbability < 0)
                throw new Exception("Forbidden value on dodgePMLostProbability = " + dodgePMLostProbability + ", it doesn't respect the following condition : dodgePMLostProbability < 0");
            tackleBlock = reader.ReadVarShort();
            tackleEvade = reader.ReadVarShort();
            fixedDamageReflection = reader.ReadVarShort();
            invisibilityState = reader.ReadSByte();
            meleeDamageReceivedPercent = reader.ReadVarShort();
            if (meleeDamageReceivedPercent < 0)
                throw new Exception("Forbidden value on meleeDamageReceivedPercent = " + meleeDamageReceivedPercent + ", it doesn't respect the following condition : meleeDamageReceivedPercent < 0");
            rangedDamageReceivedPercent = reader.ReadVarShort();
            if (rangedDamageReceivedPercent < 0)
                throw new Exception("Forbidden value on rangedDamageReceivedPercent = " + rangedDamageReceivedPercent + ", it doesn't respect the following condition : rangedDamageReceivedPercent < 0");
            weaponDamageReceivedPercent = reader.ReadVarShort();
            if (weaponDamageReceivedPercent < 0)
                throw new Exception("Forbidden value on weaponDamageReceivedPercent = " + weaponDamageReceivedPercent + ", it doesn't respect the following condition : weaponDamageReceivedPercent < 0");
            spellDamageReceivedPercent = reader.ReadVarShort();
            if (spellDamageReceivedPercent < 0)
                throw new Exception("Forbidden value on spellDamageReceivedPercent = " + spellDamageReceivedPercent + ", it doesn't respect the following condition : spellDamageReceivedPercent < 0");
        }

    }
    
}