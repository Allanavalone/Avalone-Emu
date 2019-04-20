using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
    {
        public const uint Id = 6469;
        public override uint MessageId
        {
            get { return Id; }
        }

        public IEnumerable<GameServerInformations> serverIds;

        public SelectedServerDataExtendedMessage()
        {
        }

        public SelectedServerDataExtendedMessage(short serverId, string address, short port, bool canCreateNewCharacter, IEnumerable<sbyte> ticket, IEnumerable<GameServerInformations> serverIds)
         : base(serverId, address, port, canCreateNewCharacter, ticket)
        {
            this.serverIds = serverIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt((int)serverIds.Count());
            foreach (var entry in serverIds)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadVarInt();
            var serverIds_ = new GameServerInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                var m_aux = new GameServerInformations();
                m_aux.Deserialize(reader);
                serverIds_[i] = m_aux;
            }
            this.serverIds = serverIds_;
        }
    }
}