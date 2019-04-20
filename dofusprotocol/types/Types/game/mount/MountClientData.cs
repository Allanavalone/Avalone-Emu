

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class MountClientData
    {
        public const short Id = 178;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public bool sex;
        public bool isRideable;
        public bool isWild;
        public bool isFecondationReady;
        public bool useHarnessColors;
        public double id;
        public int model;
        public IEnumerable<int> ancestor;
        public IEnumerable<int> behaviors;
        public string name;
        public int ownerId;
        public long experience;
        public long experienceForLevel;
        public double experienceForNextLevel;
        public sbyte level;
        public int maxPods;
        public int stamina;
        public int staminaMax;
        public int maturity;
        public int maturityForAdult;
        public int energy;
        public int energyMax;
        public int serenity;
        public int aggressivityMax;
        public int serenityMax;
        public int love;
        public int loveMax;
        public int fecondationTime;
        public int boostLimiter;
        public double boostMax;
        public int reproductionCount;
        public int reproductionCountMax;
        public short harnessGID;
        public IEnumerable<Types.ObjectEffectInteger> effectList;
        
        public MountClientData()
        {
        }
        
        public MountClientData(bool sex, bool isRideable, bool isWild, bool isFecondationReady, bool useHarnessColors, double id, int model, IEnumerable<int> ancestor, IEnumerable<int> behaviors, string name, int ownerId, long experience, long experienceForLevel, double experienceForNextLevel, sbyte level, int maxPods, int stamina, int staminaMax, int maturity, int maturityForAdult, int energy, int energyMax, int serenity, int aggressivityMax, int serenityMax, int love, int loveMax, int fecondationTime, int boostLimiter, double boostMax, int reproductionCount, int reproductionCountMax, short harnessGID, IEnumerable<Types.ObjectEffectInteger> effectList)
        {
            this.sex = sex;
            this.isRideable = isRideable;
            this.isWild = isWild;
            this.isFecondationReady = isFecondationReady;
            this.useHarnessColors = useHarnessColors;
            this.id = id;
            this.model = model;
            this.ancestor = ancestor;
            this.behaviors = behaviors;
            this.name = name;
            this.ownerId = ownerId;
            this.experience = experience;
            this.experienceForLevel = experienceForLevel;
            this.experienceForNextLevel = experienceForNextLevel;
            this.level = level;
            this.maxPods = maxPods;
            this.stamina = stamina;
            this.staminaMax = staminaMax;
            this.maturity = maturity;
            this.maturityForAdult = maturityForAdult;
            this.energy = energy;
            this.energyMax = energyMax;
            this.serenity = serenity;
            this.aggressivityMax = aggressivityMax;
            this.serenityMax = serenityMax;
            this.love = love;
            this.loveMax = loveMax;
            this.fecondationTime = fecondationTime;
            this.boostLimiter = boostLimiter;
            this.boostMax = boostMax;
            this.reproductionCount = reproductionCount;
            this.reproductionCountMax = reproductionCountMax;
            this.harnessGID = harnessGID;
            this.effectList = effectList;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, sex);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isRideable);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, isWild);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, isFecondationReady);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 4, useHarnessColors);
            writer.WriteByte(flag1);
            writer.WriteDouble(id);
            writer.WriteVarInt(model);
            var ancestor_before = writer.Position;
            var ancestor_count = 0;
            writer.WriteShort(0);
            foreach (var entry in ancestor)
            {
                 writer.WriteInt(entry);
                 ancestor_count++;
            }
            var ancestor_after = writer.Position;
            writer.Seek((int)ancestor_before);
            writer.WriteShort((short)ancestor_count);
            writer.Seek((int)ancestor_after);

            var behaviors_before = writer.Position;
            var behaviors_count = 0;
            writer.WriteShort(0);
            foreach (var entry in behaviors)
            {
                 writer.WriteInt(entry);
                 behaviors_count++;
            }
            var behaviors_after = writer.Position;
            writer.Seek((int)behaviors_before);
            writer.WriteShort((short)behaviors_count);
            writer.Seek((int)behaviors_after);

            writer.WriteUTF(name);
            writer.WriteInt(ownerId);
            writer.WriteVarLong(experience);
            writer.WriteVarLong(experienceForLevel);
            writer.WriteDouble(experienceForNextLevel);
            writer.WriteSByte(level);
            writer.WriteVarInt(maxPods);
            writer.WriteVarInt(stamina);
            writer.WriteVarInt(staminaMax);
            writer.WriteVarInt(maturity);
            writer.WriteVarInt(maturityForAdult);
            writer.WriteVarInt(energy);
            writer.WriteVarInt(energyMax);
            writer.WriteInt(serenity);
            writer.WriteInt(aggressivityMax);
            writer.WriteVarInt(serenityMax);
            writer.WriteVarInt(love);
            writer.WriteVarInt(loveMax);
            writer.WriteInt(fecondationTime);
            writer.WriteInt(boostLimiter);
            writer.WriteDouble(boostMax);
            writer.WriteInt(reproductionCount);
            writer.WriteVarInt(reproductionCountMax);
            writer.WriteVarShort(harnessGID);
            var effectList_before = writer.Position;
            var effectList_count = 0;
            writer.WriteShort(0);
            foreach (var entry in effectList)
            {
                 entry.Serialize(writer);
                 effectList_count++;
            }
            var effectList_after = writer.Position;
            writer.Seek((int)effectList_before);
            writer.WriteShort((short)effectList_count);
            writer.Seek((int)effectList_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            sex = BooleanByteWrapper.GetFlag(flag1, 0);
            isRideable = BooleanByteWrapper.GetFlag(flag1, 1);
            isWild = BooleanByteWrapper.GetFlag(flag1, 2);
            isFecondationReady = BooleanByteWrapper.GetFlag(flag1, 3);
            useHarnessColors = BooleanByteWrapper.GetFlag(flag1, 4);
            id = reader.ReadDouble();
            if (id < -9007199254740990 || id > 9007199254740990)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < -9007199254740990 || id > 9007199254740990");
            model = reader.ReadVarInt();
            if (model < 0)
                throw new Exception("Forbidden value on model = " + model + ", it doesn't respect the following condition : model < 0");
            var limit = reader.ReadShort();
            var ancestor_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 ancestor_[i] = reader.ReadInt();
                 if (ancestor_[i] < 0)
                     throw new Exception("Forbidden value on ancestor_[i] = " + ancestor_[i] + ", it doesn't respect the following condition : ancestor_[i] < 0");
            }
            ancestor = ancestor_;
            limit = reader.ReadShort();
            var behaviors_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 behaviors_[i] = reader.ReadInt();
                 if (behaviors_[i] < 0)
                     throw new Exception("Forbidden value on behaviors_[i] = " + behaviors_[i] + ", it doesn't respect the following condition : behaviors_[i] < 0");
            }
            behaviors = behaviors_;
            name = reader.ReadUTF();
            ownerId = reader.ReadInt();
            if (ownerId < 0)
                throw new Exception("Forbidden value on ownerId = " + ownerId + ", it doesn't respect the following condition : ownerId < 0");
            experience = reader.ReadVarLong();
            if (experience < 0 || experience > 9007199254740990)
                throw new Exception("Forbidden value on experience = " + experience + ", it doesn't respect the following condition : experience < 0 || experience > 9007199254740990");
            experienceForLevel = reader.ReadVarLong();
            if (experienceForLevel < 0 || experienceForLevel > 9007199254740990)
                throw new Exception("Forbidden value on experienceForLevel = " + experienceForLevel + ", it doesn't respect the following condition : experienceForLevel < 0 || experienceForLevel > 9007199254740990");
            experienceForNextLevel = reader.ReadDouble();
            if (experienceForNextLevel < -9007199254740990 || experienceForNextLevel > 9007199254740990)
                throw new Exception("Forbidden value on experienceForNextLevel = " + experienceForNextLevel + ", it doesn't respect the following condition : experienceForNextLevel < -9007199254740990 || experienceForNextLevel > 9007199254740990");
            level = reader.ReadSByte();
            if (level < 0)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0");
            maxPods = reader.ReadVarInt();
            if (maxPods < 0)
                throw new Exception("Forbidden value on maxPods = " + maxPods + ", it doesn't respect the following condition : maxPods < 0");
            stamina = reader.ReadVarInt();
            if (stamina < 0)
                throw new Exception("Forbidden value on stamina = " + stamina + ", it doesn't respect the following condition : stamina < 0");
            staminaMax = reader.ReadVarInt();
            if (staminaMax < 0)
                throw new Exception("Forbidden value on staminaMax = " + staminaMax + ", it doesn't respect the following condition : staminaMax < 0");
            maturity = reader.ReadVarInt();
            if (maturity < 0)
                throw new Exception("Forbidden value on maturity = " + maturity + ", it doesn't respect the following condition : maturity < 0");
            maturityForAdult = reader.ReadVarInt();
            if (maturityForAdult < 0)
                throw new Exception("Forbidden value on maturityForAdult = " + maturityForAdult + ", it doesn't respect the following condition : maturityForAdult < 0");
            energy = reader.ReadVarInt();
            if (energy < 0)
                throw new Exception("Forbidden value on energy = " + energy + ", it doesn't respect the following condition : energy < 0");
            energyMax = reader.ReadVarInt();
            if (energyMax < 0)
                throw new Exception("Forbidden value on energyMax = " + energyMax + ", it doesn't respect the following condition : energyMax < 0");
            serenity = reader.ReadInt();
            aggressivityMax = reader.ReadInt();
            serenityMax = reader.ReadVarInt();
            if (serenityMax < 0)
                throw new Exception("Forbidden value on serenityMax = " + serenityMax + ", it doesn't respect the following condition : serenityMax < 0");
            love = reader.ReadVarInt();
            if (love < 0)
                throw new Exception("Forbidden value on love = " + love + ", it doesn't respect the following condition : love < 0");
            loveMax = reader.ReadVarInt();
            if (loveMax < 0)
                throw new Exception("Forbidden value on loveMax = " + loveMax + ", it doesn't respect the following condition : loveMax < 0");
            fecondationTime = reader.ReadInt();
            boostLimiter = reader.ReadInt();
            if (boostLimiter < 0)
                throw new Exception("Forbidden value on boostLimiter = " + boostLimiter + ", it doesn't respect the following condition : boostLimiter < 0");
            boostMax = reader.ReadDouble();
            if (boostMax < -9007199254740990 || boostMax > 9007199254740990)
                throw new Exception("Forbidden value on boostMax = " + boostMax + ", it doesn't respect the following condition : boostMax < -9007199254740990 || boostMax > 9007199254740990");
            reproductionCount = reader.ReadInt();
            reproductionCountMax = reader.ReadVarInt();
            if (reproductionCountMax < 0)
                throw new Exception("Forbidden value on reproductionCountMax = " + reproductionCountMax + ", it doesn't respect the following condition : reproductionCountMax < 0");
            harnessGID = reader.ReadVarShort();
            if (harnessGID < 0)
                throw new Exception("Forbidden value on harnessGID = " + harnessGID + ", it doesn't respect the following condition : harnessGID < 0");
            limit = reader.ReadShort();
            var effectList_ = new Types.ObjectEffectInteger[limit];
            for (int i = 0; i < limit; i++)
            {
                 effectList_[i] = new Types.ObjectEffectInteger();
                 effectList_[i].Deserialize(reader);
            }
            effectList = effectList_;
        }
        
        
    }
    
}