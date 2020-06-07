// Decorators & Lifehooks
import {
  ChangeDetectionStrategy,
  Component,
  Input,
  OnInit,
} from '@angular/core';

@Component({
  selector: 'app-user-account-headline',
  templateUrl: './headline.component.html',
  styleUrls: ['./headline.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HeadlineComponent implements OnInit {
  @Input() title: string = null;

  @Input() subtitle: string = null;

  constructor() {}

  ngOnInit(): void {}
}
