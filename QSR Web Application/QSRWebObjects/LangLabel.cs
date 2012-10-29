using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class LangLabel : ErrorLogger
    {
        private string _langLabelCode;
        private string _value;
        private DateTime _modified;

        public string LangLabelCode
        {
            get { return _langLabelCode; }
            set { _langLabelCode = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        /// <summary>
        /// Purpose: Grabs language label information based on language label code
        /// Accepts: String
        /// Returns: Nothing
        /// </summary>
        public void GetLangLabelByCode(string code)
        {
            try
            {
                LangLabelData data = new LangLabelData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetLangLabelByCode(code);

                _langLabelCode = code;
                try{ _value = hsh["value"].ToString(); } catch (Exception){ _value = ""; }
                try{ _modified = Convert.ToDateTime(hsh["modified"]); } catch (Exception){ _modified = DateTime.MinValue; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "LangLabel", "GetLangLabelByCode");
            }
        }
    }
}
