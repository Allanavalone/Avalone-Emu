

// Generated on 02/17/2017 01:58:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class QuestStepInfoMessage : Message
    {
        public const uint Id = 5625;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public QuestActiveInformations infos;
        
        public QuestStepInfoMessage()
        {
        }
        
        public QuestStepInfoMessage(QuestActiveInformations infos)
        {
            this.infos = infos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(infos.TypeId);
            infos.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            infos = Types.ProtocolTypeManager.GetInstance<QuestActiveInformations>(reader.ReadShort());
            infos.Deserialize(reader);
        }
        
    }
    
}