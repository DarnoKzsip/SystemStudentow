using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RekawekApp
{
    public class ControlLayer
    {
        DataAccessLayer dal = new DataAccessLayer();
        bool execute;

        public DataSet DisplayData() {
            DataSet ds = new DataSet();

            ds = dal.DisplayData();

            return ds;

        }

        public List<String> DisplayData(int id) {

            List<string> StudentList = new List<string>();
            DataSet QueryDs = new DataSet();

            
            QueryDs = dal.DisplayData(id);

            //var zmienna = QueryDs.GetXml();
            StudentList.Add(Convert.ToString(QueryDs.Tables[0].Rows[0]["Imie"]));
            StudentList.Add(Convert.ToString(QueryDs.Tables[0].Rows[0]["Nazwisko"]));
            StudentList.Add(Convert.ToString(QueryDs.Tables[0].Rows[0]["NumerAlbumu"]));
            return StudentList;

        }

        public bool InsertData(string imie, string nazwisko, string numeralbumu) {

            bool execute = dal.InsertData(imie,nazwisko,numeralbumu);
            return execute;

        }

        public bool DeletData(string id) {

            int id_studenta = Convert.ToInt16(id);

            bool execute = dal.DeleteData(id_studenta);

            return true;
        }

        public bool UpdateData(string id , string imie, string nazwisko, string numeralbumu)
        {

            int id_studenta = Convert.ToInt16(id);

            bool execute = dal.UpdateData(id_studenta,imie,nazwisko,numeralbumu);

            return true;
        }
    }
}