

// Generated on 02/17/2017 01:57:59
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PaddockToSellFilterMessage : Message
    {
        public const uint Id = 6161;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int areaId;
        public sbyte atLeastNbMount;
        public sbyte atLeastNbMachine;
        public long maxPrice;
        
        public PaddockToSellFilterMessage()
        {
        }
        
        public PaddockToSellFilterMessage(int areaId, sbyte atLeastNbMount, sbyte atLeastNbMachine, long maxPrice)
        {
            this.areaId = areaId;
            this.atLeastNbMount = atLeastNbMount;
            this.atLeastNbMachine = atLeastNbMachine;
            this.maxPrice = maxPrice;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(areaId);
            writer.WriteSByte(atLeastNbMount);
            writer.WriteSByte(atLeastNbMachine);
            writer.WriteVarLong(maxPrice);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            areaId = reader.ReadInt();
            atLeastNbMount = reader.ReadSByte();
            atLeastNbMachine = reader.ReadSByte();
            maxPrice = reader.ReadVarLong();
            if (maxPrice < 0 || maxPrice > 9007199254740990)
                throw new Exception("Forbidden value on maxPrice = " + maxPrice + ", it doesn't respect the following condition : maxPrice < 0 || maxPrice > 9007199254740990");
        }
        
    }
    
}