

// Generated on 02/17/2017 01:58:15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeCraftPaymentModificationRequestMessage : Message
    {
        public const uint Id = 6579;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long quantity;
        
        public ExchangeCraftPaymentModificationRequestMessage()
        {
        }
        
        public ExchangeCraftPaymentModificationRequestMessage(long quantity)
        {
            this.quantity = quantity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(quantity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            quantity = reader.ReadVarLong();
            if (quantity < 0 || quantity > 9007199254740990)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0 || quantity > 9007199254740990");
        }
        
    }
    
}