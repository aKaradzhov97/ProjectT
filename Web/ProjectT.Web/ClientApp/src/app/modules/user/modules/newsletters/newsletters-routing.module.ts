// Decorators
import { NgModule } from '@angular/core';

// Modules
import { RouterModule, Routes } from '@angular/router';

// Guards

// Components
import { NewslettersComponent } from './containers/newsletters/newsletters.component';

const ROUTES: Routes = [
  {
    path: '',
    component: NewslettersComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
})
export class NewslettersRoutingModule {}
