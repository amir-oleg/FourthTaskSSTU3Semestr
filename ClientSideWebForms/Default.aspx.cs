using System;
using ClientSideWebForms.ServiceReference1;

namespace ClientSideWebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btn_GetAllCustomers_Click(object sender, EventArgs e)
        {
            var client = new Service1Client();
            var customers = client.GetAllCustomers();
            
            grid_Customers.DataSource = customers;
            grid_Customers.DataBind();
            client.Close();
        }

        protected void btn_GetOrdersById_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtbox_customerId.Text, out var userId))
            {
                return;
            }

            var client = new Service1Client();
            var orders = client.GetCustomerOrders(userId);
            grid_Orders.DataSource = orders;
            grid_Orders.DataBind();
            client.Close();
        }

        protected void btn_ClearGridCustomer_Click(object sender, EventArgs e)
        {
            grid_Customers.DataSource = null;
            grid_Customers.DataBind();
        }

        protected void btn_ClearGridOrders_Click(object sender, EventArgs e)
        {
            grid_Orders.DataSource = null;
            grid_Orders.DataBind();
        }
    }
}