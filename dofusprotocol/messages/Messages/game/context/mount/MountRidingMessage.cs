

// Generated on 02/17/2017 01:57:50
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MountRidingMessage : Message
    {
        public const uint Id = 5967;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool isRiding;
        
        public MountRidingMessage()
        {
        }
        
        public MountRidingMessage(bool isRiding)
        {
            this.isRiding = isRiding;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(isRiding);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            isRiding = reader.ReadBoolean();
        }
        
    }
    
}