

// Generated on 02/17/2017 01:57:50
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MountEmoteIconUsedOkMessage : Message
    {
        public const uint Id = 5978;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int mountId;
        public sbyte reactionType;
        
        public MountEmoteIconUsedOkMessage()
        {
        }
        
        public MountEmoteIconUsedOkMessage(int mountId, sbyte reactionType)
        {
            this.mountId = mountId;
            this.reactionType = reactionType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(mountId);
            writer.WriteSByte(reactionType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            mountId = reader.ReadVarInt();
            reactionType = reader.ReadSByte();
            if (reactionType < 0)
                throw new Exception("Forbidden value on reactionType = " + reactionType + ", it doesn't respect the following condition : reactionType < 0");
        }
        
    }
    
}