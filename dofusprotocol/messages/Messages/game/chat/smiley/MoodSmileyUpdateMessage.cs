

// Generated on 02/17/2017 01:57:45
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MoodSmileyUpdateMessage : Message
    {
        public const uint Id = 6388;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int accountId;
        public long playerId;
        public short smileyId;
        
        public MoodSmileyUpdateMessage()
        {
        }
        
        public MoodSmileyUpdateMessage(int accountId, long playerId, short smileyId)
        {
            this.accountId = accountId;
            this.playerId = playerId;
            this.smileyId = smileyId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(accountId);
            writer.WriteVarLong(playerId);
            writer.WriteVarShort(smileyId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            accountId = reader.ReadInt();
            if (accountId < 0)
                throw new Exception("Forbidden value on accountId = " + accountId + ", it doesn't respect the following condition : accountId < 0");
            playerId = reader.ReadVarLong();
            if (playerId < 0 || playerId > 9007199254740990)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0 || playerId > 9007199254740990");
            smileyId = reader.ReadVarShort();
            if (smileyId < 0)
                throw new Exception("Forbidden value on smileyId = " + smileyId + ", it doesn't respect the following condition : smileyId < 0");
        }
        
    }
    
}