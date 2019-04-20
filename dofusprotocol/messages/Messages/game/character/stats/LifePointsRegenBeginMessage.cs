

// Generated on 02/17/2017 01:57:43
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class LifePointsRegenBeginMessage : Message
    {
        public const uint Id = 5684;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte regenRate;
        
        public LifePointsRegenBeginMessage()
        {
        }
        
        public LifePointsRegenBeginMessage(sbyte regenRate)
        {
            this.regenRate = regenRate;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(regenRate);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            regenRate = reader.ReadSByte();
            if (regenRate < 0 || regenRate > 255)
                throw new Exception("Forbidden value on regenRate = " + regenRate + ", it doesn't respect the following condition : regenRate < 0 || regenRate > 255");
        }
        
    }
    
}