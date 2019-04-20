using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class IdolsPresetDeleteMessage : AbstractPresetDeleteMessage
    {
        public const uint Id = 6602;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IdolsPresetDeleteMessage()
        {
        }
        
        public IdolsPresetDeleteMessage(byte presetId)
         :base(presetId)
        {
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}