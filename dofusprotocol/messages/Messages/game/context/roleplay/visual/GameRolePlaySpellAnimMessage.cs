

// Generated on 02/17/2017 01:58:05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameRolePlaySpellAnimMessage : Message
    {
        public const uint Id = 6114;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long casterId;
        public short targetCellId;
        public short spellId;
        public short spellLevel;
        
        public GameRolePlaySpellAnimMessage()
        {
        }
        
        public GameRolePlaySpellAnimMessage(long casterId, short targetCellId, short spellId, short spellLevel)
        {
            this.casterId = casterId;
            this.targetCellId = targetCellId;
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(casterId);
            writer.WriteVarShort(targetCellId);
            writer.WriteVarShort(spellId);
            writer.WriteShort(spellLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            casterId = reader.ReadVarLong();
            if (casterId < 0 || casterId > 9007199254740990)
                throw new Exception("Forbidden value on casterId = " + casterId + ", it doesn't respect the following condition : casterId < 0 || casterId > 9007199254740990");
            targetCellId = reader.ReadVarShort();
            if (targetCellId < 0 || targetCellId > 559)
                throw new Exception("Forbidden value on targetCellId = " + targetCellId + ", it doesn't respect the following condition : targetCellId < 0 || targetCellId > 559");
            spellId = reader.ReadVarShort();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            spellLevel = reader.ReadShort();
            if (spellLevel < 1 || spellLevel > 200)
                throw new Exception("Forbidden value on spellLevel = " + spellLevel + ", it doesn't respect the following condition : spellLevel < 1 || spellLevel > 200");
        }
        
    }
    
}