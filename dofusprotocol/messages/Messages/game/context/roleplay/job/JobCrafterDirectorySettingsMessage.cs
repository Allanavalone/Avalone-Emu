

// Generated on 02/17/2017 01:57:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class JobCrafterDirectorySettingsMessage : Message
    {
        public const uint Id = 5652;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.JobCrafterDirectorySettings> craftersSettings;
        
        public JobCrafterDirectorySettingsMessage()
        {
        }
        
        public JobCrafterDirectorySettingsMessage(IEnumerable<Types.JobCrafterDirectorySettings> craftersSettings)
        {
            this.craftersSettings = craftersSettings;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var craftersSettings_before = writer.Position;
            var craftersSettings_count = 0;
            writer.WriteShort(0);
            foreach (var entry in craftersSettings)
            {
                 entry.Serialize(writer);
                 craftersSettings_count++;
            }
            var craftersSettings_after = writer.Position;
            writer.Seek((int)craftersSettings_before);
            writer.WriteShort((short)craftersSettings_count);
            writer.Seek((int)craftersSettings_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var craftersSettings_ = new Types.JobCrafterDirectorySettings[limit];
            for (int i = 0; i < limit; i++)
            {
                 craftersSettings_[i] = new Types.JobCrafterDirectorySettings();
                 craftersSettings_[i].Deserialize(reader);
            }
            craftersSettings = craftersSettings_;
        }
        
    }
    
}