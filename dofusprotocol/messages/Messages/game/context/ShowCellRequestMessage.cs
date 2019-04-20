

// Generated on 02/17/2017 01:57:47
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ShowCellRequestMessage : Message
    {
        public const uint Id = 5611;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short cellId;
        
        public ShowCellRequestMessage()
        {
        }
        
        public ShowCellRequestMessage(short cellId)
        {
            this.cellId = cellId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(cellId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            cellId = reader.ReadVarShort();
            if (cellId < 0 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < 0 || cellId > 559");
        }
        
    }
    
}