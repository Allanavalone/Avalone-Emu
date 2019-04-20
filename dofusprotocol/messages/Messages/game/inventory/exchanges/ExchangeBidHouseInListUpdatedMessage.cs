

// Generated on 02/17/2017 01:58:14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage
    {
        public const uint Id = 6337;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        
        public ExchangeBidHouseInListUpdatedMessage()
        {
        }
        
        public ExchangeBidHouseInListUpdatedMessage(int itemUID, int objGenericId, IEnumerable<ObjectEffect> effects, IEnumerable<long> prices)
         : base(itemUID, objGenericId, effects, prices)
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