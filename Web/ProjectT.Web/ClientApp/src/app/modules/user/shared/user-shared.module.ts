// Decorators
import { NgModule } from '@angular/core';

// Modules
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../../material/material.module';

// Components
import { ShoppingBagComponent } from './components/shopping-bag/shopping-bag.component';
import { HeadlineComponent } from './components/headline/headline.component';

// - Products

@NgModule({
  declarations: [ShoppingBagComponent, HeadlineComponent],
  imports: [CommonModule, RouterModule, MaterialModule],
  exports: [ShoppingBagComponent, HeadlineComponent],
})
export class UserSharedModule {}
