// Decorators & Lifehooks
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

// Models
import { UserSidenavRoute } from '../../models/user-sidenav-route.model';

@Component({
  selector: 'app-user-sidenav',
  templateUrl: './user-sidenav.component.html',
  styleUrls: ['./user-sidenav.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserSidenavComponent implements OnInit {
  constructor() {}

  routes: UserSidenavRoute[] = [
    {
      label: 'Account',
      path: '/user/account',
    },
    {
      label: 'Addresses',
      path: '/user/addresses',
    },
    {
      label: 'Details',
      path: '/user/details',
    },
    {
      label: 'Orders',
      path: '/user/orders',
    },
    {
      label: 'Vouchers',
      path: '/user/vouchers',
    },
    {
      label: 'Newsletters',
      path: '/user/newsletters',
    },
  ];

  ngOnInit(): void {}
}
