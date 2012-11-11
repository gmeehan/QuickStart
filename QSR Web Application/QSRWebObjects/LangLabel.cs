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

        public Object LangLabelCode
        {
            get { return _langLabelCode; }
            set
            {
                try
                {
                    _langLabelCode = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _langLabelCode = "";
                }
            }
        }

        public Object Value
        {
            get { return _value; }
            set
            {
                try
                {
                    _value = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _value = "";
                }
            }
        }

        public Object Modified
        {
            get { return _modified; }
            set
            {
                try
                {
                    _modified = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    _modified = DateTime.MinValue;
                }
            }
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

                LangLabelCode = code;
                Value = hsh["value"];
                Modified = hsh["modified"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "LangLabel", "GetLangLabelByCode");
            }
        }
    }
}
