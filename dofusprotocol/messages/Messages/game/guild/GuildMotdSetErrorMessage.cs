

// Generated on 02/17/2017 01:58:10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GuildMotdSetErrorMessage : SocialNoticeSetErrorMessage
    {
        public const uint Id = 6591;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        
        public GuildMotdSetErrorMessage()
        {
        }
        
        public GuildMotdSetErrorMessage(sbyte reason)
         : base(reason)
        {
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
        
    }
    
}