using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AbstractPresetDeleteMessage : Message
    {
        public const uint Id = 6735;
        public override uint MessageId
        {
            get { return Id; }
        }

        public byte presetId;

        public AbstractPresetDeleteMessage()
        {
        }

        public AbstractPresetDeleteMessage(byte presetId)
        {
            this.presetId = presetId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(this.presetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.presetId = reader.ReadByte();
            if (this.presetId < 0)
                throw new Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
        }

    }

}