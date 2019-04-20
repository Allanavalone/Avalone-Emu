

// Generated on 02/17/2017 01:58:24
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class InventoryPresetUseResultMessage : Message
    {
        public const uint Id = 6163;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte presetId;
        public sbyte code;
        public IEnumerable<sbyte> unlinkedPosition;
        
        public InventoryPresetUseResultMessage()
        {
        }
        
        public InventoryPresetUseResultMessage(sbyte presetId, sbyte code, IEnumerable<sbyte> unlinkedPosition)
        {
            this.presetId = presetId;
            this.code = code;
            this.unlinkedPosition = unlinkedPosition;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(presetId);
            writer.WriteSByte(code);
            var unlinkedPosition_before = writer.Position;
            var unlinkedPosition_count = 0;
            writer.WriteShort(0);
            foreach (var entry in unlinkedPosition)
            {
                 writer.WriteSByte(entry);
                 unlinkedPosition_count++;
            }
            var unlinkedPosition_after = writer.Position;
            writer.Seek((int)unlinkedPosition_before);
            writer.WriteShort((short)unlinkedPosition_count);
            writer.Seek((int)unlinkedPosition_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            code = reader.ReadSByte();
            var limit = reader.ReadShort();
            var unlinkedPosition_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 unlinkedPosition_[i] = reader.ReadSByte();
            }
            unlinkedPosition = unlinkedPosition_;
        }
        
    }
    
}