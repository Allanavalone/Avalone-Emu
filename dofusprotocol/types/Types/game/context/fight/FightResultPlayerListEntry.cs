

// Generated on 02/17/2017 01:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightResultPlayerListEntry : FightResultFighterListEntry
    {
        public const short Id = 24;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte level;
        public IEnumerable<FightResultAdditionalData> additional;
        
        public FightResultPlayerListEntry()
        {
        }
        
        public FightResultPlayerListEntry(short outcome, sbyte wave, Types.FightLoot rewards, double id, bool alive, sbyte level, IEnumerable<FightResultAdditionalData> additional)
         : base(outcome, wave, rewards, id, alive)
        {
            this.level = level;
            this.additional = additional;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(level);
            var additional_before = writer.Position;
            var additional_count = 0;
            writer.WriteShort(0);
            foreach (var entry in additional)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 additional_count++;
            }
            var additional_after = writer.Position;
            writer.Seek((int)additional_before);
            writer.WriteShort((short)additional_count);
            writer.Seek((int)additional_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            level = reader.ReadSByte();
            if (level < 1 || level > 206)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 1 || level > 206");
            var limit = reader.ReadShort();
            var additional_ = new FightResultAdditionalData[limit];
            for (int i = 0; i < limit; i++)
            {
                 additional_[i] = Types.ProtocolTypeManager.GetInstance<FightResultAdditionalData>(reader.ReadShort());
                 additional_[i].Deserialize(reader);
            }
            additional = additional_;
        }
        
        
    }
    
}