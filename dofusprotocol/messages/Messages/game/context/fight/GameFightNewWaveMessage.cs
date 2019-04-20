

// Generated on 02/17/2017 01:57:47
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightNewWaveMessage : Message
    {
        public const uint Id = 6490;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte id;
        public sbyte teamId;
        public short nbTurnBeforeNextWave;
        
        public GameFightNewWaveMessage()
        {
        }
        
        public GameFightNewWaveMessage(sbyte id, sbyte teamId, short nbTurnBeforeNextWave)
        {
            this.id = id;
            this.teamId = teamId;
            this.nbTurnBeforeNextWave = nbTurnBeforeNextWave;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(id);
            writer.WriteSByte(teamId);
            writer.WriteShort(nbTurnBeforeNextWave);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadSByte();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            teamId = reader.ReadSByte();
            nbTurnBeforeNextWave = reader.ReadShort();
        }
        
    }
    
}