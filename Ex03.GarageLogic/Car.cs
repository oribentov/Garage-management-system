using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        public enum eCarColor
        {
            Red,
            Blue,
            Black,
            Gray
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;

        public Car(Dictionary<string, string> i_CarInfo)
            :base(i_CarInfo)
        {
            this.m_CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), i_CarInfo["Car Color"]);
            this.m_NumOfDoors = (eNumOfDoors)Enum.Parse(typeof(eNumOfDoors), i_CarInfo["Number Of Doors"]);
        }

        public override string ToString()
        {
            StringBuilder carString = new StringBuilder(base.ToString());
            carString.Append(string.Format("\nCar details:\nCar Color:{0}\nNumber of Doors:{1}\n", m_CarColor.ToString(), m_NumOfDoors.ToString()));

            return carString.ToString();
        }
    }
}
