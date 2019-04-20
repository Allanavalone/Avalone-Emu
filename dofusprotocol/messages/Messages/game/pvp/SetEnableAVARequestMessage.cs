

// Generated on 02/17/2017 01:58:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class SetEnableAVARequestMessage : Message
    {
        public const uint Id = 6443;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool enable;
        
        public SetEnableAVARequestMessage()
        {
        }
        
        public SetEnableAVARequestMessage(bool enable)
        {
            this.enable = enable;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(enable);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            enable = reader.ReadBoolean();
        }
        
    }
    
}