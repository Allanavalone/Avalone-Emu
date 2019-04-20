

// Generated on 02/17/2017 01:58:14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeBidHouseInListAddedMessage : Message
    {
        public const uint Id = 5949;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int itemUID;
        public int objGenericId;
        public IEnumerable<ObjectEffect> effects;
        public IEnumerable<long> prices;
        
        public ExchangeBidHouseInListAddedMessage()
        {
        }
        
        public ExchangeBidHouseInListAddedMessage(int itemUID, int objGenericId, IEnumerable<ObjectEffect> effects, IEnumerable<long> prices)
        {
            this.itemUID = itemUID;
            this.objGenericId = objGenericId;
            this.effects = effects;
            this.prices = prices;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(itemUID);
            writer.WriteInt(objGenericId);
            var effects_before = writer.Position;
            var effects_count = 0;
            writer.WriteShort(0);
            foreach (var entry in effects)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 effects_count++;
            }
            var effects_after = writer.Position;
            writer.Seek((int)effects_before);
            writer.WriteShort((short)effects_count);
            writer.Seek((int)effects_after);

            var prices_before = writer.Position;
            var prices_count = 0;
            writer.WriteShort(0);
            foreach (var entry in prices)
            {
                 writer.WriteVarLong(entry);
                 prices_count++;
            }
            var prices_after = writer.Position;
            writer.Seek((int)prices_before);
            writer.WriteShort((short)prices_count);
            writer.Seek((int)prices_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            itemUID = reader.ReadInt();
            objGenericId = reader.ReadInt();
            var limit = reader.ReadShort();
            var effects_ = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                 effects_[i] = Types.ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                 effects_[i].Deserialize(reader);
            }
            effects = effects_;
            limit = reader.ReadShort();
            var prices_ = new long[limit];
            for (int i = 0; i < limit; i++)
            {
                 prices_[i] = reader.ReadVarLong();
                 if (prices_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on prices_[i] = " + prices_[i] + ", it doesn't respect the following condition : prices_[i] > 9007199254740990");
            }
            prices = prices_;
        }
        
    }
    
}