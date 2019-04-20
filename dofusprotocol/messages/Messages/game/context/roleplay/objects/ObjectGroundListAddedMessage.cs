

// Generated on 02/17/2017 01:57:58
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ObjectGroundListAddedMessage : Message
    {
        public const uint Id = 5925;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> cells;
        public IEnumerable<short> referenceIds;
        
        public ObjectGroundListAddedMessage()
        {
        }
        
        public ObjectGroundListAddedMessage(IEnumerable<short> cells, IEnumerable<short> referenceIds)
        {
            this.cells = cells;
            this.referenceIds = referenceIds;
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

            var referenceIds_before = writer.Position;
            var referenceIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in referenceIds)
            {
                 writer.WriteVarShort(entry);
                 referenceIds_count++;
            }
            var referenceIds_after = writer.Position;
            writer.Seek((int)referenceIds_before);
            writer.WriteShort((short)referenceIds_count);
            writer.Seek((int)referenceIds_after);

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
            limit = reader.ReadShort();
            var referenceIds_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 referenceIds_[i] = reader.ReadVarShort();
                 if (referenceIds_[i] < 0)
                     throw new Exception("Forbidden value on referenceIds_[i] = " + referenceIds_[i] + ", it doesn't respect the following condition : referenceIds_[i] < 0");
            }
            referenceIds = referenceIds_;
        }
        
    }
    
}