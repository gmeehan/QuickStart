using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class LangLabelData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs language label information based on language label code
        /// Accepts: String
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetLangLabelByCode(string code)
        {
            LangLabel obj = new LangLabel();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.LangLabels.FirstOrDefault(l => l.LangLabelCode == code);
                if (obj != null)
                {
                    hsh["langlabelcode"] = obj.LangLabelCode;
                    hsh["value"] = obj.Value;
                    hsh["modified"] = obj.Modified;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "LangLabelData", "GetLangLabelByCode");
            }

            return hsh;
        }
    }
}
