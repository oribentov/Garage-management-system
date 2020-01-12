using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<string, VehicleInGarage> m_VehivleInGarageDict;

        public Garage()
        {
            m_VehivleInGarageDict = new Dictionary<string, VehicleInGarage>();
        }

        internal void AddVehicle(Dictionary<string, Object> i_VehicleInGarageInfo)
        {

            Vehicle OwnerVehicle = Validation.ObjectToVehicle(i_VehicleInGarageInfo["Vehicle"]);
            string LicenseNumber = ((string) OwnerVehicle.m_LicenseNumber);

            if (this.m_VehivleInGarageDict.ContainsKey(LicenseNumber))
            {
                //
                // Should print a Messege that Vehicle is in allready in garage
                //
                this.m_VehivleInGarageDict[LicenseNumber].m_VehicleStatus = VehicleInGarage.eVehicleStatus.Fixing;
            }
            else
            {
                VehicleInGarage OwnerVehicleInGarage = new VehicleInGarage(i_VehicleInGarageInfo);
                this.m_VehivleInGarageDict[LicenseNumber] = OwnerVehicleInGarage;
            }
        }

        public List<string> PrintVehiclesLicenseNumbers(string i_ChoosenVehicleStatus)
        {
            //
            //Should check input validation - checked!
            //
            List<string> LicenseNumberList = new List<string>();
            VehicleInGarage.eVehicleStatus eStatus = Validation.StringToVehicleStatus(i_ChoosenVehicleStatus);
            
            foreach (KeyValuePair<string, VehicleInGarage> vehicle in m_VehivleInGarageDict)
            {
                if(vehicle.Value.m_VehicleStatus == eStatus)
                {
                    LicenseNumberList.Add(vehicle.Value.m_Vehicle.m_LicenseNumber);
                }
            }

            return LicenseNumberList;
        }

        public List<string> PrintVehiclesLicenseNumbers()
        {
            List<string> LicenseNumberList = new List<string>();

            foreach (KeyValuePair<string, VehicleInGarage> vehicle in m_VehivleInGarageDict)
            {
                LicenseNumberList.Add(vehicle.Value.m_Vehicle.m_LicenseNumber);
            }

            return LicenseNumberList;
        }

        public void ChangeStatus(string i_LicenseNumber, string i_status)
        {
            //
            //Should check input validation - checked
            //
            VehicleInGarage.eVehicleStatus eStatus = Validation.StringToVehicleStatus(i_status);

            m_VehivleInGarageDict[i_LicenseNumber].m_VehicleStatus = eStatus;
        }

        public void InflateAir(string i_VehicleLicenseNumber)
        {

           foreach(Wheel wheel in m_VehivleInGarageDict[i_VehicleLicenseNumber].m_Vehicle.m_Wheels)
            {
                //
                // did changes to wheel class - set the bottom class members to internal
                //
                float MaxAirInWheel = wheel.m_MaxAirPressure;
                float CurrentAir = wheel.m_AirPressure;
                float AirToFill = MaxAirInWheel - CurrentAir;
                wheel.InflateWheel(AirToFill);
            }
        }

        public void Refuel(string i_LicenseNumber, string i_FuelType, float i_FuelAmount)
        {

            VehicleInGarage vehicle;
            FuelEngine.eFuelKind eFuelType = Validation.StringToFuelKind(i_FuelType);

            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                //
                // throws key not found error on i_LicenseNumber
                //
                handleVehicleNotFound(i_LicenseNumber);
            }
            else if (!IsVehicleFuel(i_LicenseNumber))
            {
                //
                // vehicle is not a fuel vehicle
                //
                string ExceptionString = string.Format("Vehicle License Num: {0} is not a fuel vehicle", i_LicenseNumber);
                throw new ArgumentException(ExceptionString);
            }
            else
            {
                vehicle = m_VehivleInGarageDict[i_LicenseNumber];
                FuelEngine engine = ((FuelEngine)m_VehivleInGarageDict[i_LicenseNumber].m_Vehicle.m_Engine);
                if(engine.m_FuelKind.Equals(eFuelType))
                {
                    // should check for exception in engine.fillEnergy
                    engine.FillEnergy(i_FuelAmount);
                }
                else
                {
                    // Fuel type is wrong
                    string ExceptionString = string.Format("Vehicle License Num: {0} has a different fuel type", i_LicenseNumber);
                    throw new ArgumentException(ExceptionString);
                }
            }
        }

        public void Recharge(string i_LicenseNumber, float i_AmountToCharge)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                handleVehicleNotFound(i_LicenseNumber);
            }
            else if (!IsVehicleElectric(i_LicenseNumber))
            {
                string ExceptionString = string.Format("Vehicle License Num: {0} is not an electric vehicle", i_LicenseNumber);
                throw new ArgumentException(ExceptionString);
            }
            else
            {
                ElectricEngine engine = ((ElectricEngine)m_VehivleInGarageDict[i_LicenseNumber].m_Vehicle.m_Engine);
                engine.FillEnergy(i_AmountToCharge);
            }
        }

        private Exception handleVehicleNotFound(string i_LicenseNumber)
        {
            string ExceptionString = string.Format("Vehicle License Num: {0} was not found in garage", i_LicenseNumber);
            throw new KeyNotFoundException(ExceptionString);
        }

        public string PrintVehicleInfo(string i_LicenseNumber)
        {
            if (IsVehicleInGarage(i_LicenseNumber))
            {
                return m_VehivleInGarageDict[i_LicenseNumber].ToString();
            }
            else
            {
                string ExceptionString = string.Format("Vehicle License Num: {0} was not found in garage", i_LicenseNumber);
                throw new KeyNotFoundException(ExceptionString);
            }
        }

        // should the following methods move to validations?

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return m_VehivleInGarageDict.ContainsKey(i_LicenseNumber);
        }

        public bool IsVehicleElectric(string i_LicenseNumber)
        {
            return m_VehivleInGarageDict[i_LicenseNumber].m_Vehicle.m_Engine is ElectricEngine;
        }

        public bool IsVehicleFuel(string i_LicenseNumber)
        {
            return m_VehivleInGarageDict[i_LicenseNumber].m_Vehicle.m_Engine is FuelEngine;
        }
    }
}
