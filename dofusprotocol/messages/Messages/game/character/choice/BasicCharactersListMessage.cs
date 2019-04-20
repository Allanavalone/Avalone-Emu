

// Generated on 02/17/2017 01:57:41
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class BasicCharactersListMessage : Message
    {
        public const uint Id = 6475;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<CharacterBaseInformations> characters;
        
        public BasicCharactersListMessage()
        {
        }
        
        public BasicCharactersListMessage(IEnumerable<CharacterBaseInformations> characters)
        {
            this.characters = characters;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var characters_before = writer.Position;
            var characters_count = 0;
            writer.WriteShort(0);
            foreach (var entry in characters)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 characters_count++;
            }
            var characters_after = writer.Position;
            writer.Seek((int)characters_before);
            writer.WriteShort((short)characters_count);
            writer.Seek((int)characters_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var characters_ = new CharacterBaseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 characters_[i] = Types.ProtocolTypeManager.GetInstance<CharacterBaseInformations>(reader.ReadShort());
                 characters_[i].Deserialize(reader);
            }
            characters = characters_;
        }
        
    }
    
}