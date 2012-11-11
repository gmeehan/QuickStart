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

        /// <summary>
        /// Purpose: Grabs all configuration settings
        /// Accepts: Nothing
        /// Returns: List<Configuration>
        /// </summary>
        public List<Configuration> GetAllConfigurations()
        {
            List<Configuration> configs = new List<Configuration>();
            try
            {
                ConfigurationData data = new ConfigurationData();
                List<QSRDataObjects.Configuration> dataConfigs = data.GetAllConfigurations();

                foreach (QSRDataObjects.Configuration c in dataConfigs)
                {
                    Configuration config = new Configuration();
                    config.ConfigurationCode = c.ConfigurationCode;
                    config.Description = c.Description;
                    config.Value = c.Value;
                    config.IsYesNoValue = c.IsYesNoValue;
                    config.YesNoValue = c.YesNoValue;
                    config.Modified = c.Modified;
                    configs.Add(config);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Configuration", "GetAllConfigurations");
            }
            return configs;
        }
    }

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderConfiguration
    {
        private string _configurationCode;

        public string ConfigurationCode
        {
            get { return _configurationCode; }
            set { _configurationCode = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private bool _isYesNoValue;

        public bool IsYesNoValue
        {
            get { return _isYesNoValue; }
            set { _isYesNoValue = value; }
        }
        private bool _yesNoValue;

        public bool YesNoValue
        {
            get { return _yesNoValue; }
            set { _yesNoValue = value; }
        }
        private DateTime _modified;

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        public RenderConfiguration(Configuration c)
        {
            ConfigurationCode = Convert.ToString(c.ConfigurationCode);
            Description = Convert.ToString(c.Description);
            Value = Convert.ToString(c.Value);
            IsYesNoValue = Convert.ToBoolean(c.IsYesNoValue);
            YesNoValue = Convert.ToBoolean(c.YesNoValue);
            Modified = Convert.ToDateTime(c.Modified);
        }

    }
}
