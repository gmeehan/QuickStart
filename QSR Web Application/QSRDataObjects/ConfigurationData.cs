using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class ConfigurationData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs configuration information based on configuration code
        /// Accepts: String
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetConfigurationByCode(string code)
        {
            Configuration obj = new Configuration();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.Configurations.FirstOrDefault(c => c.ConfigurationCode == code);
                if (obj != null)
                {
                    hsh["configurationcode"] = obj.ConfigurationCode;
                    hsh["description"] = obj.Description;
                    hsh["value"] = obj.Value;
                    hsh["isyesnovalue"] = obj.IsYesNoValue;
                    hsh["yesnovalue"] = obj.YesNoValue;
                    hsh["modified"] = obj.Modified;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "ConfigurationData", "GetConfigurationByCode");
            }

            return hsh;
        }
    }
}
