// Decorators
import { NgModule } from '@angular/core';

// Modules
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../../material/material.module';

// Components
import { UserSidenavComponent } from './components/user-sidenav/user-sidenav.component';

// - Products

@NgModule({
  declarations: [UserSidenavComponent],
  imports: [CommonModule, RouterModule, MaterialModule],
  exports: [UserSidenavComponent],
})
export class UserSharedModule {}
