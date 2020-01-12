using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageSystemUI
    {
        internal static void GarageSystem()
        {
            Ex03.GarageLogic.Garage myGarage = new Ex03.GarageLogic.Garage();

            string helloMassage = string.Format(
@"Welcome to garage manager!
Please select the action you want:

1. Add new vehicle to the garage
2. Show all the vehicles in garage (by license number)
3. Change car status
4. Inflate air in the wheels of a vehicle
5. Fuel a vehicle powered by fuel
6. To charge an electric vehicle
7. Show full details of a vehicle

enter the number of action");

            Console.WriteLine(helloMassage);
            string selectionString = Console.ReadLine();
            int actionNumber = validateMenuSelection(selectionString);

            switch (actionNumber)
            {
                case 1:
                    addNewVehicle(myGarage);
                    break;
                case 2:
                    showAllVehiclesLicenses(myGarage);
                    break;
                case 3:
                    changeCarStatus(myGarage);
                    break;
                case 4:
                    inflateAirToVehicle(myGarage);
                    break;
                case 5:
                    refuelVehicle(myGarage);
                    break;
                case 6:
                    rechargeVehicle(myGarage);
                    break;
                case 7:
                    showAllDetailsOfVehicle(myGarage);
                    break;


            }

        }

        private static void showAllDetailsOfVehicle(Garage myGarage)
        {
           


        }

        private static void rechargeVehicle(Garage myGarage)
        {
            throw new NotImplementedException();
        }

        private static void refuelVehicle(Garage myGarage)
        {
            Console.WriteLine("Fueling vehicle: please enter lisence number:");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine(@"Choose fuel type:
1. Soler
2. Octan95
3. Octan96
4. Octan98");

            int numOfFuelType = validateSelection(Console.ReadLine(), 1, 4);
            string fuelType = "";

            switch (numOfFuelType)
            {
                case 1:
                    fuelType = "Soler";
                    break;
                case 2:
                    fuelType = "Octan95";
                    break;
                case 3:
                    fuelType = "Octan96";
                    break;
                case 4:
                    fuelType = "Octan98";
                    break;
            }

            Console.WriteLine("how much to fill? enter  the desired number of liters:");
            float fuelAmount = validateFloat(Console.ReadLine());

            try
            {
                myGarage.Refuel(licenseNumber, fuelType, fuelAmount);
                Console.WriteLine(string.Format("Vehicle {0} was successfully refuled\n", licenseNumber));
                GarageSystem();
            }
            catch (Ex03.GarageLogic.ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void showAllVehiclesLicenses(Garage myGarage)
        {
            Console.WriteLine("All vehicles lisence numbers: please follow the instruction.\n");
            Console.WriteLine(@"Filter by status:
1. Vehicles currently in repair
2. Vehicles repaired
3. Repairs paid
4. Show all vehicles");

            int numOfFilter = validateSelection(Console.ReadLine(), 1, 4);
        }

        private static void inflateAirToVehicle(Garage myGarage)
        {
            Console.WriteLine("Adding a new car: please enter lisence number.");
            string licenseNumber = Console.ReadLine();

            try
            {
                myGarage.InflateAir(licenseNumber);
                Console.WriteLine(string.Format("Wheel's vehicle {0} was successfully inflated\n", licenseNumber));
                GarageSystem();
            }
            catch(Ex03.GarageLogic.ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void changeCarStatus(Garage myGarage)
        {
            Console.WriteLine("Changing vehicle status in the garage: please enter lisence number.");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine(string.Format(@"change vehicle {0} status to:
1. Vehicle currently in repair
2. Vehicle repaired
3. Repairs paid

enter the number of action", licenseNumber));

            int newStausSelction = validateSelection(Console.ReadLine(), 1, 3);
            switch (newStausSelction)
            {
                case 1:
                    myGarage.ChangeStatus(licenseNumber, "in repair");
                    break;
                case 2:
                    myGarage.ChangeStatus(licenseNumber, "repaired");
                    break;
                case 3:
                    myGarage.ChangeStatus(licenseNumber, "paid");
                    break;
            }

            Console.WriteLine(string.Format("the status of vehicle {0} was successfully updated\n", licenseNumber));
            GarageSystem();

        }

        private static void addNewVehicle(Garage myGarage)
        {
            Dictionary<string, string> vehicleInfo = new Dictionary<string, string>();
            Console.WriteLine("Adding a new car: please follow the instruction.");

            Console.WriteLine("enter car number");
        }

        private static int validateMenuSelection(string io_SelectionString)
        {
            int numOfSelection = 0;

            try
            {
                numOfSelection = int.Parse(io_SelectionString);

                if(numOfSelection < 1 || numOfSelection > 7)
                {
                    Console.WriteLine("you have to choose number in range of 1 to 7, corresponding to the action you want");
                    string newInput = Console.ReadLine();
                    validateMenuSelection(newInput);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(@"your choice must be a number from the following actions (1-7):
1. Add new vehicle to the garage
2. Show all the vehicles in garage (by license number)
3. Change car status
4. Inflate air in the wheels of a vehicle
5. Fuel a vehicle powered by fuel
6. To charge an electric vehicle
7. Show full details of a vehicle");
                string newInput = Console.ReadLine();
                validateMenuSelection(newInput);
            }

            return numOfSelection;
        }

        private static int validateFilterSelection(string io_SelectionString)
        {
            int numOfSelection = 0;

            try
            {
                numOfSelection = int.Parse(io_SelectionString);

                if (numOfSelection < 1 || numOfSelection > 4)
                {
                    Console.WriteLine("you have to choose number in range of 1 to 7, corresponding to the action you want");
                    string newInput = Console.ReadLine();
                    validateMenuSelection(newInput);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"your choice must be a number from the following actions (1-7):
1. Vehicles currently in repair
2. Vehicles repaired
3. Repairs paid
4. Show all vehicles");
                string newInput = Console.ReadLine();
                validateMenuSelection(newInput);
            }

            return numOfSelection;
        }

        private static int validateSelection(string io_SelectionString, int i_minValue, int i_maxValue)
        {
            int numOfSelection = 0;

            try
            {
                numOfSelection = int.Parse(io_SelectionString);

                if (numOfSelection < i_minValue || numOfSelection > i_maxValue)
                {
                    Console.WriteLine(string.Format("you have to choose number in range of {0} to {1}, corresponding to the possible options", i_minValue, i_maxValue));
                    string newInput = Console.ReadLine();
                    validateSelection(newInput, i_minValue, i_maxValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("wrong value." +
                    "\nyou have to choose number in range of {0} to {1}, corresponding to the possible options", i_minValue, i_maxValue));
                string newInput = Console.ReadLine();
                validateSelection(newInput, i_minValue, i_maxValue);
            }

            return numOfSelection;
        }

        private static float validateFloat(string io_StringToCast)
        {
            float retFloat = 0;
            bool isValidString = float.TryParse(io_StringToCast, out retFloat);

            if (!isValidString)
            {
                Console.WriteLine("you have to enter a number. please enter the number of liters you want to fuel");
                string newInput = Console.ReadLine();
                validateFloat(newInput);
            }

            return retFloat;
        }
    }
}
