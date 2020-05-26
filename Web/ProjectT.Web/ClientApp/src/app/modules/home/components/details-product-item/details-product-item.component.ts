// Decorators & Lifehooks
import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewEncapsulation,
} from '@angular/core';

// Models
import { Product } from '../../../../shared/models/product.model';
import { Image } from '@ks89/angular-modal-gallery';

// Forms
import {
  FormArray,
  FormControl,
  FormGroup,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { F } from '@angular/cdk/keycodes';

@Component({
  selector: 'app-details-product-item',
  templateUrl: './details-product-item.component.html',
  styleUrls: ['./details-product-item.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None,
})
export class DetailsProductItemComponent implements OnInit {
  @Input() product: Product = null;

  @Output() onRemove = new EventEmitter();

  @Output() formSubmit = new EventEmitter();

  form: FormGroup;

  images: Image[] = [];

  deliveryData = {
    text: 'Express',
    value: true,
  };

  dataArr = [
    {
      text: 'Pizza',
      value: false,
    },
    {
      text: 'Pasta',
      value: true,
    },
  ];

  sizes = [
    {
      text: 'XS',
      value: 'xs',
    },
    {
      text: 'S',
      value: 's',
    },
    {
      text: 'M',
      value: 'm',
    },
    {
      text: 'L',
      value: 'l',
    },
    {
      text: 'XL',
      value: 'xl',
    },
  ];

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.initImages();
    this.initForm();
  }

  removeProduct() {
    this.onRemove.emit(this.product);
  }

  onSubmit(): void {
    const product: Product = {
      id: this.product.id,
      ...this.form.value,
    };
    this.formSubmit.emit(this.form.value);
    console.log(this.form.value);
  }

  initForm(): void {
    this.form = new FormGroup({
      size: new FormControl('', Validators.required),
      title: new FormControl('', Validators.required),
      express: new FormControl('', Validators.requiredTrue),
    });
  }

  initImages(): void {
    this.images = this.product.images.map((image, index) => {
      return new Image(index, {
        img: image.url,
      });
    });
  }
}
