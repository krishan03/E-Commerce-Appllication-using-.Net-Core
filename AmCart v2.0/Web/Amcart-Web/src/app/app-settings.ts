export namespace Constants {
    export class AppConstants {
        public static readonly stsAuthority = 'https://iam-dot-regal-yew-236623.appspot.com/';

        public static readonly clientId = '5c0a5b04e54cce9c38588e6f';
        public static readonly clientRoot = 'http://localhost:5200/';
        public static readonly clientScope = 'openid profile';
        // public static readonly productApiRoot = 'http://localhost:4100/api/';
        public static readonly productApiRoot = 'http://localhost:4100/api/';
        public static readonly customerApiRoot = 'https://customer-dot-regal-yew-236623.appspot.com/api/';
        public static readonly orderApiRoot = 'http://localhost:4200/api/';
    }
    export class Urls {
        public static readonly ProductList = 'product';
    }
} 