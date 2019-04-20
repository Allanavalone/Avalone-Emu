

// Generated on 02/17/2017 01:58:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class SpellModifySuccessMessage : Message
    {
        public const uint Id = 6654;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int spellId;
        public short spellLevel;
        
        public SpellModifySuccessMessage()
        {
        }
        
        public SpellModifySuccessMessage(int spellId, short spellLevel)
        {
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(spellId);
            writer.WriteShort(spellLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            spellId = reader.ReadInt();
            spellLevel = reader.ReadShort();
            if (spellLevel < 1 || spellLevel > 200)
                throw new Exception("Forbidden value on spellLevel = " + spellLevel + ", it doesn't respect the following condition : spellLevel < 1 || spellLevel > 200");
        }
        
    }
    
}