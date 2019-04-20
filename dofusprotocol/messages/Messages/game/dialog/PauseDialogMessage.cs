

// Generated on 02/17/2017 01:58:06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PauseDialogMessage : Message
    {
        public const uint Id = 6012;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte dialogType;
        
        public PauseDialogMessage()
        {
        }
        
        public PauseDialogMessage(sbyte dialogType)
        {
            this.dialogType = dialogType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(dialogType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            dialogType = reader.ReadSByte();
        }
        
    }
    
}