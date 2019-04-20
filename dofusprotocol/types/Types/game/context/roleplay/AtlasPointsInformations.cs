

// Generated on 02/17/2017 01:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class AtlasPointsInformations
    {
        public const short Id = 175;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte type;
        public IEnumerable<Types.MapCoordinatesExtended> coords;
        
        public AtlasPointsInformations()
        {
        }
        
        public AtlasPointsInformations(sbyte type, IEnumerable<Types.MapCoordinatesExtended> coords)
        {
            this.type = type;
            this.coords = coords;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(type);
            var coords_before = writer.Position;
            var coords_count = 0;
            writer.WriteShort(0);
            foreach (var entry in coords)
            {
                 entry.Serialize(writer);
                 coords_count++;
            }
            var coords_after = writer.Position;
            writer.Seek((int)coords_before);
            writer.WriteShort((short)coords_count);
            writer.Seek((int)coords_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            type = reader.ReadSByte();
            var limit = reader.ReadShort();
            var coords_ = new Types.MapCoordinatesExtended[limit];
            for (int i = 0; i < limit; i++)
            {
                 coords_[i] = new Types.MapCoordinatesExtended();
                 coords_[i].Deserialize(reader);
            }
            coords = coords_;
        }
        
        
    }
    
}