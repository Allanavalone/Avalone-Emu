

// Generated on 02/17/2017 01:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightResumeSlaveInfo
    {
        public const short Id = 364;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public double slaveId;
        public IEnumerable<Types.GameFightSpellCooldown> spellCooldowns;
        public sbyte summonCount;
        public sbyte bombCount;
        
        public GameFightResumeSlaveInfo()
        {
        }
        
        public GameFightResumeSlaveInfo(double slaveId, IEnumerable<Types.GameFightSpellCooldown> spellCooldowns, sbyte summonCount, sbyte bombCount)
        {
            this.slaveId = slaveId;
            this.spellCooldowns = spellCooldowns;
            this.summonCount = summonCount;
            this.bombCount = bombCount;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(slaveId);
            var spellCooldowns_before = writer.Position;
            var spellCooldowns_count = 0;
            writer.WriteShort(0);
            foreach (var entry in spellCooldowns)
            {
                 entry.Serialize(writer);
                 spellCooldowns_count++;
            }
            var spellCooldowns_after = writer.Position;
            writer.Seek((int)spellCooldowns_before);
            writer.WriteShort((short)spellCooldowns_count);
            writer.Seek((int)spellCooldowns_after);

            writer.WriteSByte(summonCount);
            writer.WriteSByte(bombCount);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            slaveId = reader.ReadDouble();
            if (slaveId < -9007199254740990 || slaveId > 9007199254740990)
                throw new Exception("Forbidden value on slaveId = " + slaveId + ", it doesn't respect the following condition : slaveId < -9007199254740990 || slaveId > 9007199254740990");
            var limit = reader.ReadShort();
            var spellCooldowns_ = new Types.GameFightSpellCooldown[limit];
            for (int i = 0; i < limit; i++)
            {
                 spellCooldowns_[i] = new Types.GameFightSpellCooldown();
                 spellCooldowns_[i].Deserialize(reader);
            }
            spellCooldowns = spellCooldowns_;
            summonCount = reader.ReadSByte();
            if (summonCount < 0)
                throw new Exception("Forbidden value on summonCount = " + summonCount + ", it doesn't respect the following condition : summonCount < 0");
            bombCount = reader.ReadSByte();
            if (bombCount < 0)
                throw new Exception("Forbidden value on bombCount = " + bombCount + ", it doesn't respect the following condition : bombCount < 0");
        }
        
        
    }
    
}