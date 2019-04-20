

// Generated on 02/17/2017 01:57:51
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PaddockBuyResultMessage : Message
    {
        public const uint Id = 6516;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int paddockId;
        public bool bought;
        public long realPrice;
        
        public PaddockBuyResultMessage()
        {
        }
        
        public PaddockBuyResultMessage(int paddockId, bool bought, long realPrice)
        {
            this.paddockId = paddockId;
            this.bought = bought;
            this.realPrice = realPrice;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(paddockId);
            writer.WriteBoolean(bought);
            writer.WriteVarLong(realPrice);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            paddockId = reader.ReadInt();
            bought = reader.ReadBoolean();
            realPrice = reader.ReadVarLong();
            if (realPrice < 0 || realPrice > 9007199254740990)
                throw new Exception("Forbidden value on realPrice = " + realPrice + ", it doesn't respect the following condition : realPrice < 0 || realPrice > 9007199254740990");
        }
        
    }
    
}