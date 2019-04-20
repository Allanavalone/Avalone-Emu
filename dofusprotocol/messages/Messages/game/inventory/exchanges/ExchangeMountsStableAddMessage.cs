

// Generated on 02/17/2017 01:58:16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeMountsStableAddMessage : Message
    {
        public const uint Id = 6555;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.MountClientData> mountDescription;
        
        public ExchangeMountsStableAddMessage()
        {
        }
        
        public ExchangeMountsStableAddMessage(IEnumerable<Types.MountClientData> mountDescription)
        {
            this.mountDescription = mountDescription;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var mountDescription_before = writer.Position;
            var mountDescription_count = 0;
            writer.WriteShort(0);
            foreach (var entry in mountDescription)
            {
                 entry.Serialize(writer);
                 mountDescription_count++;
            }
            var mountDescription_after = writer.Position;
            writer.Seek((int)mountDescription_before);
            writer.WriteShort((short)mountDescription_count);
            writer.Seek((int)mountDescription_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var mountDescription_ = new Types.MountClientData[limit];
            for (int i = 0; i < limit; i++)
            {
                 mountDescription_[i] = new Types.MountClientData();
                 mountDescription_[i].Deserialize(reader);
            }
            mountDescription = mountDescription_;
        }
        
    }
    
}