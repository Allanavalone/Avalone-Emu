

// Generated on 02/17/2017 01:58:17
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeObjectTransfertListWithQuantityToInvMessage : Message
    {
        public const uint Id = 6470;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<int> ids;
        public IEnumerable<int> qtys;
        
        public ExchangeObjectTransfertListWithQuantityToInvMessage()
        {
        }
        
        public ExchangeObjectTransfertListWithQuantityToInvMessage(IEnumerable<int> ids, IEnumerable<int> qtys)
        {
            this.ids = ids;
            this.qtys = qtys;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var ids_before = writer.Position;
            var ids_count = 0;
            writer.WriteShort(0);
            foreach (var entry in ids)
            {
                 writer.WriteVarInt(entry);
                 ids_count++;
            }
            var ids_after = writer.Position;
            writer.Seek((int)ids_before);
            writer.WriteShort((short)ids_count);
            writer.Seek((int)ids_after);

            var qtys_before = writer.Position;
            var qtys_count = 0;
            writer.WriteShort(0);
            foreach (var entry in qtys)
            {
                 writer.WriteVarInt(entry);
                 qtys_count++;
            }
            var qtys_after = writer.Position;
            writer.Seek((int)qtys_before);
            writer.WriteShort((short)qtys_count);
            writer.Seek((int)qtys_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var ids_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 ids_[i] = reader.ReadVarInt();
                 if (ids_[i] < 0)
                     throw new Exception("Forbidden value on ids_[i] = " + ids_[i] + ", it doesn't respect the following condition : ids_[i] < 0");
            }
            ids = ids_;
            limit = reader.ReadShort();
            var qtys_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 qtys_[i] = reader.ReadVarInt();
                 if (qtys_[i] < 0)
                     throw new Exception("Forbidden value on qtys_[i] = " + qtys_[i] + ", it doesn't respect the following condition : qtys_[i] < 0");
            }
            qtys = qtys_;
        }
        
    }
    
}