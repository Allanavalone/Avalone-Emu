

// Generated on 02/17/2017 01:57:50
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MountHarnessColorsUpdateRequestMessage : Message
    {
        public const uint Id = 6697;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool useHarnessColors;
        
        public MountHarnessColorsUpdateRequestMessage()
        {
        }
        
        public MountHarnessColorsUpdateRequestMessage(bool useHarnessColors)
        {
            this.useHarnessColors = useHarnessColors;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(useHarnessColors);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            useHarnessColors = reader.ReadBoolean();
        }
        
    }
    
}