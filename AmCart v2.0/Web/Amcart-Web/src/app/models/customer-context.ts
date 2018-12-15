import { Customer } from "./customer";
import { SimpleClaim } from "./simple-claim";

export class CustomerContext {
    Customer: Customer
    Claims: SimpleClaim[]
}