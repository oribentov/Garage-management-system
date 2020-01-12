using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        internal float m_AirPressure;
        internal float m_MaxAirPressure;

        public Wheel(Dictionary<string, string> i_VehicleInfo)
        {
            this.m_Manufacturer = i_VehicleInfo["Wheel Manufacturer"];
            this.m_AirPressure = Validation.StringToFloat(i_VehicleInfo["Wheel Air Pressure"]);
            this.m_MaxAirPressure = Validation.StringToFloat(i_VehicleInfo["Wheel Max Air Pressure"]);
        }

        internal void InflateWheel(float i_amount)
        {
            if(m_AirPressure + i_amount > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure, 0);
            }
            else
            {
                m_MaxAirPressure += i_amount;
            }
        }

        public override string ToString()
        {
            return string.Format("Wheel manufacturer: {0}\nCurrent air pressure: {1}\nMax air pressure: {2}", m_Manufacturer, m_AirPressure, m_MaxAirPressure);
        }
    }
}
