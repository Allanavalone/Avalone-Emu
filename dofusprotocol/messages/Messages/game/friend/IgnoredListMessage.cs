

// Generated on 02/17/2017 01:58:08
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class IgnoredListMessage : Message
    {
        public const uint Id = 5674;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<IgnoredInformations> ignoredList;
        
        public IgnoredListMessage()
        {
        }
        
        public IgnoredListMessage(IEnumerable<IgnoredInformations> ignoredList)
        {
            this.ignoredList = ignoredList;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var ignoredList_before = writer.Position;
            var ignoredList_count = 0;
            writer.WriteShort(0);
            foreach (var entry in ignoredList)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 ignoredList_count++;
            }
            var ignoredList_after = writer.Position;
            writer.Seek((int)ignoredList_before);
            writer.WriteShort((short)ignoredList_count);
            writer.Seek((int)ignoredList_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var ignoredList_ = new IgnoredInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 ignoredList_[i] = Types.ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadShort());
                 ignoredList_[i].Deserialize(reader);
            }
            ignoredList = ignoredList_;
        }
        
    }
    
}