// Decorators & Lifehooks
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vouchers',
  templateUrl: './vouchers.component.html',
  styleUrls: ['./vouchers.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class VouchersComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
