

// Generated on 02/17/2017 01:57:52
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MapRunningFightListMessage : Message
    {
        public const uint Id = 5743;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.FightExternalInformations> fights;
        
        public MapRunningFightListMessage()
        {
        }
        
        public MapRunningFightListMessage(IEnumerable<Types.FightExternalInformations> fights)
        {
            this.fights = fights;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var fights_before = writer.Position;
            var fights_count = 0;
            writer.WriteShort(0);
            foreach (var entry in fights)
            {
                 entry.Serialize(writer);
                 fights_count++;
            }
            var fights_after = writer.Position;
            writer.Seek((int)fights_before);
            writer.WriteShort((short)fights_count);
            writer.Seek((int)fights_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var fights_ = new Types.FightExternalInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fights_[i] = new Types.FightExternalInformations();
                 fights_[i].Deserialize(reader);
            }
            fights = fights_;
        }
        
    }
    
}