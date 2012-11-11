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

        public Object ConfigurationCode
        {
            get { return _configurationCode; }
            set
            {
                try
                {
                    _configurationCode = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _configurationCode = "";
                }
            }
        }

        public Object Description
        {
            get { return _description; }
            set
            {
                try
                {
                    _description = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _description = "";
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

        public Object IsYesNoValue
        {
            get { return _isYesNoValue; }
            set
            {
                try
                {
                    _isYesNoValue = Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    _isYesNoValue = false;
                }
            }
        }

        public Object YesNoValue
        {
            get { return _yesNoValue; }
            set
            {
                try
                {
                    _yesNoValue = Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    _yesNoValue = false;
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

                ConfigurationCode= code;
                Description = hsh["description"];
                Value = hsh["value"];
                IsYesNoValue = hsh["isyesnovalue"];
                YesNoValue = hsh["yesnovalue"];
                Modified = hsh["modified"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Configuration", "GetConfigurationByCode");
            }
        }
    }
}
