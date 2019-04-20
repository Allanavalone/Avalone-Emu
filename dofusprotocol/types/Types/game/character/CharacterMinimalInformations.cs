

// Generated on 02/17/2017 01:52:53
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class CharacterMinimalInformations : CharacterBasicMinimalInformations
    {
        public const short Id = 110;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte level;
        
        public CharacterMinimalInformations()
        {
        }
        
        public CharacterMinimalInformations(long id, string name, sbyte level)
         : base(id, name)
        {
            this.level = level;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(level);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            level = reader.ReadSByte();
            if (level < 1 || level > 206)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 1 || level > 206");
        }
        
        
    }
    
}