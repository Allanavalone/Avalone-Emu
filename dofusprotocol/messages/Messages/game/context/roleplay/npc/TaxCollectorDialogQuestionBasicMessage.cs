

// Generated on 02/17/2017 01:57:58
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TaxCollectorDialogQuestionBasicMessage : Message
    {
        public const uint Id = 5619;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.BasicGuildInformations guildInfo;
        
        public TaxCollectorDialogQuestionBasicMessage()
        {
        }
        
        public TaxCollectorDialogQuestionBasicMessage(Types.BasicGuildInformations guildInfo)
        {
            this.guildInfo = guildInfo;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            guildInfo.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            guildInfo = new Types.BasicGuildInformations();
            guildInfo.Deserialize(reader);
        }
        
    }
    
}