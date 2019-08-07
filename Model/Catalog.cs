using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model {
    public class Catalog {
        private int caID;

        public int CaID {
            get { return caID; }
            set { caID = value; }
        }
        private string  caNum;

        public string CaNum {
            get { return caNum; }
            set { caNum = value; }
        }
        private string caName;

        public string CaName {
            get { return caName; }
            set { caName = value; }
        }
        private int tID;

        public int TID {
            get { return tID; }
            set { tID = value; }
        }
        private int textID;

        public int TextID {
            get { return textID; }
            set { textID = value; }
        }
        private int page;

        public int Page {
            get { return page; }
            set { page = value; }
        }
        private string author;

        public string Author {
            get { return author; }
            set { author = value; }
        }
        private string state;

        public string State {
            get { return state; }
            set { state = value; }
        }
        private int viid;

        public int Viid {
            get { return viid; }
            set { viid = value; }
        }
    }
}