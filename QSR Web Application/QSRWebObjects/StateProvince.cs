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
    }
}
