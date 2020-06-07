// Decorators & Lifehooks
import {
  ChangeDetectionStrategy,
  Component,
  Input,
  OnInit,
} from '@angular/core';

@Component({
  selector: 'app-sub-nav',
  templateUrl: './sub-nav.component.html',
  styleUrls: ['./sub-nav.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SubNavComponent implements OnInit {
  @Input() categories: any[] = [];

  constructor() {}

  ngOnInit(): void {}
}
