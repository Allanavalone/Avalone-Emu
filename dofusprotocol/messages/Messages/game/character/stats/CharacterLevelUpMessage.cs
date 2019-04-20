

// Generated on 02/17/2017 01:57:43
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class CharacterLevelUpMessage : Message
    {
        public const uint Id = 5670;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte newLevel;
        
        public CharacterLevelUpMessage()
        {
        }
        
        public CharacterLevelUpMessage(sbyte newLevel)
        {
            this.newLevel = newLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(newLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            newLevel = reader.ReadSByte();
            if (newLevel < 2 || newLevel > 206)
                throw new Exception("Forbidden value on newLevel = " + newLevel + ", it doesn't respect the following condition : newLevel < 2 || newLevel > 206");
        }
        
    }
    
}