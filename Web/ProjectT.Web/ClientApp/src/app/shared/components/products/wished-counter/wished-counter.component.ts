// Decorators & Lifehooks
import {
  ChangeDetectionStrategy,
  Component,
  Input,
  OnInit,
  ViewEncapsulation,
} from '@angular/core';

@Component({
  selector: 'app-wished-counter',
  templateUrl: './wished-counter.component.html',
  styleUrls: ['./wished-counter.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None,
})
export class WishedCounterComponent implements OnInit {
  @Input() wishCount: number;

  constructor() {}

  ngOnInit(): void {}
}
