

// Generated on 02/17/2017 01:58:16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeLeaveMessage : LeaveDialogMessage
    {
        public const uint Id = 5628;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool success;
        
        public ExchangeLeaveMessage()
        {
        }
        
        public ExchangeLeaveMessage(sbyte dialogType, bool success)
         : base(dialogType)
        {
            this.success = success;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(success);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            success = reader.ReadBoolean();
        }
        
    }
    
}