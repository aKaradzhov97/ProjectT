// Decorators
import { NgModule } from '@angular/core';

// Material Modules
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { MatFormFieldDefaultOptions } from '@angular/material/form-field';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSnackBarModule } from '@angular/material/snack-bar';

// Constants
const MaterialComponents = [
  MatListModule,
  MatSidenavModule,
  MatIconModule,
  MatToolbarModule,
  MatButtonModule,
  MatExpansionModule,
  MatInputModule,
  MatSelectModule,
  MatCheckboxModule,
  MatSnackBarModule,
];

const appearance: MatFormFieldDefaultOptions = {
  appearance: 'outline',
};

@NgModule({
  imports: [MaterialComponents],
  exports: [MaterialComponents],
  providers: [
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: appearance,
    },
  ],
})
export class MaterialModule {}
