

// Generated on 02/17/2017 01:58:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ShortcutBarRemoveRequestMessage : Message
    {
        public const uint Id = 6228;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte barType;
        public sbyte slot;
        
        public ShortcutBarRemoveRequestMessage()
        {
        }
        
        public ShortcutBarRemoveRequestMessage(sbyte barType, sbyte slot)
        {
            this.barType = barType;
            this.slot = slot;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(barType);
            writer.WriteSByte(slot);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            barType = reader.ReadSByte();
            slot = reader.ReadSByte();
            if (slot < 0 || slot > 99)
                throw new Exception("Forbidden value on slot = " + slot + ", it doesn't respect the following condition : slot < 0 || slot > 99");
        }
        
    }
    
}