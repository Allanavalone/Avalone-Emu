

// Generated on 02/17/2017 01:58:29
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class NewMailMessage : MailStatusMessage
    {
        public const uint Id = 6292;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<int> sendersAccountId;
        
        public NewMailMessage()
        {
        }
        
        public NewMailMessage(short unread, short total, IEnumerable<int> sendersAccountId)
         : base(unread, total)
        {
            this.sendersAccountId = sendersAccountId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var sendersAccountId_before = writer.Position;
            var sendersAccountId_count = 0;
            writer.WriteShort(0);
            foreach (var entry in sendersAccountId)
            {
                 writer.WriteInt(entry);
                 sendersAccountId_count++;
            }
            var sendersAccountId_after = writer.Position;
            writer.Seek((int)sendersAccountId_before);
            writer.WriteShort((short)sendersAccountId_count);
            writer.Seek((int)sendersAccountId_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var sendersAccountId_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 sendersAccountId_[i] = reader.ReadInt();
                 if (sendersAccountId_[i] < 0)
                     throw new Exception("Forbidden value on sendersAccountId_[i] = " + sendersAccountId_[i] + ", it doesn't respect the following condition : sendersAccountId_[i] < 0");
            }
            sendersAccountId = sendersAccountId_;
        }
        
    }
    
}