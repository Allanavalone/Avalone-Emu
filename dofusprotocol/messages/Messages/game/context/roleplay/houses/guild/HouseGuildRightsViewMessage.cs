using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HouseGuildRightsViewMessage : Message
    {
        public const uint Id = 5700;
        public override uint MessageId
        {
            get { return Id; }
        }

        public int houseId;
        public int instanceId;
        
        public HouseGuildRightsViewMessage()
        {
        }

        public HouseGuildRightsViewMessage(int houseId, int instanceId)
        {
            this.houseId = houseId;
            this.instanceId = instanceId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(this.houseId);
            writer.WriteInt(this.instanceId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            this.houseId = reader.ReadInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            this.instanceId = reader.ReadInt();
            if (instanceId < 0)
                throw new Exception("Forbidden value on instanceId = " + instanceId + ", it doesn't respect the following condition : instanceId < 0");
        }
    } 
}