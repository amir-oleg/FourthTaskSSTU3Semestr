using System.Collections.Generic;
using WcfMyServiceLibrary.Models;

namespace WcfMyServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public List<Customer> GetAllCustomers()
        {
            var sqlRepository = new SqlRepository();
            return sqlRepository.GetAllCustomers();
        }

        public List<Order> GetCustomerOrders(int userId)
        {
            var sqlRepository = new SqlRepository();
            return sqlRepository.GetOrdersByUserId(userId);
        }
    }
}
