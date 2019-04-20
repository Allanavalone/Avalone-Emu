using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class IdolsPresetSaveMessage : AbstractPresetSaveMessage
    {
        public const uint Id = 6603;
        public override uint MessageId
        {
            get { return Id; }
        }

        public IdolsPresetSaveMessage()
        {
        }
        
        public IdolsPresetSaveMessage(byte presetId, byte symbolId)
         : base(presetId, symbolId)
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