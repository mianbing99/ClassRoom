using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webz {
    public class model {
        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }

        private string count;

        public string Count {
            get { return count; }
            set { count = value; }
        }
        private double money;

        public double Money {
            get { return money; }
            set { money = value; }
        }
        private double zmoney;

        public double Zmoney {
            get { return zmoney; }
            set { zmoney = value; }
        }
        private double shouru;

        public double Shouru {
            get { return shouru; }
            set { shouru = value; }
        }
        private DateTime time;

        public DateTime Time {
            get { return time; }
            set { time = value; }
        }
    }
}