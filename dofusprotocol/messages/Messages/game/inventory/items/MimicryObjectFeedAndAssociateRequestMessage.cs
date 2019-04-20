

// Generated on 02/17/2017 01:58:21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MimicryObjectFeedAndAssociateRequestMessage : SymbioticObjectAssociateRequestMessage
    {
        public const uint Id = 6460;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int foodUID;
        public sbyte foodPos;
        public bool preview;
        
        public MimicryObjectFeedAndAssociateRequestMessage()
        {
        }
        
        public MimicryObjectFeedAndAssociateRequestMessage(int symbioteUID, sbyte symbiotePos, int hostUID, sbyte hostPos, int foodUID, sbyte foodPos, bool preview)
         : base(symbioteUID, symbiotePos, hostUID, hostPos)
        {
            this.foodUID = foodUID;
            this.foodPos = foodPos;
            this.preview = preview;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(foodUID);
            writer.WriteSByte(foodPos);
            writer.WriteBoolean(preview);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            foodUID = reader.ReadVarInt();
            if (foodUID < 0)
                throw new Exception("Forbidden value on foodUID = " + foodUID + ", it doesn't respect the following condition : foodUID < 0");
            foodPos = reader.ReadSByte();
            if (foodPos < 0 || foodPos > 255)
                throw new Exception("Forbidden value on foodPos = " + foodPos + ", it doesn't respect the following condition : foodPos < 0 || foodPos > 255");
            preview = reader.ReadBoolean();
        }
        
    }
    
}