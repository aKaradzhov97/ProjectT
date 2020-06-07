// Decorators and Lifehooks
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

// Forms
import { FormControl, FormGroup, Validators } from '@angular/forms';

// Services
import { AuthService } from '@services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  @Input() categories: any[] = [];

  @Output() public sidenavToggle = new EventEmitter();
  @Output() formSubmit = new EventEmitter();

  form: FormGroup;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      search: new FormControl('', Validators.required),
    });
  }

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  };

  onSubmit(): void {
    this.formSubmit.emit(this.form.value);
  }

  isAuthenticated(): boolean {
    return this.authService.isLoggedIn();
  }
}
