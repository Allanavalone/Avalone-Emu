using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MigratedServerListMessage : Message
    {
        public const uint Id = 6731;
        public override uint MessageId
        {
            get { return Id; }
        }

        public IEnumerable<short> migratedServerIds;

        public MigratedServerListMessage()
        {
        }

        public MigratedServerListMessage(IEnumerable<short> migratedServerIds)
        {
            this.migratedServerIds = migratedServerIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)migratedServerIds.Count());
            foreach (var entry in migratedServerIds)
            {
                writer.WriteVarShort(entry);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var m_tam = reader.ReadVarInt();
            short migratedId = 0;
            var migratedServerIds_ = new short[m_tam];
            for (int i = 0; i < m_tam; i++)
            {
                migratedId = reader.ReadVarShort();
                if (migratedId < 0)
                    throw new Exception("Forbidden value on migratedId = " + migratedId + ", it doesn't respect the following condition : migratedId < 0");

                migratedServerIds_[i] = migratedId;
            }

            migratedServerIds = migratedServerIds_;
        }

    }

}            