

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class PaddockBuyableInformations
    {
        public const short Id = 130;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public long price;
        public bool locked;
        
        public PaddockBuyableInformations()
        {
        }
        
        public PaddockBuyableInformations(long price, bool locked)
        {
            this.price = price;
            this.locked = locked;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(price);
            writer.WriteBoolean(locked);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            price = reader.ReadVarLong();
            if (price < 0 || price > 9007199254740990)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0 || price > 9007199254740990");
            locked = reader.ReadBoolean();
        }
        
        
    }
    
}