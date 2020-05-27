// Decorators & Lifehooks
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-newsletters',
  templateUrl: './newsletters.component.html',
  styleUrls: ['./newsletters.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NewslettersComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
