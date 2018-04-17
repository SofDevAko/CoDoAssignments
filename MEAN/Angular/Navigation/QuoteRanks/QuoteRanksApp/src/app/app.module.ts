import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { QuoterService } from './quoter.service';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NewAuthorComponent } from './new-author/new-author.component';
import { QuotesComponent } from './quotes/quotes.component';
import { NewQuoteComponent } from './new-quote/new-quote.component';
import { EditComponent } from './edit/edit.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NewAuthorComponent,
    QuotesComponent,
    NewQuoteComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule

  ],
  providers: [QuoterService],
  bootstrap: [AppComponent]
})
export class AppModule { }
