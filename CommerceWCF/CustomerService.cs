using CommerceEF.Repository;
using Ord.Core.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CommerceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CustomerService : ICustomerService
    {
        CommerceBL mainBL;

        public CustomerService()
        {
            mainBL = new CommerceBL(new EFCustomerRepository());
        }

        public bool CreateCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                return false;

            return this.mainBL.CreateCustomer(newCustomer);
        }



        public bool DeleteCustomerById(int idCustomer)
        {
            if (idCustomer > 0)
                return this.mainBL.DeleteCustomerById(idCustomer);

            return false;
        }



        public bool EditCustomer(Customer editedCustomer)
        {
            if (editedCustomer == null)
                return false;

            return this.mainBL.EditCustomer(editedCustomer);
        }



        public IEnumerable<Customer> FetchCustomers()
        {
            return this.mainBL.FetchCustomers();
        }


    }
}
}
