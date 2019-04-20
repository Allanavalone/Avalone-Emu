

// Generated on 02/17/2017 01:57:42
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class CharacterCreationRequestMessage : Message
    {
        public const uint Id = 160;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string name;
        public sbyte breed;
        public bool sex;
        public IEnumerable<int> colors;
        public short cosmeticId;
        
        public CharacterCreationRequestMessage()
        {
        }
        
        public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, IEnumerable<int> colors, short cosmeticId)
        {
            this.name = name;
            this.breed = breed;
            this.sex = sex;
            this.colors = colors;
            this.cosmeticId = cosmeticId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(name);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            foreach (var entry in colors)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteVarShort(cosmeticId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            name = reader.ReadUTF();
            breed = reader.ReadSByte();
            sex = reader.ReadBoolean();
            var colors_ = new int[5];
            for (int i = 0; i < 5; i++)
            {
                 colors_[i] = reader.ReadInt();
            }
            colors = colors_;
            cosmeticId = reader.ReadVarShort();
            if (cosmeticId < 0)
                throw new Exception("Forbidden value on cosmeticId = " + cosmeticId + ", it doesn't respect the following condition : cosmeticId < 0");
        }
        
    }
    
}