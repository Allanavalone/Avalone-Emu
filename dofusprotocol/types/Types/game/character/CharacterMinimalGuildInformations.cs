

// Generated on 02/17/2017 01:52:53
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class CharacterMinimalGuildInformations : CharacterMinimalPlusLookInformations
    {
        public const short Id = 445;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.BasicGuildInformations guild;
        
        public CharacterMinimalGuildInformations()
        {
        }
        
        public CharacterMinimalGuildInformations(long id, string name, sbyte level, Types.EntityLook entityLook, Types.BasicGuildInformations guild)
         : base(id, name, level, entityLook)
        {
            this.guild = guild;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            guild.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            guild = new Types.BasicGuildInformations();
            guild.Deserialize(reader);
        }
        
        
    }
    
}