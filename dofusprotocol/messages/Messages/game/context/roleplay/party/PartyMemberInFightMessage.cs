

// Generated on 02/17/2017 01:58:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PartyMemberInFightMessage : AbstractPartyMessage
    {
        public const uint Id = 6342;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte reason;
        public long memberId;
        public int memberAccountId;
        public string memberName;
        public int fightId;
        public Types.MapCoordinatesExtended fightMap;
        public short timeBeforeFightStart;
        
        public PartyMemberInFightMessage()
        {
        }
        
        public PartyMemberInFightMessage(int partyId, sbyte reason, long memberId, int memberAccountId, string memberName, int fightId, Types.MapCoordinatesExtended fightMap, short timeBeforeFightStart)
         : base(partyId)
        {
            this.reason = reason;
            this.memberId = memberId;
            this.memberAccountId = memberAccountId;
            this.memberName = memberName;
            this.fightId = fightId;
            this.fightMap = fightMap;
            this.timeBeforeFightStart = timeBeforeFightStart;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(reason);
            writer.WriteVarLong(memberId);
            writer.WriteInt(memberAccountId);
            writer.WriteUTF(memberName);
            writer.WriteInt(fightId);
            fightMap.Serialize(writer);
            writer.WriteVarShort(timeBeforeFightStart);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            reason = reader.ReadSByte();
            memberId = reader.ReadVarLong();
            if (memberId < 0 || memberId > 9007199254740990)
                throw new Exception("Forbidden value on memberId = " + memberId + ", it doesn't respect the following condition : memberId < 0 || memberId > 9007199254740990");
            memberAccountId = reader.ReadInt();
            if (memberAccountId < 0)
                throw new Exception("Forbidden value on memberAccountId = " + memberAccountId + ", it doesn't respect the following condition : memberAccountId < 0");
            memberName = reader.ReadUTF();
            fightId = reader.ReadInt();
            fightMap = new Types.MapCoordinatesExtended();
            fightMap.Deserialize(reader);
            timeBeforeFightStart = reader.ReadVarShort();
        }
        
    }
    
}