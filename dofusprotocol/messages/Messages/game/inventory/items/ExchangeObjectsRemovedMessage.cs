

// Generated on 02/17/2017 01:58:20
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeObjectsRemovedMessage : ExchangeObjectMessage
    {
        public const uint Id = 6532;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<int> objectUID;
        
        public ExchangeObjectsRemovedMessage()
        {
        }
        
        public ExchangeObjectsRemovedMessage(bool remote, IEnumerable<int> objectUID)
         : base(remote)
        {
            this.objectUID = objectUID;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var objectUID_before = writer.Position;
            var objectUID_count = 0;
            writer.WriteShort(0);
            foreach (var entry in objectUID)
            {
                 writer.WriteVarInt(entry);
                 objectUID_count++;
            }
            var objectUID_after = writer.Position;
            writer.Seek((int)objectUID_before);
            writer.WriteShort((short)objectUID_count);
            writer.Seek((int)objectUID_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var objectUID_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectUID_[i] = reader.ReadVarInt();
                 if (objectUID_[i] < 0)
                     throw new Exception("Forbidden value on objectUID_[i] = " + objectUID_[i] + ", it doesn't respect the following condition : objectUID_[i] < 0");
            }
            objectUID = objectUID_;
        }
        
    }
    
}