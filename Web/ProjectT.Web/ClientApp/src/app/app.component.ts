// Decorators & Lifehooks
import { Component, OnInit } from '@angular/core';

// RXJS
import { Observable } from 'rxjs';

// NGRX
import { Store } from '@ngrx/store';
import * as fromStore from './store';

// Models
import { Category } from '@shared/models/category.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  navigation$: Observable<Category[]>;

  loadingBarColor = `#ff4081`;
  loadingBarHeight = 8;
  loadingSpinnerShown = false;
  categories: Category[] = [
    {
      id: '1',
      name: 'Mens',
      createdOn: 'Today',
      subcategories: [],
    },
    {
      id: '2',
      name: 'Womens',
      createdOn: 'Today',
      subcategories: [],
    },
    {
      id: '3',
      name: 'Kids',
      createdOn: 'Today',
      subcategories: [],
    },
    {
      id: '4',
      name: 'Collections',
      createdOn: 'Today',
      subcategories: [],
    },
    {
      id: '5',
      name: 'HOT!',
      createdOn: 'Today',
      subcategories: [],
    },
  ];

  constructor(private store: Store<fromStore.NavigationState>) {}

  ngOnInit(): void {}
}
