

// Generated on 02/17/2017 01:57:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HavenBagDailyLoteryMessage : Message
    {
        public const uint Id = 6644;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte returnType;
        public string tokenId;
        
        public HavenBagDailyLoteryMessage()
        {
        }
        
        public HavenBagDailyLoteryMessage(sbyte returnType, string tokenId)
        {
            this.returnType = returnType;
            this.tokenId = tokenId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(returnType);
            writer.WriteUTF(tokenId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            returnType = reader.ReadSByte();
            tokenId = reader.ReadUTF();
        }
        
    }
    
}