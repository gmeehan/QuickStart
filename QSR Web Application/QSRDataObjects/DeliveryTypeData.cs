using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class DeliveryTypeData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs delivery type information based on ID
        /// Accepts: Int
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetDeliveryTypeByID(int id)
        {
            DeliveryType obj = new DeliveryType();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.DeliveryTypes.FirstOrDefault(d => d.DeliveryTypeID == id);
                if (obj != null)
                {
                    hsh["deliverytypeid"] = obj.DeliveryTypeID;
                    hsh["name"] = obj.Name;
                    hsh["description"] = obj.Description;
                    hsh["cost"] = obj.Cost;
                    hsh["created"] = obj.Created;
                    hsh["modified"] = obj.Modified;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "DeliveryTypeData", "GetDeliveryTypeByID");
            }

            return hsh;
        }

        /// <summary>
        /// Purpose: Grabs all delivery types
        /// Accepts: Nothing
        /// Returns: List<DeliveryType>
        /// </summary>
        public List<DeliveryType> GetAllDeliveryTypes()
        {
            QuickStart_DBEntities dbContext;
            List<DeliveryType> alldeliverytypes = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                //all delivery types are returned
                alldeliverytypes = dbContext.DeliveryTypes.ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "DeliveryTypeData", "GetAllDeliveryTypes");
            }

            return alldeliverytypes;
        }
    }
}
