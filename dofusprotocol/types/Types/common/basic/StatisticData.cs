

// Generated on 02/17/2017 01:52:51
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class StatisticData
    {
        public const short Id = 484;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        
        public StatisticData()
        {
        }
        
        
        public virtual void Serialize(IDataWriter writer)
        {
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
        }
        
        
    }
    
}