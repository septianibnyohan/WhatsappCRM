using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneNumbers;

namespace WhatsappLib.Helpers
{
    public class PhoneHelper
    {
        private static string FixGoogle(string contact_number)
        {
            String indNumberStr = contact_number;
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

            PhoneNumber indNumberProto = phoneUtil.Parse(indNumberStr, "ID");
            contact_number = indNumberProto.CountryCode.ToString() + indNumberProto.NationalNumber.ToString();

            return contact_number;
        }

        public static string FixPhoneNumber(string phone_number)
        {    
            string res_number = FixGoogle(phone_number);

            if (res_number[0] == '8')
            {
                res_number = "62" + res_number;
                return res_number;
            }

            if (res_number[0] == '0')
            {
                res_number = "62" + res_number.Substring(1);
                return res_number;
            }

            if (res_number.Contains("+62"))
            {
                res_number = res_number.Replace("+62", "62");
                return res_number;
            }

            if (res_number.Contains("(62) "))
            {
                res_number = res_number.Replace("(62) ", "62");
                return res_number;
            }

            if (res_number.Contains("(+62) "))
            {
                res_number = res_number.Replace("(+62) ", "62");
                return res_number;
            }

            if (res_number.Contains("(628) "))
            {
                res_number = res_number.Replace("(628) ", "62");
                return res_number;
            }

            if (res_number.Contains("(+628) "))
            {
                res_number = res_number.Replace("(+628) ", "62");
                return res_number;
            }

            return res_number;
        }
    }
}
