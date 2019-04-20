

// Generated on 02/17/2017 01:58:24
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class StorageKamasUpdateMessage : Message
    {
        public const uint Id = 5645;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long kamasTotal;
        
        public StorageKamasUpdateMessage()
        {
        }
        
        public StorageKamasUpdateMessage(long kamasTotal)
        {
            this.kamasTotal = kamasTotal;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(kamasTotal);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            kamasTotal = reader.ReadVarLong();
            if (kamasTotal < 0 || kamasTotal > 9007199254740990)
                throw new Exception("Forbidden value on kamasTotal = " + kamasTotal + ", it doesn't respect the following condition : kamasTotal < 0 || kamasTotal > 9007199254740990");
        }
        
    }
    
}