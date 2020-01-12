using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    { 
        public enum eLisenceType
        {
            A,
            A1,
            A2,
            B
        }

        private eLisenceType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(Dictionary<string, string> i_MotorcycleInfo)
            :base(i_MotorcycleInfo)
        {
            //bool isValidLicenseType = Enum.TryParse(i_MotorcycleInfo["License Type"], out m_LicenseType);
            try
            {
                this.m_LicenseType = (eLisenceType)Enum.Parse(typeof(eLisenceType), i_MotorcycleInfo["License Type"]);
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("the license type is only: A, A1, A2, A3");
            }
            
            this.m_EngineVolume = Validation.StringToInt(i_MotorcycleInfo["Engine Volume"]);
        }

        public override string ToString()
        {
            StringBuilder motorcycleString = new StringBuilder(base.ToString());
            motorcycleString.Append(string.Format("\nMotorcycle details:\nLicense type:{0}\nEngine Volume:{1}\n", m_LicenseType.ToString(), m_EngineVolume));

            return motorcycleString.ToString();
        }
    }
}
