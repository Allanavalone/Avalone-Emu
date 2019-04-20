

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class EntityLook
    {
        public const short Id = 55;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public short bonesId;
        public IEnumerable<short> skins;
        public IEnumerable<int> indexedColors;
        public IEnumerable<short> scales;
        public IEnumerable<Types.SubEntity> subentities;
        
        public EntityLook()
        {
        }
        
        public EntityLook(short bonesId, IEnumerable<short> skins, IEnumerable<int> indexedColors, IEnumerable<short> scales, IEnumerable<Types.SubEntity> subentities)
        {
            this.bonesId = bonesId;
            this.skins = skins;
            this.indexedColors = indexedColors;
            this.scales = scales;
            this.subentities = subentities;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(bonesId);
            var skins_before = writer.Position;
            var skins_count = 0;
            writer.WriteShort(0);
            foreach (var entry in skins)
            {
                 writer.WriteVarShort(entry);
                 skins_count++;
            }
            var skins_after = writer.Position;
            writer.Seek((int)skins_before);
            writer.WriteShort((short)skins_count);
            writer.Seek((int)skins_after);

            var indexedColors_before = writer.Position;
            var indexedColors_count = 0;
            writer.WriteShort(0);
            foreach (var entry in indexedColors)
            {
                 writer.WriteInt(entry);
                 indexedColors_count++;
            }
            var indexedColors_after = writer.Position;
            writer.Seek((int)indexedColors_before);
            writer.WriteShort((short)indexedColors_count);
            writer.Seek((int)indexedColors_after);

            var scales_before = writer.Position;
            var scales_count = 0;
            writer.WriteShort(0);
            foreach (var entry in scales)
            {
                 writer.WriteVarShort(entry);
                 scales_count++;
            }
            var scales_after = writer.Position;
            writer.Seek((int)scales_before);
            writer.WriteShort((short)scales_count);
            writer.Seek((int)scales_after);

            var subentities_before = writer.Position;
            var subentities_count = 0;
            writer.WriteShort(0);
            foreach (var entry in subentities)
            {
                 entry.Serialize(writer);
                 subentities_count++;
            }
            var subentities_after = writer.Position;
            writer.Seek((int)subentities_before);
            writer.WriteShort((short)subentities_count);
            writer.Seek((int)subentities_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            bonesId = reader.ReadVarShort();
            if (bonesId < 0)
                throw new Exception("Forbidden value on bonesId = " + bonesId + ", it doesn't respect the following condition : bonesId < 0");
            var limit = reader.ReadShort();
            var skins_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 skins_[i] = reader.ReadVarShort();
                 if (skins_[i] < 0)
                     throw new Exception("Forbidden value on skins_[i] = " + skins_[i] + ", it doesn't respect the following condition : skins_[i] < 0");
            }
            skins = skins_;
            limit = reader.ReadShort();
            var indexedColors_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 indexedColors_[i] = reader.ReadInt();
            }
            indexedColors = indexedColors_;
            limit = reader.ReadShort();
            var scales_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 scales_[i] = reader.ReadVarShort();
            }
            scales = scales_;
            limit = reader.ReadShort();
            var subentities_ = new Types.SubEntity[limit];
            for (int i = 0; i < limit; i++)
            {
                 subentities_[i] = new Types.SubEntity();
                 subentities_[i].Deserialize(reader);
            }
            subentities = subentities_;
        }
        
        
    }
    
}