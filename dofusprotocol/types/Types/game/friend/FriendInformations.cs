

// Generated on 02/17/2017 01:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FriendInformations : AbstractContactInformations
    {
        public const short Id = 78;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte playerState;
        public short lastConnection;
        public int achievementPoints;
        
        public FriendInformations()
        {
        }
        
        public FriendInformations(int accountId, string accountName, sbyte playerState, short lastConnection, int achievementPoints)
         : base(accountId, accountName)
        {
            this.playerState = playerState;
            this.lastConnection = lastConnection;
            this.achievementPoints = achievementPoints;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(playerState);
            writer.WriteVarShort(lastConnection);
            writer.WriteInt(achievementPoints);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            playerState = reader.ReadSByte();
            lastConnection = reader.ReadVarShort();
            if (lastConnection < 0)
                throw new Exception("Forbidden value on lastConnection = " + lastConnection + ", it doesn't respect the following condition : lastConnection < 0");
            achievementPoints = reader.ReadInt();
        }
        
        
    }
    
}