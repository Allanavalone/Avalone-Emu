

// Generated on 02/17/2017 01:58:19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeWeightMessage : Message
    {
        public const uint Id = 5793;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int currentWeight;
        public int maxWeight;
        
        public ExchangeWeightMessage()
        {
        }
        
        public ExchangeWeightMessage(int currentWeight, int maxWeight)
        {
            this.currentWeight = currentWeight;
            this.maxWeight = maxWeight;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(currentWeight);
            writer.WriteVarInt(maxWeight);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            currentWeight = reader.ReadVarInt();
            if (currentWeight < 0)
                throw new Exception("Forbidden value on currentWeight = " + currentWeight + ", it doesn't respect the following condition : currentWeight < 0");
            maxWeight = reader.ReadVarInt();
            if (maxWeight < 0)
                throw new Exception("Forbidden value on maxWeight = " + maxWeight + ", it doesn't respect the following condition : maxWeight < 0");
        }
        
    }
    
}