using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class CharacterCanBeCreatedRequestMessage : Message
    {
        public const uint Id = 6732;
        public override uint MessageId
        {
            get { return Id; }
        }


        public CharacterCanBeCreatedRequestMessage()
        {
        }
        
        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }

}