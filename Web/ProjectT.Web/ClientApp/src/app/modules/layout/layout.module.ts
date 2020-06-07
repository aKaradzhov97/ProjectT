// Decorators
import { NgModule } from '@angular/core';

// Modules
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@material/material.module';

// Pipes

// Components
// - Layout
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';

@NgModule({
  declarations: [HeaderComponent, FooterComponent, SidenavComponent],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [HeaderComponent, FooterComponent, SidenavComponent],
})
export class LayoutModule {}
