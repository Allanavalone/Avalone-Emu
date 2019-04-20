using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PurchasableDialogMessage : Message
    {
        public const uint Id = 5739;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool buyOrSell;
        public bool secondHand;
        public int purchasableId;
        public int purchasableInstanceId;
        public long price;
        
        public PurchasableDialogMessage()
        {
        }
        
        public PurchasableDialogMessage(bool buyOrSell, bool secondHand, int purchasableId, int purchasableInstanceId, long price)
        {
            this.buyOrSell = buyOrSell;
            this.secondHand = secondHand;
            this.purchasableId = purchasableId;
            this.purchasableInstanceId = purchasableInstanceId;
            this.price = price;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, buyOrSell);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, secondHand);
            writer.WriteByte(flag1);
            writer.WriteVarInt(purchasableId);
            writer.WriteInt(purchasableInstanceId);
            writer.WriteVarLong(price);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            buyOrSell = BooleanByteWrapper.GetFlag(flag1, 0);
            secondHand = BooleanByteWrapper.GetFlag(flag1, 1);
            purchasableId = reader.ReadVarInt();
            if (purchasableId < 0)
                throw new Exception("Forbidden value on purchasableId = " + purchasableId + ", it doesn't respect the following condition : purchasableId < 0");
            purchasableInstanceId = reader.ReadInt();
            if (purchasableInstanceId < 0)
                throw new Exception("Forbidden value on purchasableInstanceId = " + purchasableInstanceId + ", it doesn't respect the following condition : purchasableInstanceId < 0 || purchasableInstanceId > 4294967295");
            price = reader.ReadVarLong();
            if (price < 0 || price > 9007199254740990)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0 || price > 9007199254740990");
        }
        
    }
    
}