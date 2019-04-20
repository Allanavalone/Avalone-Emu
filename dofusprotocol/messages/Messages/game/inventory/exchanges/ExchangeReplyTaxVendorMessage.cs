

// Generated on 02/17/2017 01:58:17
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeReplyTaxVendorMessage : Message
    {
        public const uint Id = 5787;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long objectValue;
        public long totalTaxValue;
        
        public ExchangeReplyTaxVendorMessage()
        {
        }
        
        public ExchangeReplyTaxVendorMessage(long objectValue, long totalTaxValue)
        {
            this.objectValue = objectValue;
            this.totalTaxValue = totalTaxValue;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(objectValue);
            writer.WriteVarLong(totalTaxValue);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            objectValue = reader.ReadVarLong();
            if (objectValue < 0 || objectValue > 9007199254740990)
                throw new Exception("Forbidden value on objectValue = " + objectValue + ", it doesn't respect the following condition : objectValue < 0 || objectValue > 9007199254740990");
            totalTaxValue = reader.ReadVarLong();
            if (totalTaxValue < 0 || totalTaxValue > 9007199254740990)
                throw new Exception("Forbidden value on totalTaxValue = " + totalTaxValue + ", it doesn't respect the following condition : totalTaxValue < 0 || totalTaxValue > 9007199254740990");
        }
        
    }
    
}