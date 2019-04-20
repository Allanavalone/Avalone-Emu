
// Generated on 02/17/2017 01:57:36
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public const uint Id = 1010;
        public override uint MessageId
        {
            get { return Id; }
        }

        public short spellId;
        public short spellLevel;
        public IEnumerable<short> portalsIds;

        public GameActionFightSpellCastMessage()
        {
        }

        public GameActionFightSpellCastMessage(short actionId, double sourceId, bool silentCast, bool verboseCast, double targetId, short destinationCellId, sbyte critical, short spellId, short spellLevel, IEnumerable<short> portalsIds)
         : base(actionId, sourceId, silentCast, verboseCast, targetId, destinationCellId, critical)
        {
            this.spellId = spellId;
            this.spellLevel = spellLevel;
            this.portalsIds = portalsIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(spellId);
            writer.WriteShort(spellLevel);
            var portalsIds_before = writer.Position;
            var portalsIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in portalsIds)
            {
                writer.WriteShort(entry);
                portalsIds_count++;
            }
            var portalsIds_after = writer.Position;
            writer.Seek((int)portalsIds_before);
            writer.WriteShort((short)portalsIds_count);
            writer.Seek((int)portalsIds_after);

        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            spellId = reader.ReadVarShort();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            spellLevel = reader.ReadShort();
            if (spellLevel < 1 || spellLevel > 200)
                throw new Exception("Forbidden value on spellLevel = " + spellLevel + ", it doesn't respect the following condition : spellLevel < 1 || spellLevel > 200");
            var limit = reader.ReadShort();
            var portalsIds_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                portalsIds_[i] = reader.ReadShort();
            }
            portalsIds = portalsIds_;
        }

    }
}

