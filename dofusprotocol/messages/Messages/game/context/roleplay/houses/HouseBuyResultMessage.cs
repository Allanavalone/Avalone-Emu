using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HouseBuyResultMessage : Message
    {
        public const uint Id = 5735;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool secondHand;
        public bool bought;
        public int houseId;
        public int instanceId;
        public long realPrice;
        
        public HouseBuyResultMessage()
        {
        }
        
        public HouseBuyResultMessage(bool secondHand, bool bought, int houseId, int instanceId, long realPrice)
        {
            this.secondHand = secondHand;
            this.bought = bought;
            this.houseId = houseId;
            this.instanceId = instanceId;
            this.realPrice = realPrice;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, secondHand);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, bought);
            writer.WriteByte(flag1);
            writer.WriteVarInt(houseId);
            writer.WriteInt(instanceId);
            writer.WriteVarLong(realPrice);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            secondHand = BooleanByteWrapper.GetFlag(flag1, 0);
            bought = BooleanByteWrapper.GetFlag(flag1, 1);
            houseId = reader.ReadVarInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            instanceId = reader.ReadInt();
            if (instanceId < 0)
                throw new Exception("Forbidden value on instanceId = " + instanceId + ", it doesn't respect the following condition : instanceId < 0");
            realPrice = reader.ReadVarLong();
            if (realPrice < 0 || realPrice > 9007199254740990)
                throw new Exception("Forbidden value on realPrice = " + realPrice + ", it doesn't respect the following condition : realPrice < 0 || realPrice > 9007199254740990");
        }
        
    }
    
}