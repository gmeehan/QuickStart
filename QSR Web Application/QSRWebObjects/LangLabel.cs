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

        /// <summary>
        /// Purpose: Grabs all language labels
        /// Accepts: Nothing
        /// Returns: List<LangLabel>
        /// </summary>
        public List<LangLabel> GetAllLangLabels()
        {
            List<LangLabel> langlabels = new List<LangLabel>();
            try
            {
                LangLabelData data = new LangLabelData();
                List<QSRDataObjects.LangLabel> dataAudits = data.GetAllLangLabels();

                foreach (QSRDataObjects.LangLabel l in dataAudits)
                {
                    LangLabel langLabel = new LangLabel();
                    langLabel.LangLabelCode = l.LangLabelCode;
                    langLabel.Value = l.Value;
                    langLabel.Modified = l.Modified;
                    langlabels.Add(langLabel);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "LangLabel", "GetAllLangLabels");
            }
            return langlabels;
        }
    }

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderLangLabel
    {
        private string _langLabelCode;

        public string LangLabelCode
        {
            get { return _langLabelCode; }
            set { _langLabelCode = value; }
        }
        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private DateTime _modified;

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        public RenderLangLabel(LangLabel l)
        {
            LangLabelCode = Convert.ToString(l.LangLabelCode);
            Value = Convert.ToString(l.Value);
            Modified = Convert.ToDateTime(l.Modified);
        }

    }

}
