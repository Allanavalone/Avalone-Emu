using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameRolePlayShowMultipleActorsMessage : Message
    {
        public const uint Id = 6712;
        public override uint MessageId
        {
            get { return Id; }
        }

        public IEnumerable<Types.GameRolePlayActorInformations> informationsList;

        public GameRolePlayShowMultipleActorsMessage()
        {
        }

        public GameRolePlayShowMultipleActorsMessage(IEnumerable<Types.GameRolePlayActorInformations> informationsList)
        {
            this.informationsList = informationsList;
        }

        public override void Serialize(IDataWriter writer)
        {
            var informationsList_before = writer.Position;
            var informationsList_count = 0;
            writer.WriteShort(0);
            foreach (var entry in informationsList)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
                informationsList_count++;
            }
            var informationsList_after = writer.Position;
            writer.Seek((int)informationsList_before);
            writer.WriteShort((short)informationsList_count);
            writer.Seek((int)informationsList_after);
        }

        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var informationsList_ = new Types.GameRolePlayActorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                var typeId = reader.ReadShort();
                var informationType = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(typeId);
                informationType.Deserialize(reader);
                informationsList_[i] = informationType;
            }

            informationsList = informationsList_;
        }
    }
}