

// Generated on 02/17/2017 01:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
    {
        public const short Id = 180;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string ownerName;
        public sbyte level;
        
        public GameRolePlayMountInformations()
        {
        }
        
        public GameRolePlayMountInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, string name, string ownerName, sbyte level)
         : base(contextualId, look, disposition, name)
        {
            this.ownerName = ownerName;
            this.level = level;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(ownerName);
            writer.WriteSByte(level);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ownerName = reader.ReadUTF();
            level = reader.ReadSByte();
            if (level < 0 || level > 255)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 255");
        }
        
        
    }
    
}