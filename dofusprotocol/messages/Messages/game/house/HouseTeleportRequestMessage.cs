using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HouseTeleportRequestMessage : Message
    {
        public const uint Id = 6726;
        public override uint MessageId
        {
            get { return Id; }
        }

        public int houseId;
        public int houseInstanceId;

        public HouseTeleportRequestMessage()
        {
        }

        public HouseTeleportRequestMessage(int houseId, int houseInstanceId)
        {
            this.houseId = houseId;
            this.houseInstanceId = houseInstanceId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(this.houseId);
            writer.WriteInt(this.houseInstanceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.houseId = reader.ReadVarInt();
            if (this.houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            this.houseInstanceId = reader.ReadInt();
        }
    }
}