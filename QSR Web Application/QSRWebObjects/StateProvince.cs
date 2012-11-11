using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class StateProvince : ErrorLogger
    {
        private int _stateProvinceID;
        private string _name;
        private string _country;
        private string _currencyCode;
        private double _taxRatePercentage;
        private DateTime _modified;

        public int StateProvinceID
        {
            get { return _stateProvinceID; }
            set
            {
                try
                {
                    _stateProvinceID = value;
                }
                catch (Exception)
                {
                    _stateProvinceID = 0;
                }
            }
        }

        public Object Name
        {
            get { return _name; }
            set
            {
                try
                {
                    _name = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _name = "";
                }
            }
        }

        public Object Country
        {
            get { return _country; }
            set
            {
                try
                {
                    _country = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _country = "";
                }
            }
        }

        public Object CurrencyCode
        {
            get { return _currencyCode; }
            set
            {
                try
                {
                    _currencyCode = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _currencyCode = "";
                }
            }
        }

        public double TaxRatePercentage
        {
            get { return _taxRatePercentage; }
            set
            {
                try
                {
                    _taxRatePercentage = value;
                }
                catch (Exception)
                {
                    _taxRatePercentage = 0.00;
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
        /// Purpose: Grabs state/province information based on ID
        /// Accepts: Int
        /// Returns: Nothing
        /// </summary>
        public void GetStateProvinceByID(int id)
        {
            try
            {
                StateProvinceData data = new StateProvinceData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetStateProvinceByID(id);

                StateProvinceID = id;
                Name = hsh["name"];
                Country = hsh["country"];
                CurrencyCode = hsh["currencyCode"];
                TaxRatePercentage = Convert.ToDouble(hsh["taxratepercentage"]);
                Modified = hsh["modified"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "StateProvince", "GetStateProvinceByID");
            }
        }

        /// <summary>
        /// Purpose: Grabs all states/provinces
        /// Accepts: Nothing
        /// Returns: List<StateProvince>
        /// </summary>
        public List<StateProvince> GetAllStatesProvinces()
        {
            List<StateProvince> statesProvinces = new List<StateProvince>();
            try
            {
                StateProvinceData data = new StateProvinceData();
                List<QSRDataObjects.StatesProvince> dataStatesProvinces = data.GetAllStatesProvinces();

                foreach (QSRDataObjects.StatesProvince sp in dataStatesProvinces)
                {
                    StateProvince stateProvince = new StateProvince();
                    stateProvince.StateProvinceID = sp.StateProvinceID;
                    stateProvince.Name = sp.Name;
                    stateProvince.Country = sp.Country;
                    stateProvince.CurrencyCode = sp.CurrencyCode;
                    stateProvince.TaxRatePercentage = Convert.ToDouble(sp.TaxRatePercentage);
                    stateProvince.Modified = sp.Modified;
                    statesProvinces.Add(stateProvince);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "StateProvince", "GetAllStateProvinces");
            }
            return statesProvinces;
        }
    }

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderStateProvince
    {
        private int _stateProvinceID;

        public int StateProvinceID
        {
            get { return _stateProvinceID; }
            set { _stateProvinceID = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        private string _currencyCode;

        public string CurrencyCode
        {
            get { return _currencyCode; }
            set { _currencyCode = value; }
        }
        private double _taxRatePercentage;

        public double TaxRatePercentage
        {
            get { return _taxRatePercentage; }
            set { _taxRatePercentage = value; }
        }
        private DateTime _modified;

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        public RenderStateProvince(StateProvince sp)
        {
            StateProvinceID = sp.StateProvinceID;
            Name = Convert.ToString(sp.Name);
            Country = Convert.ToString(sp.Country);
            CurrencyCode = Convert.ToString(sp.CurrencyCode);
            TaxRatePercentage = Convert.ToDouble(sp.TaxRatePercentage);
            Modified = Convert.ToDateTime(sp.Modified);
        }
    }
}
