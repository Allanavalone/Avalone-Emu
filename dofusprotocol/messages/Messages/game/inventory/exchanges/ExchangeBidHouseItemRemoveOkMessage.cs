

// Generated on 02/17/2017 01:58:14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeBidHouseItemRemoveOkMessage : Message
    {
        public const uint Id = 5946;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int sellerId;
        
        public ExchangeBidHouseItemRemoveOkMessage()
        {
        }
        
        public ExchangeBidHouseItemRemoveOkMessage(int sellerId)
        {
            this.sellerId = sellerId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(sellerId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            sellerId = reader.ReadInt();
        }
        
    }
    
}