

// Generated on 02/17/2017 01:57:48
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightSynchronizeMessage : Message
    {
        public const uint Id = 5921;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<GameFightFighterInformations> fighters;
        
        public GameFightSynchronizeMessage()
        {
        }
        
        public GameFightSynchronizeMessage(IEnumerable<GameFightFighterInformations> fighters)
        {
            this.fighters = fighters;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var fighters_before = writer.Position;
            var fighters_count = 0;
            writer.WriteShort(0);
            foreach (var entry in fighters)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 fighters_count++;
            }
            var fighters_after = writer.Position;
            writer.Seek((int)fighters_before);
            writer.WriteShort((short)fighters_count);
            writer.Seek((int)fighters_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var fighters_ = new GameFightFighterInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fighters_[i] = Types.ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadShort());
                 fighters_[i].Deserialize(reader);
            }
            fighters = fighters_;
        }
        
    }
    
}