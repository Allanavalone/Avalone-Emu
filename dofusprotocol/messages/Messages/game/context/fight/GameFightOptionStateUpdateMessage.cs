

// Generated on 02/17/2017 01:57:47
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightOptionStateUpdateMessage : Message
    {
        public const uint Id = 5927;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short fightId;
        public sbyte teamId;
        public sbyte option;
        public bool state;
        
        public GameFightOptionStateUpdateMessage()
        {
        }
        
        public GameFightOptionStateUpdateMessage(short fightId, sbyte teamId, sbyte option, bool state)
        {
            this.fightId = fightId;
            this.teamId = teamId;
            this.option = option;
            this.state = state;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(fightId);
            writer.WriteSByte(teamId);
            writer.WriteSByte(option);
            writer.WriteBoolean(state);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadShort();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            teamId = reader.ReadSByte();
            option = reader.ReadSByte();
            state = reader.ReadBoolean();
        }
        
    }
    
}