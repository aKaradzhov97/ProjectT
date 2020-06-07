// Decorators & Lifehooks
import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
} from '@angular/core';

// Models
import { Category } from '@shared/models/category.model';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SidenavComponent implements OnInit {
  @Output() sidenavClose = new EventEmitter();
  @Input() categories: Category[] = [];

  constructor() {}

  ngOnInit() {}

  public onSidenavClose = () => {
    this.sidenavClose.emit();
  };
}
