

// Generated on 02/17/2017 01:57:49
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightTurnFinishMessage : Message
    {
        public const uint Id = 718;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool isAfk;
        
        public GameFightTurnFinishMessage()
        {
        }
        
        public GameFightTurnFinishMessage(bool isAfk)
        {
            this.isAfk = isAfk;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(isAfk);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            isAfk = reader.ReadBoolean();
        }
        
    }
    
}