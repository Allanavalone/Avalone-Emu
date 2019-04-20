

// Generated on 02/17/2017 01:57:51
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PaddockSellRequestMessage : Message
    {
        public const uint Id = 5953;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long price;
        public bool forSale;
        
        public PaddockSellRequestMessage()
        {
        }
        
        public PaddockSellRequestMessage(long price, bool forSale)
        {
            this.price = price;
            this.forSale = forSale;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(price);
            writer.WriteBoolean(forSale);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            price = reader.ReadVarLong();
            if (price < 0 || price > 9007199254740990)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0 || price > 9007199254740990");
            forSale = reader.ReadBoolean();
        }
        
    }
    
}