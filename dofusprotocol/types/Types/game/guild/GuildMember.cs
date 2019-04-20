

// Generated on 02/17/2017 01:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GuildMember : CharacterMinimalInformations
    {
        public const short Id = 88;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public bool sex;
        public bool havenBagShared;
        public sbyte breed;
        public short rank;
        public long givenExperience;
        public sbyte experienceGivenPercent;
        public int rights;
        public sbyte connected;
        public sbyte alignmentSide;
        public short hoursSinceLastConnection;
        public short moodSmileyId;
        public int accountId;
        public int achievementPoints;
        public PlayerStatus status;
        
        public GuildMember()
        {
        }
        
        public GuildMember(long id, string name, sbyte level, bool sex, bool havenBagShared, sbyte breed, short rank, long givenExperience, sbyte experienceGivenPercent, int rights, sbyte connected, sbyte alignmentSide, short hoursSinceLastConnection, short moodSmileyId, int accountId, int achievementPoints, PlayerStatus status)
         : base(id, name, level)
        {
            this.sex = sex;
            this.havenBagShared = havenBagShared;
            this.breed = breed;
            this.rank = rank;
            this.givenExperience = givenExperience;
            this.experienceGivenPercent = experienceGivenPercent;
            this.rights = rights;
            this.connected = connected;
            this.alignmentSide = alignmentSide;
            this.hoursSinceLastConnection = hoursSinceLastConnection;
            this.moodSmileyId = moodSmileyId;
            this.accountId = accountId;
            this.achievementPoints = achievementPoints;
            this.status = status;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, sex);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, havenBagShared);
            writer.WriteByte(flag1);
            writer.WriteSByte(breed);
            writer.WriteVarShort(rank);
            writer.WriteVarLong(givenExperience);
            writer.WriteSByte(experienceGivenPercent);
            writer.WriteVarInt(rights);
            writer.WriteSByte(connected);
            writer.WriteSByte(alignmentSide);
            writer.WriteShort(hoursSinceLastConnection);
            writer.WriteVarShort(moodSmileyId);
            writer.WriteInt(accountId);
            writer.WriteInt(achievementPoints);
            writer.WriteShort(status.TypeId);
            status.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            sex = BooleanByteWrapper.GetFlag(flag1, 0);
            havenBagShared = BooleanByteWrapper.GetFlag(flag1, 1);
            breed = reader.ReadSByte();
            rank = reader.ReadVarShort();
            if (rank < 0)
                throw new Exception("Forbidden value on rank = " + rank + ", it doesn't respect the following condition : rank < 0");
            givenExperience = reader.ReadVarLong();
            if (givenExperience < 0 || givenExperience > 9007199254740990)
                throw new Exception("Forbidden value on givenExperience = " + givenExperience + ", it doesn't respect the following condition : givenExperience < 0 || givenExperience > 9007199254740990");
            experienceGivenPercent = reader.ReadSByte();
            if (experienceGivenPercent < 0 || experienceGivenPercent > 100)
                throw new Exception("Forbidden value on experienceGivenPercent = " + experienceGivenPercent + ", it doesn't respect the following condition : experienceGivenPercent < 0 || experienceGivenPercent > 100");
            rights = reader.ReadVarInt();
            if (rights < 0)
                throw new Exception("Forbidden value on rights = " + rights + ", it doesn't respect the following condition : rights < 0");
            connected = reader.ReadSByte();
            alignmentSide = reader.ReadSByte();
            hoursSinceLastConnection = reader.ReadShort();
            if (hoursSinceLastConnection < 0 || hoursSinceLastConnection > 65535)
                throw new Exception("Forbidden value on hoursSinceLastConnection = " + hoursSinceLastConnection + ", it doesn't respect the following condition : hoursSinceLastConnection < 0 || hoursSinceLastConnection > 65535");
            moodSmileyId = reader.ReadVarShort();
            if (moodSmileyId < 0)
                throw new Exception("Forbidden value on moodSmileyId = " + moodSmileyId + ", it doesn't respect the following condition : moodSmileyId < 0");
            accountId = reader.ReadInt();
            if (accountId < 0)
                throw new Exception("Forbidden value on accountId = " + accountId + ", it doesn't respect the following condition : accountId < 0");
            achievementPoints = reader.ReadInt();
            status = Types.ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            status.Deserialize(reader);
        }
        
        
    }
    
}