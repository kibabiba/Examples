/*
 * Created by SharpDevelop.
 * User: Simeon.u
 * Date: 6/27/2015
 * Time: 10:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NetellerApiClient
{
	[DataContract]
	public class AccountPreferences
	{
		[DataMember(EmitDefaultValue = false)]
	    public string lang { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	}
	
	[DataContract]
	public class AccountProfile
	{
		[DataMember(EmitDefaultValue = false)]
	    public string email { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string accountId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string firstName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string lastName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string address1 { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string address2 { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string address3 { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string city { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string country { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string countrySubdivisionCode { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string postCode { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<ContactDetail> contactDetails { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string gender { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public DateOfBirth dateOfBirth { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public AccountPreferences accountPreferences { get; set; }
	}
	
	[DataContract]
	public class Attribute
	{
		[DataMember(EmitDefaultValue = false)]
    	public string key { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public string value { get; set; }
	}
	
	[DataContract]
	public class Balance
	{
		[DataMember(EmitDefaultValue = false)]
    	public int amount { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public string currency { get; set; }
	}
	
	[DataContract]
	public class BillingDetail
	{
		[DataMember(EmitDefaultValue = false)]
	    public string email { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string firstName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string lastName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string address1 { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string address2 { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string address3 { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string city { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string country { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string countrySubdivisionCode { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string postCode { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string lang { get; set; }
	}
	
	[DataContract]
	public class ContactDetail
	{
		[DataMember(EmitDefaultValue = false)]
	    public string type { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string value { get; set; }
	}

	[DataContract]
	public class Customer
	{
		[DataMember(EmitDefaultValue = false)]
		public Link link { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public string customerId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public AccountProfile accountProfile { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string verificationLevel { get; set; }
	}
	
	[DataContract]
	public class Date
	{
		[DataMember(EmitDefaultValue = false)]
	    public string year { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string month { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string day { get; set; }
	}
	
	[DataContract]
	public class Error
	{
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string message { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<FieldError> fieldErrors { get; set; }
    }

    [DataContract]
    public class FieldError
    {
        [DataMember(EmitDefaultValue = false)]
        public string field { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string error { get; set; }
    }

    [DataContract]
    public class TokenError
    {
        [DataMember(EmitDefaultValue = false)]
        public string error { get; set; }
    }

    [DataContract]
    public class OtherError
    {
        [DataMember(EmitDefaultValue = false)]
        public Error error { get; set; }
    }

    [DataContract]
	public class Event
	{
		[DataMember(EmitDefaultValue = false)]
	    public string mode { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string eventDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string eventType { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int attemptNumber { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class Fee
	{
		[DataMember(EmitDefaultValue = false)]
    	public string feeName { get; set; }
		[DataMember(EmitDefaultValue = false)]
    	public string feeType { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public int feeAmount { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public string feeCurrency { get; set; }
	}
	
	[DataContract]
	public class Invoice
	{
		[DataMember(EmitDefaultValue = false)]
	    public string invoiceId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string invoiceNumber { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string invoiceDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string invoiceType { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string merchantRefId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<BillingDetail> billingDetails { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Order order { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Subscription subscription { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string periodStartDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string periodEndDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int totalAmount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int retryCount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public object nextRetryDate { get; set; }
	}
	
	[DataContract]
	public class Item
	{
		[DataMember(EmitDefaultValue = false)]
	    public int quantity { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string name { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string description { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string sku { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int amount { get; set; }
	}

	[DataContract]
	public class Link
	{
		[DataMember(EmitDefaultValue = false)]
	    public string url { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string rel { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string method { get; set; }
	}
	
	[DataContract]
	public class Order
	{
		[DataMember(EmitDefaultValue = false)]
		public Link link { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public string orderId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string merchantRefId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int totalAmount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string lang { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Item> items { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Fee> fees { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Tax> taxes { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<PaymentMethod> paymentMethods { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Redirect> redirects { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class Payment
	{
		[DataMember(EmitDefaultValue = false)]
	    public Customer customer { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Transaction transaction { get; set; }
	}
	
	[DataContract]
	public class PaymentMethod
	{
	    [DataMember(EmitDefaultValue = false)]
	    public string type { get; set; }
        [DataMember(EmitDefaultValue = false)]
	    public string value { get; set; }
	}
	
	[DataContract]
	public class Plan
	{
		[DataMember(EmitDefaultValue = false)]
		public Link link { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public string planId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string planName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int interval { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string intervalType { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int intervalCount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int amount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	}
	
	[DataContract]
	public class Redirect
	{
		[DataMember(EmitDefaultValue = false)]
	    public string rel { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<string> returnKeys { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string uri { get; set; }
	}
	
	[DataContract]
	public class Subscription
	{
		[DataMember(EmitDefaultValue = false)]
		public Link link { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public string subscriptionId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Plan plan { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Customer customer { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string startDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string endDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
        public string termEndDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
        public string currentPeriodStart { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currentPeriodEnd { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public bool cancelAtPeriodEnd { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public object cancelDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string lastCompletedPaymentDate { get; set; }
	}
	
	[DataContract]
	public class Tax
	{
		[DataMember(EmitDefaultValue = false)]
	    public string taxName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int taxAmount { get; set; }
	}
	
	[DataContract]
	public class Token
	{
		[DataMember(EmitDefaultValue = false)]
		public string tokenType { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public int expiresIn { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string accessToken { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string refreshToken { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string scope { get; set; }
	}
	
	[DataContract]
	public class Transaction
	{
	    [DataMember(EmitDefaultValue = false)]
	    public string merchantRefId { get; set; }
        [DataMember(EmitDefaultValue = false)]
	    public int amount { get; set; }
        [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
        [DataMember(EmitDefaultValue = false)]
	    public string id { get; set; }
        [DataMember(EmitDefaultValue = false)]
	    public string createDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
	    public string updateDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
        [DataMember(EmitDefaultValue = false)]
	    public List<Fee> fees { get; set; }
	}
	
	[DataContract]
	public class DateOfBirth
	{
		[DataMember(EmitDefaultValue = false)]
    	public string year { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public string month { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public string day { get; set; }
	}
	
	[DataContract]
	public class List
	{
		[DataMember(EmitDefaultValue = false)]
        public SubscriptionPlan subscriptionPlan { get; set; }
	}
	
	[DataContract]
	public class SubscriptionPlan
	{
		[DataMember(EmitDefaultValue = false)]
	    public string planId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string planName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int interval { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string intervalType { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int intervalCount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int amount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int numberOfSubscriptions { get; set; }
	}
	
	[DataContract]
	public class TransferInRequest
	{
		[DataMember(EmitDefaultValue = false)]
    	public PaymentMethod paymentMethod { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public Transaction transaction { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public string verificationCode { get; set; }
	}
	
	[DataContract]
	public class TransferInResponse
	{
		[DataMember(EmitDefaultValue = false)]
	    public Customer customer { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Transaction transaction { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class TransferOutRequest
	{
		[DataMember(EmitDefaultValue = false)]
		public AccountProfile payeeProfile { get; set; }
		[DataMember(EmitDefaultValue = false)]
    	public Transaction transaction { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public string message { get; set; }
	}
	
	[DataContract]
	public class TransferOutResponse
	{
		[DataMember(EmitDefaultValue = false)]
	    public AccountProfile payeeProfile { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Transaction transaction { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string message { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Customer customer { get; set; }
	    [DataMember(EmitDefaultValue = false)]
    	public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class LookupPaymentResponse
	{
		[DataMember(EmitDefaultValue = false)]
    	public Customer customer { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public Transaction transaction { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class CreateOrderRequest
	{
		[DataMember(EmitDefaultValue = false)]
		public Order order { get; set; }
		[DataMember(EmitDefaultValue = false)]
		public BillingDetail billingDetail { get; set; }
		[DataMember(EmitDefaultValue = false)]
		public Attribute attributes { get; set; }
	}
	
	[DataContract]
	public class CreateOrderResponse
	{
		[DataMember(EmitDefaultValue = false)]
	    public string orderId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string merchantRefId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int totalAmount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string lang { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string customerIp { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Item> items { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Fee> fees { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Tax> taxes { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<PaymentMethod> paymentMethods { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Redirect> redirects { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class LookupOrderResponse
	{
		[DataMember(EmitDefaultValue = false)]
		public string orderId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public string merchantRefId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public int totalAmount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public string lang { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public List<Item> items { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public List<Fee> fees { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public List<Tax> taxes { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public List<PaymentMethod> paymentMethods { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public List<Redirect> redirects { get; set; }
	    [DataMember(EmitDefaultValue = false)]
		public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class LookupOrderInvoiceResponse
	{
		[DataMember(EmitDefaultValue = false)]
		public string invoiceId { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public string invoiceNumber { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string invoiceDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string invoiceType { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<BillingDetail> billingDetails { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Order order { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int totalAmount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class CreateCustomerRequest
	{
		[DataMember(EmitDefaultValue = false)]
		public AccountProfile accountProfile { get; set; }
		[DataMember(EmitDefaultValue = false)]
    	public string linkBackUrl { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public string btag { get; set; }
	}
	
	[DataContract]
	public class CreateCustomerResponse
	{
    	[DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class LookupCustomerResponse
	{
		[DataMember(EmitDefaultValue = false)]
		public string customerId { get; set; }
		[DataMember(EmitDefaultValue = false)]
    	public AccountProfile accountProfile { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public string verificationLevel { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public Balance availableBalance { get; set; }
	}
	
	[DataContract]
	public class CreatePlanRequest
	{
		[DataMember(EmitDefaultValue = false)]
	    public string planId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string planName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int interval { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string intervalType { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int intervalCount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int amount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	}
	
	[DataContract]
	public class CreatePlanResponse
	{
		[DataMember(EmitDefaultValue = false)]
		public string planId { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public string planName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int interval { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string intervalType { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int intervalCount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int amount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class LookupPlanResponse
	{
		[DataMember(EmitDefaultValue = false)]
		public string planId { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public string planName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int interval { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string intervalType { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int intervalCount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int amount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class CancelPlanResponse
	{
		[DataMember(EmitDefaultValue = false)]
		public string planId { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public string planName { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int interval { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string intervalType { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int intervalCount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int amount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class ListPlansResponse
	{
		[DataMember(EmitDefaultValue = false)]
    	public List<List> list { get; set; }
    	[DataMember(EmitDefaultValue = false)]
    	public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class CreateSubscriptionRequest
	{
		[DataMember(EmitDefaultValue = false)]
	    public string planId { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public string customerId { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public string startDate { get; set; }
	}
	
	[DataContract]
	public class CreateSubscriptionResponse
	{
		[DataMember(EmitDefaultValue = false)]
	    public string subscriptionId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Plan plan { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Customer customer { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string startDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string endDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currentPeriodStart { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currentPeriodEnd { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string cancelAtPeriodEnd { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public object cancelDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class LookupSubscriptionResponse
	{
		[DataMember(EmitDefaultValue = false)]
	    public string subscriptionId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Plan plan { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Customer customer { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string startDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string endDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public object currentPeriodStart { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public object currentPeriodEnd { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string cancelAtPeriodEnd { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public object cancelDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class CancelSubscriptionResponse
	{
	    [DataMember(EmitDefaultValue = false)]
		public string subscriptionId { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public Plan plan { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Customer customer { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string startDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string endDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currentPeriodStart { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currentPeriodEnd { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public bool cancelAtPeriodEnd { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string cancelDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class ListSubscriptionsResponse
	{
	    [DataMember(EmitDefaultValue = false)]
		public List<Subscription> list { get; set; }
		[DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class LookupSubscriptionInvoiceResponse
	{
		[DataMember(EmitDefaultValue = false)]
	    public string invoiceId { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int invoiceNumber { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string invoiceDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string invoiceType { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<BillingDetail> billingDetails { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public Subscription subscription { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string status { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string periodStartDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string periodEndDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int totalAmount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public string currency { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public int retryCount { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public object nextRetryDate { get; set; }
	    [DataMember(EmitDefaultValue = false)]
	    public List<Link> links { get; set; }
	}
	
	[DataContract]
	public class ListSubscriptionInvoicesResponse
	{
		[DataMember(EmitDefaultValue = false)]
		public List<List> list { get; set; }
		[DataMember(EmitDefaultValue = false)]
    	public List<Link> links { get; set; }
	}
}