

// Generated on 02/17/2017 01:58:19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeStartOkHumanVendorMessage : Message
    {
        public const uint Id = 5767;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double sellerId;
        public IEnumerable<Types.ObjectItemToSellInHumanVendorShop> objectsInfos;
        
        public ExchangeStartOkHumanVendorMessage()
        {
        }
        
        public ExchangeStartOkHumanVendorMessage(double sellerId, IEnumerable<Types.ObjectItemToSellInHumanVendorShop> objectsInfos)
        {
            this.sellerId = sellerId;
            this.objectsInfos = objectsInfos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(sellerId);
            var objectsInfos_before = writer.Position;
            var objectsInfos_count = 0;
            writer.WriteShort(0);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
                 objectsInfos_count++;
            }
            var objectsInfos_after = writer.Position;
            writer.Seek((int)objectsInfos_before);
            writer.WriteShort((short)objectsInfos_count);
            writer.Seek((int)objectsInfos_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            sellerId = reader.ReadDouble();
            if (sellerId < -9007199254740990 || sellerId > 9007199254740990)
                throw new Exception("Forbidden value on sellerId = " + sellerId + ", it doesn't respect the following condition : sellerId < -9007199254740990 || sellerId > 9007199254740990");
            var limit = reader.ReadShort();
            var objectsInfos_ = new Types.ObjectItemToSellInHumanVendorShop[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos_[i] = new Types.ObjectItemToSellInHumanVendorShop();
                 objectsInfos_[i].Deserialize(reader);
            }
            objectsInfos = objectsInfos_;
        }
        
    }
    
}