using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.WebPages;
using ApiRestClient.Infrastructure;
using Domain.Models;
using Domain.Models.Orders;
using Microsoft.Ajax.Utilities;
using Microsoft.Data.Edm.Expressions;
using RestSharp;
using RestSharp.Serializers;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;

namespace VirtualOffice.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class ToolsController : VirtualOfficeController
    {
        public ToolsController(IWebClient webClient) : base(webClient)
        {
        }

        public ActionResult CompanyPolice()
        {

            ViewBag.Reports = GetUserReports(GetLoggedUserId()).Where(rep => rep.IsStandAlone);

            return View();
        }

        public ActionResult ContactList()
        {

            ViewBag.Reports = GetUserReports(GetLoggedUserId()).Where(rep => rep.IsStandAlone);

            return View();
        }

        public ActionResult MarketingMaterial()
        {

            ViewBag.Reports = GetUserReports(GetLoggedUserId());

            ViewBag.MarketingMaterials = GetMarketingMaterials();

            return View();
        }

        public ActionResult FormsApplications()
        {
            ViewBag.Reports = GetUserReports(GetLoggedUserId());

            var documents = GetDocuments().ToList();

            documents.ForEach(d=> d.file_name = Utils.VoDocumentsPhisicalLocation + d.file_name);

            ViewBag.Documents = documents;

            return View();
            
        }

        public ActionResult SoftwareDownload()
        {
            ViewBag.Reports = GetUserReports(GetLoggedUserId());

            return View();
        }

        [HttpPost]
        public ActionResult GetMaterialsByCategory(string categories)
        {
            var selectedCategories = new JavaScriptSerializer().Deserialize<IEnumerable<string>>(categories);

            var materials = GetMarketingMaterials();

            var idsResult = materials.Select(a => new { a.Id, Visible = selectedCategories.Contains(a.Category) }).ToArray();
            
            return Json(idsResult);
        }


        [HttpPost]
        public ActionResult GetOrderSummary(string mySelection)
        {
            try
            {
                var selectionDeserialized = new JavaScriptSerializer().Deserialize<IEnumerable<MarketingMaterialSelection>>(mySelection);

                var positiveSelection = selectionDeserialized.Where(selected => selected.Quantity > 0);

                var allMaterials = GetMarketingMaterials();

                var selection = allMaterials.Join(positiveSelection, marketing => marketing.Id, select => select.Id, (a, b) => new { a.Category, a.Id, b.Quantity });

                var selectionGrouped = selection.GroupBy(a => a.Category);

                var result = selectionGrouped.Select(group => new { Category = group.Key, Amount = group.Sum(a => a.Quantity) });

                //To be changed
                var shippingCost = 15;

                return Json(new { Summary = result, Cost = shippingCost });
            }
            catch (Exception exception)
            {
                return null;
            }
        
        }

        [HttpPost]
        public ActionResult GetThingIds()
        {
            try
            {
                var marketingMaterial = GetMarketingMaterials();

                var thingIds = marketingMaterial.Select(mark => mark.Id);

                return Json(thingIds);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult SendOrder(string things)
        {
            try
            {
                var userLogged = Session[Utils.UserKey] as UserModel;

                var thingsSelected = new JavaScriptSerializer().Deserialize<IEnumerable<MarketingMaterialSelection>>(things);

                var positiveSelection = thingsSelected.Where(selected => selected.Quantity > 0);

                var thingsInfo = GetMarketingMaterials();

                var thingsInOrder = positiveSelection.Join(thingsInfo, a => a.Id, b => b.Id, (a, b) => new MarketingProduct(b,b.Category,a.Quantity));

                var cartHeader = GetOrderReady(thingsInOrder);

                var request = Utils.GetRequestInfo(Method.POST, "/api/Orders/Add");

                var insertOrderResponse = _webClient.Execute<OrderResponse>(new JsonSerializer().Serialize(cartHeader), ApiUrls.API_KEY, ApiUrls.API_SECRET, request);

                var confirmation = new OrderConfirmation
                {
                    OrderConfirmationNumber = insertOrderResponse.OrderId,
                    Address = Utils.GetFormattedAddress(userLogged.Address1, userLogged.Address2, userLogged.City, userLogged.State, userLogged.ZipCode, "USA"),
                    Email = userLogged.Email,
                    Phone =  userLogged.Phone,
                    Name = userLogged.Name,
                };
                var result = insertOrderResponse.OrderId > 0? Utils.Success:"There were problems trying to process your order. Try it again later, please.";

                return Json(new{ShippingInfo = confirmation,  Result = result});
            }
            catch (Exception exception)
            {
                return Json(new { Result = "There were problems trying to process your order. Try it again later, please." });
            }
        }

        private string GetOrderConfirmationMessage(int orderConfirmation, UserModel user)
        {
            try
            {
                var messageResult =
                    string.Format(
                        "Thank you for your recently order.\n Your order confirmation is {0}.\nIt will be shipped to: {1}.\n Address: {2}.\n Email: {3}.\n Phone: {4}.\n",
                        orderConfirmation, user.BusinessName,
                        Utils.GetFormattedAddress(user.Address1, user.Address2, user.City, user.State, user.ZipCode,
                            "USA"), user.Email, user.Phone);
                
                return messageResult;
            }
            catch (Exception exception)
            {
                return string.Empty;
            }
        }

        private OrderConfirmation GetOrderConfirmation(int orderConfirmation, UserModel user)
        {
            var confirmation = new OrderConfirmation
            {
                Address =Utils.GetFormattedAddress(user.Address1, user.Address2, user.City, user.State, user.ZipCode, "USA"),
                OrderConfirmationNumber = orderConfirmation,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone
            };

            return confirmation;

        }

        private IEnumerable<UserReportViewModel> GetUserReports(int userId)
        {
            try
            {
                var getReportsRequestInfo = Utils.GetRequestInfo(Method.GET, "/api/ReportConfiguration/GetUserReports");

                var reportsMetadata = _webClient.Execute<List<UserReportViewModel>>(new { userId = userId }, ApiUrls.API_KEY, ApiUrls.API_SECRET, getReportsRequestInfo);

                var results = reportsMetadata.Where(rep => rep.IsStandAlone);

                return results;

            }
            catch (Exception exception)
            {
                return new List<UserReportViewModel>();
            }
        }

        private IEnumerable<Document> GetDocumentsFromFiles()
        {

            var categories = Enum.GetNames(typeof(DocumentCategory));

            var documents = new List<Document>();

            foreach (var category in categories)
            {
                var documentsForCategory = GetDocumentsByCategory(category);
                documents.AddRange(documentsForCategory);
            }

            return documents;
        }

        private IEnumerable<Document> GetDocumentsByCategory(string category)
        {
            var documentsLinkPrefix = ConfigurationManager.AppSettings[Utils.VirtualOfficeLink];

            var basePath = ConfigurationManager.AppSettings[Utils.NewVirtualOfficeLink];

            var absolutePath = basePath + category;

            var files = Directory.GetFiles(absolutePath);

            var documents = files.Select(file => new Document
            {
                category = category,
                file_name = documentsLinkPrefix + "/" + category +"/" +  Path.GetFileName(file),
                file_title = Path.GetFileName(file),
                subcategory = category
            });

            return documents;
        }

        private CartHeader GetOrderReady(IEnumerable<MarketingProduct> marketingMaterials)
        {
            try
            {
                var userLogged = Session[Utils.UserKey] as UserModel;

                var shippingInfo = new ShippingInfo
                {
                    AddressOne = userLogged.Address1,
                    AddressTwo = userLogged.Address2,
                    City = userLogged.City,
                    Cost = 15,
                    Country = "USA",
                    Email = userLogged.Email,
                    Phone = userLogged.Phone,
                    State = userLogged.State,
                    ZipCode = userLogged.ZipCode,
                    To = userLogged.Name
                };

                var cartDetails = marketingMaterials.Select(thing => new CartItem
                {
                    Description = thing.Name,
                    Price = thing.Price.IsNull() ? 0 : thing.Price.Value,
                    Discount = thing.Discount.IsNull() ? 0 : thing.Discount.Value,
                    Weight = thing.Weight.IsNull() ? 0 : thing.Weight.Value,
                    Quantity = thing.Quantity,
                    Extended = marketingMaterials.Sum(item => item.Price).Value,
                    Tax = 0,
                    Type = thing.thType.ToString(),
                    Unit = "Units",
                    WeightId = thing.Weight_measureID.Value,
                    Id = thing.thingID.Value
                });

                var isAnAgent = Utils.IsUserAgent(userLogged.UserCategory);

                var cartHeader = new CartHeader
                {
                    AgentID = isAnAgent ? userLogged.UserId : 0,
                    Items = cartDetails.ToList(),
                    ShippingInfo = shippingInfo,
                    TotalWeight = cartDetails.Sum(item => (item.Weight*item.Quantity)),
                    Total = cartDetails.Sum(item => (item.Price*item.Quantity)) + shippingInfo.Cost,
                    MerchantId = isAnAgent ? 0 : userLogged.UserId,
                };

                return cartHeader;

            }
            catch (Exception exception)
            {
                return null;
            }
            
        }

        private void ImportForms()
        {
            var documents = GetDocuments().ToList();

            var originBasePath = @"\\pswebhost\virtualoffice.blackstoneonline.com\Documents\";

            var destinationOriginPath = @"\\pswebhost\virtualoffice.blackstoneonline.com\Documents\NewVODocuments\";

            foreach (var document in documents)
            {
                var sourceFile = originBasePath + document.file_name;

                var categoryFolder = GetCategoryFolder(document.subcategory.Trim());

                if (string.IsNullOrEmpty(categoryFolder))
                    continue;

                var destinationFile = destinationOriginPath + categoryFolder + @"\" + document.file_title.Trim() + Path.GetExtension(sourceFile);

                CopyFile(sourceFile, destinationFile);
            }


        }

        private string GetCategoryFolder(string category)
        {
            switch (category)
            {
                case "Agent Forms":
                    {
                        return "AgentForms";

                    }
                case "Distributor Forms":
                    {
                        return "DistributorForms";
                    }
                case "Applications and Agreements":
                    {
                        return "Agreements";
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        private void CopyFile(string sourceFileName, string destinationFileName)
        {
            try
            {
                System.IO.File.Copy(sourceFileName, destinationFileName);
            }
            catch (Exception)
            {

            }

        }


        private int GetLoggedUserId()
        {
            var userModel = HttpContext.Session[Utils.UserKey] as UserModel;

            return userModel.IsNull() ? 0 : userModel.UserId;
        }
    }
}