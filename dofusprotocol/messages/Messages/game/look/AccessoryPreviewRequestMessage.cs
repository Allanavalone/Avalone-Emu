

// Generated on 02/17/2017 01:58:24
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AccessoryPreviewRequestMessage : Message
    {
        public const uint Id = 6518;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> genericId;
        
        public AccessoryPreviewRequestMessage()
        {
        }
        
        public AccessoryPreviewRequestMessage(IEnumerable<short> genericId)
        {
            this.genericId = genericId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var genericId_before = writer.Position;
            var genericId_count = 0;
            writer.WriteShort(0);
            foreach (var entry in genericId)
            {
                 writer.WriteVarShort(entry);
                 genericId_count++;
            }
            var genericId_after = writer.Position;
            writer.Seek((int)genericId_before);
            writer.WriteShort((short)genericId_count);
            writer.Seek((int)genericId_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var genericId_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 genericId_[i] = reader.ReadVarShort();
                 if (genericId_[i] < 0)
                     throw new Exception("Forbidden value on genericId_[i] = " + genericId_[i] + ", it doesn't respect the following condition : genericId_[i] < 0");
            }
            genericId = genericId_;
        }
        
    }
    
}