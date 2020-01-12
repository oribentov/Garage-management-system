using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Validation
    {
        internal static float StringToFloat(string io_StringToCast)
        {
            float retFloat = 0f;
            bool isValidString = float.TryParse(io_StringToCast, out retFloat);

            if (!isValidString)
            {
                throw new FormatException("the input must be a number");
            }

            return retFloat;
        }

        internal static int StringToInt(string io_StringToCast)
        {
            int retInt = 0;
            bool isValidString = int.TryParse(io_StringToCast, out retInt);

            if (!isValidString)
            {
                throw new FormatException("the input must be a number");
            }

            return retInt;
        }

        internal static bool StringToBool(string i_StringToCast)
        {
            bool retBool = false;

            if (i_StringToCast.ToLower() == "yes")
            {
                retBool = true;
            }
            if (i_StringToCast.ToLower() == "no")
            {
                retBool = false;
            }
            else
            {
                throw new FormatException();
            }

            return retBool;
        }

        //**********************************************************************
        // New Functions
        //**********************************************************************
        internal static VehicleInGarage.eVehicleStatus StringToVehicleStatus(string i_StringToCast)
        {
            VehicleInGarage.eVehicleStatus eVehiclestatus;
            bool didCast = Enum.TryParse(i_StringToCast, out eVehiclestatus);

            if (!didCast)
            {
                throw new FormatException("string statues could not be cast to Enum eVehicleStatus");
            }

            return eVehiclestatus;
        }

        internal static Vehicle ObjectToVehicle(object i_ObjectToCast)
        {
            Vehicle VehicleToRet;
            try
            {
                VehicleToRet = ((Vehicle)i_ObjectToCast);
            }
            catch
            {
                throw new FormatException("Could not cast object to vehicle");
            }

            return VehicleToRet;
        }

        internal static FuelEngine.eFuelKind StringToFuelKind(string i_StringToCast)
        {
            FuelEngine.eFuelKind eFuelKind;
            bool didCast = Enum.TryParse(i_StringToCast, out eFuelKind);

            if (!didCast)
            {
                throw new FormatException("Could not cast string to Fuel Kind Enum");
            }

            return eFuelKind;
        }

    }
}
