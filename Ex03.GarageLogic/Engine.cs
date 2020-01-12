using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_MaxEnergy;
        protected float m_EnergyLeft;
        public Engine(Dictionary<string, string> i_EngineInfo)
        {
            this.m_MaxEnergy = float.Parse(i_EngineInfo["Max Energy"]);
            this.m_EnergyLeft = float.Parse(i_EngineInfo["Energy Left"]);
        }

        public virtual void FillEnergy(float i_EnergyFilled)
        {
            float DeltaEnergyLeft = this.m_MaxEnergy - this.m_EnergyLeft;

            if (DeltaEnergyLeft < i_EnergyFilled)
            {
                throw new ValueOutOfRangeException(DeltaEnergyLeft, 0);
            }
            this.m_EnergyLeft = this.m_EnergyLeft + i_EnergyFilled;
        }

        public override string ToString()
        {
            return string.Format("Engine Energy Capacity:  {0}\nEngine Energy Left:  {1}\n", this.m_MaxEnergy, this.m_EnergyLeft);
        }
    }
}
