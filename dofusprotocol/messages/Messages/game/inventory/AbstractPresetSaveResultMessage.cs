using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AbstractPresetSaveResultMessage : Message
    {
        public const uint Id = 6734;
        public override uint MessageId
        {
            get { return Id; }
        }

        public byte presetId;
        public byte code = 2;

        public AbstractPresetSaveResultMessage()
        {
        }

        public AbstractPresetSaveResultMessage(byte presetId, byte code)
        {
            this.presetId = presetId;
            this.code = code;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(this.presetId);
            writer.WriteByte(this.code);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.presetId = reader.ReadByte();
            if (this.presetId < 0)
                throw new Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            this.code = reader.ReadByte();
            if (this.code < 0)
                throw new Exception("Forbidden value on code = " + code + ", it doesn't respect the following condition : code < 0");
        }

    }

}