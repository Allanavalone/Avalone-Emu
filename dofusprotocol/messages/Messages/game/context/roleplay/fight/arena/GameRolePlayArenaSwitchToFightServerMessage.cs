using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameRolePlayArenaSwitchToFightServerMessage : Message
    {
        public const uint Id = 6575;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string address;
        public IEnumerable<short> ports;
        public IEnumerable<sbyte> ticket;
        
        public GameRolePlayArenaSwitchToFightServerMessage()
        {
        }
        
        public GameRolePlayArenaSwitchToFightServerMessage(string address, IEnumerable<short> ports, IEnumerable<sbyte> ticket)
        {
            this.address = address;
            this.ports = ports;
            this.ticket = ticket;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(address);
            writer.WriteVarInt((int)ports.Count());
            foreach (var entry in ports)
            {
                writer.WriteShort(entry);
            }
            writer.WriteVarInt((int)ticket.Count());
            foreach (var entry in ticket)
            {
                 writer.WriteSByte(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            address = reader.ReadUTF();
            var limit_p = reader.ReadVarInt();
            var port_ = new short[limit_p];
            for (int i = 0; i < limit_p; i++)
            {
                port_[i] = reader.ReadShort();
            }
            ports = port_;
            var limit = reader.ReadVarInt();
            var ticket_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 ticket_[i] = reader.ReadSByte();
            }
            ticket = ticket_;
        }
    } 
}