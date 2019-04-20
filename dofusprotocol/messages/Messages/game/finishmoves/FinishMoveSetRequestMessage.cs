

// Generated on 02/17/2017 01:58:07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class FinishMoveSetRequestMessage : Message
    {
        public const uint Id = 6703;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int finishMoveId;
        public bool finishMoveState;
        
        public FinishMoveSetRequestMessage()
        {
        }
        
        public FinishMoveSetRequestMessage(int finishMoveId, bool finishMoveState)
        {
            this.finishMoveId = finishMoveId;
            this.finishMoveState = finishMoveState;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(finishMoveId);
            writer.WriteBoolean(finishMoveState);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            finishMoveId = reader.ReadInt();
            if (finishMoveId < 0)
                throw new Exception("Forbidden value on finishMoveId = " + finishMoveId + ", it doesn't respect the following condition : finishMoveId < 0");
            finishMoveState = reader.ReadBoolean();
        }
        
    }
    
}