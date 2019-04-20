

// Generated on 02/17/2017 01:57:58
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ObjectGroundRemovedMultipleMessage : Message
    {
        public const uint Id = 5944;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> cells;
        
        public ObjectGroundRemovedMultipleMessage()
        {
        }
        
        public ObjectGroundRemovedMultipleMessage(IEnumerable<short> cells)
        {
            this.cells = cells;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var cells_before = writer.Position;
            var cells_count = 0;
            writer.WriteShort(0);
            foreach (var entry in cells)
            {
                 writer.WriteVarShort(entry);
                 cells_count++;
            }
            var cells_after = writer.Position;
            writer.Seek((int)cells_before);
            writer.WriteShort((short)cells_count);
            writer.Seek((int)cells_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var cells_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 cells_[i] = reader.ReadVarShort();
                 if (cells_[i] > 559)
                     throw new Exception("Forbidden value on cells_[i] = " + cells_[i] + ", it doesn't respect the following condition : cells_[i] > 559");
            }
            cells = cells_;
        }
        
    }
    
}