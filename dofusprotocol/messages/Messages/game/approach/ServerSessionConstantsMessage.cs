

// Generated on 02/17/2017 01:57:40
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ServerSessionConstantsMessage : Message
    {
        public const uint Id = 6434;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<ServerSessionConstant> variables;
        
        public ServerSessionConstantsMessage()
        {
        }
        
        public ServerSessionConstantsMessage(IEnumerable<ServerSessionConstant> variables)
        {
            this.variables = variables;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var variables_before = writer.Position;
            var variables_count = 0;
            writer.WriteShort(0);
            foreach (var entry in variables)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 variables_count++;
            }
            var variables_after = writer.Position;
            writer.Seek((int)variables_before);
            writer.WriteShort((short)variables_count);
            writer.Seek((int)variables_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var variables_ = new ServerSessionConstant[limit];
            for (int i = 0; i < limit; i++)
            {
                 variables_[i] = Types.ProtocolTypeManager.GetInstance<ServerSessionConstant>(reader.ReadShort());
                 variables_[i].Deserialize(reader);
            }
            variables = variables_;
        }
        
    }
    
}