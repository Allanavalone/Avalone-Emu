

// Generated on 02/17/2017 01:57:43
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PlayerStatusUpdateMessage : Message
    {
        public const uint Id = 6386;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int accountId;
        public long playerId;
        public PlayerStatus status;
        
        public PlayerStatusUpdateMessage()
        {
        }
        
        public PlayerStatusUpdateMessage(int accountId, long playerId, PlayerStatus status)
        {
            this.accountId = accountId;
            this.playerId = playerId;
            this.status = status;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(accountId);
            writer.WriteVarLong(playerId);
            writer.WriteShort(status.TypeId);
            status.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            accountId = reader.ReadInt();
            if (accountId < 0)
                throw new Exception("Forbidden value on accountId = " + accountId + ", it doesn't respect the following condition : accountId < 0");
            playerId = reader.ReadVarLong();
            if (playerId < 0 || playerId > 9007199254740990)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0 || playerId > 9007199254740990");
            status = Types.ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            status.Deserialize(reader);
        }
        
    }
    
}