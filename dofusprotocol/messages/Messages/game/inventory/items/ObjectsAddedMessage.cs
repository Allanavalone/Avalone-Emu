

// Generated on 02/17/2017 01:58:22
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ObjectsAddedMessage : Message
    {
        public const uint Id = 6033;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.ObjectItem> @object;
        
        public ObjectsAddedMessage()
        {
        }
        
        public ObjectsAddedMessage(IEnumerable<Types.ObjectItem> @object)
        {
            this.@object = @object;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var @object_before = writer.Position;
            var @object_count = 0;
            writer.WriteShort(0);
            foreach (var entry in @object)
            {
                 entry.Serialize(writer);
                 @object_count++;
            }
            var @object_after = writer.Position;
            writer.Seek((int)@object_before);
            writer.WriteShort((short)@object_count);
            writer.Seek((int)@object_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var @object_ = new Types.ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 @object_[i] = new Types.ObjectItem();
                 @object_[i].Deserialize(reader);
            }
            @object = @object_;
        }
        
    }
    
}