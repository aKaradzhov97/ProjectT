// Decorators & Lifehooks
import {
  AfterViewInit,
  Component,
  EventEmitter,
  Input,
  Output,
  ViewChild,
} from '@angular/core';

// Forms
import { FormGroup } from '@angular/forms';

// Models
import { SelectItem } from '../interfaces/SelectItem';
import { MatSelect } from '@angular/material/select';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.scss'],
})
export class SelectComponent implements AfterViewInit {
  @ViewChild('select', { static: false }) select: MatSelect;

  @Output() onChange: EventEmitter<string> = new EventEmitter<string>();

  @Input() form: FormGroup = null;

  @Input() name: any = null;

  @Input() label: string = null;

  @Input() placeholder: string = null;

  @Input() data: SelectItem[] = [];

  @Input() error: string = null;

  constructor() {}

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
