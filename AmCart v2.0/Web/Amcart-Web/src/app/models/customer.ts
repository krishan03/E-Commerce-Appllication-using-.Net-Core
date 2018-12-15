import { CustomerAddress } from "./customer-address";
import { Product } from "./product-item";

export class Customer {
    Id: string
    UserId: string
    Gender: string
    DOB: string
    Phone: string
    Addresses: CustomerAddress[]
    Wishlist: Product[]
    Cart: Product[]
}