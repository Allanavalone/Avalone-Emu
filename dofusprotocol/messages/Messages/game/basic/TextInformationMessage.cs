

// Generated on 02/17/2017 01:57:41
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TextInformationMessage : Message
    {
        public const uint Id = 780;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte msgType;
        public short msgId;
        public IEnumerable<string> parameters;
        
        public TextInformationMessage()
        {
        }
        
        public TextInformationMessage(sbyte msgType, short msgId, IEnumerable<string> parameters)
        {
            this.msgType = msgType;
            this.msgId = msgId;
            this.parameters = parameters;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(msgType);
            writer.WriteVarShort(msgId);
            var parameters_before = writer.Position;
            var parameters_count = 0;
            writer.WriteShort(0);
            foreach (var entry in parameters)
            {
                 writer.WriteUTF(entry);
                 parameters_count++;
            }
            var parameters_after = writer.Position;
            writer.Seek((int)parameters_before);
            writer.WriteShort((short)parameters_count);
            writer.Seek((int)parameters_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            msgType = reader.ReadSByte();
            msgId = reader.ReadVarShort();
            if (msgId < 0)
                throw new Exception("Forbidden value on msgId = " + msgId + ", it doesn't respect the following condition : msgId < 0");
            var limit = reader.ReadShort();
            var parameters_ = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 parameters_[i] = reader.ReadUTF();
            }
            parameters = parameters_;
        }
        
    }
    
}