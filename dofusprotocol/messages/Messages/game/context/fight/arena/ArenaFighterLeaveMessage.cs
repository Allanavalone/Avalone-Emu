

// Generated on 02/17/2017 01:57:49
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ArenaFighterLeaveMessage : Message
    {
        public const uint Id = 6700;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.CharacterBasicMinimalInformations leaver;
        
        public ArenaFighterLeaveMessage()
        {
        }
        
        public ArenaFighterLeaveMessage(Types.CharacterBasicMinimalInformations leaver)
        {
            this.leaver = leaver;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            leaver.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            leaver = new Types.CharacterBasicMinimalInformations();
            leaver.Deserialize(reader);
        }
        
    }
    
}