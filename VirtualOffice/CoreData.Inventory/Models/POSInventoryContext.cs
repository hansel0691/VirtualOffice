using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using CoreData.Inventory.Models.Mapping;

namespace CoreData.Inventory.Models
{
    public partial class POSInventoryContext : DbContext
    {
        static POSInventoryContext()
        {
            Database.SetInitializer<POSInventoryContext>(null);
        }

        public POSInventoryContext()
            : base("Name=POSInventoryContext")
        {
        }

        public DbSet<Cart_Header> CartHeaders { get; set; }

        public DbSet<Cart_Detail> CartDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Acc_InventoryCountingPOSMap());
            modelBuilder.Configurations.Add(new BusinessCardMap());
            modelBuilder.Configurations.Add(new Cart_DetailMap());
            modelBuilder.Configurations.Add(new Cart_HeaderMap());
            modelBuilder.Configurations.Add(new CreditCardTypeMap());
            modelBuilder.Configurations.Add(new dtpropertyMap());
            modelBuilder.Configurations.Add(new GEO_CitiesMap());
            modelBuilder.Configurations.Add(new GEO_CountiesMap());
            modelBuilder.Configurations.Add(new GEO_StatesMap());
            modelBuilder.Configurations.Add(new GEO_ZipsMap());
            modelBuilder.Configurations.Add(new MonthMap());
            modelBuilder.Configurations.Add(new pinproductMap());
            modelBuilder.Configurations.Add(new POS_Inv_ApplicationsMap());
            modelBuilder.Configurations.Add(new POS_Inv_CodeGenTestTableMap());
            modelBuilder.Configurations.Add(new POS_Inv_CodesMap());
            modelBuilder.Configurations.Add(new POS_Inv_DefaultIDSuppliesMap());
            modelBuilder.Configurations.Add(new POS_Inv_DeployMethodsMap());
            modelBuilder.Configurations.Add(new POS_Inv_EntriesMap());
            modelBuilder.Configurations.Add(new POS_Inv_EquipmentMap());
            modelBuilder.Configurations.Add(new POS_Inv_EquipmentByLocationHistoryMap());
            modelBuilder.Configurations.Add(new POS_Inv_EquipsByOrderMap());
            modelBuilder.Configurations.Add(new POS_Inv_InvoicesMap());
            modelBuilder.Configurations.Add(new POS_Inv_ItemsMap());
            modelBuilder.Configurations.Add(new POS_Inv_KitsMap());
            modelBuilder.Configurations.Add(new POS_Inv_KitsbyOrderMap());
            modelBuilder.Configurations.Add(new POS_Inv_LocationHistoryMap());
            modelBuilder.Configurations.Add(new POS_Inv_LocationsMap());
            modelBuilder.Configurations.Add(new POS_Inv_LocationTypesMap());
            modelBuilder.Configurations.Add(new POS_Inv_MeasureConversionMap());
            modelBuilder.Configurations.Add(new POS_Inv_MeasuresMap());
            modelBuilder.Configurations.Add(new POS_Inv_MovementGroupCountersMap());
            modelBuilder.Configurations.Add(new POS_Inv_MovementsMap());
            modelBuilder.Configurations.Add(new POS_Inv_Movements_BackMap());
            modelBuilder.Configurations.Add(new POS_Inv_OrderCCNumbersMap());
            modelBuilder.Configurations.Add(new POS_Inv_OrderCCVerifyMap());
            modelBuilder.Configurations.Add(new POS_Inv_OrdersMap());
            modelBuilder.Configurations.Add(new POS_Inv_Orders_UpdatedToProcessedMap());
            modelBuilder.Configurations.Add(new POS_Inv_Orders1Map());
            modelBuilder.Configurations.Add(new pos_inv_ordersbck2007Map());
            modelBuilder.Configurations.Add(new POS_Inv_PackageByOrderMap());
            modelBuilder.Configurations.Add(new POS_Inv_PackageByOrderbck2007Map());
            modelBuilder.Configurations.Add(new POS_Inv_PackagesMap());
            modelBuilder.Configurations.Add(new POS_Inv_PartsMap());
            modelBuilder.Configurations.Add(new POS_Inv_PaymentTypesMap());
            modelBuilder.Configurations.Add(new POS_Inv_PrintersMap());
            modelBuilder.Configurations.Add(new POS_Inv_ProvidersMap());
            modelBuilder.Configurations.Add(new POS_Inv_PurchasesMap());
            modelBuilder.Configurations.Add(new POS_Inv_ReasonsMap());
            modelBuilder.Configurations.Add(new POS_Inv_ReplacementsMap());
            modelBuilder.Configurations.Add(new POS_Inv_ReturnsMap());
            modelBuilder.Configurations.Add(new POS_Inv_RotationsMap());
            modelBuilder.Configurations.Add(new POS_Inv_SalesMap());
            modelBuilder.Configurations.Add(new POS_Inv_StatusMap());
            modelBuilder.Configurations.Add(new POS_Inv_SustitutionsMap());
            modelBuilder.Configurations.Add(new POS_Inv_TerminalsMap());
            modelBuilder.Configurations.Add(new POS_Inv_ThingsMap());
            modelBuilder.Configurations.Add(new pos_inv_thingsbck12122013Map());
            modelBuilder.Configurations.Add(new POS_Inv_ThingsbyKitMap());
            modelBuilder.Configurations.Add(new POS_Inv_ThingsByOrderMap());
            modelBuilder.Configurations.Add(new POS_Inv_ThingsByProviderMap());
            modelBuilder.Configurations.Add(new POS_Inv_TransferencesMap());
            modelBuilder.Configurations.Add(new POS_Inv_TypesMap());
            modelBuilder.Configurations.Add(new POS_Inv_UsersMap());
            modelBuilder.Configurations.Add(new POSInvoiceDetailMap());
            modelBuilder.Configurations.Add(new PosInvoiceHeaderMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new table1Map());
            modelBuilder.Configurations.Add(new YearMap());
            modelBuilder.Configurations.Add(new vw_AllProcessedOrdersMap());
            modelBuilder.Configurations.Add(new vw_aux_EntriesMap());
            modelBuilder.Configurations.Add(new vw_aux_ReplacementsMap());
            modelBuilder.Configurations.Add(new vw_Aux_ReservedAmountsMap());
            modelBuilder.Configurations.Add(new vw_aux_ReturnsMap());
            modelBuilder.Configurations.Add(new vw_aux_RotationsMap());
            modelBuilder.Configurations.Add(new vw_aux_SalesMap());
            modelBuilder.Configurations.Add(new vw_aux_SustitutionsMap());
            modelBuilder.Configurations.Add(new vw_aux_TransferencesMap());
            modelBuilder.Configurations.Add(new vw_AuxCreateThingMap());
            modelBuilder.Configurations.Add(new vw_CheckReadersAtLocationsMap());
            modelBuilder.Configurations.Add(new vw_CheckReadersAtMerchantsMap());
            modelBuilder.Configurations.Add(new vw_EquipmentsMap());
            modelBuilder.Configurations.Add(new vw_GetCancelableOrdersMap());
            modelBuilder.Configurations.Add(new vw_IDOrdersReadyToDeployMap());
            modelBuilder.Configurations.Add(new vw_ImprintersAtLocationsMap());
            modelBuilder.Configurations.Add(new vw_ImprintersAtMerchantsMap());
            modelBuilder.Configurations.Add(new vw_LocationDescripMap());
            modelBuilder.Configurations.Add(new vw_LocationMainFieldsMap());
            modelBuilder.Configurations.Add(new vw_LocationsMap());
            modelBuilder.Configurations.Add(new vw_LocationsBasicMap());
            modelBuilder.Configurations.Add(new vw_LocationTypesMap());
            modelBuilder.Configurations.Add(new vw_MerchantsMap());
            modelBuilder.Configurations.Add(new vw_Orders_MerchantsMap());
            modelBuilder.Configurations.Add(new vw_PinpadsAtLocationsMap());
            modelBuilder.Configurations.Add(new vw_PinpadsAtMerchantsMap());
            modelBuilder.Configurations.Add(new vw_PrintersAtLocationsMap());
            modelBuilder.Configurations.Add(new vw_PrintersAtMerchantsMap());
            modelBuilder.Configurations.Add(new vw_ProcessedOrdersMap());
            modelBuilder.Configurations.Add(new vw_QueuedOrdersMap());
            modelBuilder.Configurations.Add(new vw_ReadyOrdersMap());
            modelBuilder.Configurations.Add(new vw_ReasonsMap());
            modelBuilder.Configurations.Add(new vw_rpt_OrderItemsDetailsMap());
            modelBuilder.Configurations.Add(new vw_rpt_Packages_and_Kits_By_OrderMap());
            modelBuilder.Configurations.Add(new vw_rpt_PackagesByOrderMap());
            modelBuilder.Configurations.Add(new vw_rpt_ThingsByOrderMap());
            modelBuilder.Configurations.Add(new vw_SPOrdersReadyToDeployMap());
            modelBuilder.Configurations.Add(new vw_TerminalsAtLocationsMap());
            modelBuilder.Configurations.Add(new vw_TerminalsAtMerchantsMap());
            modelBuilder.Configurations.Add(new vw_ThingsMap());
            modelBuilder.Configurations.Add(new vw_UsersMap());
        }

        public int InsertOrder(
            int id,
            int agentId,
            int deploymentId,
            int incident,
            string to,
            string addressOne,
            string addressTwo,
            string city,
            string state,
            string zipCode,
            string country,
            string phone,
            decimal tax,
            decimal discount,
            decimal net,
            bool homeDelivery,
            bool fedExSaturdayDelivery,
            string email)
        {
            SqlParameter Cart_ID = new SqlParameter("@Cart_ID", id);
            SqlParameter agt_id = new SqlParameter("@agt_id", agentId);
            SqlParameter deploymethID = new SqlParameter("@deploymethID", deploymentId);
            SqlParameter Incident = new SqlParameter("@Incident", incident);
            SqlParameter orShipTo = new SqlParameter("@orShipTo", to??"");
            SqlParameter orShipAddress1 = new SqlParameter("@orShipAddress1", addressOne ?? "");
            SqlParameter orShipAddress2 = new SqlParameter("@orShipAddress2", addressTwo ?? "");
            SqlParameter orShipCity = new SqlParameter("@orShipCity", city ?? "");
            SqlParameter orShipState = new SqlParameter("@orShipState", state ?? "");
            SqlParameter orShipZipCode = new SqlParameter("@orShipZipCode", zipCode ?? "");
            SqlParameter Shipto_Country = new SqlParameter("@Shipto_Country", country ?? "");
            SqlParameter orShipPhone = new SqlParameter("@orShipPhone", phone ?? "");
            SqlParameter order_tax = new SqlParameter("@order_tax", tax);
            SqlParameter order_discount = new SqlParameter("@order_discount", discount);
            SqlParameter order_net = new SqlParameter("@order_net", net);
            SqlParameter HomeDelivery = new SqlParameter("@HomeDelivery", homeDelivery);


            SqlParameter SaturdayDelivery = new SqlParameter("@SaturdayDelivery", fedExSaturdayDelivery);
            SqlParameter orShipEmail = new SqlParameter("@orShipEmail", email ?? "");

            var x = Database.SqlQuery<int>("SP_InsertOrderVO "
                                       + "@Cart_ID,"
                                       + "@agt_id,"
                                       + "@deploymethID,"
                                       + "@Incident,"
                                       + "@orShipTo,"
                                       + "@orShipAddress1,"
                                       + "@orShipAddress2,"
                                       + "@orShipCity,"
                                       + "@orShipState,"
                                       + "@orShipZipCode,"
                                       + "@Shipto_Country,"
                                       + "@orShipPhone,"
                                       + "@order_tax,"
                                       + "@order_discount,"
                                       + "@order_net,"
                                       + "@HomeDelivery,"
                                       + "@SaturdayDelivery,"
                                       + "@orShipEmail",

                Cart_ID,
                agt_id,
                deploymethID,
                Incident,
                orShipTo,
                orShipAddress1,
                orShipAddress2,
                orShipCity,
                orShipState,
                orShipZipCode,
                Shipto_Country,
                orShipPhone,
                order_tax,
                order_discount,
                order_net,
                HomeDelivery,
                SaturdayDelivery,
                orShipEmail
               ).FirstOrDefault();

            return x;
            
        }

        public int InsertCartHeader(Cart_Header cHeader)
        {
            SqlParameter @merchant_fk = new SqlParameter("@merchant_fk", cHeader.merchant_fk);
            SqlParameter @order_total = new SqlParameter("@order_total", cHeader.order_total);
            SqlParameter @order_tax = new SqlParameter("@order_tax", cHeader.order_tax);
            SqlParameter @order_discount = new SqlParameter("@order_discount", cHeader.order_discount);
            SqlParameter @order_net = new SqlParameter("@order_net", cHeader.order_net);
            SqlParameter @orShipTo = new SqlParameter("@orShipTo", cHeader.orShipTo??"");
            SqlParameter @orShipAddress1 = new SqlParameter("@orShipAddress1", cHeader.orShipAddress1 ?? "");
            SqlParameter @orShipAddress2 = new SqlParameter("@orShipAddress2", cHeader.orShipAddress2 ?? "");
            SqlParameter @orShipCity = new SqlParameter("@orShipCity", cHeader.orShipCity ?? "");
            SqlParameter @orShipState = new SqlParameter("@orShipState", cHeader.orShipState ?? "");
            SqlParameter @orShipZipCode = new SqlParameter("@orShipZipCode", cHeader.orShipZipCode ?? "");

            SqlParameter @orShipCountry = new SqlParameter("@orShipCountry", cHeader.orShipCountry ?? "");
            SqlParameter @orShipPhone = new SqlParameter("@orShipPhone", cHeader.orShipPhone ?? "");
            SqlParameter @orRefNotes = new SqlParameter("@orRefNotes", cHeader.orRefNotes ?? "");
            SqlParameter @orTotalWeight = new SqlParameter("@orTotalWeight", cHeader.orTotalWeight);
            SqlParameter @orWeight_measureID = new SqlParameter("@orWeight_measureID", cHeader.orWeight_measureID);
            SqlParameter @deploymethID = new SqlParameter("@deploymethID", cHeader.deploymethID);
            SqlParameter @FedExHomeDelivery = new SqlParameter("@FedExHomeDelivery", cHeader.FedExHomeDelivery);
            SqlParameter @FedExSaturdayDelivery = new SqlParameter("@FedExSaturdayDelivery", cHeader.FedExSaturdayDelivery);
            SqlParameter @orShipType = new SqlParameter("@orShipType", cHeader.orShipType);
            SqlParameter @pmt_method = new SqlParameter("@pmt_method", cHeader.pmt_method);
            SqlParameter @orShipCost = new SqlParameter("@orShipCost", cHeader.orShipCost);
            SqlParameter @orComment = new SqlParameter("@orComment", cHeader.orComment ?? "");
            SqlParameter @agentID = new SqlParameter("@agentID", cHeader.agentID);
            SqlParameter @orShipEmail = new SqlParameter("@orShipEmail", cHeader.orShipEmail ?? "");

            int result = 0;
            SqlParameter @id = new SqlParameter("@id", result);

            var x =Database.SqlQuery<decimal>("SP_InsertCardHeader "
                                       + "@merchant_fk,"
                                       + "@order_total,"
                                       + "@order_tax,"
                                       + "@order_discount,"
                                       + "@order_net,"
                                       + "@orShipTo,"
                                       + "@orShipAddress1,"
                                       + "@orShipAddress2,"
                                       + "@orShipCity,"
                                       + "@orShipState,"
                                       + "@orShipZipCode,"
                                       + "@orShipCountry,"
                                       + "@orShipPhone,"
                                       + "@orRefNotes,"
                                       + "@orTotalWeight,"
                                       + "@orWeight_measureID,"
                                       + "@deploymethID,"
                                       + "@FedExHomeDelivery,"
                                       + "@FedExSaturdayDelivery,"
                                       + "@orShipType,"
                                       + "@pmt_method,"
                                       + "@orShipCost,"
                                       + "@orComment,"
                                       + "@agentID,"
                                       + "@orShipEmail,"
                                       + "@id",
                @merchant_fk,
                @order_total,
                @order_tax,
                @order_discount,
                @order_net,
                @orShipTo,
                @orShipAddress1,
                @orShipAddress2,
                @orShipCity,
                @orShipState,
                @orShipZipCode,
                @orShipCountry,
                @orShipPhone,
                @orRefNotes,
                @orTotalWeight,
                @orWeight_measureID,
                @deploymethID,
                @FedExHomeDelivery,
                @FedExSaturdayDelivery,
                @orShipType,
                @pmt_method,
                @orShipCost,
                @orComment,
                @agentID,
                @orShipEmail,
                @id).FirstOrDefault();

            return (int)x;
        }

        public int InsertCartDetails(Cart_Detail cDetail)
        {
            SqlParameter @cart_id = new SqlParameter("@cart_id", cDetail.cart_id);
            SqlParameter @thType = new SqlParameter("@thType", cDetail.thType??"");
            SqlParameter @thingID = new SqlParameter("@thingID", cDetail.thingID);
            SqlParameter @description = new SqlParameter("@description", cDetail.description??"");
            SqlParameter @qty = new SqlParameter("@qty", cDetail.qty);
            SqlParameter @price = new SqlParameter("@price", cDetail.price);
            SqlParameter @extended = new SqlParameter("@extended", cDetail.extended);
            SqlParameter @discount = new SqlParameter("@discount", cDetail.discount);
            SqlParameter @tax = new SqlParameter("@tax", cDetail.tax);
            SqlParameter @order_id = new SqlParameter("@order_id", cDetail.order_id);
            SqlParameter @unit = new SqlParameter("@unit", cDetail.unit??"");
            SqlParameter @weight = new SqlParameter("@weight", cDetail.weight);
            SqlParameter @weight_measureID = new SqlParameter("@weight_measureID", cDetail.weight_measureID);

            var result = Database.SqlQuery<decimal>("SP_InsertCartDetails "
                                                + "@cart_id,"
                                                + "@thType,"
                                                + "@thingID,"
                                                + "@description,"
                                                + "@qty,"
                                                + "@price,"
                                                + "@extended,"
                                                + "@discount,"
                                                + "@tax,"
                                                + "@order_id,"
                                                + "@unit,"
                                                + "@weight,"
                                                + "@weight_measureID",
                @cart_id,
                @thType,
                @thingID,
                @description,
                @qty,
                @price,
                @extended,
                @discount,
                @tax,
                @order_id,
                @unit,
                @weight,
                @weight_measureID
                ).FirstOrDefault();

            return (int)result;
        }
    }
}
