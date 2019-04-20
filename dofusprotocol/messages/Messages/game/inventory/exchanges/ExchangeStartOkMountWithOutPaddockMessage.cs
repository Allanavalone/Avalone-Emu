

// Generated on 02/17/2017 01:58:19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeStartOkMountWithOutPaddockMessage : Message
    {
        public const uint Id = 5991;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.MountClientData> stabledMountsDescription;
        
        public ExchangeStartOkMountWithOutPaddockMessage()
        {
        }
        
        public ExchangeStartOkMountWithOutPaddockMessage(IEnumerable<Types.MountClientData> stabledMountsDescription)
        {
            this.stabledMountsDescription = stabledMountsDescription;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var stabledMountsDescription_before = writer.Position;
            var stabledMountsDescription_count = 0;
            writer.WriteShort(0);
            foreach (var entry in stabledMountsDescription)
            {
                 entry.Serialize(writer);
                 stabledMountsDescription_count++;
            }
            var stabledMountsDescription_after = writer.Position;
            writer.Seek((int)stabledMountsDescription_before);
            writer.WriteShort((short)stabledMountsDescription_count);
            writer.Seek((int)stabledMountsDescription_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var stabledMountsDescription_ = new Types.MountClientData[limit];
            for (int i = 0; i < limit; i++)
            {
                 stabledMountsDescription_[i] = new Types.MountClientData();
                 stabledMountsDescription_[i].Deserialize(reader);
            }
            stabledMountsDescription = stabledMountsDescription_;
        }
        
    }
    
}