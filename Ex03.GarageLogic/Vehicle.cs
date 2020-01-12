using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        internal string m_LicenseNumber;
        internal float m_EnergyRemain;
        internal List<Wheel> m_Wheels;
        internal Engine m_Engine;

        public Vehicle(Dictionary<string, string> i_VehicleInfo)
        {
            this.m_ModelName = i_VehicleInfo["Model Name"];
            this.m_LicenseNumber = i_VehicleInfo["Lisence Number"];
            this.m_EnergyRemain = Validation.StringToFloat(i_VehicleInfo["Energy Remain"]);
            this.m_Wheels = CreateWheelList(i_VehicleInfo);
            this.m_Engine = CreateEngine(i_VehicleInfo);
        }

        private List<Wheel> CreateWheelList(Dictionary<string, string> i_VehicleInfo)
        {
            int numOfWheels = 0;

            switch (i_VehicleInfo["Type"].ToString())
            {
                case "Motorcycle":
                    numOfWheels = 2;
                    break;

                case "Car":
                    numOfWheels = 4;
                    break;

                case "Truck":
                    numOfWheels = 12;
                    break;
            }

            List<Wheel> ListOfWheels = new List<Wheel>(numOfWheels);
            for(int i = 0; i < numOfWheels; i++)
            {
                ListOfWheels.Add(new Wheel(i_VehicleInfo));
            }

            return ListOfWheels;
        }

        private Engine CreateEngine(Dictionary<string, string> i_VehicleInfo)
        {

        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder(string.Format("Full details of vehicle {0}\n", m_LicenseNumber));

            vehicleString.Append("Wheels details:\n\n");
            foreach(Wheel wheel in m_Wheels)
            {
                vehicleString.Append(wheel.ToString());
            }

            vehicleString.Append("Vehicle details:\n\n");
            vehicleString.Append(string.Format("Model Name: {0}\nLisence Number: {1}\n",m_ModelName, m_LicenseNumber));
            vehicleString.Append(m_Engine.ToString());

            return vehicleString.ToString();
        }
    }
}

