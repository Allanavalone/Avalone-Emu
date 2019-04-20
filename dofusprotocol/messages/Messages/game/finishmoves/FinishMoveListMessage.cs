

// Generated on 02/17/2017 01:58:06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class FinishMoveListMessage : Message
    {
        public const uint Id = 6704;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.FinishMoveInformations> finishMoves;

        public FinishMoveListMessage()
        {
        }
        
        public FinishMoveListMessage(IEnumerable<Types.FinishMoveInformations> finishMoves)
        {
            this.finishMoves = finishMoves;
        }

        public override void Serialize(IDataWriter writer)
        {
            var finishMoves_before = writer.Position;
            var finishMoves_count = 0;
            writer.WriteShort(0);
            foreach (var entry in finishMoves)
            {
                 entry.Serialize(writer);
                 finishMoves_count++;
            }
            var finishMoves_after = writer.Position;
            writer.Seek((int)finishMoves_before);
            writer.WriteShort((short)finishMoves_count);
            writer.Seek((int)finishMoves_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var finishMoves_ = new Types.FinishMoveInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 finishMoves_[i] = new Types.FinishMoveInformations();
                 finishMoves_[i].Deserialize(reader);
            }
            finishMoves = finishMoves_;
        }
        
    }
    
}