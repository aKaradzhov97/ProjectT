// Decorators & Lifehooks
import {
  Component,
  Input,
  ViewChild,
  ElementRef,
  AfterViewInit,
} from '@angular/core';

// Forms
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss'],
})
export class InputComponent implements AfterViewInit {
  @ViewChild('input') input: ElementRef;

  @Input() form: FormGroup = null;

  @Input() isMaterial = true;

  @Input() type = 'text';

  @Input() name = null;

  @Input() label: string = null;

  @Input() placeholder: string = null;

  @Input() required = false;

  @Input() disabled = false;

  @Input() error: string;

  ngAfterViewInit(): void {
    // Obtain the control over the select.
    const control = this.form.get(this.name);

    // Then check validity and mark as touched.
    if (!!control && control.invalid && control.dirty) {
      control.markAsTouched();
    }
  }

  showError() {
    return !!this.error;
  }
}
