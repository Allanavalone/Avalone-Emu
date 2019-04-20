

// Generated on 02/17/2017 01:57:54
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameRolePlayArenaRegisterMessage : Message
    {
        public const uint Id = 6280;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int battleMode;
        
        public GameRolePlayArenaRegisterMessage()
        {
        }
        
        public GameRolePlayArenaRegisterMessage(int battleMode)
        {
            this.battleMode = battleMode;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(battleMode);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            battleMode = reader.ReadInt();
        }
        
    }
    
}