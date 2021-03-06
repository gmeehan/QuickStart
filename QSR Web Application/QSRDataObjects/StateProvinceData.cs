﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class StateProvinceData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs state/province information based on ID
        /// Accepts: Int
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetStateProvinceByID(int id)
        {
            StatesProvince obj = new StatesProvince();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.StatesProvinces.FirstOrDefault(s => s.StateProvinceID == id);
                if (obj != null)
                {
                    hsh["stateprovinceid"] = obj.StateProvinceID;
                    hsh["name"] = obj.Name;
                    hsh["country"] = obj.Country;
                    hsh["currencycode"] = obj.CurrencyCode;
                    hsh["taxratepercentage"] = obj.TaxRatePercentage;
                    hsh["modified"] = obj.Modified;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "StateProvinceData", "GetStateProvinceByID");
            }

            return hsh;
        }


        /// <summary>
        /// Purpose: Grabs all StatesProvinces
        /// Accepts: Nothing
        /// Returns: List<StatesProvince>
        /// </summary>
        public List<StatesProvince> GetAllStatesProvinces()
        {
            QuickStart_DBEntities dbContext;
            List<StatesProvince> allstatesprovinces = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                //all states/provinces are returned
                allstatesprovinces = dbContext.StatesProvinces.ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "StatesProvinceData", "GetAllStatesProvinces");
            }

            return allstatesprovinces;
        }
    }
}
