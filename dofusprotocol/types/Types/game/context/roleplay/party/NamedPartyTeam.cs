

// Generated on 02/17/2017 01:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class NamedPartyTeam
    {
        public const short Id = 469;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte teamId;
        public string partyName;
        
        public NamedPartyTeam()
        {
        }
        
        public NamedPartyTeam(sbyte teamId, string partyName)
        {
            this.teamId = teamId;
            this.partyName = partyName;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(teamId);
            writer.WriteUTF(partyName);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            teamId = reader.ReadSByte();
            partyName = reader.ReadUTF();
        }
        
        
    }
    
}