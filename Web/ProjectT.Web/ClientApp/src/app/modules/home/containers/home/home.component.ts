// Decorators & Lifehooks
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

// NGRX
import { Store } from '@ngrx/store';
import * as fromStore from '../../store';

// RXJS
import { Observable } from 'rxjs';

// Models
import { Product } from '../../../../shared/models/product.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomeComponent implements OnInit {
  trendingProducts$: Observable<Product[]>;
  newestProducts$: Observable<Product[]>;

  constructor(private store: Store<fromStore.ProductsState>) {}

  ngOnInit() {
    this.trendingProducts$ = this.store.select(fromStore.getTrendingProducts);
    this.newestProducts$ = this.store.select(fromStore.getNewestProducts);
  }
}
