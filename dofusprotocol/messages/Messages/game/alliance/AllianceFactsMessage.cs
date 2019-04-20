

// Generated on 02/17/2017 01:57:38
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AllianceFactsMessage : Message
    {
        public const uint Id = 6414;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public AllianceFactSheetInformations infos;
        public IEnumerable<Types.GuildInAllianceInformations> guilds;
        public IEnumerable<short> controlledSubareaIds;
        public long leaderCharacterId;
        public string leaderCharacterName;
        
        public AllianceFactsMessage()
        {
        }
        
        public AllianceFactsMessage(AllianceFactSheetInformations infos, IEnumerable<Types.GuildInAllianceInformations> guilds, IEnumerable<short> controlledSubareaIds, long leaderCharacterId, string leaderCharacterName)
        {
            this.infos = infos;
            this.guilds = guilds;
            this.controlledSubareaIds = controlledSubareaIds;
            this.leaderCharacterId = leaderCharacterId;
            this.leaderCharacterName = leaderCharacterName;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(infos.TypeId);
            infos.Serialize(writer);
            var guilds_before = writer.Position;
            var guilds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in guilds)
            {
                 entry.Serialize(writer);
                 guilds_count++;
            }
            var guilds_after = writer.Position;
            writer.Seek((int)guilds_before);
            writer.WriteShort((short)guilds_count);
            writer.Seek((int)guilds_after);

            var controlledSubareaIds_before = writer.Position;
            var controlledSubareaIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in controlledSubareaIds)
            {
                 writer.WriteVarShort(entry);
                 controlledSubareaIds_count++;
            }
            var controlledSubareaIds_after = writer.Position;
            writer.Seek((int)controlledSubareaIds_before);
            writer.WriteShort((short)controlledSubareaIds_count);
            writer.Seek((int)controlledSubareaIds_after);

            writer.WriteVarLong(leaderCharacterId);
            writer.WriteUTF(leaderCharacterName);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            infos = Types.ProtocolTypeManager.GetInstance<AllianceFactSheetInformations>(reader.ReadShort());
            infos.Deserialize(reader);
            var limit = reader.ReadShort();
            var guilds_ = new Types.GuildInAllianceInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 guilds_[i] = new Types.GuildInAllianceInformations();
                 guilds_[i].Deserialize(reader);
            }
            guilds = guilds_;
            limit = reader.ReadShort();
            var controlledSubareaIds_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 controlledSubareaIds_[i] = reader.ReadVarShort();
                 if (controlledSubareaIds_[i] < 0)
                     throw new Exception("Forbidden value on controlledSubareaIds_[i] = " + controlledSubareaIds_[i] + ", it doesn't respect the following condition : controlledSubareaIds_[i] < 0");
            }
            controlledSubareaIds = controlledSubareaIds_;
            leaderCharacterId = reader.ReadVarLong();
            if (leaderCharacterId < 0 || leaderCharacterId > 9007199254740990)
                throw new Exception("Forbidden value on leaderCharacterId = " + leaderCharacterId + ", it doesn't respect the following condition : leaderCharacterId < 0 || leaderCharacterId > 9007199254740990");
            leaderCharacterName = reader.ReadUTF();
        }
        
    }
    
}