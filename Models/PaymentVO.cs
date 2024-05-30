using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Models
{
    public class Identification
    {
        public string number { get; set; }
        public string type { get; set; }
    }

    public class Cardholder
    {
        public Identification identification { get; set; }
        public string name { get; set; }
    }

    public class Card
    {
        public string bin { get; set; }
        public Cardholder cardholder { get; set; }
        public DateTime? date_created { get; set; }
        public DateTime? date_last_updated { get; set; }
        public int? expiration_month { get; set; }
        public int? expiration_year { get; set; }
        public string first_six_digits { get; set; }
        public object id { get; set; }
        public string last_four_digits { get; set; }
    }

    public class Amounts
    {
        public double? original { get; set; }
        public int? refunded { get; set; }
    }

    public class Accounts
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class ChargesDetails
    {
        public Accounts accounts { get; set; }
        public Amounts amounts { get; set; }
        public int? client_id { get; set; }
        public DateTime? date_created { get; set; }
        public string id { get; set; }
        public DateTime? last_updated { get; set; }
        public Dictionary<string, object> metadata { get; set; }
        public string name { get; set; }
        public List<object> refund_charges { get; set; }
        public object reserve_id { get; set; }
        public string type { get; set; }
    }

    public class AdditionalInfo
    {
        public object authentication_code { get; set; }
        public object available_balance { get; set; }
        public string ip_address { get; set; }
        public List<Item> items { get; set; }
        public object nsu_processadora { get; set; }
    }

    public class Item
    {
        public object category_id { get; set; }
        public object description { get; set; }
        public string id { get; set; }
        public object picture_url { get; set; }
        public string quantity { get; set; }
        public string title { get; set; }
        public string unit_price { get; set; }
    }

    public class Payer
    {
        public string email { get; set; }
        public object entity_type { get; set; }
        public object first_name { get; set; }
        public string id { get; set; }
        public Identification identification { get; set; }
        public object last_name { get; set; }
        public object operator_id { get; set; }
        public Phone phone { get; set; }
        public object type { get; set; }
    }

    public class Phone
    {
        public object number { get; set; }
        public object extension { get; set; }
        public object area_code { get; set; }
    }

    public class Data
    {
        public RoutingData routing_data { get; set; }
    }

    public class RoutingData
    {
        public string merchant_account_id { get; set; }
    }

    public class PaymentMethod
    {
        public Data data { get; set; }
        public string id { get; set; }
        public string issuer_id { get; set; }
        public string type { get; set; }
    }

    public class PointOfInteraction
    {
        public BusinessInfo business_info { get; set; }
        public TransactionData transaction_data { get; set; }
        public string type { get; set; }
    }

    public class BusinessInfo
    {
        public object branch { get; set; }
        public string sub_unit { get; set; }
        public string unit { get; set; }
    }

    public class TransactionData
    {
        public object e2e_id { get; set; }
    }

    public class Tax
    {
        public string type { get; set; }
        public int? value { get; set; }
    }

    public class TransactionDetails
    {
        public object acquirer_reference { get; set; }
        public object external_resource_url { get; set; }
        public object financial_institution { get; set; }
        public int? installment_amount { get; set; }
        public double? net_received_amount { get; set; }
        public int? overpaid_amount { get; set; }
        public object payable_deferral_period { get; set; }
        public object payment_method_reference_id { get; set; }
        public int? total_paid_amount { get; set; }
    }

    public class PaymentVO
    {
        public object accounts_info { get; set; }
        public List<object> acquirer_reconciliation { get; set; }
        public AdditionalInfo additional_info { get; set; }
        public string authorization_code { get; set; }
        public bool? binary_mode { get; set; }
        public object brand_id { get; set; }
        public string build_version { get; set; }
        public object call_for_authorize_id { get; set; }
        public bool? captured { get; set; }
        public Card card { get; set; }
        public List<ChargesDetails> charges_details { get; set; }
        public int? collector_id { get; set; }
        public object corporation_id { get; set; }
        public object counter_currency { get; set; }
        public int? coupon_amount { get; set; }
        public string currency_id { get; set; }
        public DateTime? date_approved { get; set; }
        public DateTime? date_created { get; set; }
        public DateTime? date_last_updated { get; set; }
        public DateTime? date_of_expiration { get; set; }
        public object deduction_schema { get; set; }
        public string description { get; set; }
        public object differential_pricing_id { get; set; }
        public object external_reference { get; set; }
        public List<object> fee_details { get; set; }
        public object financing_group { get; set; }
        public long? id { get; set; }
        public int? installments { get; set; }
        public object integrator_id { get; set; }
        public string issuer_id { get; set; }
        public bool? live_mode { get; set; }
        public object marketplace_owner { get; set; }
        public object merchant_account_id { get; set; }
        public object merchant_number { get; set; }
        public Dictionary<string, object> metadata { get; set; }
        public DateTime? money_release_date { get; set; }
        public object money_release_schema { get; set; }
        public string money_release_status { get; set; }
        public int? net_amount { get; set; }
        public object notification_url { get; set; }
        public string operation_type { get; set; }
        public Object order { get; set; }
        public PaymentMethod payment_method { get; set; }
        public string payment_type_id { get; set; }
        public string status { get; set; }
        public int? transaction_amount { get; set; }
    }

}