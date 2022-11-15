# **Payment service**

* "As a customer, I'd like to pay for the full amount once my booking is confirmed"


<br>

### **Booking integration**

Front-end will request a pre-authorization token before making a booking, this happens by calling payment service to get it from Stripe. 

If a booking is successful, booking will then call Payment service to collect payment from a given `pre-authorization token` 

- You have to work with Booking to define a contract and authorization for collecting payments.
- You have to work with Front-end to define a contract and authorization for collecting payments data to collect the money.

<br>

![Serverless Airline Booking sample](./media/integration/integration_payment.png)



<br> 

### **Front-end integration**

#### **Pre-authorizing payment**

Front-end sends payment form data directly to Payment service in the following payload format:

```json
{
    "name": "Demo",
    "address_postcode": "EC1A 2FD",
    "address_country": "UK",
    "email": "customerEmail",
    "amount": 100,
    "currency": "EUR",
    "description": "Payment by lessa@amazon.co.uk",
    "card": {
       "number": "1055 444 3032 4679",
       "expireMonth": "1",
       "expireYear": "22",
       "cvc": "444"
    }
}
```

> NOTE: for future reference We may change the implementation and encrypt payment form in the browser, requiring payment service to decrypt on their side.

<br>

If payment pre-authorization is successful, front-end expects the response in the following format:

```json
{
    "createdCharge": {
      "id": "opaque-payment-authorization-token-string"
    }
}
```

