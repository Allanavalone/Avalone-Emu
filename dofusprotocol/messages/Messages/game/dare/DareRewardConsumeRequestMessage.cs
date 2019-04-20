

// Generated on 02/17/2017 01:58:06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class DareRewardConsumeRequestMessage : Message
    {
        public const uint Id = 6676;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double dareId;
        public sbyte type;
        
        public DareRewardConsumeRequestMessage()
        {
        }
        
        public DareRewardConsumeRequestMessage(double dareId, sbyte type)
        {
            this.dareId = dareId;
            this.type = type;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(dareId);
            writer.WriteSByte(type);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            dareId = reader.ReadDouble();
            if (dareId < -9007199254740990 || dareId > 9007199254740990)
                throw new Exception("Forbidden value on dareId = " + dareId + ", it doesn't respect the following condition : dareId < -9007199254740990 || dareId > 9007199254740990");
            type = reader.ReadSByte();
        }
        
    }
    
}