using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        public enum eFuelKind
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        internal eFuelKind m_FuelKind;

        public FuelEngine(Dictionary<string,string> i_EngineInfo)
            :base(i_EngineInfo)
        {
            this.m_FuelKind = (eFuelKind)Enum.Parse(typeof(eFuelKind), i_EngineInfo["Fuel Kind"]);
        }

        public override void FillEnergy(float i_EnergyFilled)
        {
            base.FillEnergy(i_EnergyFilled);
        }

        public override string ToString()
        {
            StringBuilder FuelEngineString = new StringBuilder();
            FuelEngineString.Append(string.Format("Engine Type:  Fuel\nFuel Type:  {0}", this.m_FuelKind));
            FuelEngineString.Append(base.ToString());
            return FuelEngineString.ToString();
        }
    }
}
