

// Generated on 02/17/2017 01:58:05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TreasureHuntFlagRequestMessage : Message
    {
        public const uint Id = 6508;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte questType;
        public sbyte index;
        
        public TreasureHuntFlagRequestMessage()
        {
        }
        
        public TreasureHuntFlagRequestMessage(sbyte questType, sbyte index)
        {
            this.questType = questType;
            this.index = index;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(questType);
            writer.WriteSByte(index);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            questType = reader.ReadSByte();
            index = reader.ReadSByte();
            if (index < 0)
                throw new Exception("Forbidden value on index = " + index + ", it doesn't respect the following condition : index < 0");
        }
        
    }
    
}