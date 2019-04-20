

// Generated on 02/17/2017 01:58:24
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class InventoryPresetItemUpdateRequestMessage : Message
    {
        public const uint Id = 6210;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte presetId;
        public sbyte position;
        public int objUid;
        
        public InventoryPresetItemUpdateRequestMessage()
        {
        }
        
        public InventoryPresetItemUpdateRequestMessage(sbyte presetId, sbyte position, int objUid)
        {
            this.presetId = presetId;
            this.position = position;
            this.objUid = objUid;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(presetId);
            writer.WriteSByte(position);
            writer.WriteVarInt(objUid);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            position = reader.ReadSByte();
            objUid = reader.ReadVarInt();
            if (objUid < 0)
                throw new Exception("Forbidden value on objUid = " + objUid + ", it doesn't respect the following condition : objUid < 0");
        }
        
    }
    
}