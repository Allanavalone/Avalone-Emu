

// Generated on 02/17/2017 01:57:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HavenBagPermissionsUpdateRequestMessage : Message
    {
        public const uint Id = 6714;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int permissions;
        
        public HavenBagPermissionsUpdateRequestMessage()
        {
        }
        
        public HavenBagPermissionsUpdateRequestMessage(int permissions)
        {
            this.permissions = permissions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(permissions);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            permissions = reader.ReadInt();
            if (permissions < 0)
                throw new Exception("Forbidden value on permissions = " + permissions + ", it doesn't respect the following condition : permissions < 0");
        }
        
    }
    
}