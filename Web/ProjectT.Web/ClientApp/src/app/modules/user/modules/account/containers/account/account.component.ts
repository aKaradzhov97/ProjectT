// Decorators & Lifehooks
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

import { UserService } from '../../../../../../core/services/user.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AccountComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit(): void {}

  logout(): void {
    this.userService.logout().subscribe((res) => {
      console.log(res);
    });
  }
}
