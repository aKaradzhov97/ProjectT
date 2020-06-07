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
// - Forms
import { InputComponent } from './components/forms/input/input.component';
import { CheckboxComponent } from './components/forms/checkbox/checkbox.component';
import { ButtonComponent } from './components/forms/button/button.component';
import { TextareaComponent } from './components/forms/textarea/textarea.component';
import { SelectComponent } from './components/forms/select/select.component';
import { RadioComponent } from './components/forms/radio/radio.component';
import { WishedCounterComponent } from './components/products/wished-counter/wished-counter.component';

@NgModule({
  declarations: [
    InputComponent,
    SelectComponent,
    CheckboxComponent,
    ButtonComponent,
    TextareaComponent,
    RadioComponent,
    WishedCounterComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    InputComponent,
    SelectComponent,
    CheckboxComponent,
    WishedCounterComponent,
  ],
})
export class SharedModule {}
