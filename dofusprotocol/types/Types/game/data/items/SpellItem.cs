

// Generated on 02/17/2017 01:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class SpellItem : Item
    {
        public const short Id = 49;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public int spellId;
        public short spellLevel;
        
        public SpellItem()
        {
        }
        
        public SpellItem(int spellId, short spellLevel)
        {
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(spellId);
            writer.WriteShort(spellLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            spellId = reader.ReadInt();
            spellLevel = reader.ReadShort();
            if (spellLevel < 1 || spellLevel > 200)
                throw new Exception("Forbidden value on spellLevel = " + spellLevel + ", it doesn't respect the following condition : spellLevel < 1 || spellLevel > 200");
        }
        
        
    }
    
}