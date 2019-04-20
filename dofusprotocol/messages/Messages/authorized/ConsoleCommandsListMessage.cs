

// Generated on 02/17/2017 01:57:31
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ConsoleCommandsListMessage : Message
    {
        public const uint Id = 6127;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<string> aliases;
        public IEnumerable<string> args;
        public IEnumerable<string> descriptions;
        
        public ConsoleCommandsListMessage()
        {
        }
        
        public ConsoleCommandsListMessage(IEnumerable<string> aliases, IEnumerable<string> args, IEnumerable<string> descriptions)
        {
            this.aliases = aliases;
            this.args = args;
            this.descriptions = descriptions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var aliases_before = writer.Position;
            var aliases_count = 0;
            writer.WriteShort(0);
            foreach (var entry in aliases)
            {
                 writer.WriteUTF(entry);
                 aliases_count++;
            }
            var aliases_after = writer.Position;
            writer.Seek((int)aliases_before);
            writer.WriteShort((short)aliases_count);
            writer.Seek((int)aliases_after);

            var args_before = writer.Position;
            var args_count = 0;
            writer.WriteShort(0);
            foreach (var entry in args)
            {
                 writer.WriteUTF(entry);
                 args_count++;
            }
            var args_after = writer.Position;
            writer.Seek((int)args_before);
            writer.WriteShort((short)args_count);
            writer.Seek((int)args_after);

            var descriptions_before = writer.Position;
            var descriptions_count = 0;
            writer.WriteShort(0);
            foreach (var entry in descriptions)
            {
                 writer.WriteUTF(entry);
                 descriptions_count++;
            }
            var descriptions_after = writer.Position;
            writer.Seek((int)descriptions_before);
            writer.WriteShort((short)descriptions_count);
            writer.Seek((int)descriptions_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var aliases_ = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 aliases_[i] = reader.ReadUTF();
            }
            aliases = aliases_;
            limit = reader.ReadShort();
            var args_ = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 args_[i] = reader.ReadUTF();
            }
            args = args_;
            limit = reader.ReadShort();
            var descriptions_ = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 descriptions_[i] = reader.ReadUTF();
            }
            descriptions = descriptions_;
        }
        
    }
    
}