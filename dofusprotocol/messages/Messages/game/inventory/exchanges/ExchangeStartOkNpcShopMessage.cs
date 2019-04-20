

// Generated on 02/17/2017 01:58:19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeStartOkNpcShopMessage : Message
    {
        public const uint Id = 5761;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double npcSellerId;
        public short tokenId;
        public IEnumerable<Types.ObjectItemToSellInNpcShop> objectsInfos;
        
        public ExchangeStartOkNpcShopMessage()
        {
        }
        
        public ExchangeStartOkNpcShopMessage(double npcSellerId, short tokenId, IEnumerable<Types.ObjectItemToSellInNpcShop> objectsInfos)
        {
            this.npcSellerId = npcSellerId;
            this.tokenId = tokenId;
            this.objectsInfos = objectsInfos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(npcSellerId);
            writer.WriteVarShort(tokenId);
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
            npcSellerId = reader.ReadDouble();
            if (npcSellerId < -9007199254740990 || npcSellerId > 9007199254740990)
                throw new Exception("Forbidden value on npcSellerId = " + npcSellerId + ", it doesn't respect the following condition : npcSellerId < -9007199254740990 || npcSellerId > 9007199254740990");
            tokenId = reader.ReadVarShort();
            if (tokenId < 0)
                throw new Exception("Forbidden value on tokenId = " + tokenId + ", it doesn't respect the following condition : tokenId < 0");
            var limit = reader.ReadShort();
            var objectsInfos_ = new Types.ObjectItemToSellInNpcShop[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos_[i] = new Types.ObjectItemToSellInNpcShop();
                 objectsInfos_[i].Deserialize(reader);
            }
            objectsInfos = objectsInfos_;
        }
        
    }
    
}