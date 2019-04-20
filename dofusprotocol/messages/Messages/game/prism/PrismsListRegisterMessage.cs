

// Generated on 02/17/2017 01:58:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PrismsListRegisterMessage : Message
    {
        public const uint Id = 6441;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte listen;
        
        public PrismsListRegisterMessage()
        {
        }
        
        public PrismsListRegisterMessage(sbyte listen)
        {
            this.listen = listen;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(listen);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            listen = reader.ReadSByte();
        }
        
    }
    
}