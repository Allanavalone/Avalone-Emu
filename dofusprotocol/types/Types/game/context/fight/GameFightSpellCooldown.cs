

// Generated on 02/17/2017 01:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightSpellCooldown
    {
        public const short Id = 205;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int spellId;
        public sbyte cooldown;
        
        public GameFightSpellCooldown()
        {
        }
        
        public GameFightSpellCooldown(int spellId, sbyte cooldown)
        {
            this.spellId = spellId;
            this.cooldown = cooldown;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(spellId);
            writer.WriteSByte(cooldown);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            spellId = reader.ReadInt();
            cooldown = reader.ReadSByte();
            if (cooldown < 0)
                throw new Exception("Forbidden value on cooldown = " + cooldown + ", it doesn't respect the following condition : cooldown < 0");
        }
        
        
    }
    
}