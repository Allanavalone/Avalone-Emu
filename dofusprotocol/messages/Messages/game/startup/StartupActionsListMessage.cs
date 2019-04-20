

// Generated on 02/17/2017 01:58:27
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class StartupActionsListMessage : Message
    {
        public const uint Id = 1301;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.StartupActionAddObject> actions;
        
        public StartupActionsListMessage()
        {
        }
        
        public StartupActionsListMessage(IEnumerable<Types.StartupActionAddObject> actions)
        {
            this.actions = actions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var actions_before = writer.Position;
            var actions_count = 0;
            writer.WriteShort(0);
            foreach (var entry in actions)
            {
                 entry.Serialize(writer);
                 actions_count++;
            }
            var actions_after = writer.Position;
            writer.Seek((int)actions_before);
            writer.WriteShort((short)actions_count);
            writer.Seek((int)actions_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var actions_ = new Types.StartupActionAddObject[limit];
            for (int i = 0; i < limit; i++)
            {
                 actions_[i] = new Types.StartupActionAddObject();
                 actions_[i].Deserialize(reader);
            }
            actions = actions_;
        }
        
    }
    
}