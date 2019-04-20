using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AbstractPresetSaveMessage : Message
    {
        public const uint Id = 6736;
        public override uint MessageId
        {
            get { return Id; }
        }

        public byte presetId;
        public byte symbolId;

        public AbstractPresetSaveMessage()
        {
        }

        public AbstractPresetSaveMessage(byte presetId, byte symbolId)
        {
            this.presetId = presetId;
            this.symbolId = symbolId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(this.presetId);
            writer.WriteByte(this.symbolId);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.presetId = reader.ReadByte();
            if (this.presetId < 0)
                throw new Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            this.symbolId = reader.ReadByte();
            if (this.symbolId < 0)
                throw new Exception("Forbidden value on symbolId = " + symbolId + ", it doesn't respect the following condition : symbolId < 0");
        }

    }

}