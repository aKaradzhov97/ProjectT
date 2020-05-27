// Decorators & Lifehooks
import {ChangeDetectionStrategy, Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-addresses',
  templateUrl: './addresses.component.html',
  styleUrls: ['./addresses.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddressesComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
