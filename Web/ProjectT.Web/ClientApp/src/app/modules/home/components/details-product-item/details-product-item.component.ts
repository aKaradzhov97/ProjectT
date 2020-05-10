// Decorators & Lifehooks
import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewEncapsulation
} from '@angular/core';
// Models
import {Product} from '../../../../shared/models/product.model';
import {Image} from '@ks89/angular-modal-gallery';

// Forms
import {FormControl, FormGroup, Validators} from '@angular/forms';

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

  images: Image[] = []

  sizes: string[] = [
    'XS',
    'S',
    'M',
    'L',
    'XL',
  ]

  constructor() {
  }

  ngOnInit() {
    this.images = [
      new Image(1, {
        img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-547115.jpeg'
      }),
      new Image(2, {
        img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-556664.jpeg',
      }),
      new Image(3, {
        img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-787594.jpeg',
      }),
      new Image(4, {
        img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-803105.jpeg'
      })
    ];

    this.form = new FormGroup({
      size: new FormControl('', Validators.required),
    });
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
  }
}
