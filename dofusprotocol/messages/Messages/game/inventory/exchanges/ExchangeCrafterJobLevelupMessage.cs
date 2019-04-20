

// Generated on 02/17/2017 01:58:15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeCrafterJobLevelupMessage : Message
    {
        public const uint Id = 6598;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte crafterJobLevel;
        
        public ExchangeCrafterJobLevelupMessage()
        {
        }
        
        public ExchangeCrafterJobLevelupMessage(sbyte crafterJobLevel)
        {
            this.crafterJobLevel = crafterJobLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(crafterJobLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            crafterJobLevel = reader.ReadSByte();
            if (crafterJobLevel < 0 || crafterJobLevel > 255)
                throw new Exception("Forbidden value on crafterJobLevel = " + crafterJobLevel + ", it doesn't respect the following condition : crafterJobLevel < 0 || crafterJobLevel > 255");
        }
        
    }
    
}