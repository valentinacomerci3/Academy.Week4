using Ord.Core.Models;
using Ord.Core.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommerceEF.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly CommerceContext ctx;

        public EFOrderRepository() : this(new CommerceContext()) { }

        public EFOrderRepository(CommerceContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Order newOrder)
        {
            if (newOrder == null)
                return false;

            try
            {
                ctx.Orders.Add(newOrder);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Order item)
        {
            if (item == null)
                return false;

            try
            {
                var Customer = ctx.Orders.Find(item.Id);

                if (Customer != null)
                    ctx.Orders.Remove(Customer);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Order> Fetch()
        {
            try
            {
                return ctx.Orders.ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }

        public Order GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Orders.Find(id);
        }

        public Order GetByISBN(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                return null;

            try
            {
                var Customer = ctx.Orders.Find(isbn);

                return Customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Order updatedOrder)
        {
            if (updatedOrder == null)
                return false;

            try
            {
                ctx.Orders.Update(updatedOrder);
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
