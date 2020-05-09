// Decorators & Lifehooks
import {ChangeDetectionStrategy, Component, OnInit} from '@angular/core';

// NGRX
import {Store} from '@ngrx/store';
import * as fromStore from '../../store';

// RXJS
import {Observable} from 'rxjs';

// Models
import {Product} from '../../../../../../shared/models/product.model';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProductsComponent implements OnInit {

  products$: Observable<Product[]>;

  constructor(private store: Store<fromStore.ProductsState>) {
  }

  ngOnInit() {
    this.products$ = this.store.select(fromStore.getAllProducts);
  }

}
