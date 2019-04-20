

// Generated on 02/17/2017 01:58:28
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TitlesAndOrnamentsListMessage : Message
    {
        public const uint Id = 6367;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> titles;
        public IEnumerable<short> ornaments;
        public short activeTitle;
        public short activeOrnament;
        
        public TitlesAndOrnamentsListMessage()
        {
        }
        
        public TitlesAndOrnamentsListMessage(IEnumerable<short> titles, IEnumerable<short> ornaments, short activeTitle, short activeOrnament)
        {
            this.titles = titles;
            this.ornaments = ornaments;
            this.activeTitle = activeTitle;
            this.activeOrnament = activeOrnament;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var titles_before = writer.Position;
            var titles_count = 0;
            writer.WriteShort(0);
            foreach (var entry in titles)
            {
                 writer.WriteVarShort(entry);
                 titles_count++;
            }
            var titles_after = writer.Position;
            writer.Seek((int)titles_before);
            writer.WriteShort((short)titles_count);
            writer.Seek((int)titles_after);

            var ornaments_before = writer.Position;
            var ornaments_count = 0;
            writer.WriteShort(0);
            foreach (var entry in ornaments)
            {
                 writer.WriteVarShort(entry);
                 ornaments_count++;
            }
            var ornaments_after = writer.Position;
            writer.Seek((int)ornaments_before);
            writer.WriteShort((short)ornaments_count);
            writer.Seek((int)ornaments_after);

            writer.WriteVarShort(activeTitle);
            writer.WriteVarShort(activeOrnament);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var titles_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 titles_[i] = reader.ReadVarShort();
                 if (titles_[i] < 0)
                     throw new Exception("Forbidden value on titles_[i] = " + titles_[i] + ", it doesn't respect the following condition : titles_[i] < 0");
            }
            titles = titles_;
            limit = reader.ReadShort();
            var ornaments_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 ornaments_[i] = reader.ReadVarShort();
                 if (ornaments_[i] < 0)
                     throw new Exception("Forbidden value on ornaments_[i] = " + ornaments_[i] + ", it doesn't respect the following condition : ornaments_[i] < 0");
            }
            ornaments = ornaments_;
            activeTitle = reader.ReadVarShort();
            if (activeTitle < 0)
                throw new Exception("Forbidden value on activeTitle = " + activeTitle + ", it doesn't respect the following condition : activeTitle < 0");
            activeOrnament = reader.ReadVarShort();
            if (activeOrnament < 0)
                throw new Exception("Forbidden value on activeOrnament = " + activeOrnament + ", it doesn't respect the following condition : activeOrnament < 0");
        }
        
    }
    
}