

// Generated on 02/17/2017 01:57:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class JobAllowMultiCraftRequestMessage : Message
    {
        public const uint Id = 5748;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool enabled;
        
        public JobAllowMultiCraftRequestMessage()
        {
        }
        
        public JobAllowMultiCraftRequestMessage(bool enabled)
        {
            this.enabled = enabled;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(enabled);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            enabled = reader.ReadBoolean();
        }
        
    }
    
}