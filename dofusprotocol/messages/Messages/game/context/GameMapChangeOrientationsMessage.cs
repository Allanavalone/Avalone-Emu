

// Generated on 02/17/2017 01:57:46
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameMapChangeOrientationsMessage : Message
    {
        public const uint Id = 6155;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.ActorOrientation> orientations;
        
        public GameMapChangeOrientationsMessage()
        {
        }
        
        public GameMapChangeOrientationsMessage(IEnumerable<Types.ActorOrientation> orientations)
        {
            this.orientations = orientations;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var orientations_before = writer.Position;
            var orientations_count = 0;
            writer.WriteShort(0);
            foreach (var entry in orientations)
            {
                 entry.Serialize(writer);
                 orientations_count++;
            }
            var orientations_after = writer.Position;
            writer.Seek((int)orientations_before);
            writer.WriteShort((short)orientations_count);
            writer.Seek((int)orientations_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var orientations_ = new Types.ActorOrientation[limit];
            for (int i = 0; i < limit; i++)
            {
                 orientations_[i] = new Types.ActorOrientation();
                 orientations_[i].Deserialize(reader);
            }
            orientations = orientations_;
        }
        
    }
    
}