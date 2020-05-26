// Decorators
import { NgModule } from '@angular/core';

// Modules
import { CommonModule } from '@angular/common';

// Components
import { ModalComponent } from './modal/modal.component';

@NgModule({
  declarations: [ModalComponent],
  imports: [CommonModule],
  exports: [ModalComponent],
})
export class ModalModule {}
