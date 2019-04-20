using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HouseSellingUpdateMessage : Message
    {
        public const uint Id = 6727;
        public override uint MessageId
        {
            get { return Id; }
        }

        public int houseId;
        public int instanceId;
        public bool secondHand;
        public long realPrice;
        public string buyerName;

        public HouseSellingUpdateMessage()
        {
        }

        public HouseSellingUpdateMessage(int houseId, int instanceId, bool secondHand, long realPrice, string buyerName)
        {
            this.houseId = houseId;
            this.instanceId = instanceId;
            this.secondHand = secondHand;
            this.realPrice = realPrice;
            this.buyerName = buyerName;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(this.houseId);
            writer.WriteInt(this.instanceId);
            writer.WriteBoolean(this.secondHand);
            writer.WriteVarLong(this.realPrice);
            writer.WriteUTF(this.buyerName);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.houseId = reader.ReadVarInt();
            if (this.houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            this.instanceId = reader.ReadInt();
            if (this.instanceId < 0)
                throw new Exception("Forbidden value on instanceId = " + instanceId + ", it doesn't respect the following condition : instanceId < 0");
            this.secondHand = reader.ReadBoolean();
            this.realPrice = reader.ReadVarLong();
            if (this.realPrice < 0 || this.realPrice > 9007199254740992)
                throw new Exception("Forbidden value on realPrice = " + realPrice + ", it doesn't respect the following condition : realPrice < 0 || realPrice > 9007199254740992");
            this.buyerName = reader.ReadUTF();
        }
    }
}
