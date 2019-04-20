

// Generated on 02/17/2017 01:52:53
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class CharacterRemodelingInformation : AbstractCharacterInformation
    {
        public const short Id = 479;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string name;
        public sbyte breed;
        public bool sex;
        public short cosmeticId;
        public IEnumerable<int> colors;
        
        public CharacterRemodelingInformation()
        {
        }
        
        public CharacterRemodelingInformation(long id, string name, sbyte breed, bool sex, short cosmeticId, IEnumerable<int> colors)
         : base(id)
        {
            this.name = name;
            this.breed = breed;
            this.sex = sex;
            this.cosmeticId = cosmeticId;
            this.colors = colors;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(name);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            writer.WriteVarShort(cosmeticId);
            var colors_before = writer.Position;
            var colors_count = 0;
            writer.WriteShort(0);
            foreach (var entry in colors)
            {
                 writer.WriteInt(entry);
                 colors_count++;
            }
            var colors_after = writer.Position;
            writer.Seek((int)colors_before);
            writer.WriteShort((short)colors_count);
            writer.Seek((int)colors_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            name = reader.ReadUTF();
            breed = reader.ReadSByte();
            sex = reader.ReadBoolean();
            cosmeticId = reader.ReadVarShort();
            if (cosmeticId < 0)
                throw new Exception("Forbidden value on cosmeticId = " + cosmeticId + ", it doesn't respect the following condition : cosmeticId < 0");
            var limit = reader.ReadShort();
            var colors_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 colors_[i] = reader.ReadInt();
            }
            colors = colors_;
        }
        
        
    }
    
}