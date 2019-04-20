

// Generated on 02/17/2017 01:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightTeamMemberCharacterInformations : FightTeamMemberInformations
    {
        public const short Id = 13;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string name;
        public sbyte level;
        
        public FightTeamMemberCharacterInformations()
        {
        }
        
        public FightTeamMemberCharacterInformations(double id, string name, sbyte level)
         : base(id)
        {
            this.name = name;
            this.level = level;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(name);
            writer.WriteSByte(level);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            name = reader.ReadUTF();
            level = reader.ReadSByte();
            if (level < 0 || level > 255)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 255");
        }
        
        
    }
    
}