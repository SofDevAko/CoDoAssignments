import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { HomeComponent } from './home/home.component';
import { BuyComponent } from './buy/buy.component';
import { SellComponent } from './sell/sell.component';
import { MineComponent } from './mine/mine.component';
import { BrowseComponent } from './browse/browse.component';
import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { ShintoService } from './shinto.service';


@NgModule({
  declarations: [
    AppComponent, HomeComponent, BuyComponent, SellComponent, MineComponent, BrowseComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [ShintoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
