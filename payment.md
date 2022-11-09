### Payment service

* "As a customer, I'd like to pay for the full amount once my booking is confirmed"

> **NOTE**: Optionally, you can help front-end to send payment details in an opaque form (e.g. tokenization, encryption)

#### Booking integration

Front-end will request a pre-authorization token before making a booking. If a booking is successful, booking will then call Payment service to collect payment from a given `pre-authorization token` - You have to work with Booking to define a contract and authorisation for collecting payments.

#### Front-end integration

##### Pre-authorizing payment

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

> NOTE: To simplify development, you don't need to provide card tokenization feature for front-end.
> Future reference: We may change implementation and encrypt payment form in the browser, requiring payment service to decrypt on their side.

If payment pre-authorization is successful, front-end expects the response in the following format:

```json
{
    "createdCharge": {
      "id": "opaque-payment-authorization-token-string"
    }
}
```
