

// Generated on 02/17/2017 01:57:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage
    {
        public const uint Id = 5747;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long playerId;
        public IEnumerable<short> skills;
        
        public JobMultiCraftAvailableSkillsMessage()
        {
        }
        
        public JobMultiCraftAvailableSkillsMessage(bool enabled, long playerId, IEnumerable<short> skills)
         : base(enabled)
        {
            this.playerId = playerId;
            this.skills = skills;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(playerId);
            var skills_before = writer.Position;
            var skills_count = 0;
            writer.WriteShort(0);
            foreach (var entry in skills)
            {
                 writer.WriteVarShort(entry);
                 skills_count++;
            }
            var skills_after = writer.Position;
            writer.Seek((int)skills_before);
            writer.WriteShort((short)skills_count);
            writer.Seek((int)skills_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            playerId = reader.ReadVarLong();
            if (playerId < 0 || playerId > 9007199254740990)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0 || playerId > 9007199254740990");
            var limit = reader.ReadShort();
            var skills_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 skills_[i] = reader.ReadVarShort();
                 if (skills_[i] < 0)
                     throw new Exception("Forbidden value on skills_[i] = " + skills_[i] + ", it doesn't respect the following condition : skills_[i] < 0");
            }
            skills = skills_;
        }
        
    }
    
}