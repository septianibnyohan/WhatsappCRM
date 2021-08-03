using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace WhatsappLib
{
    public class Keygen
    {

        private static bool _activated = false;

        public static bool isActivated
        {
            get{
                return _activated;
            }

            set
            {
                _activated = value;
            }
        }

        public static string GetSerialNumber()
        {
            //ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            //string serial = "";
            //foreach (ManagementObject getserial in MOS.Get())
            //{
            //    serial = getserial["SerialNumber"].ToString();
            //}

            //return serial.Replace("/", "");
            //var test = System.Management
            //var serialNumber = Window.System.Profile.SystemManufacturers.
            //           SmbiosInformation.SerialNumber;
            //return serialNumber;

            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }

        public static string GetSHA1(string input)
        {
            var sb1 = "";
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                sb1 = sb.ToString();
            }

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(sb1));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public static bool Check(string keygen)
        {
            string serial = Keygen.GetSerialNumber();
            string sha = Keygen.GetSHA1(serial);

            if (keygen == sha)
            {
                return true;
            }

            return false;
        }

        public static void GenerateLicense(string keygen)
        {
            try
            {
                if (File.Exists("license.key")) File.Delete("license.key");

                StreamWriter file;
                file = new StreamWriter("license.key", true);
                file.WriteLine(keygen);
                file.Close();
            }
            catch (Exception) { throw; }
        }

        public static bool CheckLicense()
        {
            if (!File.Exists("license.key")) return false;

            var fileStream = new FileStream("license.key", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    return Check(line);
                }
            }

            return false;
        }
    }
}
