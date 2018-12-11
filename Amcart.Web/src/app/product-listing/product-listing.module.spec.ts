import { ProductListingModule } from './product-listing.module';

describe('ProductListingModule', () => {
  let productListingModule: ProductListingModule;

  beforeEach(() => {
    productListingModule = new ProductListingModule();
  });

  it('should create an instance', () => {
    expect(productListingModule).toBeTruthy();
  });
});
