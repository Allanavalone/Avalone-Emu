

// Generated on 02/17/2017 01:57:50
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MountSetMessage : Message
    {
        public const uint Id = 5968;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.MountClientData mountData;
        
        public MountSetMessage()
        {
        }
        
        public MountSetMessage(Types.MountClientData mountData)
        {
            this.mountData = mountData;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            mountData.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            mountData = new Types.MountClientData();
            mountData.Deserialize(reader);
        }
        
    }
    
}