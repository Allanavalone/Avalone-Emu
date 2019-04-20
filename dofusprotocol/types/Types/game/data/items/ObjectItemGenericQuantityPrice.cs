

// Generated on 02/17/2017 01:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class ObjectItemGenericQuantityPrice : ObjectItemGenericQuantity
    {
        public const short Id = 494;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public long price;
        
        public ObjectItemGenericQuantityPrice()
        {
        }
        
        public ObjectItemGenericQuantityPrice(short objectGID, int quantity, long price)
         : base(objectGID, quantity)
        {
            this.price = price;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(price);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            price = reader.ReadVarLong();
            if (price < 0 || price > 9007199254740990)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0 || price > 9007199254740990");
        }
        
        
    }
    
}