

// Generated on 02/17/2017 01:57:59
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameDataPlayFarmObjectAnimationMessage : Message
    {
        public const uint Id = 6026;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> cellId;
        
        public GameDataPlayFarmObjectAnimationMessage()
        {
        }
        
        public GameDataPlayFarmObjectAnimationMessage(IEnumerable<short> cellId)
        {
            this.cellId = cellId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var cellId_before = writer.Position;
            var cellId_count = 0;
            writer.WriteShort(0);
            foreach (var entry in cellId)
            {
                 writer.WriteVarShort(entry);
                 cellId_count++;
            }
            var cellId_after = writer.Position;
            writer.Seek((int)cellId_before);
            writer.WriteShort((short)cellId_count);
            writer.Seek((int)cellId_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var cellId_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 cellId_[i] = reader.ReadVarShort();
                 if (cellId_[i] > 559)
                     throw new Exception("Forbidden value on cellId_[i] = " + cellId_[i] + ", it doesn't respect the following condition : cellId_[i] > 559");
            }
            cellId = cellId_;
        }
        
    }
    
}