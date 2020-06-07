// Decorators & Lifehooks
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

import { UserService } from '../../../../../../core/services/user.service';

import { User } from '../../../../../../shared/models/user.model';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AccountComponent implements OnInit {
  user: User | any = {
    username: 'Fiko',
  };

  constructor(private userService: UserService) {}

  ngOnInit(): void {}
}
