using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HouseGuildShareRequestMessage : Message
    {
        public const uint Id = 5704;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int houseId;
        public int instanceId;
        public bool enable;
        public int rights;
        
        public HouseGuildShareRequestMessage()
        {
        }
        
        public HouseGuildShareRequestMessage(int houseId, int instanceId, bool enable, int rights)
        {
            this.houseId = houseId;
            this.instanceId = instanceId;
            this.enable = enable;
            this.rights = rights;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(houseId);
            writer.WriteInt(instanceId);
            writer.WriteBoolean(enable);
            writer.WriteVarInt(rights);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadVarInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            instanceId = reader.ReadInt();
            if (instanceId < 0)
                throw new Exception("Forbidden value on instanceId = " + instanceId + ", it doesn't respect the following condition : instanceId < 0");
            enable = reader.ReadBoolean();
            rights = reader.ReadVarInt();
            if (rights < 0)
                throw new Exception("Forbidden value on rights = " + rights + ", it doesn't respect the following condition : rights < 0");
        }
        
    }
    
}