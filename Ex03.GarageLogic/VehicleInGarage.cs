using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class VehicleInGarage
    {
        public enum eVehicleStatus
        {
            Fixing,
            Fixed,
            Paid
        }

        internal string m_OwnerName;
        internal string m_OwnerPhone;
        public eVehicleStatus m_VehicleStatus;
        internal Vehicle m_Vehicle;

        public VehicleInGarage(Dictionary<string, Object> i_VehicleInGarageInfo)
        {
            m_OwnerName = (string)i_VehicleInGarageInfo["Owner Name"];
            m_OwnerPhone = (string)i_VehicleInGarageInfo["Owner Phone"];
            m_Vehicle = (Vehicle)i_VehicleInGarageInfo["Vehicle"];
            m_VehicleStatus = eVehicleStatus.Fixing;
        }

        public override string ToString()
        {
            string VehicleInGarageString = string.Format(@"Owner Name:  {0}
Owner Phone:  {1}
Vehicle Details:
{2}", this.m_OwnerName, this.m_OwnerPhone, this.m_Vehicle.ToString());

            return VehicleInGarageString;
        }
    }
}
