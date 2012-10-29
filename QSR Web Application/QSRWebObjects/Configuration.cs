using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class Configuration : ErrorLogger
    {
        private string _configurationCode;
        private string _description;
        private string _value;
        private bool _isYesNoValue;
        private bool _yesNoValue;
        private DateTime _modified;

        public string ConfigurationCode
        {
            get { return _configurationCode; }
            set { _configurationCode = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public bool IsYesNoValue
        {
            get { return _isYesNoValue; }
            set { _isYesNoValue = value; }
        }

        public bool YesNoValue
        {
            get { return _yesNoValue; }
            set { _yesNoValue = value; }
        }

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        /// <summary>
        /// Purpose: Grabs configuration information based on configuration code
        /// Accepts: String
        /// Returns: Nothing
        /// </summary>
        public void GetConfigurationByCode(string code)
        {
            try
            {
                ConfigurationData data = new ConfigurationData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetConfigurationByCode(code);

                _configurationCode= code;
                try{ _description = hsh["description"].ToString(); } catch (Exception){ _description = ""; }
                try{ _value = hsh["value"].ToString(); } catch (Exception){ _value = ""; }
                try{ _isYesNoValue = Convert.ToBoolean(hsh["isyesnovalue"]); } catch (Exception){ _isYesNoValue = false; }
                try{ _yesNoValue = Convert.ToBoolean(hsh["yesnovalue"]); } catch (Exception){ _yesNoValue = false; }
                try{ _modified = Convert.ToDateTime(hsh["modified"]); } catch (Exception){ _modified = DateTime.MinValue; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Configuration", "GetConfigurationByCode");
            }
        }
    }
}
