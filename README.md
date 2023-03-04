# HotelsWebAPI

HotelsWebAPI is a RESTful web API built using .NET, which provides a set of endpoints for managing hotels, rooms, bookings, amenities, facilities, cities, and user accounts.

## Features

- JWT token-based authentication using access and refresh tokens
- Generics repository pattern for database operations
- Data access layer for interacting with the database
- Model layer for defining entities and data contracts
- Utility layer for common functionality
- Four-layer architecture for code separation
- Booking validity check for ensuring valid bookings
- Support for CORS
- Swagger UI for easy API testing

## Installation

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Build and run the project.

## API Endpoints

### AccountController

- `POST /api/account/login` - authenticate user and return JWT tokens
- `POST /api/account/refresh-token` - refresh expired access token
- `POST /api/account/revoke-token` - revoke refresh token

### AmenitiesController

- `GET /api/amenities` - get all amenities
- `GET /api/amenities/{id}` - get a specific amenity
- `POST /api/amenities` - create a new amenity
- `PUT /api/amenities/{id}` - update an existing amenity
- `DELETE /api/amenities/{id}` - delete an amenity

### BookingController

- `GET /api/bookings` - get all bookings
- `GET /api/bookings/{id}` - get a specific booking
- `POST /api/bookings` - create a new booking
- `PUT /api/bookings/{id}` - update an existing booking
- `DELETE /api/bookings/{id}` - delete a booking

### CitiesController

- `GET /api/cities` - get all cities
- `GET /api/cities/{id}` - get a specific city
- `POST /api/cities` - create a new city
- `PUT /api/cities/{id}` - update an existing city
- `DELETE /api/cities/{id}` - delete a city

### FacilitiesController

- `GET /api/facilities` - get all facilities
- `GET /api/facilities/{id}` - get a specific facility
- `POST /api/facilities` - create a new facility
- `PUT /api/facilities/{id}` - update an existing facility
- `DELETE /api/facilities/{id}` - delete a facility

### HotelsController

- `GET /api/hotels` - get all hotels
- `GET /api/hotels/{id}` - get a specific hotel
- `POST /api/hotels` - create a new hotel
- `PUT /api/hotels/{id}` - update an existing hotel
- `DELETE /api/hotels/{id}` - delete a hotel

### RoomsController

- `GET /api/rooms` - get all rooms
- `GET /api/rooms/{id}` - get a specific room
- `POST /api/rooms` - create a new room
- `PUT /api/rooms/{id}` - update an existing room
- `DELETE /api/rooms/{id}` - delete a room

