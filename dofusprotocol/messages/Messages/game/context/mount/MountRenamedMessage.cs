

// Generated on 02/17/2017 01:57:50
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MountRenamedMessage : Message
    {
        public const uint Id = 5983;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int mountId;
        public string name;
        
        public MountRenamedMessage()
        {
        }
        
        public MountRenamedMessage(int mountId, string name)
        {
            this.mountId = mountId;
            this.name = name;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(mountId);
            writer.WriteUTF(name);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            mountId = reader.ReadVarInt();
            name = reader.ReadUTF();
        }
        
    }
    
}