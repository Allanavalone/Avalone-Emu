

// Generated on 02/17/2017 01:57:47
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightPlacementSwapPositionsAcceptMessage : Message
    {
        public const uint Id = 6547;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int requestId;
        
        public GameFightPlacementSwapPositionsAcceptMessage()
        {
        }
        
        public GameFightPlacementSwapPositionsAcceptMessage(int requestId)
        {
            this.requestId = requestId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(requestId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            requestId = reader.ReadInt();
            if (requestId < 0)
                throw new Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0");
        }
        
    }
    
}