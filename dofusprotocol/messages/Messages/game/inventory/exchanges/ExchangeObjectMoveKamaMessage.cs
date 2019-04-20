

// Generated on 02/17/2017 01:58:16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeObjectMoveKamaMessage : Message
    {
        public const uint Id = 5520;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long quantity;
        
        public ExchangeObjectMoveKamaMessage()
        {
        }
        
        public ExchangeObjectMoveKamaMessage(long quantity)
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
            if (quantity < -9007199254740990 || quantity > 9007199254740990)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < -9007199254740990 || quantity > 9007199254740990");
        }
        
    }
    
}