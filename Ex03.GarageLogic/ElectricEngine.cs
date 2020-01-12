using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        // proper way??
        //
        public ElectricEngine(Dictionary<string, string> i_EngineInfo)
            : base(i_EngineInfo) { }

        public override void FillEnergy(float i_EnergyFilled)
        {
            base.FillEnergy(i_EnergyFilled);
        }

        public override string ToString()
        {
            StringBuilder ElectricEngineString = new StringBuilder();
            ElectricEngineString.Append("Engine Type:  Electric");
            ElectricEngineString.Append(base.ToString());
            return ElectricEngineString.ToString();
        }
    }
}
