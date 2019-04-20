

// Generated on 02/17/2017 01:58:15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeCraftPaymentModifiedMessage : Message
    {
        public const uint Id = 6578;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long goldSum;
        
        public ExchangeCraftPaymentModifiedMessage()
        {
        }
        
        public ExchangeCraftPaymentModifiedMessage(long goldSum)
        {
            this.goldSum = goldSum;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(goldSum);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            goldSum = reader.ReadVarLong();
            if (goldSum < 0 || goldSum > 9007199254740990)
                throw new Exception("Forbidden value on goldSum = " + goldSum + ", it doesn't respect the following condition : goldSum < 0 || goldSum > 9007199254740990");
        }
        
    }
    
}