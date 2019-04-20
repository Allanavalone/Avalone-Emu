

// Generated on 02/17/2017 01:57:38
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AllianceInsiderInfoMessage : Message
    {
        public const uint Id = 6403;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.AllianceFactSheetInformations allianceInfos;
        public IEnumerable<Types.GuildInsiderFactSheetInformations> guilds;
        public IEnumerable<PrismSubareaEmptyInfo> prisms;
        
        public AllianceInsiderInfoMessage()
        {
        }
        
        public AllianceInsiderInfoMessage(Types.AllianceFactSheetInformations allianceInfos, IEnumerable<Types.GuildInsiderFactSheetInformations> guilds, IEnumerable<PrismSubareaEmptyInfo> prisms)
        {
            this.allianceInfos = allianceInfos;
            this.guilds = guilds;
            this.prisms = prisms;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            allianceInfos.Serialize(writer);
            var guilds_before = writer.Position;
            var guilds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in guilds)
            {
                 entry.Serialize(writer);
                 guilds_count++;
            }
            var guilds_after = writer.Position;
            writer.Seek((int)guilds_before);
            writer.WriteShort((short)guilds_count);
            writer.Seek((int)guilds_after);

            var prisms_before = writer.Position;
            var prisms_count = 0;
            writer.WriteShort(0);
            foreach (var entry in prisms)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 prisms_count++;
            }
            var prisms_after = writer.Position;
            writer.Seek((int)prisms_before);
            writer.WriteShort((short)prisms_count);
            writer.Seek((int)prisms_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            allianceInfos = new Types.AllianceFactSheetInformations();
            allianceInfos.Deserialize(reader);
            var limit = reader.ReadShort();
            var guilds_ = new Types.GuildInsiderFactSheetInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 guilds_[i] = new Types.GuildInsiderFactSheetInformations();
                 guilds_[i].Deserialize(reader);
            }
            guilds = guilds_;
            limit = reader.ReadShort();
            var prisms_ = new PrismSubareaEmptyInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 prisms_[i] = Types.ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>(reader.ReadShort());
                 prisms_[i].Deserialize(reader);
            }
            prisms = prisms_;
        }
        
    }
    
}