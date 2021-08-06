using Ord.Core.Models;
using Ord.Core.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ord.Core.BusinessLayer
{
    public class CommerceBL : ICommerceBL
    {
        private readonly ICustomerRepository CustomerRepo;
        private readonly IOrderRepository OrderRepo;

        

        public CommerceBL(ICustomerRepository CustomerR, IOrderRepository OrderR)
        {
            this.CustomerRepo = CustomerR;
            this.OrderRepo = OrderR;
        }

        

        public bool CreateCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                return false;

            return CustomerRepo.Add(newCustomer);
        }
        public bool EditCustomer(Customer editedCustomer)
        {
            if (editedCustomer == null)
                return false;

            return CustomerRepo.Update(editedCustomer);
        }

        public IEnumerable<Customer> FetchCustomers(Func<Customer, bool> filter = null)
        {
            if (filter != null)
                return CustomerRepo.Fetch().Where(filter);

            return CustomerRepo.Fetch();
        }

        public Customer FetchCustomerById(int id)
        {
            if (id <= 0)
                return null;

            return CustomerRepo.GetById(id);
        }

        public bool DeleteCustomerById(int idCustomer)
        {
            if (idCustomer <= 0)
                return false;

            Customer CustomerToBeDeleted = this.CustomerRepo.GetById(idCustomer);

            if (CustomerToBeDeleted != null)
                return CustomerRepo.Delete(CustomerToBeDeleted);

            return false;
        }



        public IEnumerable<Order> FetchOrders(Func<Order, bool> filter = null)
        {
            if (filter != null)
                return OrderRepo.Fetch().Where(filter);

            return OrderRepo.Fetch();
        }

        public Order FetchOrderById(int id)
        {
            if (id <= 0)
                return null;

            return OrderRepo.GetById(id);
        }

        public bool CreateOrder(Order newOrder)
        {
            if (newOrder == null)
                return false;

            return OrderRepo.Add(newOrder);
        }

        public bool EditOrder(Order editedOrder)
        {
            if (editedOrder == null)
                return false;

            return OrderRepo.Update(editedOrder);
        }

        public bool DeleteOrderById(int idOrder)
        {
            if (idOrder <= 0)
                return false;

            Order OrderBeDeleted = this.OrderRepo.GetById(idOrder);

            if (OrderBeDeleted != null)
                return OrderRepo.Delete(OrderBeDeleted);

            return false;
        }

    }

}
