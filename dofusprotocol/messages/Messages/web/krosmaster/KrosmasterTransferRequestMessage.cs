

// Generated on 02/17/2017 01:58:30
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class KrosmasterTransferRequestMessage : Message
    {
        public const uint Id = 6349;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string uid;
        
        public KrosmasterTransferRequestMessage()
        {
        }
        
        public KrosmasterTransferRequestMessage(string uid)
        {
            this.uid = uid;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(uid);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            uid = reader.ReadUTF();
        }
        
    }
    
}