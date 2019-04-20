

// Generated on 02/17/2017 01:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class DungeonPartyFinderPlayer
    {
        public const short Id = 373;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public long playerId;
        public string playerName;
        public sbyte breed;
        public bool sex;
        public sbyte level;
        
        public DungeonPartyFinderPlayer()
        {
        }
        
        public DungeonPartyFinderPlayer(long playerId, string playerName, sbyte breed, bool sex, sbyte level)
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.breed = breed;
            this.sex = sex;
            this.level = level;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(playerId);
            writer.WriteUTF(playerName);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            writer.WriteSByte(level);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            playerId = reader.ReadVarLong();
            if (playerId < 0 || playerId > 9007199254740990)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0 || playerId > 9007199254740990");
            playerName = reader.ReadUTF();
            breed = reader.ReadSByte();
            sex = reader.ReadBoolean();
            level = reader.ReadSByte();
            if (level < 0 || level > 255)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 255");
        }
        
        
    }
    
}