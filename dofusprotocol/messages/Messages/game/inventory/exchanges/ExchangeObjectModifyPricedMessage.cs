

// Generated on 02/17/2017 01:58:16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeObjectModifyPricedMessage : ExchangeObjectMovePricedMessage
    {
        public const uint Id = 6238;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        
        public ExchangeObjectModifyPricedMessage()
        {
        }
        
        public ExchangeObjectModifyPricedMessage(int objectUID, int quantity, long price)
         : base(objectUID, quantity, price)
        {
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
        
    }
    
}