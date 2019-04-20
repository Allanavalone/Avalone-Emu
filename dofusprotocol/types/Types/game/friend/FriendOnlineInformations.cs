

// Generated on 02/17/2017 01:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FriendOnlineInformations : FriendInformations
    {
        public const short Id = 92;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public bool sex;
        public bool havenBagShared;
        public long playerId;
        public string playerName;
        public sbyte level;
        public sbyte alignmentSide;
        public sbyte breed;
        public Types.GuildInformations guildInfo;
        public short moodSmileyId;
        public PlayerStatus status;
        
        public FriendOnlineInformations()
        {
        }
        
        public FriendOnlineInformations(int accountId, string accountName, sbyte playerState, short lastConnection, int achievementPoints, bool sex, bool havenBagShared, long playerId, string playerName, sbyte level, sbyte alignmentSide, sbyte breed, Types.GuildInformations guildInfo, short moodSmileyId, PlayerStatus status)
         : base(accountId, accountName, playerState, lastConnection, achievementPoints)
        {
            this.sex = sex;
            this.havenBagShared = havenBagShared;
            this.playerId = playerId;
            this.playerName = playerName;
            this.level = level;
            this.alignmentSide = alignmentSide;
            this.breed = breed;
            this.guildInfo = guildInfo;
            this.moodSmileyId = moodSmileyId;
            this.status = status;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, sex);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, havenBagShared);
            writer.WriteByte(flag1);
            writer.WriteVarLong(playerId);
            writer.WriteUTF(playerName);
            writer.WriteSByte(level);
            writer.WriteSByte(alignmentSide);
            writer.WriteSByte(breed);
            guildInfo.Serialize(writer);
            writer.WriteVarShort(moodSmileyId);
            writer.WriteShort(status.TypeId);
            status.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            sex = BooleanByteWrapper.GetFlag(flag1, 0);
            havenBagShared = BooleanByteWrapper.GetFlag(flag1, 1);
            playerId = reader.ReadVarLong();
            if (playerId < 0 || playerId > 9007199254740990)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0 || playerId > 9007199254740990");
            playerName = reader.ReadUTF();
            level = reader.ReadSByte();
            if (level < 0 || level > 206)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 206");
            alignmentSide = reader.ReadSByte();
            breed = reader.ReadSByte();
            guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
            moodSmileyId = reader.ReadVarShort();
            if (moodSmileyId < 0)
                throw new Exception("Forbidden value on moodSmileyId = " + moodSmileyId + ", it doesn't respect the following condition : moodSmileyId < 0");
            status = Types.ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            status.Deserialize(reader);
        }
        
        
    }
    
}