

// Generated on 02/17/2017 01:57:53
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class EmotePlayAbstractMessage : Message
    {
        public const uint Id = 5690;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public byte emoteId;
        public double emoteStartTime;
        
        public EmotePlayAbstractMessage()
        {
        }
        
        public EmotePlayAbstractMessage(byte emoteId, double emoteStartTime)
        {
            this.emoteId = emoteId;
            this.emoteStartTime = emoteStartTime;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(emoteId);
            writer.WriteDouble(emoteStartTime);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            emoteId = reader.ReadByte();
            if (emoteId < 0 || emoteId > 255)
                throw new Exception("Forbidden value on emoteId = " + emoteId + ", it doesn't respect the following condition : emoteId < 0 || emoteId > 255");
            emoteStartTime = reader.ReadDouble();
            if (emoteStartTime < -9007199254740990 || emoteStartTime > 9007199254740990)
                throw new Exception("Forbidden value on emoteStartTime = " + emoteStartTime + ", it doesn't respect the following condition : emoteStartTime < -9007199254740990 || emoteStartTime > 9007199254740990");
        }
        
    }
    
}