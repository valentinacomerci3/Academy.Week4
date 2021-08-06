using Ord.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CommerceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IEnumerable<Customer> FetchCustomers();

        [OperationContract]
        bool CreateCustomer(Customer newCustomer);

        [OperationContract]
        bool EditCustomer(Customer editedCustomer);

        [OperationContract]
        bool DeleteCustomerById(int idCustomer);

        
    }
}
