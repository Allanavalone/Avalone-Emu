

// Generated on 02/17/2017 01:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class VersionExtended : Version
    {
        public const short Id = 393;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte install;
        public sbyte technology;
        
        public VersionExtended()
        {
        }
        
        public VersionExtended(sbyte major, sbyte minor, sbyte release, int revision, sbyte patch, sbyte buildType, sbyte install, sbyte technology)
         : base(major, minor, release, revision, patch, buildType)
        {
            this.install = install;
            this.technology = technology;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(install);
            writer.WriteSByte(technology);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            install = reader.ReadSByte();
            technology = reader.ReadSByte();
        }
        
        
    }
    
}