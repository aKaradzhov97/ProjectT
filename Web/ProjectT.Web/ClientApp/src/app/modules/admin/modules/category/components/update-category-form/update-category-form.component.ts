// Decorators and Lifehooks
import {ChangeDetectionStrategy, Component, EventEmitter, OnInit, Output} from '@angular/core';

// Forms
import {FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-update-category-form',
  templateUrl: './update-category-form.component.html',
  styleUrls: ['./update-category-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UpdateCategoryFormComponent implements OnInit {

  form: FormGroup;

  @Output() formSubmit = new EventEmitter();

  constructor() { }

  onSubmit(): void {
    this.formSubmit.emit(this.form.value);
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

}
