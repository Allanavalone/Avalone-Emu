

// Generated on 02/17/2017 01:58:10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GuildPaddockRemovedMessage : Message
    {
        public const uint Id = 5955;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int paddockId;
        
        public GuildPaddockRemovedMessage()
        {
        }
        
        public GuildPaddockRemovedMessage(int paddockId)
        {
            this.paddockId = paddockId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(paddockId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            paddockId = reader.ReadInt();
        }
        
    }
    
}