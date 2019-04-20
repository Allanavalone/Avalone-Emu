

// Generated on 02/17/2017 01:52:53
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations
    {
        public const short Id = 474;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte deathState;
        public short deathCount;
        public sbyte deathMaxLevel;
        
        public CharacterHardcoreOrEpicInformations()
        {
        }
        
        public CharacterHardcoreOrEpicInformations(long id, string name, sbyte level, Types.EntityLook entityLook, sbyte breed, bool sex, sbyte deathState, short deathCount, sbyte deathMaxLevel)
         : base(id, name, level, entityLook, breed, sex)
        {
            this.deathState = deathState;
            this.deathCount = deathCount;
            this.deathMaxLevel = deathMaxLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(deathState);
            writer.WriteVarShort(deathCount);
            writer.WriteSByte(deathMaxLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            deathState = reader.ReadSByte();
            deathCount = reader.ReadVarShort();
            if (deathCount < 0)
                throw new Exception("Forbidden value on deathCount = " + deathCount + ", it doesn't respect the following condition : deathCount < 0");
            deathMaxLevel = reader.ReadSByte();
            if (deathMaxLevel < 1 || deathMaxLevel > 206)
                throw new Exception("Forbidden value on deathMaxLevel = " + deathMaxLevel + ", it doesn't respect the following condition : deathMaxLevel < 1 || deathMaxLevel > 206");
        }
        
        
    }
    
}