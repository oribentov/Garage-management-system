using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        private float m_MinValue;
        public float MinValue
        {
            get { return m_MinValue; }
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            :base(string.Format("An error occured, the values are out of range. Max value is {0) and Min Vlaue is {1}", i_MaxValue, i_MinValue))
        {
            this.m_MaxValue = i_MaxValue;
            this.m_MinValue = i_MinValue;
        }
    }
}
