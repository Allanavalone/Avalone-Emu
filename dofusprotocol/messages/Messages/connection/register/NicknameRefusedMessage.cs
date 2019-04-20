

// Generated on 02/17/2017 01:57:33
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class NicknameRefusedMessage : Message
    {
        public const uint Id = 5638;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte reason;
        
        public NicknameRefusedMessage()
        {
        }
        
        public NicknameRefusedMessage(sbyte reason)
        {
            this.reason = reason;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(reason);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            reason = reader.ReadSByte();
        }
        
    }
    
}