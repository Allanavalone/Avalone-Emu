

// Generated on 02/17/2017 01:57:45
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameContextCreateMessage : Message
    {
        public const uint Id = 200;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte context;
        
        public GameContextCreateMessage()
        {
        }
        
        public GameContextCreateMessage(sbyte context)
        {
            this.context = context;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(context);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            context = reader.ReadSByte();
        }
        
    }
    
}