import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { QuotesComponent } from './quotes/quotes.component';
import { NewAuthorComponent } from './new-author/new-author.component';
import { NewQuoteComponent } from './new-quote/new-quote.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'quotes/:id', component: QuotesComponent },
  { path: 'new', component: NewAuthorComponent },
  { path: 'write/:id', component: NewQuoteComponent },
  { path: 'edit/:id', component: EditComponent },
  { path: '', pathMatch: 'full', redirectTo: '/home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
