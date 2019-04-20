

// Generated on 02/17/2017 01:57:33
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class DebugHighlightCellsMessage : Message
    {
        public const uint Id = 2001;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int color;
        public IEnumerable<short> cells;
        
        public DebugHighlightCellsMessage()
        {
        }
        
        public DebugHighlightCellsMessage(int color, IEnumerable<short> cells)
        {
            this.color = color;
            this.cells = cells;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(color);
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
            color = reader.ReadInt();
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