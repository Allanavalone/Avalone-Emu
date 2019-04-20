

// Generated on 02/17/2017 01:58:05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TreasureHuntRequestMessage : Message
    {
        public const uint Id = 6488;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte questLevel;
        public sbyte questType;
        
        public TreasureHuntRequestMessage()
        {
        }
        
        public TreasureHuntRequestMessage(sbyte questLevel, sbyte questType)
        {
            this.questLevel = questLevel;
            this.questType = questType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(questLevel);
            writer.WriteSByte(questType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            questLevel = reader.ReadSByte();
            if (questLevel < 1 || questLevel > 206)
                throw new Exception("Forbidden value on questLevel = " + questLevel + ", it doesn't respect the following condition : questLevel < 1 || questLevel > 206");
            questType = reader.ReadSByte();
        }
        
    }
    
}