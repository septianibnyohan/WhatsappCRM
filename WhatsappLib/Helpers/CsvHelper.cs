using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsappLib.Models;

namespace WhatsappLib.Helpers
{
    public class CsvHelper
    {
        public static List<Contact> CsvToContact(string csvfile)
        {
            List<Contact> contacts = new List<Contact>();

            try
            {
                using (TextFieldParser parser = new TextFieldParser(csvfile))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        //Processing row
                        string[] fields = parser.ReadFields();
                        var contact = new Contact();
                        contact.FirstName = fields[0].Trim();
                        contact.LastName = fields[1].Trim();
                        contact.Number = PhoneHelper.FixPhoneNumber(fields[2].Trim());
                        contact.Country = fields[3].Trim();
                        contact.Greeting = fields[4].Trim();

                        contacts.Add(contact);
                    }
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogEx(ex);
                return null;
            }

            return contacts;
        }
    }
}
