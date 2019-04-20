

// Generated on 02/17/2017 01:58:14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeBidHouseBuyMessage : Message
    {
        public const uint Id = 5804;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int uid;
        public int qty;
        public long price;
        
        public ExchangeBidHouseBuyMessage()
        {
        }
        
        public ExchangeBidHouseBuyMessage(int uid, int qty, long price)
        {
            this.uid = uid;
            this.qty = qty;
            this.price = price;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(uid);
            writer.WriteVarInt(qty);
            writer.WriteVarLong(price);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            uid = reader.ReadVarInt();
            if (uid < 0)
                throw new Exception("Forbidden value on uid = " + uid + ", it doesn't respect the following condition : uid < 0");
            qty = reader.ReadVarInt();
            if (qty < 0)
                throw new Exception("Forbidden value on qty = " + qty + ", it doesn't respect the following condition : qty < 0");
            price = reader.ReadVarLong();
            if (price < 0 || price > 9007199254740990)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0 || price > 9007199254740990");
        }
        
    }
    
}