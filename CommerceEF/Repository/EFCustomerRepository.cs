using Microsoft.EntityFrameworkCore;
using Ord.Core.Models;
using Ord.Core.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommerceEF.Repository
{
    
        public class EFCustomerRepository : ICustomerRepository
        {
            private readonly CommerceContext ctx;

            public EFCustomerRepository() : this(new CommerceContext()) { }

            public EFCustomerRepository(CommerceContext ctx)
            {
                this.ctx = ctx;
            }

            public bool Add(Customer newCustomer)
            {
                if (newCustomer == null)
                    return false;

                try
                {
                    ctx.Customers.Add(newCustomer);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public bool Delete(Customer item)
            {
                if (item == null)
                    return false;

                try
                {
                    var Customer = ctx.Customers.Find(item.Id);

                    if (Customer != null)
                        ctx.Customers.Remove(Customer);

                    ctx.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public List<Customer> Fetch()
            {
                try
                {
                    return ctx.Customers.Include(b => b.Orders).ToList();
                }
                catch (Exception)
                {
                    return new List<Customer>();
                }
            }

            public Customer GetById(int id)
            {
                if (id <= 0)
                    return null;

                return ctx.Customers.Find(id);
            }

            

            public bool Update(Customer updatedCustomer)
            {
                if (updatedCustomer == null)
                    return false;

                try
                {
                    ctx.Customers.Update(updatedCustomer);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    
}
