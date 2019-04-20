

// Generated on 02/17/2017 01:58:20
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeKamaModifiedMessage : ExchangeObjectMessage
    {
        public const uint Id = 5521;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long quantity;
        
        public ExchangeKamaModifiedMessage()
        {
        }
        
        public ExchangeKamaModifiedMessage(bool remote, long quantity)
         : base(remote)
        {
            this.quantity = quantity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(quantity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            quantity = reader.ReadVarLong();
            if (quantity < 0 || quantity > 9007199254740990)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0 || quantity > 9007199254740990");
        }
        
    }
    
}