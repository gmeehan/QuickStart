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
            set { _stateProvinceID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string CurrencyCode
        {
            get { return _currencyCode; }
            set { _currencyCode = value; }
        }

        public double TaxRatePercentage
        {
            get { return _taxRatePercentage; }
            set { _taxRatePercentage = value; }
        }

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
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

                _stateProvinceID = id;
                try{ _name = hsh["name"].ToString(); } catch (Exception){ _name = ""; }
                try{ _country = hsh["country"].ToString(); } catch (Exception){ _country = ""; }
                try{ _currencyCode = hsh["currencyCode"].ToString(); } catch (Exception){ _currencyCode = ""; }
                try{ _taxRatePercentage = Convert.ToDouble(hsh["taxratepercentage"]); } catch (Exception){ _taxRatePercentage = 0.00; }
                try{ _modified = Convert.ToDateTime(hsh["modified"]); } catch (Exception){ _modified = DateTime.MinValue; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "StateProvince", "GetStateProvinceByID");
            }
        }
    }
}
