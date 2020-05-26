// Decorators & Lifehooks
import { Component, Input, OnInit } from '@angular/core';

// Forms
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-radio',
  templateUrl: './radio.component.html',
  styleUrls: ['./radio.component.scss'],
})
export class RadioComponent implements OnInit {
  @Input() form: FormGroup = null;

  @Input() name = null;

  @Input() label: string = null;

  @Input() required = false;

  @Input() disabled = false;

  @Input() error: string;

  constructor() {}

  ngOnInit(): void {}
}
