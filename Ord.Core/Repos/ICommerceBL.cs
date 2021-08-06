using Ord.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ord.Core.Repos
{
    public interface ICommerceBL
    {
        

        IEnumerable<Customer> FetchCustomers(Func<Customer, bool> filter = null);
        Customer FetchCustomerById(int id);
        bool CreateCustomer(Customer newCustomer);
        bool EditCustomer(Customer editedCustomer);
        bool DeleteCustomerById(int idCustomer);

        

        
        IEnumerable<Order> FetchOrders(Func<Order, bool> filter = null);
        Order FetchOrderById(int id);
        bool CreateOrder(Order newOrder);
        bool EditOrder(Order editedOrder);
        bool DeleteOrderById(int idOrder);

        

        
    }
}
