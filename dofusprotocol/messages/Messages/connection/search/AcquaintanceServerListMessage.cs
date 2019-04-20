

// Generated on 02/17/2017 01:57:33
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AcquaintanceServerListMessage : Message
    {
        public const uint Id = 6142;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> servers;
        
        public AcquaintanceServerListMessage()
        {
        }
        
        public AcquaintanceServerListMessage(IEnumerable<short> servers)
        {
            this.servers = servers;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var servers_before = writer.Position;
            var servers_count = 0;
            writer.WriteShort(0);
            foreach (var entry in servers)
            {
                 writer.WriteVarShort(entry);
                 servers_count++;
            }
            var servers_after = writer.Position;
            writer.Seek((int)servers_before);
            writer.WriteShort((short)servers_count);
            writer.Seek((int)servers_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var servers_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 servers_[i] = reader.ReadVarShort();
                 if (servers_[i] < 0)
                     throw new Exception("Forbidden value on servers_[i] = " + servers_[i] + ", it doesn't respect the following condition : servers_[i] < 0");
            }
            servers = servers_;
        }
        
    }
    
}