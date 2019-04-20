

// Generated on 02/17/2017 01:58:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class SpellVariantActivationMessage : Message
    {
        public const uint Id = 6705;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool result;
        public short activatedSpellId;
        public short deactivatedSpellId;
        
        public SpellVariantActivationMessage()
        {
        }
        
        public SpellVariantActivationMessage(bool result, short activatedSpellId, short deactivatedSpellId)
        {
            this.result = result;
            this.activatedSpellId = activatedSpellId;
            this.deactivatedSpellId = deactivatedSpellId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(result);
            writer.WriteVarShort(activatedSpellId);
            writer.WriteVarShort(deactivatedSpellId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            result = reader.ReadBoolean();
            activatedSpellId = reader.ReadVarShort();
            if (activatedSpellId < 0)
                throw new Exception("Forbidden value on activatedSpellId = " + activatedSpellId + ", it doesn't respect the following condition : activatedSpellId < 0");
            deactivatedSpellId = reader.ReadVarShort();
            if (deactivatedSpellId < 0)
                throw new Exception("Forbidden value on deactivatedSpellId = " + deactivatedSpellId + ", it doesn't respect the following condition : deactivatedSpellId < 0");
        }
        
    }
    
}