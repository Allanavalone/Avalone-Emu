

// Generated on 02/17/2017 01:58:29
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class RawDataMessage : Message
    {
        public const uint Id = 6253;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<sbyte> content;
        
        public RawDataMessage()
        {
        }
        
        public RawDataMessage(IEnumerable<sbyte> content)
        {
            this.content = content;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)content.Count());
            foreach (var entry in content)
            {
                 writer.WriteSByte(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadVarInt();
            var content_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 content_[i] = reader.ReadSByte();
            }
            content = content_;
        }
        
    }
    
}