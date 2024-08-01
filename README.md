# GlowHarmonySkin

## Overview
GlowHarmonySkin is an eCommerce website for skin care products. Users can browse products, manage their cart, and check out. 

## Tech Stack
- **Frontend:** .NET Web MVC
- **Backend:** .NET
- **Database:** MongoDB

## Database Schema

**Users**
- **userId**: String
- **username**: String
- **email**: String
- **passwordHash**: String

**Products**
- **productId**: String
- **name**: String
- **description**: String
- **price**: Decimal
- **category**: String
- **imageUrl**: String
- **stock**: Integer

**Orders**
- **orderId**: String
- **userId**: String
- **items**: Array of Objects
  - **productId**: String
  - **quantity**: Integer
  - **price**: Decimal
- **totalPrice**: Decimal
- **status**: String

**Cart**
- **cartId**: String
- **userId**: String
- **items**: Array of Objects
  - **productId**: String
  - **quantity**: Integer

## Usage
- Access the website at the URL provided by the .NET server.
- Use the admin panel to manage products.
