

// Generated on 02/17/2017 01:57:59
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class DungeonPartyFinderRegisterSuccessMessage : Message
    {
        public const uint Id = 6241;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> dungeonIds;
        
        public DungeonPartyFinderRegisterSuccessMessage()
        {
        }
        
        public DungeonPartyFinderRegisterSuccessMessage(IEnumerable<short> dungeonIds)
        {
            this.dungeonIds = dungeonIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var dungeonIds_before = writer.Position;
            var dungeonIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in dungeonIds)
            {
                 writer.WriteVarShort(entry);
                 dungeonIds_count++;
            }
            var dungeonIds_after = writer.Position;
            writer.Seek((int)dungeonIds_before);
            writer.WriteShort((short)dungeonIds_count);
            writer.Seek((int)dungeonIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var dungeonIds_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 dungeonIds_[i] = reader.ReadVarShort();
                 if (dungeonIds_[i] < 0)
                     throw new Exception("Forbidden value on dungeonIds_[i] = " + dungeonIds_[i] + ", it doesn't respect the following condition : dungeonIds_[i] < 0");
            }
            dungeonIds = dungeonIds_;
        }
        
    }
    
}