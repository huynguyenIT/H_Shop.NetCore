﻿using Model.DTO.DTO_Client;
using Model.DTO_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UI.Service;
using PagedList;
using Model.DTO.DTO_Ad;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        ServiceRepository service = new ServiceRepository();

        public ActionResult TypeProduct()
        {
            HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/GetAllProductByType");
            responseMessage.EnsureSuccessStatusCode();
            List<List<DTO_Dis_Product>> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<List<DTO_Dis_Product>>>().Result;


            //HttpResponseMessage responseMessage3 = service.GetResponse("api/Products_Ad/GetAllProductByType");
            //responseMessage3.EnsureSuccessStatusCode();
            //List<List<DTO_Product>> dTO_Accounts2 = responseMessage3.Content.ReadAsAsync<List<List<DTO_Product>>>().Result;
            var view = dTO_Accounts.ToPagedList(1, 50);
            return View(view);

        }
        // GET: Product
        public ActionResult Index(FormCollection fc, int? page, int? gia, int? gia_, string searchName1)
        {

            var searchName = fc["searchName"];
            var searchPrice = Request.Form["searchPrice"];
            var priceGiaMin = Request.Form["priceGiaMin"];
            var priceGiaMax = Request.Form["priceGiaMax"];
            var max500 = Request.Form["max500"];
            var max1tr = Request.Form["max1tr"];
            var max2tr = Request.Form["max2tr"];
            var max = Request.Form["max"];




            if (page == null) page = 1;
            int pageSize = 25;

            int pageNumber = (page ?? 1);

            if ((searchName != null && searchName != "") || (searchName1 != "" && searchName1 != null))
            {
                try
                {
                    HttpResponseMessage responseMessage2 = service.GetResponse("api/product/GetAllProductByName/" + searchName);
                    responseMessage2.EnsureSuccessStatusCode();

                    List<DTO_Dis_Product> dTO_Accounts2 = responseMessage2.Content.ReadAsAsync<List<DTO_Dis_Product>>().Result;
                    return View(dTO_Accounts2.ToPagedList(pageNumber, pageSize));
                }
                catch
                {
                    HttpResponseMessage responseMessage3 = service.GetResponse("api/product/GetAllProductByName/" + searchName1);
                    responseMessage3.EnsureSuccessStatusCode();

                    List<DTO_Dis_Product> dTO_Accounts3 = responseMessage3.Content.ReadAsAsync<List<DTO_Dis_Product>>().Result;
                    return View(dTO_Accounts3.ToPagedList(pageNumber, pageSize));

                }



            }

            //if (searchPrice !=null && searchPrice !="" && searchPrice!="0")
            //{
            //    //if (max500 )
            //    //{
            //    //    gia_ = 0; gia = 500000;
            //    //}
            //    if (searchPrice == "2")
            //    {
            //        gia_ = 500000; gia = 1000000;
            //    }
            //    if (searchPrice == "3")
            //    {
            //        gia_ = 1000000; gia = 2000000;
            //    }
            //    if (searchPrice == "4")
            //    {
            //        gia_ = 2000000; gia = 1000000000;
            //    }


            //}

            if (priceGiaMin != null && priceGiaMax != null && priceGiaMin != "" && priceGiaMax != "")
            {
                HttpResponseMessage responseMessage2 = service.GetResponse("api/product/GetAllProductByPrice/" + priceGiaMin + "/" + priceGiaMax);
                responseMessage2.EnsureSuccessStatusCode();

                List<DTO_Dis_Product> dTO_Accounts2 = responseMessage2.Content.ReadAsAsync<List<DTO_Dis_Product>>().Result;
                return View(dTO_Accounts2.ToPagedList(pageNumber, pageSize));
            }
            try
            {

                HttpResponseMessage responseMessage2 = service.GetResponse("api/product/GetAllProductByPrice/" + gia_ + "/" + gia);
                responseMessage2.EnsureSuccessStatusCode();

                List<DTO_Dis_Product> dTO_Accounts2 = responseMessage2.Content.ReadAsAsync<List<DTO_Dis_Product>>().Result;
                return View(dTO_Accounts2.ToPagedList(pageNumber, pageSize));


            }
            catch
            {
                //HttpResponseMessage responseMessage = service.GetResponse("api/product/GetAllProducts");
                //responseMessage.EnsureSuccessStatusCode();
                //List<DTO_Product_Client> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Product_Client>>().Result;
                //return View(dTO_Accounts.ToPagedList(pageNumber, pageSize));
                HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/GetAllProduct_Discount");
                responseMessage.EnsureSuccessStatusCode();
                List<DTO_Dis_Product> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Dis_Product>>().Result;
                return View(dTO_Accounts.ToPagedList(pageNumber, pageSize));

            }






        }
        public ActionResult Index_(DTO_Dis_Product dTO_Product, int? page)
        {
            if (page == null) page = 1;
            int pageSize = 25;

            int pageNumber = (page ?? 1);
            HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/GetAllProduct_Discount");
            responseMessage.EnsureSuccessStatusCode();
            List<DTO_Dis_Product> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Dis_Product>>().Result;
            return View(dTO_Accounts.ToPagedList(pageNumber, pageSize));










        }
        public ActionResult Search(int? page, string searchName)
        {





            if (page == null) page = 1;
            int pageSize = 10;

            int pageNumber = (page ?? 1);




            HttpResponseMessage responseMessage2 = service.GetResponse("api/product/GetAllProductByName/" + searchName);
            responseMessage2.EnsureSuccessStatusCode();

            List<DTO_Product_Client> dTO_Accounts2 = responseMessage2.Content.ReadAsAsync<List<DTO_Product_Client>>().Result;
            return View(dTO_Accounts2.ToPagedList(pageNumber, pageSize));







        }
        public ActionResult Index2(int id, string seachBy, string search, int? page, int? gia, int? gia_)
        {



            if (page == null) page = 1;



            int pageSize = 10;

            int pageNumber = (page ?? 1);

            if (seachBy == "NameProduct")
            {
                //return View(db.Products.Where(s => s.Name.StartsWith(search)).ToList().ToPagedList(pageNumber, pageSize));
                HttpResponseMessage responseMessage2 = service.GetResponse("api/product/GetAllProductByName/" + search);
                responseMessage2.EnsureSuccessStatusCode();

                List<DTO_Dis_Product> dTO_Accounts2 = responseMessage2.Content.ReadAsAsync<List<DTO_Dis_Product>>().Result;
                return View(dTO_Accounts2.ToPagedList(pageNumber, pageSize));

            }


            if (seachBy == "Price")
            {

                HttpResponseMessage responseMessage2 = service.GetResponse("api/product/GetAllProductByPrice/" + gia_ + "/" + gia);
                responseMessage2.EnsureSuccessStatusCode();

                List<DTO_Dis_Product> dTO_Accounts2 = responseMessage2.Content.ReadAsAsync<List<DTO_Dis_Product>>().Result;
                return View(dTO_Accounts2.ToPagedList(pageNumber, pageSize));

            }
            HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/GetAllProductByIdItem/" + id);
            responseMessage.EnsureSuccessStatusCode();

            List<DTO_Dis_Product> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Dis_Product>>().Result;

            if (dTO_Accounts == null)
            {
                return Content("Chưa có sản phẩm bạn đang muốn tìm kiếm");
            }
            var view = dTO_Accounts.ToPagedList(1, 10);
            return View(view);

        }

        // GET: Product/Details/5
        public ActionResult Details()
        {

            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
            if (cart == null)
            {
                return View("~/Cart/Thankyou1");
            }


            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public PartialViewResult BagCart()
        {



            //    int item = 0;
            //List<Item> cart = (List<Item>)Session["cart"];
            //Item item1 = new Item();

            //if (cart != null)
            //  item=

            try
            {
                if (Session["cart"] != null)
                {
                    List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];

                    int total = cart.Count();
                    ViewBag.Quantity = total;

                }
            }
            catch
            {

                ViewBag.Quantity = 0;

            }


            //ViewBag.Quantity = item;




            return PartialView("BagCart");
        }
        public PartialViewResult BagCart_()
        {



            try
            {
                if (Session["cart_"] != null)
                {
                    List<DTO_Product_Item_Type> cart_ = (List<DTO_Product_Item_Type>)Session["cart_"];

                    int total1 = cart_.Count();
                    ViewBag.yeuthich = total1;

                }
            }
            catch
            {

                ViewBag.yeuthich = 0;

            }

            //ViewBag.Quantity = item;




            return PartialView("BagCart_");
        }

        private int isExist(string Id)
        {
            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];

            for (int i = 0; i < cart.Count; i++)
                if (cart[i]._id.Equals(Id))
                    return i;
            return -1;
        }
        public ActionResult Remove(string Id)
        {
            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
            int index = isExist(Id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Details");
        }
        public ActionResult Buy(string Id)
        {

            HttpResponseMessage response = service.GetResponse("api/Product/GetSoLuong/" + Id);

            response.EnsureSuccessStatusCode();
            int quantity = response.Content.ReadAsAsync<int>().Result;
            if (quantity > 0)
            {
                if (Session["cart"] == null)
                {
                    List<DTO_Product_Item_Type> li = new List<DTO_Product_Item_Type>();
                    // var product = db.Products.Find(Id);

                    HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                    responseUser.EnsureSuccessStatusCode();
                    DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;


                    li.Add(new DTO_Product_Item_Type()
                    {

                        Quantity = 1,
                        _id = proItem._id,
                        Id_SanPham = proItem.Id_SanPham,
                        Name = proItem.Name,
                        Price = proItem.Price,
                        Details = proItem.Details,
                        Photo = proItem.Photo,
                        Id_Item = proItem.Id_Item,
                        //Quantity = item.Quantity
                    });
                    Session["cart"] = li;






                }
                else
                {
                    List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                    HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                    responseUser.EnsureSuccessStatusCode();
                    DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                    int index = isExist(Id);
                    if (index != -1)
                    {
                        li[index].Quantity++;
                    }
                    else
                    {
                        li.Add(new DTO_Product_Item_Type()
                        {

                            Id_SanPham = proItem.Id_SanPham,
                            _id = proItem._id,
                            Name = proItem.Name,
                            Price = proItem.Price,
                            Details = proItem.Details,
                            Photo = proItem.Photo,
                            Id_Item = proItem.Id_Item,
                            Quantity = 1
                        });

                    }


                    Session["cart"] = li;

                }
                return RedirectToAction("Details", "Product");
            }
            else
            {

                return RedirectToAction("HetHang", "Cart");
            }


        }







        public ActionResult Buy_Favorite(string Id)
        {




            HttpResponseMessage response = service.GetResponse("api/Product/GetSoLuong/" + Id);



            //  // response.EnsureSuccessStatusCode();
            int quantity2 = response.Content.ReadAsAsync<int>().Result;

            if (quantity2 > 0)
            {
                if (Session["cart"] == null)
                {
                    List<DTO_Product_Item_Type> li = new List<DTO_Product_Item_Type>();
                    // var product = db.Products.Find(Id);

                    HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                    responseUser.EnsureSuccessStatusCode();
                    DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;



                    li.Add(new DTO_Product_Item_Type()
                    {

                        Quantity = 1,
                        Id_SanPham = proItem.Id_SanPham,
                        _id = proItem._id,
                        Name = proItem.Name,
                        Price = proItem.Price,
                        Details = proItem.Details,
                        Photo = proItem.Photo,
                        Id_Item = proItem.Id_Item,
                        //Quantity = item.Quantity
                    });
                    Session["cart"] = li;
                    return Json(new { buy = li, status = "Thành công" });






                }
                else
                {
                    List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                    HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                    responseUser.EnsureSuccessStatusCode();
                    DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                    int index = isExist(Id);
                    if (index != -1)
                    {
                        li[index].Quantity++;
                    }
                    else
                    {
                        li.Add(new DTO_Product_Item_Type()
                        {

                            Id_SanPham = proItem.Id_SanPham,
                            _id = proItem._id,
                            Name = proItem.Name,
                            Price = proItem.Price,
                            Details = proItem.Details,
                            Photo = proItem.Photo,
                            Id_Item = proItem.Id_Item,
                            Quantity = 1
                        });
                        return Json(new { buy = li, status = "Thành công" });
                    }


                    Session["cart"] = li;
                    return Json(new { buy = li, status = "Thành công" });

                }

            }
            else
            {

                //ViewData["MessQuantity"] = ("Sản phẩm đã hết");
                //return RedirectToAction("HetHang", "Cart");
                return Json(new { buy = 0, status = "Hết hàng" });
            }

            //return View();
        }
        //public ActionResult Buy_Favorite(string Id)
        //{
        //    bool flag = true;
        //    List<string> messages = new List<string>();
        //    List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
        //    foreach (var item in cart)
        //    {
        //        //int quantityBuy = Convert.ToInt32(Request.Form["quantity"]);

        //        HttpResponseMessage response = service.GetResponse("api/Product/GetSoLuong/" + item._id);

        //        response.EnsureSuccessStatusCode();
        //        int quantity = response.Content.ReadAsAsync<int>().Result;
        //        int quantityAfterBuy = quantity - (int)item.Quantity;
        //        if (quantityAfterBuy < -1)
        //        {
        //            flag = false;
        //            string message = (item.Name + " đã vượt quá số lượng đang có");
        //            messages.Add(message);
        //        }
        //    }
        //    ViewData["messages"] = messages;
        //    if (flag)



        //    {
        //        if (Session["cart"] == null)
        //        {
        //            List<DTO_Product_Item_Type> li = new List<DTO_Product_Item_Type>();
        //            // var product = db.Products.Find(Id);

        //            HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
        //            responseUser.EnsureSuccessStatusCode();
        //            DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;



        //            li.Add(new DTO_Product_Item_Type()
        //            {

        //                Quantity = 1,
        //                Id_SanPham = proItem.Id_SanPham,
        //                _id = proItem._id,
        //                Name = proItem.Name,
        //                Price = proItem.Price,
        //                Details = proItem.Details,
        //                Photo = proItem.Photo,
        //                Id_Item = proItem.Id_Item,
        //                //Quantity = item.Quantity
        //            });
        //            Session["cart"] = li;
        //            return Json(new { buy = li, status = "Thành công" });






        //        }
        //        else
        //        {
        //            List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
        //            HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
        //            responseUser.EnsureSuccessStatusCode();
        //            DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

        //            int index = isExist(Id);
        //            if (index != -1)
        //            {
        //                li[index].Quantity++;
        //            }
        //            else
        //            {
        //                li.Add(new DTO_Product_Item_Type()
        //                {

        //                    Id_SanPham = proItem.Id_SanPham,
        //                    _id = proItem._id,
        //                    Name = proItem.Name,
        //                    Price = proItem.Price,
        //                    Details = proItem.Details,
        //                    Photo = proItem.Photo,
        //                    Id_Item = proItem.Id_Item,
        //                    Quantity = 1
        //                });
        //                return Json(new { buy = li, status = "Thành công" });
        //            }


        //            Session["cart"] = li;
        //            return Json(new { buy = li, status = "Thành công" });

        //        }

        //    }
        //    else
        //    {

        //        //ViewData["MessQuantity"] = ("Sản phẩm đã hết");
        //        //return RedirectToAction("HetHang", "Cart");
        //        return Json(new { buy = 0, status = "Hết hàng" });
        //    }

        //    //return View();
        //}
        public ActionResult Giam(string Id, DTO_Product_Item_Type item1)
        {
            if (Session["cart"] == null)
            {
                List<DTO_Product_Item_Type> li = new List<DTO_Product_Item_Type>();
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                li.Add(new DTO_Product_Item_Type()
                {

                    Id_SanPham = proItem.Id_SanPham,
                    _id = proItem._id,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    Quantity = 1
                });
                foreach (var item in li)
                {
                    if (item.Quantity < 0)
                        item.Quantity = 1;
                }
                Session["cart"] = li;
                return Json(new { soLuong = li });





            }
            else
            {
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                int index = isExist(Id);
                if (index != -1)
                {
                    if (li[index].Quantity - 1 > 0)
                    {
                        li[index].Quantity--;
                        li[index].Price = proItem.Price * li[index].Quantity;
                    }

                }
                else
                {
                    li.Add(new DTO_Product_Item_Type()
                    {
                        Id_SanPham = proItem.Id_SanPham,
                        _id = proItem._id,
                        Name = proItem.Name,
                        Price = proItem.Price,
                        Details = proItem.Details,
                        Photo = proItem.Photo,
                        Id_Item = proItem.Id_Item,
                        Quantity = -1
                    });
                    return Json(new { soLuong = li });

                }

                Session["cart"] = li;
                return Json(new { soLuong = li });
            }



        }
        public ActionResult Update(string Id, FormCollection fc)
        {

            List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
            HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
            responseUser.EnsureSuccessStatusCode();
            DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

            int index = isExist(Id);
            if (index != -1)
            {


                li[index].Quantity++;


            }
            else
            {
                li.Add(new DTO_Product_Item_Type()
                {

                    Id_SanPham = proItem.Id_SanPham,
                    _id = proItem._id,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    Quantity = 1
                });

            }


            Session["cart"] = li;


            return RedirectToAction("Details", "Product");
        }
        [HttpPost]
        public ActionResult Tang(string Id, DTO_Product_Item_Type item1)
        {
            if (Session["cart"] == null)
            {
                List<DTO_Product_Item_Type> li = new List<DTO_Product_Item_Type>();
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;
                DTO_Product_Item_Type dTO_Product_Item_Type = new DTO_Product_Item_Type();
                li.Add(new DTO_Product_Item_Type()
                {

                    Id_SanPham = proItem.Id_SanPham,
                    _id = proItem._id,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    Quantity = 1
                });
                Session["cart"] = li;
                return Json(new { soLuong = li });





            }
            else
            {
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                int index = isExist(Id);
                if (index != -1)
                {
                    li[index].Quantity++;
                    li[index].Price = proItem.Price * li[index].Quantity;
                }
                else
                {
                    DTO_Product_Item_Type dTO_Product_Item_Type = new DTO_Product_Item_Type();
                    li.Add(new DTO_Product_Item_Type()
                    {
                        Id_SanPham = proItem.Id_SanPham,
                        _id = proItem._id,
                        Name = proItem.Name,
                        Price = proItem.Price,
                        Details = proItem.Details,
                        Photo = proItem.Photo,
                        Id_Item = proItem.Id_Item,
                        Quantity = +1
                    });
                    return Json(new { soLuong = li });

                }


                Session["cart"] = li;
                return Json(new { soLuong = li });
            }

        }

        public ActionResult Details1(string Id)
        {
            if (Session["cart__"] == null)
            {
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                //var product = db.Products.Find(Id);

                new DTO_Product_Item_Type()
                {
                    Id_SanPham = proItem.Id_SanPham,
                    _id = proItem._id,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    Quantity = 1
                };
                Session["cart__"] = proItem;






            }
            else
            {
                //    Item li = (Item)Session["cart__"];
                //    var product = db.Products.Find(Id);



                //        new Item()
                //        {
                //            Product = product,
                //            Quantity = 1
                //        };
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                new DTO_Product_Item_Type()
                {
                    Id_SanPham = proItem.Id_SanPham,
                    _id = proItem._id,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    Quantity = 1
                };
                Session["cart__"] = proItem;






            }
            return RedirectToAction("LuaChon", "Cart");
        }
        public PartialViewResult Search()
        {
            return PartialView("Search");
        }
        public ActionResult TheThaovaDuLich(List<DTO_Item_Type> dTO_Item_Type)
        {
            return View(dTO_Item_Type);
        }
       


    }
}
