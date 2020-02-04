## Products Comparison API

API that allows either comparing products by a given consumption or comparing products using the values stored in the database.

Endpoints: 

GET /api/products/compare/all => obtains a pair of annual costs for each one of the consumptions stored in the database 

GET /api/products/compare?consumption={value} => obtains a pair of annual costs based on the input provided in the query

POST /api/products => saves a new product

POST /api/consumptions => saves a new consumption 

In addition to those, there are two more endpoints related to authentication, which are 
POST /api/account/register \ 
POST /api/account/login

After you've been registered, you'll get a temporary token for requesting the endpoints passing it as a Bearer token. 

The app has been configured to use SQLite, so no database engine requires to be installed. 