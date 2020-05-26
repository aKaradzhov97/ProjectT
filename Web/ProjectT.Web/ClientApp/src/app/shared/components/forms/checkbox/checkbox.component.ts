// Decorators & Lifehooks
import { Component, Input, OnInit } from '@angular/core';

// Forms
import { FormGroup } from '@angular/forms';

// Models
import { CheckboxItem } from '../interfaces/CheckboxItem';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.scss'],
})
export class CheckboxComponent implements OnInit {
  @Input() data: CheckboxItem = null;

  @Input() form: FormGroup = null;

  @Input() name: any = null;

  @Input() error: string = null;

  constructor() {}

  ngOnInit(): void {
    // Obtain the control over the select.
    const control = this.form.get(this.name);

    // Then check validity and mark as touched.
    control.valueChanges.subscribe(() => {
      control.markAsTouched();
    });
  }

  showError() {
    return (
      !!this.error &&
      this.form.get(this.name).dirty &&
      this.form.get(this.name).invalid
    );
  }
}
