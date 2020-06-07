// Decorators & Lifehooks
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-account-shopping-bag',
  templateUrl: './shopping-bag.component.html',
  styleUrls: ['./shopping-bag.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShoppingBagComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
