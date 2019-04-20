

// Generated on 02/17/2017 01:57:45
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ChatSmileyExtraPackListMessage : Message
    {
        public const uint Id = 6596;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<sbyte> packIds;
        
        public ChatSmileyExtraPackListMessage()
        {
        }
        
        public ChatSmileyExtraPackListMessage(IEnumerable<sbyte> packIds)
        {
            this.packIds = packIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var packIds_before = writer.Position;
            var packIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in packIds)
            {
                 writer.WriteSByte(entry);
                 packIds_count++;
            }
            var packIds_after = writer.Position;
            writer.Seek((int)packIds_before);
            writer.WriteShort((short)packIds_count);
            writer.Seek((int)packIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var packIds_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 packIds_[i] = reader.ReadSByte();
                 if (packIds_[i] < 0)
                     throw new Exception("Forbidden value on packIds_[i] = " + packIds_[i] + ", it doesn't respect the following condition : packIds_[i] < 0");
            }
            packIds = packIds_;
        }
        
    }
    
}