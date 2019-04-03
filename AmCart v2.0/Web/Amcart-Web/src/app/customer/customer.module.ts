import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { CartComponent } from './cart/cart.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ProfileComponent, ProfileDetailsComponent, WishlistComponent, CartComponent]
})
export class CustomerModule { }
