// Decorators & Lifehooks
import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

// Forms
import {FormControl, FormGroup, Validators} from '@angular/forms';

// Models
import {Product} from '../../../../../../shared/models/product.model';

@Component({
  selector: 'app-update-product-form',
  templateUrl: './update-product-form.component.html',
  styleUrls: ['./update-product-form.component.scss']
})
export class UpdateProductFormComponent implements OnInit {
  @Input() product: Product = null;

  @Output() formSubmit = new EventEmitter();

  form: FormGroup;

  constructor() {
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      image: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      quantity: new FormControl('', Validators.required),
      price: new FormControl('', Validators.required),
    });
    this.form.patchValue(this.product);
  }

  onSubmit(): void {
    const product: Product = {
      id: this.product.id,
      ...this.form.value,
    };
    this.formSubmit.emit(this.form.value);
  }

}
