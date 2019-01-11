using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winDapper
{
    class InsertProduct
    {
        private string productname;

        public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }
        private string companyname;

        public string CompanyName
        {
            get { return companyname; }
            set { companyname = value; }
        }

        private string categoryname;

        public string CategoryName
        {
            get { return categoryname; }
            set { categoryname = value; }
        }

        private decimal unitprice;

        public decimal UnitPrice
        {
            get { return unitprice; }
            set { unitprice = value; }
        }

    }
}
