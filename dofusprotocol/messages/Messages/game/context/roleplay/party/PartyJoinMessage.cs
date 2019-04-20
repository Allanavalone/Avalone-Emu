

// Generated on 02/17/2017 01:58:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PartyJoinMessage : AbstractPartyMessage
    {
        public const uint Id = 5576;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte partyType;
        public long partyLeaderId;
        public sbyte maxParticipants;
        public IEnumerable<PartyMemberInformations> members;
        public IEnumerable<Types.PartyGuestInformations> guests;
        public bool restricted;
        public string partyName;
        
        public PartyJoinMessage()
        {
        }
        
        public PartyJoinMessage(int partyId, sbyte partyType, long partyLeaderId, sbyte maxParticipants, IEnumerable<PartyMemberInformations> members, IEnumerable<Types.PartyGuestInformations> guests, bool restricted, string partyName)
         : base(partyId)
        {
            this.partyType = partyType;
            this.partyLeaderId = partyLeaderId;
            this.maxParticipants = maxParticipants;
            this.members = members;
            this.guests = guests;
            this.restricted = restricted;
            this.partyName = partyName;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(partyType);
            writer.WriteVarLong(partyLeaderId);
            writer.WriteSByte(maxParticipants);
            var members_before = writer.Position;
            var members_count = 0;
            writer.WriteShort(0);
            foreach (var entry in members)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 members_count++;
            }
            var members_after = writer.Position;
            writer.Seek((int)members_before);
            writer.WriteShort((short)members_count);
            writer.Seek((int)members_after);

            var guests_before = writer.Position;
            var guests_count = 0;
            writer.WriteShort(0);
            foreach (var entry in guests)
            {
                 entry.Serialize(writer);
                 guests_count++;
            }
            var guests_after = writer.Position;
            writer.Seek((int)guests_before);
            writer.WriteShort((short)guests_count);
            writer.Seek((int)guests_after);

            writer.WriteBoolean(restricted);
            writer.WriteUTF(partyName);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            partyType = reader.ReadSByte();
            partyLeaderId = reader.ReadVarLong();
            if (partyLeaderId < 0 || partyLeaderId > 9007199254740990)
                throw new Exception("Forbidden value on partyLeaderId = " + partyLeaderId + ", it doesn't respect the following condition : partyLeaderId < 0 || partyLeaderId > 9007199254740990");
            maxParticipants = reader.ReadSByte();
            if (maxParticipants < 0)
                throw new Exception("Forbidden value on maxParticipants = " + maxParticipants + ", it doesn't respect the following condition : maxParticipants < 0");
            var limit = reader.ReadShort();
            var members_ = new PartyMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 members_[i] = Types.ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadShort());
                 members_[i].Deserialize(reader);
            }
            members = members_;
            limit = reader.ReadShort();
            var guests_ = new Types.PartyGuestInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 guests_[i] = new Types.PartyGuestInformations();
                 guests_[i].Deserialize(reader);
            }
            guests = guests_;
            restricted = reader.ReadBoolean();
            partyName = reader.ReadUTF();
        }
        
    }
    
}