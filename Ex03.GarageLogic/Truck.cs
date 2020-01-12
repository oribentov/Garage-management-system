using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_IsDangerous;
        private float m_CargoVolume;

        public Truck(Dictionary<string, string> i_TruckInfo) 
            : base(i_TruckInfo)
        {
            try
            {
                this.m_IsDangerous = Validation.StringToBool(i_TruckInfo["Is Dangerous"]);
            }
            catch (FormatException fe)
            {
                throw new FormatException("Are there any dangerous substances in the cargo ?\nAnswer yes or no");
            }
            
            this.m_CargoVolume = Validation.StringToFloat(i_TruckInfo["Cargo Volume"]);
        }

        public override string ToString()
        {
            StringBuilder truckString = new StringBuilder(base.ToString());
            truckString.Append(string.Format("\nTruck details:\nTruck contain hazardous materials:{0}\nCargo volume:{1}\n", m_IsDangerous, m_CargoVolume));

            return truckString.ToString();
        }

    }
}
