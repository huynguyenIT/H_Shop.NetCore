﻿using DataAndServices.CommonModel;
using DataAndServices.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Client_Services
{
    public interface ICartServices
    {
        Task<int> InsertBill(CheckoutCustomer_Order dTO_CheckoutCustomer_Order);


        Task<bool> InsertCheckoutOrder(Checkout_Oder checkout_Order);


        Task<double> GetGiamGia(string zipcode);
      
    }
}
